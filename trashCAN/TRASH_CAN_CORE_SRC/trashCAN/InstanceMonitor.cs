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
    public partial class InstanceMonitor : Form
    {

        public Queue<int> InstanceDestructionQueue = new Queue<int>(256);
        public Queue<int> InstanceShowQueue = new Queue<int>(256);

        public InstanceMonitor()
        {
            InitializeComponent();
            ResizeInstanceMonitor();
        }

        private void InstanceMonitor_Load(object sender, EventArgs e)
        {
            
        }

        void ResizeInstanceMonitor()
        {
            this.InstanceGrid.Location = new Point(0, 0);
            this.InstanceGrid.Size = new Size(this.ClientRectangle.Width,this.ClientRectangle.Height);
        }

        private void InstanceMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        public void Clear()
        {
            InstanceGrid.Rows.Clear();
        }
        public void AddData(Image PluginImage, string InstanceID, String PluginName, string Version)
        {
            InstanceGrid.Rows.Add(PluginImage, InstanceID, PluginName, Version);

        }

        private void InstanceMonitor_Resize(object sender, EventArgs e)
        {
            ResizeInstanceMonitor();
        }

        private void InstanceGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void destroyInstanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in InstanceGrid.SelectedRows)
            {
                string InstanceToDestoyString = (string)Row.Cells["InstanceId"].Value;
                try
                {
                    int InstanceToDestroy = Convert.ToInt32(InstanceToDestoyString);
                    InstanceDestructionQueue.Enqueue(InstanceToDestroy);
                }
                catch
                {

                }
            }
        }

        private void showInstanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in InstanceGrid.SelectedRows)
            {
                string InstanceToShowString = (string)Row.Cells["InstanceId"].Value;
                try
                {
                    int Instance = Convert.ToInt32(InstanceToShowString);
                    InstanceShowQueue.Enqueue(Instance);
                }
                catch
                {

                }
            }
        }
    }
}
