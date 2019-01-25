namespace CANMessageSniffer
{
    partial class CANMessageSniffer
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
            System.Windows.Forms.Timer SnifferUpdateTimer;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CANMessageSniffer));
            this.CANMsgTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusMessagesIn = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLockCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            SnifferUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SnifferUpdateTimer
            // 
            SnifferUpdateTimer.Enabled = true;
            SnifferUpdateTimer.Tick += new System.EventHandler(this.SnifferUpdateTimer_Tick);
            // 
            // CANMsgTextBox
            // 
            this.CANMsgTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CANMsgTextBox.BackColor = System.Drawing.Color.Black;
            this.CANMsgTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CANMsgTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.CANMsgTextBox.Location = new System.Drawing.Point(0, 0);
            this.CANMsgTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CANMsgTextBox.Multiline = true;
            this.CANMsgTextBox.Name = "CANMsgTextBox";
            this.CANMsgTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CANMsgTextBox.Size = new System.Drawing.Size(659, 306);
            this.CANMsgTextBox.TabIndex = 0;
            this.CANMsgTextBox.WordWrap = false;
            // 
            // statusStrip
            // 
            this.statusStrip.ContextMenuStrip = this.contextMenuStrip1;
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusMessagesIn,
            this.statusLockCount,
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 319);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip.Size = new System.Drawing.Size(664, 28);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(212, 67);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // statusMessagesIn
            // 
            this.statusMessagesIn.AutoSize = false;
            this.statusMessagesIn.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusMessagesIn.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusMessagesIn.Margin = new System.Windows.Forms.Padding(1, 3, 0, 2);
            this.statusMessagesIn.Name = "statusMessagesIn";
            this.statusMessagesIn.Size = new System.Drawing.Size(128, 23);
            this.statusMessagesIn.Text = "IN:  0";
            this.statusMessagesIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.statusMessagesIn.Click += new System.EventHandler(this.statusMessagesIn_Click);
            // 
            // statusLockCount
            // 
            this.statusLockCount.AutoSize = false;
            this.statusLockCount.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusLockCount.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusLockCount.Name = "statusLockCount";
            this.statusLockCount.Size = new System.Drawing.Size(75, 23);
            this.statusLockCount.Text = "LOCK:  0";
            this.statusLockCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(437, 23);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CANMessageSniffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 347);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.CANMsgTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(664, 362);
            this.Name = "CANMessageSniffer";
            this.Text = "CAN Message Sniffer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CANMessageSniffer_FormClosing);
            this.LocationChanged += new System.EventHandler(this.CANMessageSniffer_LocationChanged);
            this.Resize += new System.EventHandler(this.CANMessageSniffer_Resize);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CANMsgTextBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusMessagesIn;
        private System.Windows.Forms.ToolStripStatusLabel statusLockCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

    }
}