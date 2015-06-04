namespace PCAN_USB
{
    partial class PCAN_USB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PCAN_USB));
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
            this.SuspendLayout();
            // 
            // USBChannelCB
            // 
            this.USBChannelCB.Enabled = false;
            this.USBChannelCB.FormattingEnabled = true;
            this.USBChannelCB.Location = new System.Drawing.Point(140, 92);
            this.USBChannelCB.Name = "USBChannelCB";
            this.USBChannelCB.Size = new System.Drawing.Size(59, 21);
            this.USBChannelCB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available USB Channels";
            // 
            // BAUDRateCB
            // 
            this.BAUDRateCB.FormattingEnabled = true;
            this.BAUDRateCB.Location = new System.Drawing.Point(70, 119);
            this.BAUDRateCB.Name = "BAUDRateCB";
            this.BAUDRateCB.Size = new System.Drawing.Size(129, 21);
            this.BAUDRateCB.TabIndex = 2;
            // 
            // BaudRateLabel
            // 
            this.BaudRateLabel.AutoSize = true;
            this.BaudRateLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BaudRateLabel.Location = new System.Drawing.Point(6, 122);
            this.BaudRateLabel.Name = "BaudRateLabel";
            this.BaudRateLabel.Size = new System.Drawing.Size(60, 13);
            this.BaudRateLabel.TabIndex = 3;
            this.BaudRateLabel.Text = "Baud Rate";
            // 
            // RefreshButton
            // 
            this.RefreshButton.BackgroundImage = global::PCAN_USB.Properties.Resources.refresh;
            this.RefreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RefreshButton.FlatAppearance.BorderSize = 0;
            this.RefreshButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.RefreshButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.Location = new System.Drawing.Point(23, 2);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(64, 64);
            this.RefreshButton.TabIndex = 6;
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // RefreshLabel
            // 
            this.RefreshLabel.AutoSize = true;
            this.RefreshLabel.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshLabel.Location = new System.Drawing.Point(41, 69);
            this.RefreshLabel.Name = "RefreshLabel";
            this.RefreshLabel.Size = new System.Drawing.Size(46, 13);
            this.RefreshLabel.TabIndex = 8;
            this.RefreshLabel.Text = "Refresh";
            // 
            // ConnectLabel
            // 
            this.ConnectLabel.AutoSize = true;
            this.ConnectLabel.Enabled = false;
            this.ConnectLabel.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectLabel.Location = new System.Drawing.Point(118, 69);
            this.ConnectLabel.Name = "ConnectLabel";
            this.ConnectLabel.Size = new System.Drawing.Size(50, 13);
            this.ConnectLabel.TabIndex = 9;
            this.ConnectLabel.Text = "Connect";
            // 
            // ConnectButton
            // 
            this.ConnectButton.BackgroundImage = global::PCAN_USB.Properties.Resources.connect;
            this.ConnectButton.Enabled = false;
            this.ConnectButton.FlatAppearance.BorderSize = 0;
            this.ConnectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectButton.Location = new System.Drawing.Point(111, 2);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(64, 64);
            this.ConnectButton.TabIndex = 10;
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // FormUpdateTimer
            // 
            this.FormUpdateTimer.Enabled = true;
            this.FormUpdateTimer.Interval = 500;
            this.FormUpdateTimer.Tick += new System.EventHandler(this.FormUpdateTimer_Tick);
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(6, 148);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(42, 13);
            this.StatusLabel.TabIndex = 11;
            this.StatusLabel.Text = "Status:";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.ErrorLabel.Location = new System.Drawing.Point(80, 169);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(38, 17);
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
            // PCAN_USB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 195);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(225, 233);
            this.MinimumSize = new System.Drawing.Size(224, 233);
            this.Name = "PCAN_USB";
            this.Text = "PCAN_USB";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PCAN_USB_FormClosing);
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
    }
}