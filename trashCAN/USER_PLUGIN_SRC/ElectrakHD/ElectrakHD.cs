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

namespace ElectrakHD

{

    

    public partial class ElectrakHD : Form , ItrashCANPlugin
    {
        uint ActivityTTL = 0;
        AFM MyFeedback = new AFM();
        ACM MyControlMessage = new ACM();

        const string _PluginNameString = "Elecktrak HD Controller";

        const int MsgDisplayHistory = 64;
        Queue <String> MsgDisplayQueue = new Queue<string>();

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
            get { return global::ElectrakHD.Properties.Resources.ElectrakHD; }
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


        public ElectrakHD()
        {
            InitializeComponent();
        }

    

  
        private void MsgCheckTimer_Tick(object sender, EventArgs e)
        {
            if (_IncomingCANMsgQueue != null)
            {
                lock (_IncomingCANMsgQueue)
                {
                    if (_IncomingCANMsgQueue.Count > 0)
                    {
                        CAN_t Message = _IncomingCANMsgQueue.Dequeue();
                        if (Message != null)
                        { 
                            if (J1939.GetSourceAddress_FromPDU(Message.ID) == (uint)ActuatorAddress.Value)
                            {
                                ActivityTTL = 20;
                                uint PGN = J1939.GetPGN_FromPDU(Message.ID);
                              //  if (PGN == AFM.ProprietaryA2)
                                {

                                    MyFeedback.ProcessProprietaryA2(Message.Data);

                                }
                            }
                        }
                    }
                

                }
            }
        }

        private void FormUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (ActivityTTL > 0)
                ActivityTTL--;

           if ( ActivityTTL>0)
            {
                ActivityLED.On = true;
            }
           else
            {
                ActivityLED.On = false;
            }

            MeasuredPositionTextBox.Text = MyFeedback.MeasuredPosition.ToString("0.0");
            MeasuredCurrentTextBox.Text = MyFeedback.MeasuredCurrent.ToString("0.0");
            RunningSpeedTextBox.Text = MyFeedback.RunningSpeed.ToString("0");
            VoltageErrorTextBox.Text = MyFeedback.MakeVoltageErrorString(MyFeedback.Raw_VoltageError);
            TemperatureErrorTextBox.Text = MyFeedback.MakeTemperatureErrorString(MyFeedback.Raw_TemperatureError);

            MotionLED.On = MyFeedback.MotionFlag;
            OverloadLED.On = MyFeedback.OverloadFlag;
            ParameterLED.On = MyFeedback.ParameterFlag;
            SaturationLED.On = MyFeedback.SaturationFlag;
            FatalErrorLED.On = MyFeedback.FatalErrorFlag;
            BackDriveLED.On = MyFeedback.BackdriveFlag;

        }



        private void ElectrakHD_FormClosing(object sender, FormClosingEventArgs e)
        {
            _RequestTermination = true;
        }



        private void ActuatorAddress_ValueChanged(object sender, EventArgs e)
        {
            if(ActuatorAddress.Value == 23)
            {
                ActuatorAddress.Value = 26;
            }
            if (ActuatorAddress.Value == 27)
            {
                ActuatorAddress.Value = 19;
            }
            if (ActuatorAddress.Value == 25)
            {
                ActuatorAddress.Value = 21;
            }
        }

        private void ledBulb1_Click(object sender, EventArgs e)
        {
            ActivityLED.On = true;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void ledBulb2_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void ledBulb3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SendCommandButton_Click(object sender, EventArgs e)
        {
            MyControlMessage.Position = (float)PositionNUD.Value;
            MyControlMessage.CurrentLimit = (float)CurrentLimitNUD.Value;
            MyControlMessage.Speed = (float)SpeedNUD.Value;
            MyControlMessage.MotionEnable = MotionEnableCB.Checked;
            MyControlMessage.CommandSourceAddress = (byte)CommandSourceAddressNUD.Value;
            MyControlMessage.CommandDstAddress = (byte)CommandDestinationAddressNUD.Value;
            MyControlMessage.CommandPriority = (byte)CommandPriorityNUD.Value;

            _OutgoingCANMsgQueue.Enqueue(MyControlMessage.MakeMessage());
        }

        private void ElectrakHD_Load(object sender, EventArgs e)
        {

        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            MyControlMessage.MotionEnable = false;
            MyControlMessage.Speed = 0;

            MyControlMessage.CommandSourceAddress = (byte)CommandSourceAddressNUD.Value;
            MyControlMessage.CommandDstAddress = (byte)CommandDestinationAddressNUD.Value;
            MyControlMessage.CommandPriority = (byte)CommandPriorityNUD.Value;

            _OutgoingCANMsgQueue.Enqueue(MyControlMessage.MakeMessage());
        }
    }


