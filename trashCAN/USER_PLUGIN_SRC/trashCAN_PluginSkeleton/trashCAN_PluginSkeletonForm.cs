using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ItrashCAN;


namespace trashCAN_PluginSkeleton
{
    public partial class trashCAN_PluginSkeletonForm : Form , ItrashCANPlugin
    {

        const string _PluginNameString = "trashCAN Plugin Skeleton";

        System.Windows.Forms.Timer MessageGeneratorTimer = new Timer();

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
            get { return _PluginNameString; }
        }

        public String PluginVersion
        {
            get { return "0.1"; }
        }

        public Image PluginImage
        {
            get { return global::trashCAN_PluginSkeleton.Properties.Resources.trashCAN_PluginSkeleton; }
        }

        int _MyInstanceID;

        public int PluginInstanceID
        {
            get { return _MyInstanceID; }
            set { _MyInstanceID = value; }
        }

        public String Init()
        {
            _IncomingCANMsgQueue = new Queue<CAN_t>(1024);
            _OutgoingCANMsgQueue = new Queue<CAN_t>(1024);
            _IncomingPluginMessage = new Queue<string>(1024);
            _OutgoingPluginMessage = new Queue<string>(1024);
            _OutgoingPluginMessage.Enqueue(_PluginNameString + " Initialized....");

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

        
        public trashCAN_PluginSkeletonForm()
        {
            InitializeComponent();
            MessageGeneratorTimer.Interval = 1000;
            MessageGeneratorTimer.Tick += MessageGeneratorTimer_Tick;
            MessageGeneratorTimer.Enabled = true;
        }

        void MessageGeneratorTimer_Tick(object sender, EventArgs e)
        {
            CAN_t OutputMsg = new CAN_t();

            Random R = new Random();
            OutputMsg.ID = (uint) R.Next();
            OutputMsg.ExtendedID = true;
            OutputMsg.Data = new Byte[8];
            OutputMsg.Data[0] = (byte)R.Next();
            OutputMsg.Data[1] = (byte)R.Next();
            OutputMsg.Data[2] = (byte)R.Next();
            OutputMsg.Data[3] = (byte)R.Next();
            OutputMsg.Data[4] = (byte)R.Next();
            OutputMsg.Data[5] = (byte)R.Next();
            OutputMsg.Data[6] = (byte)R.Next();
            OutputMsg.Data[7] = (byte)R.Next();

            _OutgoingCANMsgQueue.Enqueue(OutputMsg);


        }

        private void Form1_Load(object sender, EventArgs e)
        {
   
        }

        private void trashCAN_PluginSkeletonForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _RequestTermination = true;
        }
    }
}
