namespace trashCAN
{
    partial class trashCANHost
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(trashCANHost));
            this.trashCANMainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.pluginsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginInstanceMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hostLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pluginMessageLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabelActive = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerUpdateGUI = new System.Windows.Forms.Timer(this.components);
            this.trashCANMainMenuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trashCANMainMenuStrip
            // 
            this.trashCANMainMenuStrip.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.trashCANMainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pluginsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.trashCANMainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.trashCANMainMenuStrip.Name = "trashCANMainMenuStrip";
            this.trashCANMainMenuStrip.Padding = new System.Windows.Forms.Padding(6, 6, 0, 2);
            this.trashCANMainMenuStrip.Size = new System.Drawing.Size(189, 75);
            this.trashCANMainMenuStrip.TabIndex = 0;
            this.trashCANMainMenuStrip.Text = "menuStrip1";
            // 
            // pluginsToolStripMenuItem
            // 
            this.pluginsToolStripMenuItem.Image = global::trashCAN.Properties.Resources.PluginMenuHeader;
            this.pluginsToolStripMenuItem.Name = "pluginsToolStripMenuItem";
            this.pluginsToolStripMenuItem.Size = new System.Drawing.Size(60, 67);
            this.pluginsToolStripMenuItem.Text = "Plugins";
            this.pluginsToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pluginInstanceMonitorToolStripMenuItem,
            this.hostLogToolStripMenuItem,
            this.pluginMessageLogToolStripMenuItem,
            this.restoreLayoutToolStripMenuItem,
            this.saveLayoutToolStripMenuItem});
            this.toolsToolStripMenuItem.Image = global::trashCAN.Properties.Resources.Tools;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(60, 67);
            this.toolsToolStripMenuItem.Text = "Tools";
            this.toolsToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolsToolStripMenuItem.Click += new System.EventHandler(this.toolsToolStripMenuItem_Click);
            // 
            // pluginInstanceMonitorToolStripMenuItem
            // 
            this.pluginInstanceMonitorToolStripMenuItem.Image = global::trashCAN.Properties.Resources.PluginInstanceMonitor;
            this.pluginInstanceMonitorToolStripMenuItem.Name = "pluginInstanceMonitorToolStripMenuItem";
            this.pluginInstanceMonitorToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.pluginInstanceMonitorToolStripMenuItem.Text = "Plugin Instance Monitor";
            this.pluginInstanceMonitorToolStripMenuItem.Click += new System.EventHandler(this.pluginInstanceMonitorToolStripMenuItem_Click);
            // 
            // hostLogToolStripMenuItem
            // 
            this.hostLogToolStripMenuItem.Image = global::trashCAN.Properties.Resources.SyslogMenuIcon;
            this.hostLogToolStripMenuItem.Name = "hostLogToolStripMenuItem";
            this.hostLogToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.hostLogToolStripMenuItem.Text = "Host Log";
            this.hostLogToolStripMenuItem.Click += new System.EventHandler(this.hostLogToolStripMenuItem_Click);
            // 
            // pluginMessageLogToolStripMenuItem
            // 
            this.pluginMessageLogToolStripMenuItem.Image = global::trashCAN.Properties.Resources.SyslogMenuIcon;
            this.pluginMessageLogToolStripMenuItem.Name = "pluginMessageLogToolStripMenuItem";
            this.pluginMessageLogToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.pluginMessageLogToolStripMenuItem.Text = "Plugin Message Log";
            this.pluginMessageLogToolStripMenuItem.Click += new System.EventHandler(this.pluginMessageLogToolStripMenuItem_Click);
            // 
            // restoreLayoutToolStripMenuItem
            // 
            this.restoreLayoutToolStripMenuItem.Image = global::trashCAN.Properties.Resources.svn_update;
            this.restoreLayoutToolStripMenuItem.Name = "restoreLayoutToolStripMenuItem";
            this.restoreLayoutToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.restoreLayoutToolStripMenuItem.Text = "Restore Layout";
            this.restoreLayoutToolStripMenuItem.Click += new System.EventHandler(this.restoreLayoutToolStripMenuItem_Click);
            // 
            // saveLayoutToolStripMenuItem
            // 
            this.saveLayoutToolStripMenuItem.Image = global::trashCAN.Properties.Resources.svn_commit;
            this.saveLayoutToolStripMenuItem.Name = "saveLayoutToolStripMenuItem";
            this.saveLayoutToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.saveLayoutToolStripMenuItem.Text = "Save Layout";
            this.saveLayoutToolStripMenuItem.Click += new System.EventHandler(this.saveLayoutToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.documentationToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Image = global::trashCAN.Properties.Resources.help;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(60, 67);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // documentationToolStripMenuItem
            // 
            this.documentationToolStripMenuItem.Image = global::trashCAN.Properties.Resources.docs;
            this.documentationToolStripMenuItem.Name = "documentationToolStripMenuItem";
            this.documentationToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.documentationToolStripMenuItem.Text = "Documentation";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::trashCAN.Properties.Resources.trashCAN;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Trash Bag|*.bag|All files|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "bag";
            this.saveFileDialog1.Filter = "Trash Bag|*.bag|All files|*.*";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelActive});
            this.statusStrip1.Location = new System.Drawing.Point(0, 75);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(189, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabelActive
            // 
            this.statusLabelActive.AutoSize = false;
            this.statusLabelActive.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusLabelActive.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.statusLabelActive.Margin = new System.Windows.Forms.Padding(2, 3, -13, 2);
            this.statusLabelActive.Name = "statusLabelActive";
            this.statusLabelActive.Size = new System.Drawing.Size(185, 17);
            this.statusLabelActive.Spring = true;
            this.statusLabelActive.Text = "Active: 0";
            // 
            // timerUpdateGUI
            // 
            this.timerUpdateGUI.Enabled = true;
            this.timerUpdateGUI.Tick += new System.EventHandler(this.timerUpdateGUI_Tick);
            // 
            // trashCANHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 97);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.trashCANMainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.trashCANMainMenuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(205, 135);
            this.MinimumSize = new System.Drawing.Size(205, 135);
            this.Name = "trashCANHost";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CANHost_FormClosing);
            this.Load += new System.EventHandler(this.trashCANHost_Load);
            this.LocationChanged += new System.EventHandler(this.trashCANHost_LocationChanged);
            this.trashCANMainMenuStrip.ResumeLayout(false);
            this.trashCANMainMenuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip trashCANMainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem pluginsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginInstanceMonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hostLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pluginMessageLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreLayoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLayoutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelActive;
        private System.Windows.Forms.Timer timerUpdateGUI;
    }
}

