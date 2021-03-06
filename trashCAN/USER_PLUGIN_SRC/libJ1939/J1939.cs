﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ItrashCAN;

namespace J1939_Routines
{
    public class J1939
    {

        public static class PGN
        {
            public  const uint ADDRESS_CLAIMED = 60928;
            public const uint REQUEST_PGN = 59904;
            public const uint TP_CM =60416;
            public const uint TP_DT = 60160;
        }
        

        public static String GetJ1939_String(CAN_t C)
        {
            string S;

            S= "<PRI:"+ GetPriority_FromPDU(C.ID) + "> " ;

            S += "<PGN:" + GetPGN_FromPDU(C.ID).ToString("D6") + "> <Source Address: " + GetSourceAddress_FromPDU(C.ID).ToString("D2") + "> " + "<Destination Address: " + GetDestinationAddress_FromPDU(C.ID).ToString("D2") + "> ";

            for (int i = 0; i < C.Data.Length;i++ )
            {
                S += "0x" +  C.Data[i].ToString("X2") + " ";
            }

            if(GetPGN_FromPDU(C.ID) == PGN.TP_CM)
            {
                uint P = GetPGN_From_TP_CM(C);
               
                switch(C.Data[0])
                {
                    case 16:
                         S += "[TP.CM_RTS for PGN " + P.ToString() + "]";
                        break;
                    case 17:
                         S += "[TP.CM_CTS for PGN " + P.ToString() + "]";
                        break;

                    case 19:
                        S += "[TP.EndOfMsgACK for PGN " + P.ToString() + "]";
                        break;

                    case 255:
                         S += "[TP.Conn_Abort for PGN " + P.ToString() + "]";
                        break;

                    case 32:
                        int Size = (C.Data[1] + (C.Data[2] << 8));
                         S += "[TP.CM_BAM " + Size  + " bytes " + C.Data[3] + " Packets for PGN:" + P.ToString() + "]";
                        break;

                }
            }
            else if (GetPGN_FromPDU(C.ID) == PGN.TP_DT)
            {

                S += "[TP.DT Seq:" +C.Data[0] +"]";

            }
            

            return S;
        }

        public static uint GetPGN_From_TP_CM(CAN_t C)
        {
            return (C.Data[5]) + ((uint)C.Data[6] << 8) + ((uint)C.Data[7] << 16);
        }

        public static uint GetPGN_FromPDU(uint PDU)
        {
            uint PGN = 0;

            if (GetPDU_Format_FromPDU(PDU) < 240)
            {
                PGN = (GetDataPage_FromPDU(PDU) << 16) + (GetPDU_Format_FromPDU(PDU) << 8);
            }
            else
            {
                PGN = (GetDataPage_FromPDU(PDU) << 16) + (GetPDU_Format_FromPDU(PDU) << 8) + GetPDU_Specific_FromPDU(PDU);
            }
            return PGN;

        }

        //Get the desintation Address
        public static uint GetDestinationAddress_FromPDU(uint PDU)
        {
            uint DA = 0;

            if (GetPDU_Format_FromPDU(PDU) < 240)
            {
                DA = GetPDU_Specific_FromPDU(PDU);
            }
            else
            {
                DA = 0xFF;
            }
            return DA;
        }

        //Get the Source Address Address
        public static uint GetSourceAddress_FromPDU(uint PDU)
        {
            return (PDU & 0xFF);
        }

        public static uint GetPDU_Specific_FromPDU(uint PDU)
        {
            return ((PDU >> 8) & 0xFF);

        }

        public static uint GetPDU_Format_FromPDU(uint PDU)
        {
            return ((PDU >> 16) & 0xFF);

        }

        public static uint GetDataPage_FromPDU(uint PDU)
        {
            return ((PDU >> 24) & 0x1);
        }

        public static uint GetExtendedDataPage_FromPDU(uint PDU)
        {
            return ((PDU >> 25) & 0x1);
        }

        public static uint GetPriority_FromPDU(uint PDU)
        {
            return ((PDU >> 26) & 0x7);
        }

        public static uint MakePDU(byte Priority, byte DataPage, byte PDU_Format, byte PDU_Specific,byte SourceAddress)
        {
            return (uint)  (((Priority & 0x7) << 26)   |
                           ((DataPage & 0x1) << 25)    |
                           ((PDU_Format) << 16)        |
                           ((PDU_Specific) << 8)       |    
                           (SourceAddress));
        }

        public static CAN_t MakeAddressClaimedMessage(byte Address)
        {
            CAN_t Msg = new CAN_t();


            //See Page 22 of J1939-81 JUN2011
            Msg.ExtendedID = true;
            Msg.ID = MakePDU(6, 0, 238 , 255, Address); //Priority of is from the J1939 spec (Page 22 of J1939-81)

            //For now we are making the name bits all set to zero

            for (int i = 0; i < 8; i++ )
            {
                Msg.Data[i] = 0;
            }
                return Msg;
        }

        //See Page 19 of 49 of J1939-21 REV DEC2010
        public static CAN_t MakePGN_RequestMessage(byte DestAddress,byte SourceAddress, uint PGN)
        {
            CAN_t Msg = new CAN_t();
            
            //See Page 22 of J1939-81 JUN2011
            Msg.ExtendedID = true;
            Msg.ID = MakePDU(6, 0, 234, DestAddress, SourceAddress);

            Msg.Data = new byte[3];

            Msg.Data[0] = (byte)(PGN & 0xFF);
            Msg.Data[1] = (byte)(PGN>>8 & 0xFF);
            Msg.Data[2] = (byte)(PGN>>16 & 0x7);

            //For now we are making the name bits all set to zero
            return Msg;
        }

        //See Page 22 of 49 of J1939-21 REV DEC2010
        public static CAN_t MakePGN_RequestNACK(byte SourceAddress, byte PGN_RequestorAddress, uint PGN)
        {
            CAN_t Msg = new CAN_t();

            //See Page 22 of J1939-81 JUN2011
            Msg.ExtendedID = true;
            Msg.ID = MakePDU(6, 0, 232, 255, SourceAddress);

            Msg.Data[0] = 1; //Figure nine in J1939-21 states that a 1 means a NACK
            Msg.Data[1] = 0; //COntrol Group is N/A
            Msg.Data[2] = 0xFF; //reserved, should be an 0xFF
            Msg.Data[3] = 0xFF; //reserved, should be an 0xFF
            Msg.Data[4] = PGN_RequestorAddress; //Since the response is the global address, this has the requestors address.

            Msg.Data[5] = (byte)(PGN & 0xFF);
            Msg.Data[6] = (byte)(PGN >> 8 & 0xFF);
            Msg.Data[7] = (byte)(PGN >> 16 & 0x7);

            return Msg;
        }


     }
}
