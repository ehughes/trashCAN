using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ItrashCAN
{

    #region CAN Node Interface
    /// <summary>
    /// All trashCAN plugins must inherit this interface.  
    /// </summary>
    public interface ItrashCANPlugin : IPlugin
    {
        /// <summary>
      /// The plugin will push CAN messages into this queue.  The trashCAN router will pull messages
      /// out and push to the other plugins.  The trashCAN router will use this queue if the PluginInterfaceType
      /// is set to READ_WRITE or WRITE_ONLY
      /// </summary>
        Queue<CAN_t> OutgoingCANMsgQueue
        {
            get;
        }
        /// <summary>
        /// The will recieve CAN messages in this queue.  The trashCAN router will place messages from other
        /// plugins into this queue.  The trashCAN router will use this queue if the PluginInterfaceType
        /// is set to READ_WRITE or READ_ONLY
        /// </summary>
        Queue<CAN_t> IncomingCANMsgQueue
        {
            get;
        }
        /// <summary>
        /// This enum is used to specify how the plugin use CAN information
        /// READ_WRITE means the trashCAN message router will use the plug-ins read 
        /// and write queues.  READ_ONLY means the trashCAN router will push messages into its
        /// input queue but ignore its output queue.  WRITE_ONLY means the trashCAN router will not push
        /// in CAN messages to the plugin but will grab its outgoing message to the other plugins
        /// </summary>
        CAN_INTERFACE_TYPE PluginInterfaceType
        {
            get;
        }
    }

    #endregion

    #region Generic Plugin Interface

    public interface IPlugin
    {
        String PluginName
        {
          get;   
        }

        String PluginVersion
        {
            get;
        }

        /// <summary>
        /// This is used by the host for icons, etc.
        /// </summary>
        Image PluginImage
        {
            get;
        }
        
        /// <summary>
        /// The host that loads the plug will assign every instance an integer here!
        /// </summary>
        int PluginInstanceID
        {
            get;
            set;
        }
        /// <summary>
        /// This holds a rectangle and a generic object to save state
        /// When the value is set, the plugin should use the data to restore it's window state, etc
        /// </summary>
        /// 
        PluginState State
        {
            get;
            set;
        }
       
        /// <summary>
        /// General system messages that a plugin May choose to log, display, etc. Messages
        /// that start with the character @ originated from another plugin.  All other strings
        /// come from the trashCAN router.
        /// </summary>
         Queue<String> IncomingPluginMessage
        {
            get;
        }
        /// <summary>
        ///A queue of messages that a plugin will output for debugging, logging, etc.
        ///If the string starts with the character @,  the string will be routed to all
        ///of the other plugin incoming queues.  All other strings will go only to the trashCAN
        ///message router
        /// </summary>
        Queue<String> OutgoingPluginMessage
        {
            get;
        }

        /// <summary>
        /// A plugin should terminate all threads, activities, memory accesses and be prepared to be destroyed
        /// </summary>
        /// <returns>a string of "OK" should be returned if termination succeeded.  String will be logged as an Error otherwise</returns>
        String Terminate();

        /// <summary>
        /// A this will be called after the plugin is loaded.
        /// </summary>
        /// <returns>a string of "OK" should be return.  String will be logged as an error otherwise. If OK is not recieved, Terminate() will be called
        /// and the plugin will be destroyed</returns>
        String Init();

        /// <summary>
        /// The Plugin should show itself when called
        /// </summary>
        void ShowPlugin();
      
        /// <summary>
        /// The plugin should hide itself when this is called
        /// </summary>
        void HidePlugin();

        /// <summary>
        /// This is set by the plugin to request termination/unloading by the host.
        /// Plugins should not exit on their own!  The trashCAN instance manager needs to see this flag
        /// so it can be properly removed from the plugin pool.
        /// </summary>
        bool RequestTermination
        {
            get;
        }

    }

    #endregion 

    #region CAN Message Class

    /// <summary>
    /// This class is used to create CAN messages to be sent in between plugins
    /// </summary>
  
    public class CAN_t
    {
            /// <summary>
            /// ID is a 32-bit integer used to store the 11-bit or 29bit CAN ID.
            /// </summary>
            /// 
            public UInt32 ID=0;
            /// <summary>
            /// The array of bytes (0 to 8) of data to be sent with in the message
            /// </summary>
            public Byte[] Data;

            /// <summary>
            /// Set this true to mark this message as an extended ID frame
            /// </summary>
            public bool ExtendedID;

            /// <summary>
            /// This variable is use to mark an application specific time.
            /// </summary>
            public uint LocalTimeStamp;

            /// <summary>
            /// Set this flag to true to indicate that this frame will be an Remote Tramission Request
            /// </summary>
            public bool RTR = false;

            public CAN_t()
            {
                ID = 0;
                Data = new Byte[8];
                ExtendedID = false;
                for (int i = 0; i < 8; i++)
                {
                    Data[i] = 0;
                }
            }

            public CAN_t(bool ExtID, UInt32 Id, Boolean RemoteTransmissionRequest)
            {
                ExtendedID = ExtID;
                ID = Id;
                Data = new byte[0];
                RTR = RemoteTransmissionRequest;
            }

            public CAN_t(bool ExtID, UInt32 Id, byte Byte0, byte Byte1,byte Byte2,byte Byte3,byte Byte4,byte Byte5,byte Byte6, byte Byte7)
            {
                ID = Id;
                ExtendedID = ExtID;
                Data = new Byte [8];
                Data[0] = Byte0;
                Data[1] = Byte1;
                Data[2] = Byte2;
                Data[3] = Byte3;
                Data[4] = Byte4;
                Data[5] = Byte5;
                Data[6] = Byte6;
                Data[7] = Byte7;
            }

            public CAN_t(bool ExtID, UInt32 Id, byte Byte0, byte Byte1, byte Byte2, byte Byte3, byte Byte4, byte Byte5, byte Byte6)
            {
                ID = Id;
                ExtendedID = ExtID;
                Data = new Byte[7];
                Data[0] = Byte0;
                Data[1] = Byte1;
                Data[2] = Byte2;
                Data[3] = Byte3;
                Data[4] = Byte4;
                Data[5] = Byte5;
                Data[6] = Byte6;
            }

            public CAN_t(bool ExtID, UInt32 Id, byte Byte0, byte Byte1, byte Byte2, byte Byte3, byte Byte4, byte Byte5)
            {
                ID = Id;
                ExtendedID = ExtID;
                Data = new Byte[6];
                Data[0] = Byte0;
                Data[1] = Byte1;
                Data[2] = Byte2;
                Data[3] = Byte3;
                Data[4] = Byte4;
                Data[5] = Byte5;
            }

            public CAN_t(bool ExtID, UInt32 Id, byte Byte0, byte Byte1, byte Byte2, byte Byte3, byte Byte4)
            {
                ID = Id;
                ExtendedID = ExtID;
                Data = new Byte[5];
                Data[0] = Byte0;
                Data[1] = Byte1;
                Data[2] = Byte2;
                Data[3] = Byte3;
                Data[4] = Byte4;
       
            }

            public CAN_t(bool ExtID, UInt32 Id, byte Byte0, byte Byte1, byte Byte2, byte Byte3)
            {
                ID = Id;
                ExtendedID = ExtID;
                Data = new Byte[4];
                Data[0] = Byte0;
                Data[1] = Byte1;
                Data[2] = Byte2;
                Data[3] = Byte3;
            }

            public CAN_t(bool ExtID, UInt32 Id, byte Byte0, byte Byte1, byte Byte2)
            {
                ID = Id;
                ExtendedID = ExtID;
                Data = new Byte[3];
                Data[0] = Byte0;
                Data[1] = Byte1;
                Data[2] = Byte2;
            }

            public CAN_t(bool ExtID, UInt32 Id, byte Byte0, byte Byte1)
            {
                ID = Id;
                ExtendedID = ExtID;
                Data = new Byte[2];
                Data[0] = Byte0;
                Data[1] = Byte1;
            }

            public CAN_t(bool ExtID, UInt32 Id, byte Byte0)
            {
                ID = Id;
                ExtendedID = ExtID;
                Data = new Byte[1];
                Data[0] = Byte0;
         
            }

            public CAN_t(bool ExtID, UInt32 Id)
            {
                ID = Id;
                ExtendedID = ExtID;
                Data = new Byte[0];
            }

            public CAN_t(bool ExtID, UInt32 Id, Byte[] DataIn)
            {
                if (Data == null)
                {
                    throw new Exception("CAN Data can not be null.");
                }

                if (Data.Length > 8)
                {
                    throw new Exception("CAN data length must be 8 for fewer bytes.");
                }
                else if (Data.Length <= 0)
                {
                    throw new Exception("CAN data length be between 0 and 8");
                }
                ExtendedID = ExtID;
                ID = Id;
                for(int i=0;i<8;i++)
                 Data[i] = DataIn[i];
            }

            public override string ToString()
            {
                string S;

                if(ExtendedID == true)
                    S = "0x" + ID.ToString("X8") + "" ;
                else
                    S = "0x" + ID.ToString("X3") + "     ";

                S += " : ";

                if (Data!=null)
                { 
                    for (int i = 0; i < Data.Length;i++ )
                    {
                        S +=  "0x" + Data[i].ToString("X2") + " ";
                    }
                }
            
                return S;
            }
        }

    #endregion

    #region Misc Datatypes, enums, etc

    /// <summary>
    /// This enum is used to specify how the plugin use CAN information
    /// READ_WRITE means the trashCAN message router will use the plug-ins read 
    /// and write queues.  READ_ONLY means the trashCAN router will push messages into its
    /// input queue but ignore its output queue.  WRITE_ONLY means the trashCAN router will not push
    /// in CAN messages but will send the plugin's outgoing messages to the other plugins
    /// </summary>

    public enum CAN_INTERFACE_TYPE
    {
        READ_WRITE = 0,
        READ_ONLY = 1,
        WRITE_ONLY = 2
    }


    [Serializable()]
    public class PluginState
    {
        public Size WindowSize;

        public Point WindowLocation;

        public FormWindowState WindowState;
          
        public String PluginData;

    }
    
    #endregion

}
