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
using J1939_Routines;

namespace J1939_Sniffer
{
    public partial class J1939_Sniffer : Form , ItrashCANPlugin
    {

        const string _PluginNameString = "J1939 Sniffer";

        const int MsgDisplayHistory = 64;
        Queue <String> MsgDisplayQueue = new Queue<string>();

        uint PGNsAfterBreakPoint = 0;
        bool BreakpointHit = false;

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
            get { return global::J1939_Sniffer.Properties.Resources.Nose_J1939; }
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

        
        public J1939_Sniffer()
        {
            InitializeComponent();
            BreakPointType.SelectedIndex = 0;
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void MsgCheckTimer_Tick(object sender, EventArgs e)
        {
            if (_IncomingCANMsgQueue != null)
            {
                lock (_IncomingCANMsgQueue)
                {

                    if (PauseCheckBox.Checked == false)
                    {
                        while (_IncomingCANMsgQueue.Count > 0)
                        {
                            //see if our queue is bigger than what we can display
                            while (MsgDisplayQueue.Count > (MsgDisplayHistory - 1))
                            {
                                String T = MsgDisplayQueue.Dequeue();
                            }

                            CAN_t NextMsg = _IncomingCANMsgQueue.Dequeue();

                            string Trailer = "";

                            if (BreakPointCheckBox.Checked == true)
                            {
                           
                                    switch((string)BreakPointType.SelectedItem)
                                    {
                                        case "BREAK ON PGN":
                                            if (J1939.GetPGN_FromPDU(NextMsg.ID) == (uint)PGN_Breakpoint.Value)
                                            {
                                                if (BreakpointHit != true)
                                                {
                                                    BreakpointHit = true;
                                                    Trailer = " <===BREAKPOINT";
                                                }
                                            }
                                            break;

                                        case "BREAK ON BAM [Specific PGN]":

                                            if ( ((uint)PGN_Breakpoint.Value == J1939.GetPGN_From_TP_CM(NextMsg)) &&
                                                (J1939.GetPGN_FromPDU(NextMsg.ID) ==J1939.PGN.TP_CM) &&
                                                (NextMsg.Data[0] == 32))
                                            {
                                                if (BreakpointHit != true)
                                                {
                                                    BreakpointHit = true;
                                                    Trailer = " <===BREAKPOINT";
                                                }
                                            }

                                            break;


                                        case "BREAK ON BAM [Any PGN]":

                                            if ((J1939.GetPGN_FromPDU(NextMsg.ID) == J1939.PGN.TP_CM) &&
                                                (NextMsg.Data[0] == 32))
                                            {
                                                if (BreakpointHit != true)
                                                {
                                                    BreakpointHit = true;
                                                    Trailer = " <===BREAKPOINT";
                                                }
                                            }

                                            break;

                                        case "BREAK ON PGN+BAM":

                                            if ((((uint)PGN_Breakpoint.Value == J1939.GetPGN_From_TP_CM(NextMsg)) &&
                                                 (J1939.GetPGN_FromPDU(NextMsg.ID) == J1939.PGN.TP_CM) &&
                                                (NextMsg.Data[0] == 32))
                                                
                                                ||

                                                (J1939.GetPGN_FromPDU(NextMsg.ID) == (uint)PGN_Breakpoint.Value)
                                                
                                                )
                                            {
                                                if (BreakpointHit != true)
                                                {
                                                    BreakpointHit = true;
                                                    Trailer = " <===BREAKPOINT";
                                                }
                                            }


                                            break;
                                    }
                               



                                    if (BreakpointHit == true)
                                    {
                                        PGNsAfterBreakPoint++;
                                        if (PGNsAfterBreakPoint > PGN_CaptureCount.Value)
                                        {
                                            PauseCheckBox.Checked = true;
                                            _IncomingCANMsgQueue.Clear();
                                        }
                                    }
                            
                            }

                            MsgDisplayQueue.Enqueue(J1939.GetJ1939_String(NextMsg) + Trailer);


                        }
                      }
                }
            }
        }

        private void FormUpdateTimer_Tick(object sender, EventArgs e)
        {

            if(MsgDisplayQueue != null)
            {

                string[] Messages = (string[])MsgDisplayQueue.ToArray();

                string T = "";

                for(int i=0;i<Messages.Length;i++)
                {
                    T = Messages[i] + "\r\n" + T;  
                }

                MsgDisplayTextBox.Text = T;
            }
        }

        private void PauseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (PauseCheckBox.Checked == true)
            {
                PGNsAfterBreakPoint = 0;
                BreakpointHit = false;
            }
        }

        private void J1939_Sniffer_FormClosing(object sender, FormClosingEventArgs e)
        {
            _RequestTermination = true;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            MsgDisplayTextBox.Text = "";
            MsgDisplayQueue.Clear();
        }

        private void BreakPointCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(BreakPointCheckBox.Checked == true)
            {
                PGNsAfterBreakPoint = 0;
                BreakpointHit = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
