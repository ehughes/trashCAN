using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ItrashCAN;

namespace CANMessageSniffer
{
        [Serializable()]
    public partial class CANMessageSniffer : Form, ItrashCANPlugin
    {
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
            get { return "CAN Message Sniffer";}
        }
   
        public String PluginVersion
        {
            get { return "0.9"; }
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
                _State.WindowLocation = this.Location;
                _State.WindowSize = this.Size;
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

        private void SnifferUpdateTimer_Tick(object sender, EventArgs e)
        {
            _IncomingPluginMessage.Clear();
            
            while(_IncomingCANMsgQueue.Count>0)
            {
                CANMsgDisplayQueue.Enqueue(_IncomingCANMsgQueue.Dequeue());
            }

            while(CANMsgDisplayQueue.Count>64)
            {
                CAN_t Junk = CANMsgDisplayQueue.Dequeue();
            }

            CAN_t[] DisplayMsg = (CAN_t[])CANMsgDisplayQueue.ToArray();

            String Output = "";
            for (int i = 0; i < DisplayMsg.Length;i++ )
            {
                 Output += DisplayMsg[DisplayMsg.Length - i - 1].ToString() + "\r\n";
            }

            CANMsgTextBox.Text = Output;
        }

        private void CANMessageSniffer_Resize(object sender, EventArgs e)
        {
            ResizeDisplay();
        }

        void ResizeDisplay()
        {
            CANMsgTextBox.Location = new Point(0, 0);
            CANMsgTextBox.Size = new Size(this.ClientRectangle.Width, this.ClientRectangle.Height);
        }

    }
}
