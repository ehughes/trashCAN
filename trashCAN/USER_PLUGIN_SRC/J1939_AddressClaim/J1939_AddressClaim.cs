﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ItrashCAN;
using J1939_Routines;
using System.Threading;

namespace J1939_AddressClaim
{
    public partial class J1939_AddressClaim : Form , ItrashCANPlugin
    {

        const string _PluginNameString = "J1939 Address Claim";

        const int MsgDisplayHistory = 64;
        Queue <String> MsgDisplayQueue = new Queue<string>();

        int MyAddress = 0;
        UInt32 J1939_ProcessTick = 0;

        byte[] J1939_Address_Map = new byte[256/8];


       void J1939_AddressMap_Populate(byte Address)
        {

            int Idx = Address / 8;
            int Bit = Address % 8;

            J1939_Address_Map[Idx] |= (byte)(1 << Bit);
        }

       void J1939_AddressMap_Depopulate(byte Address)
       {

           int Idx = Address / 8;
           int Bit = Address % 8;

           J1939_Address_Map[Idx] &= (byte)(~(1 << Bit));
       }

       bool J1939_AddressMap_Query(byte Address)
       {

           int Idx = Address / 8;
           int Bit = Address % 8;
           bool Result = false;

           if ((J1939_Address_Map[Idx] & (1 << Bit)) > 0)
               Result = true;

           return Result;
       }

        void J1939_AddressMap_Clear()
       {
           for (int i = 0; i < 256/8; i++)
           {
               J1939_Address_Map[i] = 0;

           }
       }

        void PostMessage(string S)
        {
            while(MsgDisplayQueue.Count>=MsgDisplayHistory)
            {
                string t = MsgDisplayQueue.Dequeue();
            }

            MsgDisplayQueue.Enqueue(S);

            string[] Lines = (string[])MsgDisplayQueue.ToArray();

            for(int i=0; i<Lines.Length;i++)
            {
                StatusMessageTextBox.Text = Lines[i] + "\r\n" + StatusMessageTextBox.Text;
            }

        }


        enum J1939_State
        {
            ADDRESS_NOT_CLAIMED = 0,
            ADDRESS_REQUEST = 1,
            ADDRESS_WAITING_FOR_RESPONSE = 2,
            ADDRESS_LAST_REQUEST_DENIED = 3,
            ADDRESS_CLAIMED = 4,
            ADDRESS_ATTEMPT_CLAIM = 5,
            ADDRESS_WAIT_FOR_CONTENTION = 6,
            ADDRESS_RELEASE_CLAIM = 7,
            ADDRESS_AUTOCLAIM_START = 8,
            ADDRESS_AUTOCLAIM_WAIT_FOR_GLOBAL_MAP_UPDATE = 9,
      
        }

        J1939_State MyJ1939_State = J1939_State.ADDRESS_NOT_CLAIMED;

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
            get { return global::J1939_AddressClaim.Properties.Resources.claim; }
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

        
        public J1939_AddressClaim()
        {
            InitializeComponent();
            J1939_ChangeState(J1939_State.ADDRESS_NOT_CLAIMED);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = PluginName + " v" + PluginVersion;
        }

        private void MsgCheckTimer_Tick(object sender, EventArgs e)
        {
            if (_IncomingCANMsgQueue != null)
            {
                lock (_IncomingCANMsgQueue)
                {
                      while (_IncomingCANMsgQueue.Count > 0)
                      {
                          J1939_MessageParser(_IncomingCANMsgQueue.Dequeue());
                      }
                }
            }
        }

        int AddrTick = 0;
        private void FormUpdateTimer_Tick(object sender, EventArgs e)
        {
            switch (MyJ1939_State)
            {
                default:
                    AddressClaimButton.Text = "Claim Address";
                    AutoClaimButton.Enabled = true;
                    break;

                case J1939_State.ADDRESS_NOT_CLAIMED:
                    AddressClaimButton.Text = "Claim Address";

                    break;
                case J1939_State.ADDRESS_REQUEST:
                    AddressClaimButton.Text = "Requesting...";
                    break;
                case J1939_State.ADDRESS_WAITING_FOR_RESPONSE:
                    AddressClaimButton.Text = "Requesting...";
                    break;

                case J1939_State.ADDRESS_ATTEMPT_CLAIM:
                    AddressClaimButton.Text = "Requesting...";
                    break;

                case J1939_State.ADDRESS_WAIT_FOR_CONTENTION:
                    AddressClaimButton.Text = "Requesting...";
                    break;
        
                case J1939_State.ADDRESS_LAST_REQUEST_DENIED:
                    AddressClaimButton.Text = "Claim Address";
                    break;
                case J1939_State.ADDRESS_CLAIMED:
                    AddressClaimButton.Text = "Release Claim";
                    break;
            }

            if(MyJ1939_State == J1939_State.ADDRESS_NOT_CLAIMED)
            {
                AutoClaimButton.Enabled = true;
            }
            else
            {
                AutoClaimButton.Enabled = false;
            }

            if (++AddrTick > 5)
            {
                AddrTick = 0;
                RenderAddressMapView();
            }
        }


