namespace J1939_AddressClaim
{
    partial class J1939_AddressClaim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(J1939_AddressClaim));
            this.MsgCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.FormUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.AddressClaimButton = new System.Windows.Forms.Button();
            this.AddressToClaim = new System.Windows.Forms.NumericUpDown();
            this.J1939_ProcessTImer = new System.Windows.Forms.Timer(this.components);
            this.StatusMessageTextBox = new System.Windows.Forms.TextBox();
            this.GlobalAddressRequestButton = new System.Windows.Forms.Button();
            this.AddressMapVIew = new System.Windows.Forms.TextBox();
            this.AutoClaimButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AddressToClaim)).BeginInit();
            this.SuspendLayout();
            // 
            // MsgCheckTimer
            // 
            this.MsgCheckTimer.Enabled = true;
            this.MsgCheckTimer.Tick += new System.EventHandler(this.MsgCheckTimer_Tick);
            // 
            // FormUpdateTimer
            // 
            this.FormUpdateTimer.Enabled = true;
            this.FormUpdateTimer.Tick += new System.EventHandler(this.FormUpdateTimer_Tick);
            // 
            // AddressClaimButton
            // 
            this.AddressClaimButton.Location = new System.Drawing.Point(83, 1);
            this.AddressClaimButton.Name = "AddressClaimButton";
            this.AddressClaimButton.Size = new System.Drawing.Size(75, 23);
            this.AddressClaimButton.TabIndex = 0;
            this.AddressClaimButton.Text = "button1";
            this.AddressClaimButton.UseVisualStyleBackColor = true;
            this.AddressClaimButton.Click += new System.EventHandler(this.AddressClaimButton_Click);
            // 
            // AddressToClaim
            // 
            this.AddressToClaim.Location = new System.Drawing.Point(164, 4);
            this.AddressToClaim.Maximum = new decimal(new int[] {
            253,
            0,
            0,
            0});
            this.AddressToClaim.Name = "AddressToClaim";
            this.AddressToClaim.Size = new System.Drawing.Size(62, 20);
            this.AddressToClaim.TabIndex = 1;
            this.AddressToClaim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // J1939_ProcessTImer
            // 
            this.J1939_ProcessTImer.Enabled = true;
            this.J1939_ProcessTImer.Interval = 10;
            this.J1939_ProcessTImer.Tick += new System.EventHandler(this.J1939_ProcessTImer_Tick);
            // 
            // StatusMessageTextBox
            // 
            this.StatusMessageTextBox.BackColor = System.Drawing.Color.Black;
            this.StatusMessageTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusMessageTextBox.ForeColor = System.Drawing.Color.Lime;
            this.StatusMessageTextBox.Location = new System.Drawing.Point(2, 30);
            this.StatusMessageTextBox.Multiline = true;
            this.StatusMessageTextBox.Name = "StatusMessageTextBox";
            this.StatusMessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StatusMessageTextBox.Size = new System.Drawing.Size(683, 168);
            this.StatusMessageTextBox.TabIndex = 2;
            // 
            // GlobalAddressRequestButton
            // 
            this.GlobalAddressRequestButton.Location = new System.Drawing.Point(2, 204);
            this.GlobalAddressRequestButton.Name = "GlobalAddressRequestButton";
            this.GlobalAddressRequestButton.Size = new System.Drawing.Size(87, 38);
            this.GlobalAddressRequestButton.TabIndex = 3;
            this.GlobalAddressRequestButton.Text = "Global Address Request";
            this.GlobalAddressRequestButton.UseVisualStyleBackColor = true;
            this.GlobalAddressRequestButton.Click += new System.EventHandler(this.GlobalAddressRequestButton_Click);
            // 
            // AddressMapVIew
            // 
            this.AddressMapVIew.BackColor = System.Drawing.Color.Black;
            this.AddressMapVIew.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressMapVIew.ForeColor = System.Drawing.Color.Lime;
            this.AddressMapVIew.Location = new System.Drawing.Point(2, 248);
            this.AddressMapVIew.Multiline = true;
            this.AddressMapVIew.Name = "AddressMapVIew";
            this.AddressMapVIew.Size = new System.Drawing.Size(683, 234);
            this.AddressMapVIew.TabIndex = 4;
            this.AddressMapVIew.WordWrap = false;
            // 
            // AutoClaimButton
            // 
            this.AutoClaimButton.Location = new System.Drawing.Point(2, 1);
            this.AutoClaimButton.Name = "AutoClaimButton";
            this.AutoClaimButton.Size = new System.Drawing.Size(75, 23);
            this.AutoClaimButton.TabIndex = 5;
            this.AutoClaimButton.Text = "AutoClaim";
            this.AutoClaimButton.UseVisualStyleBackColor = true;
            this.AutoClaimButton.Click += new System.EventHandler(this.AutoClaimButton_Click);
            // 
            // J1939_AddressClaim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 486);
            this.Controls.Add(this.AutoClaimButton);
            this.Controls.Add(this.AddressMapVIew);
            this.Controls.Add(this.GlobalAddressRequestButton);
            this.Controls.Add(this.StatusMessageTextBox);
            this.Controls.Add(this.AddressToClaim);
            this.Controls.Add(this.AddressClaimButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(705, 525);
            this.MinimumSize = new System.Drawing.Size(705, 525);
            this.Name = "J1939_AddressClaim";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "J1939 Address Claim";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.J1939_AddressClaim_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AddressToClaim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer MsgCheckTimer;
        private System.Windows.Forms.Timer FormUpdateTimer;
        private System.Windows.Forms.Button AddressClaimButton;
        private System.Windows.Forms.NumericUpDown AddressToClaim;
        private System.Windows.Forms.Timer J1939_ProcessTImer;
        private System.Windows.Forms.TextBox StatusMessageTextBox;
        private System.Windows.Forms.Button GlobalAddressRequestButton;
        private System.Windows.Forms.TextBox AddressMapVIew;
        private System.Windows.Forms.Button AutoClaimButton;
    }
}

