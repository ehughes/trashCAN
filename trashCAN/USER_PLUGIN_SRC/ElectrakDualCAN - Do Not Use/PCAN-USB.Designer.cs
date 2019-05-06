namespace ElectrakDual
{
    partial class ElectrakDual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElectrakDual));
            this.USBChannelCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BAUDRateCB = new System.Windows.Forms.ComboBox();
            this.BaudRateLabel = new System.Windows.Forms.Label();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.RefreshLabel = new System.Windows.Forms.Label();
            this.ConnectLabel = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.FormUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.StatusLabel = new System.Windows.Forms.Label();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.ErrorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripIn = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripOut = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStripError = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.statusMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // USBChannelCB
            // 
            this.USBChannelCB.Enabled = false;
            this.USBChannelCB.FormattingEnabled = true;
            this.USBChannelCB.Location = new System.Drawing.Point(187, 113);
            this.USBChannelCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.USBChannelCB.Name = "USBChannelCB";
            this.USBChannelCB.Size = new System.Drawing.Size(108, 24);
            this.USBChannelCB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 117);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available USB Channels";
            // 
            // BAUDRateCB
            // 
            this.BAUDRateCB.FormattingEnabled = true;
            this.BAUDRateCB.Location = new System.Drawing.Point(93, 146);
            this.BAUDRateCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BAUDRateCB.Name = "BAUDRateCB";
            this.BAUDRateCB.Size = new System.Drawing.Size(201, 24);
            this.BAUDRateCB.TabIndex = 2;
            // 
            // BaudRateLabel
            // 
            this.BaudRateLabel.AutoSize = true;
            this.BaudRateLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaudRateLabel.Location = new System.Drawing.Point(8, 150);
            this.BaudRateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BaudRateLabel.Name = "BaudRateLabel";
            this.BaudRateLabel.Size = new System.Drawing.Size(71, 19);
            this.BaudRateLabel.TabIndex = 3;
            this.BaudRateLabel.Text = "Baud Rate";
            // 
            // RefreshButton
            // 
            this.RefreshButton.BackgroundImage = global::ElectrakDual.Properties.Resources.refresh;
            this.RefreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RefreshButton.FlatAppearance.BorderSize = 0;
            this.RefreshButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.RefreshButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.Location = new System.Drawing.Point(60, 2);
            this.RefreshButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(85, 79);
            this.RefreshButton.TabIndex = 6;
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // RefreshLabel
            // 
            this.RefreshLabel.AutoSize = true;
            this.RefreshLabel.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshLabel.Location = new System.Drawing.Point(72, 85);
            this.RefreshLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RefreshLabel.Name = "RefreshLabel";
            this.RefreshLabel.Size = new System.Drawing.Size(54, 19);
            this.RefreshLabel.TabIndex = 8;
            this.RefreshLabel.Text = "Refresh";
            // 
            // ConnectLabel
            // 
            this.ConnectLabel.AutoSize = true;
            this.ConnectLabel.Enabled = false;
            this.ConnectLabel.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectLabel.Location = new System.Drawing.Point(187, 85);
            this.ConnectLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ConnectLabel.Name = "ConnectLabel";
            this.ConnectLabel.Size = new System.Drawing.Size(60, 19);
            this.ConnectLabel.TabIndex = 9;
            this.ConnectLabel.Text = "Connect";
            // 
            // ConnectButton
            // 
            this.ConnectButton.BackgroundImage = global::ElectrakDual.Properties.Resources.connect;
            this.ConnectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ConnectButton.Enabled = false;
            this.ConnectButton.FlatAppearance.BorderSize = 0;
            this.ConnectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectButton.Location = new System.Drawing.Point(177, 2);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(85, 79);
            this.ConnectButton.TabIndex = 10;
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // FormUpdateTimer
            // 
            this.FormUpdateTimer.Enabled = true;
            this.FormUpdateTimer.Interval = 50;
            this.FormUpdateTimer.Tick += new System.EventHandler(this.FormUpdateTimer_Tick);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(8, 182);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(50, 19);
            this.StatusLabel.TabIndex = 11;
            this.StatusLabel.Text = "Status:";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.ErrorLabel.Location = new System.Drawing.Point(131, 213);
            this.ErrorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(50, 23);
            this.ErrorLabel.TabIndex = 12;
            this.ErrorLabel.Text = "Error";
            // 
            // ErrorToolTip
            // 
            this.ErrorToolTip.AutoPopDelay = 2500;
            this.ErrorToolTip.InitialDelay = 500;
            this.ErrorToolTip.ReshowDelay = 100;
            this.ErrorToolTip.ShowAlways = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ContextMenuStrip = this.statusMenu;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripIn,
            this.statusStripOut,
            this.statusStripError});
            this.statusStrip1.Location = new System.Drawing.Point(0, 238);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(309, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusMenu
            // 
            this.statusMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.statusMenu.Name = "statusMenu";
            this.statusMenu.Size = new System.Drawing.Size(113, 28);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // statusStripIn
            // 
            this.statusStripIn.AutoSize = false;
            this.statusStripIn.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusStripIn.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusStripIn.Margin = new System.Windows.Forms.Padding(1, 3, 0, 2);
            this.statusStripIn.Name = "statusStripIn";
            this.statusStripIn.Size = new System.Drawing.Size(85, 19);
            this.statusStripIn.Text = "I:  0";
            this.statusStripIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusStripOut
            // 
            this.statusStripOut.AutoSize = false;
            this.statusStripOut.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusStripOut.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusStripOut.Name = "statusStripOut";
            this.statusStripOut.Size = new System.Drawing.Size(85, 19);
            this.statusStripOut.Text = "O:  ";
            this.statusStripOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusStripError
            // 
            this.statusStripError.AutoSize = false;
            this.statusStripError.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusStripError.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.statusStripError.Margin = new System.Windows.Forms.Padding(0, 3, -13, 2);
            this.statusStripError.Name = "statusStripError";
            this.statusStripError.Size = new System.Drawing.Size(131, 19);
            this.statusStripError.Spring = true;
            this.statusStripError.Text = "E:  0";
            this.statusStripError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PCAN_USB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 262);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ErrorLabel);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.ConnectLabel);
            this.Controls.Add(this.RefreshLabel);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.BaudRateLabel);
            this.Controls.Add(this.BAUDRateCB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.USBChannelCB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(327, 309);
            this.MinimumSize = new System.Drawing.Size(327, 309);
            this.Name = "PCAN_USB";
            this.Text = "PCAN_USB";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PCAN_USB_FormClosing);
            this.Load += new System.EventHandler(this.PCAN_USB_Load);
            this.LocationChanged += new System.EventHandler(this.PCAN_USB_LocationChanged);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.statusMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox USBChannelCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox BAUDRateCB;
        private System.Windows.Forms.Label BaudRateLabel;
        private System.Windows.Forms.Label RefreshLabel;
        private System.Windows.Forms.Label ConnectLabel;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Timer FormUpdateTimer;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.ToolTip ErrorToolTip;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusStripIn;
        private System.Windows.Forms.ToolStripStatusLabel statusStripOut;
        private System.Windows.Forms.ToolStripStatusLabel statusStripError;
        private System.Windows.Forms.ContextMenuStrip statusMenu;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
    }
}