        void J1939_ChangeState(J1939_State NextState)
        {

            switch (NextState)
            {
                default:
                    MyJ1939_State = J1939_State.ADDRESS_NOT_CLAIMED;
                        MyAddress = -1;
                    break;

                case J1939_State.ADDRESS_NOT_CLAIMED:
                       MyAddress = -1;
                    PostMessage("Moving to State ADDRESS_NOT_CLAIMED");
                    MyJ1939_State = J1939_State.ADDRESS_NOT_CLAIMED;
                    break;
                case J1939_State.ADDRESS_REQUEST:
                      MyAddress = -1;
                    MyJ1939_State = J1939_State.ADDRESS_REQUEST;
                    PostMessage("Requesting Address Claim on " + AddressToClaim.Value);
                    break;
                case J1939_State.ADDRESS_WAITING_FOR_RESPONSE:
                    J1939_ProcessTick = 0;
                    MyJ1939_State = J1939_State.ADDRESS_WAITING_FOR_RESPONSE;
                    PostMessage("Waiting for reponse....");
                    break;

                case J1939_State.ADDRESS_WAIT_FOR_CONTENTION:
                    J1939_ProcessTick = 0;
                    MyJ1939_State = J1939_State.ADDRESS_WAIT_FOR_CONTENTION;
                    PostMessage("Waiting for contention....");
                    break;

                case J1939_State.ADDRESS_LAST_REQUEST_DENIED:
                    MyJ1939_State = J1939_State.ADDRESS_LAST_REQUEST_DENIED;
                    PostMessage("Last request for " + AddressToClaim.Value.ToString() + " denied");
                    break;

                case J1939_State.ADDRESS_ATTEMPT_CLAIM:
                    MyJ1939_State = J1939_State.ADDRESS_ATTEMPT_CLAIM;
                    PostMessage("Attempting to claim " + AddressToClaim.Value.ToString());
                    break;
             
                case J1939_State.ADDRESS_CLAIMED:
                    MyJ1939_State = J1939_State.ADDRESS_CLAIMED;
                    PostMessage("Address " + MyAddress + " claimed!");
                    break;

                case J1939_State.ADDRESS_RELEASE_CLAIM:
                    MyJ1939_State = J1939_State.ADDRESS_RELEASE_CLAIM;
                    PostMessage("Address " + MyAddress + " has been release");
                    break;


                case J1939_State.ADDRESS_AUTOCLAIM_START:
                    MyJ1939_State = J1939_State.ADDRESS_AUTOCLAIM_START;
                    PostMessage("Starting address auto claim process.  Requesting global map...");
                    break;

                case J1939_State.ADDRESS_AUTOCLAIM_WAIT_FOR_GLOBAL_MAP_UPDATE:
                    J1939_ProcessTick = 0;
                    MyJ1939_State = J1939_State.ADDRESS_AUTOCLAIM_WAIT_FOR_GLOBAL_MAP_UPDATE;
                    PostMessage("Waiting for global map completetion");
                    break;
            }

        }