    public class BitOps
    {

        public static bool GetBitFromArray_0Indexed(byte[] DataArray, int Bit) //Bit Starts from 0
        {
            byte Mask;

            byte BitOffset = (byte)(Bit & 0x7);
            int ByteOffset = (byte)(Bit >> 3);
            Mask = (byte)(1 << ((BitOffset)));

            if (ByteOffset < DataArray.Length)
            {
                if ((DataArray[ByteOffset] & Mask) > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        public static uint GetValueFromBitSlice(byte[] DataArray, int Start, int Length)
        {
            uint Value = 0;

            for (int i = 0; i < Length; i++)
            {
                if (GetBitFromArray_0Indexed(DataArray, Start + i) == true)
                {
                    Value = (uint)Value | (uint)(1 << i);
                }
            }

            return Value;
        }

        public static uint GetValueFromBitSlice_1Indexed(byte[] DataArray, int ByteStart, int BitStart, int Length)
        {
            return GetValueFromBitSlice(DataArray, ((ByteStart - 1) * 8) + (BitStart - 1), Length);
        }


    }


    public class ACM
    {
        public const uint ProprietaryA = 0x00EF00;

        public float Position;
        public float CurrentLimit;
        public float Speed;
   
        public uint Raw_Position;
        public uint Raw_CurrentLimit;
        public uint Raw_Speed;
        public bool MotionEnable;

        CAN_t MessageOut;

        public uint Address = 19;

        public byte CommandSourceAddress = 0;
        public byte CommandDstAddress = 0;
        public byte CommandPriority;

        public  ACM()
        {
            MessageOut = new CAN_t();
            MessageOut.Data = new byte[8];
            MessageOut.ID = ProprietaryA;
            MessageOut.RTR = false;
            MessageOut.ID = J1939.MakePDU(0, 0, 0xEF, CommandDstAddress, CommandSourceAddress);


        }

        void UpdateRaw()
        {
            if (Position > 1000.0f)
                Position = 1000.0f;

            Raw_Position = (uint)(Position * 10.0f);

            if (CurrentLimit > 25.0f)
                CurrentLimit = 25.0f;

            Raw_CurrentLimit = (uint)(CurrentLimit * 10);

            if (Speed > 100.0f)
                Speed = 100.0f;

            Raw_Speed = (uint)(Speed / 5.0);
        }

        public CAN_t MakeMessage()
        {

            UpdateRaw();

            for (int i=0;i<8;i++)
            {
                MessageOut.Data[i] = 0;
            }

            MessageOut.Data[0] = (byte)(Raw_Position & 0xFF);
            MessageOut.Data[1] |= (byte)((Raw_Position>>8) & 0x3F);

            MessageOut.Data[1] |= (byte)((Raw_CurrentLimit & 0x3) << 6);

            MessageOut.Data[2] |= (byte)(((Raw_CurrentLimit>>2) & 0x7F));

            MessageOut.Data[2] |= (byte)(((Raw_Speed&0x01) << 7));

            MessageOut.Data[3] |= (byte)( (Raw_Speed>>1)&0xF);

            if (MotionEnable == true)
                MessageOut.Data[3] |= (byte)(1 << 4);

            MessageOut.ID = J1939.MakePDU(CommandPriority, 0, 0xEF, CommandDstAddress, CommandSourceAddress);
            MessageOut.ExtendedID = true;
            return MessageOut;
        }

    }
    public class AFM
    {
        public const uint ProprietaryA2 = 126720;

        public  uint Raw_MeasuredPosition;
        public uint Raw_MeasuredCurrent;
        public uint Raw_RunningSpeed;
        public uint Raw_VoltageError;
        public uint Raw_TemperatureError;
        public uint Raw_MotionFlag;
        public uint Raw_OverloadFlag;
        public uint Raw_BackdriveFlag;
        public uint Raw_ParameterFlag;
        public uint Raw_SaturationFlag;
        public uint Raw_FatalErrorFlag;
        public uint Raw_FactoryUse;


        public float MeasuredPosition;
        public float MeasuredCurrent;
        public float RunningSpeed;
        public  bool MotionFlag;
        public bool OverloadFlag;
        public bool BackdriveFlag;
        public bool ParameterFlag;
        public  bool SaturationFlag;
        public bool FatalErrorFlag;

        public string MakeVoltageErrorString (uint VoltageError)
        {
            if (VoltageError == 0)
                return "Input Voltage within operational range";
            else if (VoltageError == 1)
                return "Input Voltage below operational range";
            else if (VoltageError == 2)
                return "Input Voltage above operational range";
            else
                return "Not Used";
        }


        public string MakeTemperatureErrorString(uint TemperatureError)
        {
            if (TemperatureError == 0)
                return "Temperature within operational range";
            else if (TemperatureError == 1)
                return "Temperature below operational range";
            else if (TemperatureError == 2)
                return "Temperature above operational range";
            else
                return "Not Used";
        }
        public void ProcessProprietaryA2(byte[] MessageIn)
        {

            if (MessageIn.Length != 8)
            {
                return;
            }
            /*
            Actuator Feedback Message Signal Information
            Start position Length Parameter name
            1.1 14 bits Measured position
            2.7 9 bits Measured current
            3.8 5 bits Running speed
            4.5 2 bits Voltage error
            4.7 2 bits Temperature error
            5.1 1 bit Motion flag
            5.2 1 bit Overload flag
            5.3 1 bit Backdrive flag
            5.4 1 bit Parameter flag
            5.5 1 bit Saturation flag
            5.6 1 bit Fatal error flag
            5.7 18 bits Factory use
            */
            //The least significant bit of each message is indicated by the start position
            Raw_MeasuredPosition = BitOps.GetValueFromBitSlice_1Indexed(MessageIn, 1, 1, 14);
            Raw_MeasuredCurrent = BitOps.GetValueFromBitSlice_1Indexed(MessageIn, 2, 7, 9);
            Raw_RunningSpeed = BitOps.GetValueFromBitSlice_1Indexed(MessageIn, 3, 8, 5);
            Raw_VoltageError = BitOps.GetValueFromBitSlice_1Indexed(MessageIn, 4, 5, 2);
            Raw_TemperatureError = BitOps.GetValueFromBitSlice_1Indexed(MessageIn, 4, 7, 2);

            Raw_MotionFlag = BitOps.GetValueFromBitSlice_1Indexed(MessageIn, 5, 1, 1);
            Raw_OverloadFlag = BitOps.GetValueFromBitSlice_1Indexed(MessageIn, 5, 2, 1);
            Raw_BackdriveFlag = BitOps.GetValueFromBitSlice_1Indexed(MessageIn, 5, 3, 1);
            Raw_ParameterFlag = BitOps.GetValueFromBitSlice_1Indexed(MessageIn, 5, 4, 1);
            Raw_SaturationFlag = BitOps.GetValueFromBitSlice_1Indexed(MessageIn, 5, 5, 1);
            Raw_FatalErrorFlag = BitOps.GetValueFromBitSlice_1Indexed(MessageIn, 5, 6, 1);
            Raw_FactoryUse = BitOps.GetValueFromBitSlice_1Indexed(MessageIn, 5, 7, 18);



            MeasuredPosition = Raw_MeasuredPosition * .1f;
            MeasuredCurrent = Raw_MeasuredCurrent * .1f;
            RunningSpeed = Raw_RunningSpeed * 5.0f;
       
            MotionFlag = Raw_MotionFlag > 0;
            OverloadFlag = Raw_OverloadFlag > 0;
            BackdriveFlag = Raw_BackdriveFlag > 0;
            ParameterFlag = Raw_ParameterFlag > 0;
            SaturationFlag = Raw_SaturationFlag > 0;
            FatalErrorFlag = Raw_FatalErrorFlag > 0;


        }
    }
}
