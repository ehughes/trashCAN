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
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace CANMessageInjector
{

    public partial class CANMessageInjector : Form, ItrashCANPlugin
    {

        CANMessageInjectorState InjectorState = new CANMessageInjectorState();
        Point MyLocation;
        Size MySize;
        int msgLockedCount;
        int msgOutCount;

        public CANMessageInjector()
        {
            InitializeComponent();
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
            get { return CAN_INTERFACE_TYPE.WRITE_ONLY; }
        }

        public String PluginName
        {
            //get { return "CAN Message Injector"; }
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Name.ToString();
            }
        }

        public String PluginVersion
        {
            //get { return "1.0"; }
            get
            {
                Version ver = Assembly.GetExecutingAssembly().GetName().Version;
                return ver.Major + "." + ver.Minor + "." + ver.Build;
            }

        }

        public Image PluginImage
        {
            get { return Properties.Resources.injector; }
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
            _OutgoingPluginMessage.Enqueue("CAN Message Injector Initialized....");

            return "OK";
        }

        PluginState _State = new PluginState();



        public PluginState State
        {
            get
            {
                SaveInjectorState();

                _State.WindowLocation = MyLocation;
                _State.WindowSize = MySize;
                _State.WindowState = this.WindowState;


                //_State.WindowLocation = this.Location;
                //_State.WindowSize = this.Size;
                //_State.WindowState = this.WindowState;

                SaveInjectorState();

                XmlSerializer xmlSerializer = new XmlSerializer(InjectorState.GetType());
                StringWriter textWriter = new StringWriter();
                xmlSerializer.Serialize(textWriter, InjectorState);
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

                    XmlSerializer xmlSerializer = new XmlSerializer(InjectorState.GetType());
                    StringReader textReader = new StringReader(_State.PluginData);
                    InjectorState = (CANMessageInjectorState)xmlSerializer.Deserialize(textReader);

                    RestoreInjectorState();

                    //  if (_State.PluginData != null && _State.PluginData.GetType() == typeof(CANMessageInjectorState))
                    // {
                    //     InjectorState = (CANMessageInjectorState)(_State.PluginData);
                    //     RestoreInjectorState();
                    // }
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
        }

        public void HidePlugin()
        {
            this.Hide();
        }

        Queue<CAN_t> _IncomingCANMsgQueue = new Queue<CAN_t>(128);
        Queue<CAN_t> _OutgoingCANMsgQueue = new Queue<CAN_t>(128);

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

        private void CANMessageInjector_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            _RequestTermination = true;
        }

        CAN_t ValidateInput()
        {
            CAN_t UserEnteredCANMessage = new CAN_t();
            String StringToCheck = CANMessageTextBox.Text;
            String RegexString = @"(\s*0x\w+\s*)";

            MatchCollection MyMatches = Regex.Matches(StringToCheck, RegexString);

            Match[] EMatch = new Match[MyMatches.Count];

            MyMatches.CopyTo(EMatch, 0);
            String Cleanup = "";
            UInt32[] MessageElements = new UInt32[MyMatches.Count];

            for (int i = 0; i < EMatch.Length; i++)
            {
                string[] splits = EMatch[i].Value.Split('x');

                try
                {
                    MessageElements[i] = UInt32.Parse(splits[1], System.Globalization.NumberStyles.HexNumber);

                }
                catch
                {
                    MessageElements[i] = 0;
                }
            }

            if (ExtIDCheckBox.Checked == true)
                UserEnteredCANMessage.ExtendedID = true;
            else
                UserEnteredCANMessage.ExtendedID = false;

            if (RTRCheckBox.Checked == true)
                UserEnteredCANMessage.RTR = true;
            else
                UserEnteredCANMessage.RTR = false;

            switch (MessageElements.Length)
            {
                case 0:
                    UserEnteredCANMessage.ID = 0;
                    if (RTRCheckBox.Checked == true)
                        UserEnteredCANMessage.Data = new byte[0];
                    else
                        UserEnteredCANMessage.Data = new byte[8];
                    break;

                case 1:
                    UserEnteredCANMessage.ID = MessageElements[0];
                    UserEnteredCANMessage.Data = new byte[0];
                    break;

                default:
                    int MsgLength = MessageElements.Length - 1;
                    UserEnteredCANMessage.ID = MessageElements[0];


                    if (RTRCheckBox.Checked == true)
                    {
                        UserEnteredCANMessage.Data = new byte[0];
                    }
                    else
                    {
                        if (MsgLength > 8)
                            MsgLength = 8;

                        UserEnteredCANMessage.Data = new byte[MsgLength];

                        for (int i = 0; i < MsgLength; i++)
                            UserEnteredCANMessage.Data[i] = (byte)MessageElements[i + 1];
                    }
                    break;
            }

            if (UserEnteredCANMessage.ExtendedID == true)
            {
                if (UserEnteredCANMessage.ID >= (uint)(Math.Pow(2, 29)))
                    UserEnteredCANMessage.ID = (uint)(Math.Pow(2, 29) - 1);

                Cleanup = "0x" + UserEnteredCANMessage.ID.ToString("X8") + " : ";
            }
            else
            {
                if (UserEnteredCANMessage.ID >= (uint)(Math.Pow(2, 11)))
                    UserEnteredCANMessage.ID = (uint)(Math.Pow(2, 11) - 1);

                Cleanup = "0x" + UserEnteredCANMessage.ID.ToString("X3") + " : ";
            }

            for (int i = 0; i < UserEnteredCANMessage.Data.Length; i++)
            {
                Cleanup += "0x" + UserEnteredCANMessage.Data[i].ToString("X2") + " ";

            }

            CANMessageTextBox.Text = Cleanup;
            return UserEnteredCANMessage;
        }

        void Transmit()
        {
            bool isUnlocked;

            ValidateInput();
            //_OutgoingCANMsgQueue.Enqueue(ValidateInput());

            isUnlocked = System.Threading.Monitor.TryEnter(_OutgoingCANMsgQueue, 10);
            if (isUnlocked == true)
            {
                try
                {
                    _OutgoingCANMsgQueue.Enqueue(ValidateInput());
                    msgOutCount++;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
                finally
                {
                    System.Threading.Monitor.Exit(_OutgoingCANMsgQueue);
                }
            }
            else
            {
                msgLockedCount++;
            }


        }

        // This method intercepts the Enter Key
        // signal before the containing Form does
        protected override bool ProcessCmdKey(ref 
                                  System.Windows.Forms.Message m,
                  System.Windows.Forms.Keys k)
        {
            // detect the pushing (Msg) of Enter Key (k)
            if (m.Msg == 256 && k ==
                   System.Windows.Forms.Keys.Tab)
            {
                // Execute an alternative action: here we
                // tabulate in order to focus
                // on the next control in the formular
                ValidateInput();
                // return true to stop any further
                // interpretation of this key action
                return true;
            }

            if (m.Msg == 256 && k ==
                  System.Windows.Forms.Keys.Enter)
            {
                // Execute an alternative action: here we
                // tabulate in order to focus
                // on the next control in the formular
                Transmit();
                // return true to stop any further
                // interpretation of this key action

            }

            // if not pushing Enter Key,
            // then process the signal as usual
            return base.ProcessCmdKey(ref m, k);
        }


        private void ClearStatistics()
        {
            msgLockedCount = 0;
            msgOutCount = 0;
        }

        private void QueueClearTimer_Tick(object sender, EventArgs e)
        {
            bool isUnlocked;

            //_IncomingCANMsgQueue.Clear();
            //_IncomingPluginMessage.Clear();

            isUnlocked = System.Threading.Monitor.TryEnter(_IncomingCANMsgQueue, 10);
            if (isUnlocked == true)
            {
                try
                {
                    _IncomingCANMsgQueue.Clear();
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
            else
            {
                msgLockedCount++;
            }

            isUnlocked = System.Threading.Monitor.TryEnter(_IncomingPluginMessage, 10);
            if (isUnlocked == true)
            {
                try
                {
                    _IncomingPluginMessage.Clear();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
                finally
                {
                    System.Threading.Monitor.Exit(_IncomingPluginMessage);
                }
            }
            else
            {
                msgLockedCount++;
            }


            statusLabelOut.Text = "OUT:  " + msgOutCount.ToString("#,0");
            statusLabelLocked.Text = "LOCK:  " + msgLockedCount.ToString("#,0");

        }


        private void CANMessageTextBox_MouseEnter(object sender, EventArgs e)
        {
        }

        private void CANMessageTextBox_MouseHover(object sender, EventArgs e)
        {
            MessageGeneratorToolTip.Show("Press TAB to validate/auto-complete and ENTER to send message.",
                                          this.CANMessageTextBox,
                                          this.CANMessageTextBox.Location.X,
                                          this.CANMessageTextBox.Location.Y + this.CANMessageTextBox.Height, 4000);

        }

        private void CANMessageTextBox_MouseLeave(object sender, EventArgs e)
        {
            MessageGeneratorToolTip.Hide(this.CANMessageTextBox);
        }

        private void CANMessageInjector_Load(object sender, EventArgs e)
        {

        }

        //Save the state of the controls, etc into our state object
        void SaveInjectorState()
        {
            InjectorState.RTR_Checked = RTRCheckBox.Checked;
            InjectorState.Extended_IDChecked = ExtIDCheckBox.Checked;
            InjectorState.CANMessageTextBox = this.CANMessageTextBox.Text;

        }

        //Restore state of the controls, etc into our state object
        void RestoreInjectorState()
        {
            RTRCheckBox.Checked = InjectorState.RTR_Checked;
            ExtIDCheckBox.Checked = InjectorState.Extended_IDChecked;
            this.CANMessageTextBox.Text = InjectorState.CANMessageTextBox;
        }

        private void AutoSendCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoSendCheckBox.Checked == true)
            {
                AutoSendTimer.Interval = (int)RepeatRateUD.Value;
                AutoSendTimer.Enabled = true;
            }
            else
            {
                AutoSendTimer.Enabled = false;
            }
        }

        private void RepeatRateUD_ValueChanged(object sender, EventArgs e)
        {
            AutoSendTimer.Interval = (int)RepeatRateUD.Value;
        }

        UInt32 LastID = 0;
        byte LastByte = 0;

        private void AutoSendTimer_Tick(object sender, EventArgs e)
        {
            if (FillDataCB.Checked == true)
            {
                CAN_t NextMsg = new CAN_t();
                NextMsg.Data = new byte[8];

                LastID++;

                if (ExtIDCheckBox.Checked == true)
                {
                    NextMsg.ExtendedID = true;

                    LastID &= 0x3FFFFFFF;
                }
                else
                {
                    NextMsg.ExtendedID = false;
                    LastID &= 0x7FF;
                }

                NextMsg.ID = LastID++;

                for (int i = 0; i < 8; i++)
                {
                    NextMsg.Data[i] = LastByte++;
                }

                CANMessageTextBox.Text = NextMsg.ToString();
            }
            Transmit();
        }

        private void CANMessageInjector_LocationChanged(object sender, EventArgs e)
        {
            if ((this.Location.X >= 0) && (this.Location.Y >= 0))
            {
                MyLocation = this.Location;
            }
        }

        private void CANMessageInjector_Resize(object sender, EventArgs e)
        {
            if (this.Size.Width >= this.MinimumSize.Width && this.Size.Height >= this.MinimumSize.Height)
            {
                MySize = this.Size;
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearStatistics();
        }

        private void CANMessageTextBox_TextChanged(object sender, EventArgs e)
        {

        }



    }

    [Serializable()]
    public class CANMessageInjectorState
    {
        public bool Extended_IDChecked;
        public bool RTR_Checked;
        public string CANMessageTextBox;
    }



}
