using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace trashCAN
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();

            this.trashCANHTMLView.DocumentText = global::trashCAN.Properties.Resources.trashCANHelp;
        }

        private void Help_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Close();
        }
    }
}
