using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ItrashCAN;

namespace CANMessageSniffer
{
        [Serializable()]
    public partial class CANMessageSniffer : Form, ItrashCANPlugin
    {

        Point MyLocation;
        Size MySize;
        int msgLockedCount;
        int msgTotalInCount;

        public CANMessageSniffer()
        {
            InitializeComponent();
            ResizeDisplay();
        }

        #region Plugin Interface

        Queue<String> _OutgoingPluginMessage = new Queue<string>(64);

        public Queue<String> OutgoingPluginMessage
        {
            get { return _OutgoingPluginMessage; }
        }
   
        Queue<String> _IncomingPluginMessage = new Queue<string>(64);

        public Queue<String> IncomingPluginMessage
        {
            get { return _IncomingPluginMessage;}
        }

        public CAN_INTERFACE_TYPE PluginInterfaceType
        {
            get { return CAN_INTERFACE_TYPE.READ_ONLY; }
        }

        public String PluginName
        {
            //get { return "CAN Message Sniffer";}
            get 
            { 
                //return _PluginNameString; 
                return Assembly.GetExecutingAssembly().GetName().Name.ToString();
            }
        }
   
        public String PluginVersion
        {
            //get { return "0.9"; }
            get 
            {
                //return _PluginVersion; 
                //return this.ProductVersion;
                Version ver = Assembly.GetExecutingAssembly().GetName().Version;
                return ver.Major + "." + ver.Minor + "." + ver.Build;
            }
        }

        public Image PluginImage
        {
            get { return Properties.Resources.nose; }
        }

        int _MyInstanceID;

        public int PluginInstanceID
        {
             get{return _MyInstanceID;}
            set { _MyInstanceID = value; }
        }

        public String Init()
            {
                _IncomingCANMsgQueue = new Queue<CAN_t>(1024);
                _OutgoingCANMsgQueue = new Queue<CAN_t>(1024);
                _IncomingPluginMessage = new Queue<string>(1024);
                _OutgoingPluginMessage = new Queue<string>(1024);
                _OutgoingPluginMessage.Enqueue("CANSniffer Initialized....");
         

                return "OK";
            }


        PluginState _State = new PluginState();

        public PluginState State
        {
            get
            {
                //_State.WindowLocation = this.Location;
                //_State.WindowSize = this.Size;
                //_State.WindowState = this.WindowState;

                //return _State;
                
                _State.WindowLocation = MyLocation;
                _State.WindowSize = MySize;
                _State.WindowState = this.WindowState;

                return _State;
            }
            set
            {
                _State = value;

                if (_State != null)
                {
                    this.Size = _State.WindowSize;
                    this.Location = _State.WindowLocation;
                    this.WindowState = _State.WindowState;
                    this.Invalidate();
                }
            }

        }

        public String Terminate()
            {
                this.DestroyHandle();
                this.Close();
                return "OK";
            }

        public void ShowPlugin()
        {
            this.Show();
            this.BringToFront();
            this.WindowState = FormWindowState.Normal;
            this.Text = PluginName + " v" + PluginVersion;
            ClearStatistics();
           
        }

        public void HidePlugin()
        {
            this.Hide();
        }

        Queue<CAN_t> _IncomingCANMsgQueue = new Queue<CAN_t>(1024);
        Queue<CAN_t> _OutgoingCANMsgQueue = new Queue<CAN_t>(1024);

        public Queue<CAN_t> IncomingCANMsgQueue
        {
            get { return _IncomingCANMsgQueue; }
        }

        public Queue<CAN_t> OutgoingCANMsgQueue
        {
            get { return _OutgoingCANMsgQueue; }
      
        }

        bool _RequestTermination = false;
        
        public bool RequestTermination 
        {
            get { return _RequestTermination; }
        }

        #endregion

        #region Plugin Implementation

        Queue<CAN_t> CANMsgDisplayQueue = new Queue<CAN_t>(64);

        #endregion

        private void CANMessageSniffer_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            _RequestTermination = true;
            _OutgoingPluginMessage.Enqueue("I want to close");
        }


        private void ClearStatistics()
        {
            msgTotalInCount = 0;
            msgLockedCount = 0;
            CANMsgDisplayQueue.Clear();
            
        }

        StringBuilder sbOutput = new StringBuilder(32768);
        private void SnifferUpdateTimer_Tick(object sender, EventArgs e)
        {

            bool isUnlocked;

            _IncomingPluginMessage.Clear();
            
            while(_IncomingCANMsgQueue.Count>0)
            {
                //CANMsgDisplayQueue.Enqueue(_IncomingCANMsgQueue.Dequeue());
                isUnlocked = System.Threading.Monitor.TryEnter(_IncomingCANMsgQueue, 0);
                if (isUnlocked == true)
                {
                    try
                    {
                        msgTotalInCount++;
                        CANMsgDisplayQueue.Enqueue(_IncomingCANMsgQueue.Dequeue());

                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.ToString());
                    }
                    finally
                    {
                        System.Threading.Monitor.Exit(_IncomingCANMsgQueue);
                    }
                }

                if  (isUnlocked == false)
                {
                    msgLockedCount++;
                }
            }

            while(CANMsgDisplayQueue.Count > 128)
            {
                CAN_t Junk = CANMsgDisplayQueue.Dequeue();
            }

            CAN_t[] DisplayMsg = (CAN_t[])CANMsgDisplayQueue.ToArray();

            sbOutput.Clear();
            //String Output = "";
            for (int i = 0; i < DisplayMsg.Length;i++ )
            {
                 //Output += DisplayMsg[DisplayMsg.Length - i - 1].ToString() + "\r\n";
                sbOutput.AppendLine(DisplayMsg[DisplayMsg.Length - i - 1].ToString());
            }

            //CANMsgTextBox.Text = Output;
            CANMsgTextBox.Text = sbOutput.ToString();
            

            statusMessagesIn.Text = "IN:  " + msgTotalInCount.ToString("#,0");
            statusLockCount.Text = "LOCK:  " + msgLockedCount.ToString("#,0");
        }

        private void CANMessageSniffer_Resize(object sender, EventArgs e)
        {
            ResizeDisplay();
        }

        void ResizeDisplay()
        {
            if (this.Size.Width >= this.MinimumSize.Width && this.Size.Height >= this.MinimumSize.Height)
            {
                MySize = this.Size;
            }

            //CANMsgTextBox.Location = new Point(0, 0);
            //CANMsgTextBox.Size = new Size(this.ClientRectangle.Width, this.ClientRectangle.Height);
        }

        private void CANMessageSniffer_LocationChanged(object sender, EventArgs e)
        {
            if ((this.Location.X >= 0) && (this.Location.Y >= 0))
            {
                MyLocation = this.Location;
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearStatistics();
        }

        private void statusMessagesIn_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }


    }
}
