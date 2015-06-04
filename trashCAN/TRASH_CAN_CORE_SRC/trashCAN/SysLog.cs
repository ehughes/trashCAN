using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace trashCAN
{
    public partial class SysLog : Form
    {
        Queue<String> Messages = new Queue<string>(64);

        public Queue<String> IncomingMessages = new Queue<string>(128);

        public void Write(String MessageIn)
        {

            IncomingMessages.Enqueue(MessageIn);
        }

        
        public SysLog()
        {
            InitializeComponent();
            ResizeControls();
            Messages.Clear();
            IncomingMessages.Clear();
        }

        void ResizeControls()
        {
            SyslogTB.Location = new Point(this.ClientRectangle.X, this.ClientRectangle.Y);
            SyslogTB.Size = new Size(this.ClientRectangle.Width, this.ClientRectangle.Height);
        }
        private void SysLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void SysLog_Resize(object sender, EventArgs e)
        {
          ResizeControls();
        }

        private void Update_Tick(object sender, EventArgs e)
        {

            while (IncomingMessages.Count > 0)
            {
                Messages.Enqueue(IncomingMessages.Dequeue());
            }

            while (Messages.Count > 64)
            {
                string Junk = (string)Messages.Dequeue();
            }
           
            string[] MyMessage = Messages.ToArray();
            string Output = "";

            for (int i = 0; i < Messages.Count; i++)
            {
                Output += MyMessage[Messages.Count-i-1] + "\r\n";
            }
            SyslogTB.Text = Output;
            
        }
    }
}