        void J1939_Process()
        {
        switch(MyJ1939_State)
            {
                default:
                break;

                 case   J1939_State.ADDRESS_NOT_CLAIMED:
                 
                    break;
                
                case   J1939_State.ADDRESS_REQUEST:
            
                    //if we are here then we need to send out a message requesting to request an address
                    MyAddress = -1;
                   _OutgoingCANMsgQueue.Enqueue(J1939.MakePGN_RequestMessage((byte)AddressToClaim.Value, 254, J1939.PGN.ADDRESS_CLAIMED));

                    //Next wait for a response for up to a second to see if someone else has the address.
                    J1939_ChangeState(J1939_State.ADDRESS_WAITING_FOR_RESPONSE);
                   
                    break;

                 case   J1939_State.ADDRESS_WAITING_FOR_RESPONSE:

                    if (J1939_ProcessTick >= 125)
                    {
                        
                        //the J1939 Spec says we only have to wait 250mSec before we attemp a claim (no one else responds)
                        J1939_ChangeState(J1939_State.ADDRESS_ATTEMPT_CLAIM); 
                    }

                    break;

                  case J1939_State.ADDRESS_ATTEMPT_CLAIM:

                    _OutgoingCANMsgQueue.Enqueue( J1939.MakeAddressClaimedMessage((byte)AddressToClaim.Value) );

                    J1939_ChangeState(J1939_State.ADDRESS_WAIT_FOR_CONTENTION); 

                 break;

                  case J1939_State.ADDRESS_WAIT_FOR_CONTENTION:

                 if (J1939_ProcessTick >= 25)
                 {

                     //the J1939 Spec says we only have to wait 250mSec before we can have the address!
                     
                     MyAddress = (int)AddressToClaim.Value;
                     J1939_AddressMap_Populate((byte)MyAddress);
                     J1939_ChangeState(J1939_State.ADDRESS_CLAIMED);
                 }

                 break;

                 case   J1939_State.ADDRESS_LAST_REQUEST_DENIED:
                 break;

                 case   J1939_State.ADDRESS_CLAIMED:
                break;


            case J1939_State.ADDRESS_RELEASE_CLAIM:

                J1939_AddressMap_Depopulate((byte)MyAddress);
                MyAddress = -1;
                J1939_ChangeState(J1939_State.ADDRESS_NOT_CLAIMED);
                break;
           
            case J1939_State.ADDRESS_AUTOCLAIM_START:

                GlobalAddressRequest();
                J1939_ChangeState(J1939_State.ADDRESS_AUTOCLAIM_WAIT_FOR_GLOBAL_MAP_UPDATE);

                break;

            case J1939_State.ADDRESS_AUTOCLAIM_WAIT_FOR_GLOBAL_MAP_UPDATE:

                if(J1939_ProcessTick>125)
                {
                    //At this point we should have an updated map.   Start a search from the prefered start address

                    byte StartAddress = (byte) AddressToClaim.Value;

                    while(StartAddress<254)
                    {
                        if(J1939_AddressMap_Query(StartAddress) == true)
                        {
                            StartAddress++;

                        }
                        else
                        {
                            //We foun the start address to request a claim to!
                            break;
                        }
                    }

                    if(StartAddress >= 254)
                    {
                        PostMessage("No addresses found!");
                        J1939_ChangeState(J1939_State.ADDRESS_NOT_CLAIMED);
                    }
                    else
                    {
                        AddressToClaim.Value = StartAddress;
                        //Move through the claim process
                        J1939_ChangeState(J1939_State.ADDRESS_REQUEST);
                    }
                }

                break;

            }
        }

