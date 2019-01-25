﻿namespace CANMessageInjector
{
    partial class CANMessageInjector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CANMessageInjector));
            this.CANMessageTextBox = new System.Windows.Forms.TextBox();
            this.ExtIDCheckBox = new System.Windows.Forms.CheckBox();
            this.QueueClearTimer = new System.Windows.Forms.Timer(this.components);
            this.RTRCheckBox = new System.Windows.Forms.CheckBox();
            this.MessageGeneratorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.AutoSendCheckBox = new System.Windows.Forms.CheckBox();
            this.RepeatRateUD = new System.Windows.Forms.NumericUpDown();
            this.RepeatRateLabel = new System.Windows.Forms.Label();
            this.AutoSendTimer = new System.Windows.Forms.Timer(this.components);
            this.FillDataCB = new System.Windows.Forms.CheckBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.contextMenuStatus = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusLabelOut = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelLocked = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.RepeatRateUD)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // CANMessageTextBox
            // 
            this.CANMessageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CANMessageTextBox.BackColor = System.Drawing.Color.Black;
            this.CANMessageTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CANMessageTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CANMessageTextBox.Location = new System.Drawing.Point(1, 2);
            this.CANMessageTextBox.Name = "CANMessageTextBox";
            this.CANMessageTextBox.Size = new System.Drawing.Size(463, 22);
            this.CANMessageTextBox.TabIndex = 0;
            this.CANMessageTextBox.TextChanged += new System.EventHandler(this.CANMessageTextBox_TextChanged);
            this.CANMessageTextBox.MouseEnter += new System.EventHandler(this.CANMessageTextBox_MouseEnter);
            this.CANMessageTextBox.MouseLeave += new System.EventHandler(this.CANMessageTextBox_MouseLeave);
            this.CANMessageTextBox.MouseHover += new System.EventHandler(this.CANMessageTextBox_MouseHover);
            // 
            // ExtIDCheckBox
            // 
            this.ExtIDCheckBox.AutoSize = true;
            this.ExtIDCheckBox.Location = new System.Drawing.Point(12, 33);
            this.ExtIDCheckBox.Name = "ExtIDCheckBox";
            this.ExtIDCheckBox.Size = new System.Drawing.Size(85, 17);
            this.ExtIDCheckBox.TabIndex = 1;
            this.ExtIDCheckBox.Text = "Extended ID";
            this.ExtIDCheckBox.UseVisualStyleBackColor = true;
            // 
            // QueueClearTimer
            // 
            this.QueueClearTimer.Enabled = true;
            this.QueueClearTimer.Tick += new System.EventHandler(this.QueueClearTimer_Tick);
            // 
            // RTRCheckBox
            // 
            this.RTRCheckBox.AutoSize = true;
            this.RTRCheckBox.Location = new System.Drawing.Point(12, 56);
            this.RTRCheckBox.Name = "RTRCheckBox";
            this.RTRCheckBox.Size = new System.Drawing.Size(170, 17);
            this.RTRCheckBox.TabIndex = 2;
            this.RTRCheckBox.Text = "Remote Transmission Request";
            this.RTRCheckBox.UseVisualStyleBackColor = true;
            // 
            // MessageGeneratorToolTip
            // 
            this.MessageGeneratorToolTip.AutomaticDelay = 2000;
            this.MessageGeneratorToolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            // 
            // AutoSendCheckBox
            // 
            this.AutoSendCheckBox.AutoSize = true;
            this.AutoSendCheckBox.Location = new System.Drawing.Point(191, 33);
            this.AutoSendCheckBox.Name = "AutoSendCheckBox";
            this.AutoSendCheckBox.Size = new System.Drawing.Size(102, 17);
            this.AutoSendCheckBox.TabIndex = 3;
            this.AutoSendCheckBox.Text = "Auto Send Data";
            this.AutoSendCheckBox.UseVisualStyleBackColor = true;
            this.AutoSendCheckBox.CheckedChanged += new System.EventHandler(this.AutoSendCheckBox_CheckedChanged);
            // 
            // RepeatRateUD
            // 
            this.RepeatRateUD.Cursor = System.Windows.Forms.Cursors.Default;
            this.RepeatRateUD.Location = new System.Drawing.Point(329, 53);
            this.RepeatRateUD.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.RepeatRateUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RepeatRateUD.Name = "RepeatRateUD";
            this.RepeatRateUD.Size = new System.Drawing.Size(120, 20);
            this.RepeatRateUD.TabIndex = 4;
            this.RepeatRateUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.RepeatRateUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.RepeatRateUD.ValueChanged += new System.EventHandler(this.RepeatRateUD_ValueChanged);
            // 
            // RepeatRateLabel
            // 
            this.RepeatRateLabel.AutoSize = true;
            this.RepeatRateLabel.Location = new System.Drawing.Point(326, 37);
            this.RepeatRateLabel.Name = "RepeatRateLabel";
            this.RepeatRateLabel.Size = new System.Drawing.Size(123, 13);
            this.RepeatRateLabel.TabIndex = 5;
            this.RepeatRateLabel.Text = "Millisecond Repeat Rate";
            // 
            // AutoSendTimer
            // 
            this.AutoSendTimer.Tick += new System.EventHandler(this.AutoSendTimer_Tick);
            // 
            // FillDataCB
            // 
            this.FillDataCB.AutoSize = true;
            this.FillDataCB.Location = new System.Drawing.Point(191, 56);
            this.FillDataCB.Name = "FillDataCB";
            this.FillDataCB.Size = new System.Drawing.Size(64, 17);
            this.FillDataCB.TabIndex = 6;
            this.FillDataCB.Text = "Fill Data";
            this.FillDataCB.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ContextMenuStrip = this.contextMenuStatus;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelOut,
            this.statusLabelLocked,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 78);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(464, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // contextMenuStatus
            // 
            this.contextMenuStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.contextMenuStatus.Name = "contextMenuStatus";
            this.contextMenuStatus.Size = new System.Drawing.Size(102, 26);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // statusLabelOut
            // 
            this.statusLabelOut.AutoSize = false;
            this.statusLabelOut.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusLabelOut.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusLabelOut.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
            this.statusLabelOut.Name = "statusLabelOut";
            this.statusLabelOut.Size = new System.Drawing.Size(150, 19);
            this.statusLabelOut.Text = "OUT:  0";
            this.statusLabelOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusLabelLocked
            // 
            this.statusLabelLocked.AutoSize = false;
            this.statusLabelLocked.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusLabelLocked.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusLabelLocked.Name = "statusLabelLocked";
            this.statusLabelLocked.Size = new System.Drawing.Size(75, 19);
            this.statusLabelLocked.Text = "LOCK:  0";
            this.statusLabelLocked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(0, 3, -13, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(235, 19);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // CANMessageInjector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 102);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.FillDataCB);
            this.Controls.Add(this.RepeatRateLabel);
            this.Controls.Add(this.RepeatRateUD);
            this.Controls.Add(this.AutoSendCheckBox);
            this.Controls.Add(this.RTRCheckBox);
            this.Controls.Add(this.ExtIDCheckBox);
            this.Controls.Add(this.CANMessageTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(480, 140);
            this.MinimumSize = new System.Drawing.Size(480, 140);
            this.Name = "CANMessageInjector";
            this.Text = "CANMessageInjector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CANMessageInjector_FormClosing);
            this.Load += new System.EventHandler(this.CANMessageInjector_Load);
            this.LocationChanged += new System.EventHandler(this.CANMessageInjector_LocationChanged);
            this.Resize += new System.EventHandler(this.CANMessageInjector_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.RepeatRateUD)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStatus.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CANMessageTextBox;
        private System.Windows.Forms.CheckBox ExtIDCheckBox;
        private System.Windows.Forms.Timer QueueClearTimer;
        private System.Windows.Forms.CheckBox RTRCheckBox;
        private System.Windows.Forms.ToolTip MessageGeneratorToolTip;
        private System.Windows.Forms.CheckBox AutoSendCheckBox;
        private System.Windows.Forms.NumericUpDown RepeatRateUD;
        private System.Windows.Forms.Label RepeatRateLabel;
        private System.Windows.Forms.Timer AutoSendTimer;
        private System.Windows.Forms.CheckBox FillDataCB;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelOut;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelLocked;
        private System.Windows.Forms.ContextMenuStrip contextMenuStatus;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}