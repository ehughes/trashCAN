﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ItrashCAN;
using Peak.Can.Basic;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace PCAN_USB
{
    public partial class PCAN_USB : Form, ItrashCANPlugin
    {
        bool ConnectionActive = false;
        byte CurrentPCANChannel = 0;
        bool KillAllThreads = false;
        Thread CANTxThread;
        Thread CANRxThread;
        int MessagesOut = 0;
        int MessagesIn = 0;
        int ErrorCount = 0;
        uint LastPCANError = 0;

        bool StateHasBeenSet = false;

        System.Drawing.Point MyLocation;

       // TPCANHandle[] m_HandlesArray;

        PCAN_USB_State MyPCAN_USB_State = new PCAN_USB_State();

        Queue<CAN_t> _IncomingCANMsgQueue;
        Queue<CAN_t> _OutgoingCANMsgQueue;
        //Queue<CAN_t> _IncomingCANMsgQueue = new Queue<CAN_t>(128);
        //Queue<CAN_t> _OutgoingCANMsgQueue = new Queue<CAN_t>(128);

        //String _PluginName = "PCAN-USB";
        //String _PluginVersion = "1.1_NAT3";

         public String Init()
        {

          

            _IncomingCANMsgQueue = new Queue<CAN_t>(1024);
            _OutgoingCANMsgQueue = new Queue<CAN_t>(1024);
            _IncomingPluginMessage = new Queue<string>(1024);
            _OutgoingPluginMessage = new Queue<string>(1024);
            _OutgoingPluginMessage.Enqueue("Peak CAN - USB Plugin Initialized....");
            System.Diagnostics.Debug.WriteLine("PCAN USB Plugin Initialized");
            
            return "OK";
        }  
        
        public PCAN_USB()
        {
            InitializeComponent();
            PopulateBAUDRateComboBox();
            CheckForAvailableChannels();
            ConnectionActive = false;
            ErrorLabel.Text = "";
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
            get { return _IncomingPluginMessage; }
        }
        
        public CAN_INTERFACE_TYPE PluginInterfaceType
        {
            get { return CAN_INTERFACE_TYPE.READ_WRITE; }
        }

        public String PluginName
        {
            get 
            { 
                //return _PluginName; 
                return Assembly.GetExecutingAssembly().GetName().Name.ToString();
            }
        }

        public String PluginVersion
        {
            get 
            { 
                //return _PluginVersion; 
                Version ver = Assembly.GetExecutingAssembly().GetName().Version;
                return ver.Major + "." + ver.Minor + "." + ver.Build;
            }
        }

        public Image PluginImage
        {
            get { return Properties.Resources.PCAN_USB; }
        }

        int _MyInstanceID;

        public int PluginInstanceID
        {
            get { return _MyInstanceID; }
            set { _MyInstanceID = value; }
        }


        PluginState _State = new PluginState();


        public PluginState State
        {
            get
            {

                SaveState();

                //_State.WindowLocation = this.Location;
                _State.WindowLocation = MyLocation;
                _State.WindowSize = this.Size;
                _State.WindowState = this.WindowState;

                XmlSerializer xmlSerializer = new XmlSerializer(MyPCAN_USB_State.GetType());
                StringWriter textWriter = new StringWriter();
                xmlSerializer.Serialize(textWriter, MyPCAN_USB_State);
                _State.PluginData = textWriter.ToString();

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


                    XmlSerializer xmlSerializer = new XmlSerializer(MyPCAN_USB_State.GetType());
                    StringReader textReader = new StringReader(_State.PluginData);
                    MyPCAN_USB_State = (PCAN_USB_State)xmlSerializer.Deserialize(textReader);

                    RestoreState();

                }
            }

        }


        public String Terminate()
        {
            this.DestroyHandle();
            KillAllThreads = true;
            DisconnectFromPCAN();
        
            this.Close();
            return "OK";

        }

        public void ShowPlugin()
        {
            this.Show();
            this.BringToFront();
            this.WindowState = FormWindowState.Normal;
            this.Text = PluginName + " v" + PluginVersion;

        }

        public void HidePlugin()
        {
            this.Hide();
        }

        public void MinimizePlugin()
        {
            this.Show();
            this.WindowState = FormWindowState.Minimized;
        }

        public void MaximizePlugin()
        {
            this.Show();
            this.WindowState = FormWindowState.Maximized;
        }

       
        

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

        #region Helper Functions

        void PopulateBAUDRateComboBox()
        {
                BAUDRateCB.Items.Clear();
                BAUDRateCB.Items.AddRange((string[])Enum.GetNames(typeof(TPCANBaudrate)));
                BAUDRateCB.SelectedIndex = 3;
        }

        void CheckForAvailableChannels()
        {
            UInt32 iBuffer;
            TPCANStatus stsResult;

            // Checks for a Plug&Play Handle and, according with the return value, includes it
            // into the list of available hardware channels.
            //

            USBChannelCB.Items.Clear();

            for (byte i = PCANBasic.PCAN_USBBUS1; i < PCANBasic.PCAN_USBBUS8; i++)
            {
                stsResult = PCANBasic.GetValue(i, TPCANParameter.PCAN_CHANNEL_CONDITION, out iBuffer, sizeof(UInt32));
                if ((stsResult == TPCANStatus.PCAN_ERROR_OK) && (iBuffer == PCANBasic.PCAN_CHANNEL_AVAILABLE))
                    USBChannelCB.Items.Add((i - PCANBasic.PCAN_USBBUS1 + 1).ToString());
            }

            if (USBChannelCB.Items.Count == 0)
            {
                USBChannelCB.Items.Add("X");
                USBChannelCB.Enabled = false;
            }
            else
            {
                USBChannelCB.Enabled = true;
                USBChannelCB.SelectedIndex = 0;
            }
        }

        void ClearStatistics()
        {
            MessagesOut = 0;
            MessagesIn = 0;
            ErrorCount = 0;
            LastPCANError = 0;
        }

        void ConnectToPCAN()
        {
            try
            {
                CurrentPCANChannel = (byte)(Convert.ToByte(USBChannelCB.SelectedItem.ToString()) + PCANBasic.PCAN_USBBUS1 - 1);

                string BaudRate = (string)BAUDRateCB.SelectedItem;

                TPCANBaudrate PCANBaudRate = (TPCANBaudrate)Enum.Parse(typeof(TPCANBaudrate), BaudRate);


                PCANBasic.Uninitialize(CurrentPCANChannel);
                PCANBasic.Reset(CurrentPCANChannel);
                TPCANStatus stsResult = PCANBasic.Initialize(CurrentPCANChannel, PCANBaudRate);

                if (stsResult == TPCANStatus.PCAN_ERROR_OK)
                {
                    _OutgoingPluginMessage.Enqueue("PCAN Initialize on channel " + USBChannelCB.SelectedItem.ToString() + " at baud rate " + (string)BAUDRateCB.SelectedItem + " successful");
                    _OutgoingCANMsgQueue.Clear();
                    _IncomingCANMsgQueue.Clear();
               
                    ConnectLabel.Text = "Disconnect";
                    ConnectButton.BackgroundImage = global::PCAN_USB.Properties.Resources.disconnect;
                    USBChannelCB.Enabled = false;
                    BAUDRateCB.Enabled = false;
                    RefreshButton.Enabled = false;
                    RefreshButton.BackgroundImage = global::PCAN_USB.Properties.Resources.refresh_gray;
                    ClearStatistics();
                    KillAllThreads = false;
                    CANRxThread = new Thread(new ThreadStart(RxCANMessagesFromAdapter));
                    CANTxThread = new Thread(new ThreadStart(TxCANMessagesToAdapter));
                    CANRxThread.Start(); _OutgoingPluginMessage.Enqueue("PCAN Rx Thread Starting");
                    CANTxThread.Start(); _OutgoingPluginMessage.Enqueue("PCAN Tx Thread Starting");
                    ConnectionActive = true;
                }
                else
                {
                    _OutgoingPluginMessage.Enqueue("PCAN Initialize on channel failed: " + stsResult.ToString());
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Connection Error");
                _OutgoingPluginMessage.Enqueue(Ex.Message);
                ConnectLabel.Text = "Connect";
                ConnectButton.BackgroundImage = global::PCAN_USB.Properties.Resources.connect;
                USBChannelCB.Enabled = true;
                BAUDRateCB.Enabled = true;
                RefreshButton.Enabled = true;
                CheckForAvailableChannels();
                RefreshButton.BackgroundImage = global::PCAN_USB.Properties.Resources.refresh;
                System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + Ex.ToString());
            }
        }

        void DisconnectFromPCAN()
        {
            try
            {
                string BaudRate = (string)BAUDRateCB.SelectedItem;
                KillAllThreads = true;

                if (ConnectionActive == true)
                {
                    TPCANBaudrate PCANBaudRate = (TPCANBaudrate)Enum.Parse(typeof(TPCANBaudrate), BaudRate);
                    TPCANStatus stsResult = PCANBasic.Uninitialize(CurrentPCANChannel);

                    if (stsResult == TPCANStatus.PCAN_ERROR_OK)
                    {
                        _OutgoingPluginMessage.Enqueue("PCAN Un-Initialize on channel " + USBChannelCB.SelectedItem.ToString() + " successful");
                        _OutgoingCANMsgQueue.Clear();
                        _IncomingCANMsgQueue.Clear();
                    }
                }

                ConnectionActive = false;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Disconnection Error");
                _OutgoingPluginMessage.Enqueue(Ex.Message);
                System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + Ex.ToString());
            }
            finally
            {
                CheckForAvailableChannels();
                ConnectLabel.Text = "Connect";
                ConnectButton.BackgroundImage = global::PCAN_USB.Properties.Resources.connect;
                USBChannelCB.Enabled = true;
                BAUDRateCB.Enabled = true;
                ConnectionActive = false;
                RefreshButton.Enabled = true;
                RefreshButton.BackgroundImage = global::PCAN_USB.Properties.Resources.refresh;
                KillAllThreads = true;
            }

        }

        void TxCANMessagesToAdapter()
        {
            while (KillAllThreads == false)
            {
                Thread.Sleep(10);
                    while (_IncomingCANMsgQueue.Count > 0 && ConnectionActive == true)
                    {
                        TPCANStatus MyStatus = PCANBasic.GetStatus(CurrentPCANChannel);

                        if (MyStatus != TPCANStatus.PCAN_ERROR_XMTFULL || (MyStatus != TPCANStatus.PCAN_ERROR_QXMTFULL) && (MyStatus == TPCANStatus.PCAN_ERROR_OK))
                        {
                            //CAN_t OutMsg = _IncomingCANMsgQueue.Dequeue();
                            //TPCANMsg PCANOutMsg = new TPCANMsg();
                            CAN_t OutMsg;
                            TPCANMsg PCANOutMsg;
                            bool isUnlocked;

                            isUnlocked = System.Threading.Monitor.TryEnter(_IncomingCANMsgQueue, 0);
                            if (isUnlocked == true)
                            {
                                try
                                {
                                    OutMsg = _IncomingCANMsgQueue.Dequeue();

                                    PCANOutMsg.LEN = (byte)OutMsg.Data.Length;

                                    PCANOutMsg.DATA = new byte[8];
                                    for (int i = 0; i < OutMsg.Data.Length; i++)
                                    {
                                        PCANOutMsg.DATA[i] = OutMsg.Data[i];
                                    }

                                    if (OutMsg.ExtendedID == true)
                                    {
                                        PCANOutMsg.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_EXTENDED;
                                    }
                                    else
                                    {
                                        PCANOutMsg.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD;
                                    }

                                    if (OutMsg.RTR == true)
                                    {
                                        PCANOutMsg.MSGTYPE |= TPCANMessageType.PCAN_MESSAGE_RTR;
                                    }

                                    PCANOutMsg.ID = OutMsg.ID;

                                    TPCANStatus TxStatus = PCANBasic.Write(CurrentPCANChannel, ref PCANOutMsg);

                                    if (TxStatus != TPCANStatus.PCAN_ERROR_OK)
                                    {
                                        //Thread.Sleep(2000);
                                        _OutgoingPluginMessage.Enqueue("PCAN error during transmit: " + TxStatus.ToString());
                                    }
                                    else
                                    {
                                        MessagesOut++;
                                    }

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

                            


                        }
                        else
                        {
                         //   break;
                        }
                    }
            }

            _OutgoingPluginMessage.Enqueue("PCAN Tx Thread Exiting");
        }

        void RxCANMessagesFromAdapter()
        {
            TPCANMsg PCANInMsg = new TPCANMsg();
            TPCANTimestamp TS = new TPCANTimestamp();
            TPCANStatus tPCANStatus;

            Thread.Sleep(1);
            while (KillAllThreads == false)
            {
                
                if (ConnectionActive == true)
                {
                    do
                    {
                        tPCANStatus = PCANBasic.Read(CurrentPCANChannel, out PCANInMsg, out TS);
                        if (tPCANStatus == TPCANStatus.PCAN_ERROR_OK)
                        {
                            CAN_t InMsg = new CAN_t();

                            InMsg.Data = new byte[PCANInMsg.LEN];

                            for (int i = 0; i < PCANInMsg.LEN; i++)
                            {
                                InMsg.Data[i] = PCANInMsg.DATA[i];
                            }

                            if ((PCANInMsg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_EXTENDED) > 0)
                            {
                                InMsg.ExtendedID = true;
                            }
                            else
                            {
                                InMsg.ExtendedID = false;
                            }

                            if ((PCANInMsg.MSGTYPE & TPCANMessageType.PCAN_MESSAGE_RTR) > 0)
                            {
                                InMsg.RTR = true;
                            }
                            else
                            {
                                InMsg.RTR = false;
                            }

                            InMsg.ID = PCANInMsg.ID;

                            if( System.Threading.Monitor.TryEnter(_OutgoingCANMsgQueue, 10))
                            {
                                try
                                {
                                    _OutgoingCANMsgQueue.Enqueue(InMsg);
                                }
                                catch (Exception ex)
                                {
                                    System.Diagnostics.Debug.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + ex.ToString());
                                }
                                finally
                                {
                                    Monitor.Exit(_OutgoingCANMsgQueue);
                                }
                                
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("PCAN Couldn't get exclusive lock!");
                            }
                            
                            
                            MessagesIn++;
                        }
                        else
                        {
                            if (!Convert.ToBoolean(tPCANStatus & TPCANStatus.PCAN_ERROR_QRCVEMPTY))
                            {
                                ErrorCount++;
                                LastPCANError = Convert.ToUInt32(tPCANStatus);
                                _OutgoingPluginMessage.Enqueue("PCAN RX Error: " + LastPCANError.ToString());
                            }

                        }
                    }
                    //while (!Convert.ToBoolean(tPCANStatus & TPCANStatus.PCAN_ERROR_QRCVEMPTY));
                    while ((!Convert.ToBoolean(tPCANStatus & TPCANStatus.PCAN_ERROR_QRCVEMPTY)) && (ConnectionActive == true));
                    
                }
            }
            _OutgoingPluginMessage.Enqueue("PCAN Rx Thread Exiting");
        }
        #endregion

        #region GUI Callbacks

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            CheckForAvailableChannels();
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (ConnectionActive == false)
            {
                ConnectToPCAN();
            }
            else
            {
                DisconnectFromPCAN();
            }
        }

        private void FormUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (USBChannelCB.Items.Count == 0)
            {
                ConnectLabel.Enabled = false;
                ConnectButton.Enabled = false;
            }
            else
            {
                ConnectLabel.Enabled = true;
                ConnectButton.Enabled = true;
            }

            if (ConnectionActive == true)
            {
                TPCANStatus MyStatus = PCANBasic.GetStatus(CurrentPCANChannel);
                //StatusLabel.Text = "Status: CONN " + MessagesIn + "/" + MessagesOut + "/" + ErrorCount + " (" + LastPCANError.ToString("X4") + ")";
                StatusLabel.Text = "Status:  CONNECTED - Last Error (" + LastPCANError.ToString("X4") + ")";

                statusStripIn.Text = "I: " + MessagesIn.ToString("#,0");
                statusStripOut.Text = "O: " + MessagesOut.ToString("#,0");
                statusStripError.Text = "E: " + ErrorCount.ToString("#,0");


                if (MyStatus != TPCANStatus.PCAN_ERROR_OK)
                {
                    StringBuilder ErrorString = new StringBuilder(256);
                    ErrorLabel.Text = "Error";
                   PCANBasic.GetErrorText(MyStatus, 0x00, ErrorString);
                   _OutgoingPluginMessage.Enqueue("Error: " + ErrorString.ToString());
               }
                else
                {
                    ErrorLabel.Text = "";
                }
            }
            else
            {
                StatusLabel.Text = "Status: Disconnected";
                ErrorLabel.Text = "";
            }
        }

        private void PCAN_USB_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            _RequestTermination = true;

        }

        #endregion

        public void SaveState()
        {
            MyPCAN_USB_State.SelectedBaudRate = BAUDRateCB.SelectedIndex;
            MyPCAN_USB_State.SelectedChannel = Convert.ToByte(USBChannelCB.SelectedItem.ToString());
            MyPCAN_USB_State.ConnectionActive = ConnectionActive;

            //(byte)(Convert.ToByte(USBChannelCB.SelectedItem.ToString()) + PCANBasic.PCAN_USBBUS1 - 1);

        }

        public void RestoreState()
        {
            BAUDRateCB.SelectedIndex =  MyPCAN_USB_State.SelectedBaudRate;

            for (int i = 0; i < USBChannelCB.Items.Count;i++ )
            {
                if(USBChannelCB.Items[i].ToString() == MyPCAN_USB_State.SelectedChannel.ToString())
                {
                    USBChannelCB.SelectedIndex = i;
                    break;
                }

            }

            if (MyPCAN_USB_State.ConnectionActive == true)
            {
                ConnectToPCAN();
            }

        }

        private void PCAN_USB_Load(object sender, EventArgs e)
        {

        }

        private void PCAN_USB_LocationChanged(object sender, EventArgs e)
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
        

    }


    [Serializable()]
    public class PCAN_USB_State
    {
     
        public int SelectedBaudRate;
        public int SelectedChannel;
        public bool ConnectionActive;
    }
   
}



