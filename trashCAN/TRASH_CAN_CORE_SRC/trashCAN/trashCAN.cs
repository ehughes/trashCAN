using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Collections;
using ItrashCAN;
using System.Threading;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

namespace trashCAN
{
    public partial class trashCANHost : Form
    {
        public Version ver = Assembly.GetExecutingAssembly().GetName().Version;
        public string sTCVersion = "v" + Assembly.GetExecutingAssembly().GetName().Version.Major + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor + "." + Assembly.GetExecutingAssembly().GetName().Version.Build;

        SysLog CANHostLog = new SysLog();
        SysLog PluginMessageLog = new SysLog();

        TrashCANStateRecord MyRecords;
        System.Drawing.Point MyLocation;

        const string RootPluginPath = "PLUGINS";
        ArrayList AvailablePlugins = new ArrayList();
        ArrayList ActivePlugins = new ArrayList();
        int LastInstanceID = 0;
        Thread PluginProcessThread;
        System.Windows.Forms.Timer PluginHousekeepingTimer = new System.Windows.Forms.Timer();
        InstanceMonitor MyInstanceMonitor = new InstanceMonitor();
        bool KillAllThreads = false;
        About MyAboutForm = new About();
        bool PausePluginProcessing;
        bool PluginRequestExitTrashCAN = false;

        
        public trashCANHost(string[] args)
        {
            
            this.Text = sTCVersion;
            
            InitializeComponent();

            CANHostLog.Text = "CAN Host Plugin Log";
            PluginMessageLog.Text = "Plugin Output Message Log";

            CANHostLog.Write("Starting Host...." + sTCVersion);
            try
            {
                HostInit(args);
                if (AvailablePlugins.Count == 0)
                {
                    trashCANMainMenuStrip.Items["pluginsToolStripMenuItem"].Enabled = false;
                }
                else
                {
                    trashCANMainMenuStrip.Items["pluginsToolStripMenuItem"].Enabled = true;
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Exception during Initialization");
                CANHostLog.Write(Ex.Message);
            }
        }

        void HostInit(string[] args)
        {
            //add any plugins sent as arguments
            foreach (string file in args)
            {
                foreach (PluginInfo PluginInfo in CheckDLLForValidCANNodePlugin(file))
                {
                    AvailablePlugins.Add(PluginInfo);
                }
            }

            //add plugins foundin local folder
            AvailablePlugins.AddRange(CheckForNodePlugins());

            if (AvailablePlugins == null || AvailablePlugins.Count == 0)
            {
                CANHostLog.Write("No Plugins Found in " + RootPluginPath);
                return;
            }

            pluginsToolStripMenuItem.DropDownItems.Clear();

            foreach (PluginInfo PR in AvailablePlugins)
            {
                CANHostLog.Write(PR.PluginDataType.Name + " found in " + Path.GetFileName(PR.AssemblyLocation));

                ToolStripMenuItem MI = new ToolStripMenuItem();

                MI.Enabled = true;
                MI.Name = GenerateNameWithVersion(PR.Name,PR.Version);
                MI.Click += new EventHandler(MI_Click);
                MI.Text = PR.Name;
                MI.Image = PR.Image;
                MI.ToolTipText = "Version: " + PR.Version;
                pluginsToolStripMenuItem.DropDownItems.Add(MI);
            }

            ActivePlugins = new ArrayList();
            LastInstanceID = 0;

            PluginProcessThread = new Thread(new ThreadStart(PluginProcessLoop));

            CANHostLog.Write("Starting PluginProcessThread.....");

            PluginProcessThread.Start();

            PluginHousekeepingTimer.Tick += new EventHandler(PluginHousekeepingTimer_Tick);
            PluginHousekeepingTimer.Interval = 100;
            PluginHousekeepingTimer.Start();

            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(),"last.bag")) == true)
                Restore_trashCAN_State(Path.Combine(Directory.GetCurrentDirectory(), "last.bag"));
                

        }

        void PluginHousekeepingTimer_Tick(object sender, EventArgs e)
        {
            CheckForPluginTerminationRequests();

            //Check to see if the instance monitor wants to destroy anything

            if (MyInstanceMonitor.InstanceDestructionQueue.Count > 0)
            {
                for (int i = 0; i < MyInstanceMonitor.InstanceDestructionQueue.Count; i++)
                {
                    AttemptToDestroyInstance(MyInstanceMonitor.InstanceDestructionQueue.Dequeue());
                }
                UpdateInstanceGrid();
            }

            //Check to see if the instance monitor show anything

            if (MyInstanceMonitor.InstanceShowQueue.Count > 0)
            {
                for (int i = 0; i < MyInstanceMonitor.InstanceShowQueue.Count; i++)
                {
                    int Instance = MyInstanceMonitor.InstanceShowQueue.Dequeue();
                    foreach (PluginInstanceRecord P in ActivePlugins)
                    {
                        if (P.PluginInstanceID == Instance)
                        {
                            P.Plugin.ShowPlugin();
                            CANHostLog.Write("calling ShowPlugin() on instance " + Instance);
                        }
                    }
                }

                UpdateInstanceGrid();
            }

            if (PluginRequestExitTrashCAN == true)
            {
                this.Close();
            }


        }

        void AddPluginToPool(string NameWithVersion, PluginState NewPluginState)
        {
            PluginInstanceRecord NewPluginInstance = new PluginInstanceRecord();
            PluginInfo SelectedPlugin = null;

            try
            {

                foreach (PluginInfo Plugin in AvailablePlugins)
                {
                    if (GenerateNameWithVersion(Plugin.Name,Plugin.Version) == NameWithVersion)
                    {
                        SelectedPlugin = Plugin;
                        break;
                    }
                }

                if (SelectedPlugin == null)
                {
                    CANHostLog.Write("Could not match " + NameWithVersion + " to available plugins");
                    return;
                }

                CANHostLog.Write("Assigning Instance ID of " + LastInstanceID + " to a new instance of " +
                                  SelectedPlugin.Name + " " + SelectedPlugin.Version);

                NewPluginInstance.PluginInstanceID = LastInstanceID++;


                CANHostLog.Write("Loading assembly " + Path.GetFileName(SelectedPlugin.AssemblyLocation));
                Assembly MyAssembly = Assembly.LoadFrom(Path.GetFullPath(SelectedPlugin.AssemblyLocation));

                CANHostLog.Write("Instantiating new instance of " + SelectedPlugin.Name);
                NewPluginInstance.Plugin = (ItrashCANPlugin)MyAssembly.CreateInstance(SelectedPlugin.PluginDataType.ToString());

                CANHostLog.Write("Calling Init()...");

                if (NewPluginInstance.Plugin.Init() != "OK")
                {
                    CANHostLog.Write("Init() did not return 'OK'.  Terminating Instance");
                    return;
                }

                NewPluginInstance.Plugin.PluginInstanceID = NewPluginInstance.PluginInstanceID;

                CANHostLog.Write("Init() successful. Adding Instance to pool");


                NewPluginInstance.Plugin.ShowPlugin();

                //IF there is State Data, load it!

                if (NewPluginState != null)
                {
                    NewPluginInstance.Plugin.State = NewPluginState;
                }

             
                NewPluginInstance.Plugin.IncomingPluginMessage.Enqueue("You have been plugged in! Instance ID: " + NewPluginInstance.PluginInstanceID);
                ActivePlugins.Add(NewPluginInstance);
                UpdateInstanceGrid();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                CANHostLog.Write(Ex.Message);
            }

        }
       
        ArrayList CheckForNodePlugins()
        {

            ArrayList UsablePlugins = new ArrayList();

            if (Directory.Exists(RootPluginPath) == false)
            {
                Directory.CreateDirectory(RootPluginPath);
                return UsablePlugins;
            }

            string appPath = Path.GetDirectoryName(Application.ExecutablePath);


            foreach (string PluginFile in Directory.GetFiles(Path.Combine(appPath, RootPluginPath), "*.dll", SearchOption.AllDirectories))
            {
                foreach (PluginInfo P in CheckDLLForValidCANNodePlugin(PluginFile))
                {
                    UsablePlugins.Add(P);
                }
            }

            return UsablePlugins;
        }

        ArrayList CheckDLLForValidCANNodePlugin(string PluginFile)
        {
            Assembly MyAssembly;
            ArrayList PluginInfo = new ArrayList();
            AppDomainSetup a = new AppDomainSetup();

            try
            {

                MyAssembly = Assembly.LoadFrom(Path.GetFullPath(PluginFile));
                foreach (Type PluginType in MyAssembly.GetTypes())
                {
                    //Check to see if the plugin is supported
                    if (typeof(ItrashCAN.ItrashCANPlugin).IsAssignableFrom(PluginType))
                    {
                        ItrashCANPlugin GetPluginData = (ItrashCANPlugin)MyAssembly.CreateInstance(PluginType.ToString());

                        Image PluginImage;

                        if (GetPluginData.PluginImage == null)
                            PluginImage = trashCAN.Properties.Resources.Gear;
                        else
                            PluginImage = GetPluginData.PluginImage;


                        PluginInfo.Add(new PluginInfo(PluginType, PluginFile, GetPluginData.PluginVersion,
                                                            GetPluginData.PluginName, PluginImage));
                        GetPluginData = null;
                    }
                }
            }
            catch (Exception Ex)
            {
                CANHostLog.Write(PluginFile + ":" + Ex.Message);
            }

            return PluginInfo;
        }

        #region Message Routing

        void PluginProcessLoop()
        {
            bool isUnlocked;

            while (true)
            {
                if (KillAllThreads == true)
                    return;
                Thread.Sleep(5);

               
                    if (PausePluginProcessing == false)
                    {
                        #region  Route CAN Messages between plugins
                        lock (ActivePlugins)
                        {
                            foreach (PluginInstanceRecord PSrc in ActivePlugins)
                            {
                                if (PSrc.Plugin.PluginInterfaceType == CAN_INTERFACE_TYPE.READ_WRITE ||
                                    PSrc.Plugin.PluginInterfaceType == CAN_INTERFACE_TYPE.WRITE_ONLY)
                                {
                                    lock (PSrc.Plugin.OutgoingCANMsgQueue)
                                    {
                                        while (PSrc.Plugin.OutgoingCANMsgQueue.Count > 0)
                                        {
                                            try
                                            {
                                                CAN_t M = PSrc.Plugin.OutgoingCANMsgQueue.Dequeue();

                                                if(M != null)
                                                {
                                                    foreach (PluginInstanceRecord PDest in ActivePlugins)
                                                    {
                                                        if (PSrc.PluginInstanceID != PDest.PluginInstanceID)
                                                        {
                                                            if (PDest.Plugin.PluginInterfaceType == CAN_INTERFACE_TYPE.READ_WRITE ||
                                                                PDest.Plugin.PluginInterfaceType == CAN_INTERFACE_TYPE.READ_ONLY)
                                                            {
                                                                isUnlocked = System.Threading.Monitor.TryEnter(PDest.Plugin.IncomingCANMsgQueue, 10);
                                                                if (isUnlocked == true)
                                                                {
                                                                    try
                                                                    {
                                                                        PDest.Plugin.IncomingCANMsgQueue.Enqueue(M);

                                                                    }
                                                                    catch (Exception ex)
                                                                    {
                                                                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                                                                    }
                                                                    finally
                                                                    {
                                                                        System.Threading.Monitor.Exit(PDest.Plugin.IncomingCANMsgQueue);
                                                                    }
                                                                }
                                                                
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    CANHostLog.IncomingMessages.Enqueue("OutgoingCANMsgQueue.Dequeue() Returned NULL with count of " + PSrc.Plugin.OutgoingCANMsgQueue.Count);
                                                }
                                            }
                                            catch (Exception Ex)
                                            {
                                                CANHostLog.IncomingMessages.Enqueue(Ex.Message);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    #endregion

                        #region Route General purpose messages between plugins
                        lock (ActivePlugins)
                        {
                            foreach (PluginInstanceRecord PSrc in ActivePlugins)
                            {
                                lock (PSrc.Plugin.OutgoingPluginMessage)
                                {
                                    while (PSrc.Plugin.OutgoingPluginMessage.Count > 0)
                                    {
                                        try
                                        {
                                            String M = PSrc.Plugin.OutgoingPluginMessage.Dequeue();

                                            if (M.Substring(0, 20) == "***EXIT_TRASH_CAN***")
                                            {
                                                PluginRequestExitTrashCAN = true;
                                            }

                                            PluginMessageLog.Write("[" + PSrc.Plugin.PluginName + ":" + PSrc.PluginInstanceID + "] " + M);

                                            if (M.Substring(0, 1) == "@")
                                            {
                                                foreach (PluginInstanceRecord PDest in ActivePlugins)
                                                {
                                                    if (PSrc.PluginInstanceID != PDest.PluginInstanceID)
                                                        PDest.Plugin.IncomingPluginMessage.Enqueue(M);
                                                }
                                            }
                                            
                                        }
                                        catch (Exception Ex)
                                        {
                                            CANHostLog.IncomingMessages.Enqueue(Ex.Message);
                                        }
                                    }
                                }
                            }
                        }

                        #endregion

                    }
               
             }
        }

        #endregion

        void KillPluginHost()
        {
            try
            {
                if (ActivePlugins != null)
                {
                    foreach (PluginInstanceRecord P in ActivePlugins)
                    {
                        P.Plugin.Terminate();
                    }
                }

                KillAllThreads = true;
                PluginProcessThread.Abort();
                PluginProcessThread = null;
            }
            catch
            {

            }
        }

        void CheckForPluginTerminationRequests()
        {
            bool PluginsRemoved = false;

            for (int i = 0; i < ActivePlugins.Count; i++)
            {
                PluginInstanceRecord P = (PluginInstanceRecord)ActivePlugins[i];
                //Check to see if 
                
                if (P.Plugin.RequestTermination == true)
                {
                    CANHostLog.Write(P.Plugin.PluginName + " with Instance ID " + P.PluginInstanceID + " is requesting termination");
                    if (P.Plugin.Terminate() != "OK")
                    {
                        CANHostLog.Write("Plugin did not return 'OK' from Terminate()");
                    }
                    CANHostLog.Write("Removing Plugin from pool");
                    P.Plugin = null;
                    ActivePlugins.RemoveAt(i);
                    PluginsRemoved = true;
                }

            }
            if (PluginsRemoved == true)
                UpdateInstanceGrid();
        }

        void UpdateInstanceGrid()
        {
            MyInstanceMonitor.Clear();
            foreach (PluginInstanceRecord P in ActivePlugins)
            {

                Image PluginImage = P.Plugin.PluginImage;

                if (PluginImage == null)
                    PluginImage = trashCAN.Properties.Resources.Gear;

                MyInstanceMonitor.AddData(PluginImage,
                                          P.PluginInstanceID.ToString(),
                                          P.Plugin.PluginName,
                                          P.Plugin.PluginVersion);
            }

        }

        void AttemptToDestroyInstance(int InstanceID)
        {
            CANHostLog.Write("Destroying plugin instance " + InstanceID);

            for (int i = 0; i < ActivePlugins.Count; i++)
            {
                PluginInstanceRecord P = (PluginInstanceRecord)ActivePlugins[i];

                if (P.PluginInstanceID == InstanceID)
                {
                    P.Plugin.Terminate();

                    ActivePlugins.RemoveAt(i);
                }
            }
        }

        string GenerateNameWithVersion(string Name, string Version)
        {
            return Name + ">" + Version;
        }

        #region GUI Callbacks

        void Save_trashCAN_State(string FileName)
        {

            if (FileName == null || FileName == "")
            {
                DialogResult ret = saveFileDialog1.ShowDialog();
                if (ret == DialogResult.OK)
                    FileName = saveFileDialog1.FileName;
                else if (ret != DialogResult.Cancel) 
                {
                    MessageBox.Show("Invalid File Name" + FileName,"File Save Error!");
                    return;
                }
                else
                    return;
            }
            
                try
                {

                    if (ActivePlugins != null)
                    {

                        TrashCANStateRecord testRecord = new TrashCANStateRecord();
                        
                        Array.Resize(ref testRecord.PluginStates, ActivePlugins.Count);
                        testRecord.MyState = new TrashCanState();
                        

                        PluginStateRecord [] MyStates = new PluginStateRecord[ActivePlugins.Count];
                        int i=0;

                        foreach(PluginInstanceRecord P in ActivePlugins)
                        {
                      
                            PluginStateRecord PSR = new PluginStateRecord();

                            PSR.NameWithVersion = GenerateNameWithVersion(P.Plugin.PluginName, P.Plugin.PluginVersion);
                            PSR.PluginInstanceID = P.PluginInstanceID;

                            PSR.State = P.Plugin.State;

                            testRecord.PluginStates[i] = PSR;

                            MyStates[i++] = PSR;

                        }

                        //TrashCanState myState = new TrashCanState();
                        testRecord.MyState.WindowLocation = MyLocation;
                        testRecord.MyState.WindowSize = this.Size;
                        testRecord.MyState.WindowState = this.WindowState;


                        //XmlSerializer serializer = new XmlSerializer(MyStates.GetType());
                        //TextWriter writer = new StreamWriter(FileName);
                        //serializer.Serialize(writer, MyStates);
                        //writer.Close();

                        XmlSerializer serializer = new XmlSerializer(testRecord.GetType());
                        TextWriter writer = new StreamWriter(FileName);
                        serializer.Serialize(writer, testRecord);
                        writer.Close();


                    }

                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message,"Error!");
                }
            
        }
        
        void Restore_trashCAN_State(string FileName)
        {

            if (FileName == null || FileName == "")
            {
                DialogResult ret = openFileDialog1.ShowDialog();
                if (ret == DialogResult.OK)
                    FileName = openFileDialog1.FileName;
                else if (ret != DialogResult.Cancel)
                {
                    MessageBox.Show("Invalid File Name" + FileName, "File Open Error!");
                    return;
                }
                else
                    return;
            }

         
                try
                {
                    lock (ActivePlugins)
                    {
                        if (ActivePlugins != null)
                        {

                            foreach (PluginInstanceRecord P in ActivePlugins)
                            {
                                P.Plugin.Terminate();
                            }

                            ActivePlugins = new ArrayList();

                            //PluginStateRecord[] MyStates;

                            
                            XmlSerializer serializer = new XmlSerializer(typeof(TrashCANStateRecord));
                            TextReader reader = new StreamReader(FileName);
                            MyRecords = (TrashCANStateRecord)serializer.Deserialize(reader);
                            reader.Close();


                            //XmlSerializer serializer = new XmlSerializer(typeof(PluginStateRecord[]));
                            //TextReader reader = new StreamReader(FileName);
                            //MyStates = (PluginStateRecord[])serializer.Deserialize(reader);
                            //reader.Close();

                    /*
                            if (MyStates != null)
                            {
                                foreach (PluginStateRecord P in MyStates)
                                {
                                    AddPluginToPool(P.NameWithVersion, P.State);
                                }
                            }*/

                            if (MyRecords.PluginStates != null)
                            {
                                foreach (PluginStateRecord P in MyRecords.PluginStates)
                                {
                                    AddPluginToPool(P.NameWithVersion, P.State);
                                }
                            }

                        }
                    }
    
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error!");
                }
        }

        private void hostLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CANHostLog.Show();
            CANHostLog.WindowState = FormWindowState.Normal;
            CANHostLog.BringToFront();
        }

        private void CANHost_FormClosing(object sender, FormClosingEventArgs e)
        {
            //CloseTrashCAN();
            Save_trashCAN_State(Path.Combine(Directory.GetCurrentDirectory(), "last.bag"));
            KillPluginHost();
        }

        private void CloseTrashCAN()
        {
            
            
        }

        private void pluginMessageLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PluginMessageLog.Show();
        }

        private void trashCANHost_Load(object sender, EventArgs e)
        {
            this.Location = MyRecords.MyState.WindowLocation;
            this.Size = MyRecords.MyState.WindowSize;
            this.WindowState = MyRecords.MyState.WindowState;
        }

        private void pluginInstanceMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyInstanceMonitor.Show();
            MyInstanceMonitor.WindowState = FormWindowState.Normal;
            MyInstanceMonitor.BringToFront();
        }

        void MI_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem S = (ToolStripMenuItem)sender;

            AddPluginToPool(S.Name,null);

        }

        #endregion

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyAboutForm.Show();
        }

        private void restoreLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restore_trashCAN_State(null);
        }

        private void saveLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save_trashCAN_State(null);
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void trashCANHost_LocationChanged(object sender, EventArgs e)
        {
            if ( (this.Location.X >= 0) && (this.Location.Y >= 0) )
            {
                MyLocation = this.Location;
            }
        }

        private void timerUpdateGUI_Tick(object sender, EventArgs e)
        {
            statusLabelActive.Text = "Active: " + ActivePlugins.Count;
        }


    }
    
    #region Helper Classes
    
    [Serializable()]
    public class PluginInfo
    {
        public Type PluginDataType;
        public string AssemblyLocation;
        public string Version;
        public string Name;
        public Image Image;

        public PluginInfo(Type T, string AL, string V, string N, Image Image)
        {
            this.PluginDataType = T;
            this.AssemblyLocation = AL;
            this.Version = V;
            this.Name = N;
            this.Image = Image;
        }
    }

    [Serializable()]
    public class PluginInstanceRecord
    {
        public ItrashCANPlugin Plugin;
        public int PluginInstanceID;
    }

    [Serializable()]
    public class TrashCANStateRecord
    {
        public PluginStateRecord[] PluginStates;
        public TrashCanState MyState;

    }

    [Serializable()]
    public class PluginStateRecord
    {
        public string NameWithVersion;
        public int PluginInstanceID;
        public PluginState State;
    }

    [Serializable()]
    public class TrashCanState
    {
        public Size WindowSize;
        public Point WindowLocation;
        public FormWindowState WindowState;

    }

}
    
    #endregion