        void J1939_MessageParser(CAN_t NextMsg)
        {


            if(MyAddress == (int)J1939.GetDestinationAddress_FromPDU(NextMsg.ID) ||
                     255 == J1939.GetDestinationAddress_FromPDU(NextMsg.ID))
            {
                switch(J1939.GetPGN_FromPDU(NextMsg.ID))
                {
                    case J1939.PGN.ADDRESS_CLAIMED:


                        if (J1939.GetSourceAddress_FromPDU(NextMsg.ID) < 254)
                        {
                            PostMessage("Address  " + J1939.GetSourceAddress_FromPDU(NextMsg.ID) + " is reported as Claimed");
                            J1939_AddressMap_Populate((byte)J1939.GetSourceAddress_FromPDU(NextMsg.ID));
                        }

                        if (MyJ1939_State == J1939_State.ADDRESS_WAITING_FOR_RESPONSE || MyJ1939_State == J1939_State.ADDRESS_WAIT_FOR_CONTENTION)
                        {
                            if (J1939.GetSourceAddress_FromPDU(NextMsg.ID) == AddressToClaim.Value)
                            {
                                PostMessage("Someone responded that " + AddressToClaim.Value.ToString() + " is taken");
                                   //If we are here then we recieved an Address Claimed message from someone else and we cannot use it
                                J1939_ChangeState(J1939_State.ADDRESS_LAST_REQUEST_DENIED); 
                                  //Add a psuedo random delay
                                Thread.Sleep(new Random().Next(50));
                                CAN_t M =  J1939.MakeAddressClaimedMessage(254);

                                M.Data = NextMsg.Data;
                                _OutgoingCANMsgQueue.Enqueue(M);

                            }
                        }
                        else if (MyJ1939_State == J1939_State.ADDRESS_CLAIMED)
                        {
                            //Since the same PGNB is used to request and deny an address claim, we will check to see if the request is for us

                            if (J1939.GetSourceAddress_FromPDU(NextMsg.ID) == MyAddress)
                            {
                                //Table 2 in J1939-81 says I have to send back a 254 as a Source address to indicate the 

                                PostMessage("Someone wants my address...  No soup for you!");
                             
                                _OutgoingCANMsgQueue.Enqueue(J1939.MakeAddressClaimedMessage((byte)MyAddress));
                            }

                        }

                        break;

                    case J1939.PGN.REQUEST_PGN:

                        uint RequestedPGN = (uint)(NextMsg.Data[0]) + (uint)(NextMsg.Data[1] * 256) + (uint)(NextMsg.Data[2] * 65536);

                        if(MyJ1939_State == J1939_State.ADDRESS_CLAIMED)
                        {
                            switch(RequestedPGN)
                            {
                                case J1939.PGN.ADDRESS_CLAIMED:

                                    PostMessage("I recieved a request for an address Claimed PGN");
                                    _OutgoingCANMsgQueue.Enqueue( J1939.MakeAddressClaimedMessage((byte)(MyAddress)));
                                 
                                    break;

                                default:

                                    PostMessage("I recieved a request for PGN " + RequestedPGN + ".  Sending a NACK as I don't support it!");
                                    _OutgoingCANMsgQueue.Enqueue(J1939.MakePGN_RequestNACK((byte)MyAddress, (byte)J1939.GetSourceAddress_FromPDU(NextMsg.ID), RequestedPGN));

                                    break;
                            }
                        }

                        break;
                }
            }

        }

        private void J1939_ProcessTImer_Tick(object sender, EventArgs e)
        {
            J1939_ProcessTick++;
            J1939_Process();
            
        }

        private void AddressClaimButton_Click(object sender, EventArgs e)
        {
            if(MyJ1939_State == J1939_State.ADDRESS_LAST_REQUEST_DENIED || MyJ1939_State == J1939_State.ADDRESS_NOT_CLAIMED)
            {
                J1939_ChangeState(J1939_State.ADDRESS_REQUEST);

            }
            else if(MyJ1939_State == J1939_State.ADDRESS_CLAIMED)
            {
                J1939_ChangeState(J1939_State.ADDRESS_RELEASE_CLAIM);

            }
        }

        private void J1939_AddressClaim_FormClosing(object sender, FormClosingEventArgs e)
        {
            _RequestTermination = true;
        }

        private void GlobalAddressRequestButton_Click(object sender, EventArgs e)
        {
            GlobalAddressRequest();
        
        }

        void GlobalAddressRequest()
        {
            J1939_AddressMap_Clear();
            _OutgoingCANMsgQueue.Enqueue(J1939.MakePGN_RequestMessage(255, 254, J1939.PGN.ADDRESS_CLAIMED));
            //We can autopopulate ours
            if (MyJ1939_State == J1939_State.ADDRESS_CLAIMED && MyAddress != -1)
            {
                J1939_AddressMap_Populate((byte)MyAddress);

            }
        }

        void RenderAddressMapView()
        {
            string T = "";

            for(int i=0;i<16;i++)
            {
                for(int j=0;j<16;j++)
                {
                    int n = i * 16 + j;
                    if(J1939_AddressMap_Query((byte)n) == true)
                    {
                        if(n == MyAddress)
                        {
                            T+= "*" + MyAddress.ToString("D3") + "*";
                        }
                        else
                        {
                            T+= "[" + n.ToString("D3") + "]";
                        }

                   
                    }
                    else
                    {
                        T += "[---]";
                    }

                    T += " ";
                }

                if (i != 15)
                    T += "\r\n";
            }

            AddressMapVIew.Text = T;
        }

        private void AutoClaimButton_Click(object sender, EventArgs e)
        {
            if(MyJ1939_State == J1939_State.ADDRESS_NOT_CLAIMED)
            {
                J1939_ChangeState(J1939_State.ADDRESS_AUTOCLAIM_START);
            }
        }

    }
}
