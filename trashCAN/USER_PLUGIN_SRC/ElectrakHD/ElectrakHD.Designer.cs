namespace ElectrakHD
{
    partial class ElectrakHD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElectrakHD));
            this.MsgCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.FormUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.AddressLabel = new System.Windows.Forms.Label();
            this.ActuatorAddress = new System.Windows.Forms.NumericUpDown();
            this.ActivityLED = new Bulb.LedBulb();
            this.label1 = new System.Windows.Forms.Label();
            this.MeasuredPositionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MeasuredCurrentTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.RunningSpeedTextBox = new System.Windows.Forms.TextBox();
            this.VoltageErrorTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TemperatureErrorTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.MotionLED = new Bulb.LedBulb();
            this.ParameterLED = new Bulb.LedBulb();
            this.label13 = new System.Windows.Forms.Label();
            this.SaturationLED = new Bulb.LedBulb();
            this.label14 = new System.Windows.Forms.Label();
            this.OverloadLED = new Bulb.LedBulb();
            this.label15 = new System.Windows.Forms.Label();
            this.BackDriveLED = new Bulb.LedBulb();
            this.BackDriveLabel = new System.Windows.Forms.Label();
            this.FatalErrorLED = new Bulb.LedBulb();
            this.FatalErrorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ActuatorAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // MsgCheckTimer
            // 
            this.MsgCheckTimer.Enabled = true;
            this.MsgCheckTimer.Interval = 25;
            this.MsgCheckTimer.Tick += new System.EventHandler(this.MsgCheckTimer_Tick);
            // 
            // FormUpdateTimer
            // 
            this.FormUpdateTimer.Enabled = true;
            this.FormUpdateTimer.Interval = 50;
            this.FormUpdateTimer.Tick += new System.EventHandler(this.FormUpdateTimer_Tick);
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Location = new System.Drawing.Point(12, 21);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(188, 25);
            this.AddressLabel.TabIndex = 4;
            this.AddressLabel.Text = "Address (Decimal)";
            // 
            // ActuatorAddress
            // 
            this.ActuatorAddress.Location = new System.Drawing.Point(206, 15);
            this.ActuatorAddress.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.ActuatorAddress.Minimum = new decimal(new int[] {
            19,
            0,
            0,
            0});
            this.ActuatorAddress.Name = "ActuatorAddress";
            this.ActuatorAddress.Size = new System.Drawing.Size(120, 31);
            this.ActuatorAddress.TabIndex = 5;
            this.ActuatorAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ActuatorAddress.Value = new decimal(new int[] {
            19,
            0,
            0,
            0});
            this.ActuatorAddress.ValueChanged += new System.EventHandler(this.ActuatorAddress_ValueChanged);
            // 
            // ActivityLED
            // 
            this.ActivityLED.Location = new System.Drawing.Point(296, 64);
            this.ActivityLED.Name = "ActivityLED";
            this.ActivityLED.On = true;
            this.ActivityLED.Size = new System.Drawing.Size(49, 50);
            this.ActivityLED.TabIndex = 6;
            this.ActivityLED.Text = "ledBulb1";
            this.ActivityLED.Click += new System.EventHandler(this.ledBulb1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Acutator Feedback Active";
            // 
            // MeasuredPositionTextBox
            // 
            this.MeasuredPositionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MeasuredPositionTextBox.Location = new System.Drawing.Point(206, 159);
            this.MeasuredPositionTextBox.Name = "MeasuredPositionTextBox";
            this.MeasuredPositionTextBox.Size = new System.Drawing.Size(139, 38);
            this.MeasuredPositionTextBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 25);
            this.label3.TabIndex = 10;
            this.label3.Text = "Measured Position";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(368, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 25);
            this.label4.TabIndex = 11;
            this.label4.Text = "mm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(368, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Measured Current";
            // 
            // MeasuredCurrentTextBox
            // 
            this.MeasuredCurrentTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MeasuredCurrentTextBox.Location = new System.Drawing.Point(206, 221);
            this.MeasuredCurrentTextBox.Name = "MeasuredCurrentTextBox";
            this.MeasuredCurrentTextBox.Size = new System.Drawing.Size(139, 38);
            this.MeasuredCurrentTextBox.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(368, 293);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 25);
            this.label8.TabIndex = 18;
            this.label8.Text = "%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 293);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 25);
            this.label9.TabIndex = 17;
            this.label9.Text = "Running Speed";
            // 
            // RunningSpeedTextBox
            // 
            this.RunningSpeedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunningSpeedTextBox.Location = new System.Drawing.Point(206, 284);
            this.RunningSpeedTextBox.Name = "RunningSpeedTextBox";
            this.RunningSpeedTextBox.Size = new System.Drawing.Size(139, 38);
            this.RunningSpeedTextBox.TabIndex = 16;
            // 
            // VoltageErrorTextBox
            // 
            this.VoltageErrorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VoltageErrorTextBox.Location = new System.Drawing.Point(206, 343);
            this.VoltageErrorTextBox.Name = "VoltageErrorTextBox";
            this.VoltageErrorTextBox.Size = new System.Drawing.Size(389, 38);
            this.VoltageErrorTextBox.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 352);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 25);
            this.label10.TabIndex = 20;
            this.label10.Text = "Voltage Error";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 416);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(187, 25);
            this.label11.TabIndex = 22;
            this.label11.Text = "Temperature Error";
            // 
            // TemperatureErrorTextBox
            // 
            this.TemperatureErrorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TemperatureErrorTextBox.Location = new System.Drawing.Point(206, 407);
            this.TemperatureErrorTextBox.Name = "TemperatureErrorTextBox";
            this.TemperatureErrorTextBox.Size = new System.Drawing.Size(389, 38);
            this.TemperatureErrorTextBox.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(33, 488);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 25);
            this.label12.TabIndex = 23;
            this.label12.Text = "Motion";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // MotionLED
            // 
            this.MotionLED.Color = System.Drawing.Color.Lime;
            this.MotionLED.Location = new System.Drawing.Point(120, 478);
            this.MotionLED.Name = "MotionLED";
            this.MotionLED.On = true;
            this.MotionLED.Size = new System.Drawing.Size(49, 50);
            this.MotionLED.TabIndex = 24;
            this.MotionLED.Text = "MotionLED";
            // 
            // ParameterLED
            // 
            this.ParameterLED.Color = System.Drawing.Color.Yellow;
            this.ParameterLED.Location = new System.Drawing.Point(120, 557);
            this.ParameterLED.Name = "ParameterLED";
            this.ParameterLED.On = true;
            this.ParameterLED.Size = new System.Drawing.Size(49, 50);
            this.ParameterLED.TabIndex = 26;
            this.ParameterLED.Text = "ParameterLED";
            this.ParameterLED.Click += new System.EventHandler(this.ledBulb2_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(-3, 557);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 25);
            this.label13.TabIndex = 25;
            this.label13.Text = "Parameter";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // SaturationLED
            // 
            this.SaturationLED.Color = System.Drawing.Color.Red;
            this.SaturationLED.Location = new System.Drawing.Point(120, 629);
            this.SaturationLED.Name = "SaturationLED";
            this.SaturationLED.On = true;
            this.SaturationLED.Size = new System.Drawing.Size(49, 50);
            this.SaturationLED.TabIndex = 28;
            this.SaturationLED.Text = "SaturationLED";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(-2, 645);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(110, 25);
            this.label14.TabIndex = 27;
            this.label14.Text = "Saturation";
            // 
            // OverloadLED
            // 
            this.OverloadLED.Color = System.Drawing.Color.Red;
            this.OverloadLED.Location = new System.Drawing.Point(420, 478);
            this.OverloadLED.Name = "OverloadLED";
            this.OverloadLED.On = true;
            this.OverloadLED.Size = new System.Drawing.Size(49, 50);
            this.OverloadLED.TabIndex = 30;
            this.OverloadLED.Text = "OverloadLED";
            this.OverloadLED.Click += new System.EventHandler(this.ledBulb3_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(306, 488);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 25);
            this.label15.TabIndex = 29;
            this.label15.Text = "Overload";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // BackDriveLED
            // 
            this.BackDriveLED.Color = System.Drawing.Color.Red;
            this.BackDriveLED.Location = new System.Drawing.Point(420, 557);
            this.BackDriveLED.Name = "BackDriveLED";
            this.BackDriveLED.On = true;
            this.BackDriveLED.Size = new System.Drawing.Size(49, 50);
            this.BackDriveLED.TabIndex = 32;
            this.BackDriveLED.Text = "BackDriveLED";
            // 
            // BackDriveLabel
            // 
            this.BackDriveLabel.AutoSize = true;
            this.BackDriveLabel.Location = new System.Drawing.Point(306, 573);
            this.BackDriveLabel.Name = "BackDriveLabel";
            this.BackDriveLabel.Size = new System.Drawing.Size(107, 25);
            this.BackDriveLabel.TabIndex = 31;
            this.BackDriveLabel.Text = "Backdrive";
            // 
            // FatalErrorLED
            // 
            this.FatalErrorLED.Color = System.Drawing.Color.Red;
            this.FatalErrorLED.Location = new System.Drawing.Point(420, 629);
            this.FatalErrorLED.Name = "FatalErrorLED";
            this.FatalErrorLED.On = true;
            this.FatalErrorLED.Size = new System.Drawing.Size(49, 50);
            this.FatalErrorLED.TabIndex = 34;
            this.FatalErrorLED.Text = "FatalErrorLED";
            // 
            // FatalErrorLabel
            // 
            this.FatalErrorLabel.AutoSize = true;
            this.FatalErrorLabel.Location = new System.Drawing.Point(266, 645);
            this.FatalErrorLabel.Name = "FatalErrorLabel";
            this.FatalErrorLabel.Size = new System.Drawing.Size(148, 25);
            this.FatalErrorLabel.TabIndex = 33;
            this.FatalErrorLabel.Text = "FatalErrorLED";
            // 
            // ElectrakHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2048, 1402);
            this.Controls.Add(this.FatalErrorLED);
            this.Controls.Add(this.FatalErrorLabel);
            this.Controls.Add(this.BackDriveLED);
            this.Controls.Add(this.BackDriveLabel);
            this.Controls.Add(this.OverloadLED);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.SaturationLED);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.ParameterLED);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.MotionLED);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TemperatureErrorTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.VoltageErrorTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.RunningSpeedTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MeasuredCurrentTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MeasuredPositionTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ActivityLED);
            this.Controls.Add(this.ActuatorAddress);
            this.Controls.Add(this.AddressLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximumSize = new System.Drawing.Size(2074, 1473);
            this.MinimumSize = new System.Drawing.Size(1774, 1473);
            this.Name = "ElectrakHD";
            this.Text = "Electrak HD Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ElectrakHD_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ActuatorAddress)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer MsgCheckTimer;
        private System.Windows.Forms.Timer FormUpdateTimer;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.NumericUpDown ActuatorAddress;
        private Bulb.LedBulb ActivityLED;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox MeasuredPositionTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox MeasuredCurrentTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox RunningSpeedTextBox;
        private System.Windows.Forms.TextBox VoltageErrorTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TemperatureErrorTextBox;
        private System.Windows.Forms.Label label12;
        private Bulb.LedBulb MotionLED;
        private Bulb.LedBulb ParameterLED;
        private System.Windows.Forms.Label label13;
        private Bulb.LedBulb SaturationLED;
        private System.Windows.Forms.Label label14;
        private Bulb.LedBulb OverloadLED;
        private System.Windows.Forms.Label label15;
        private Bulb.LedBulb BackDriveLED;
        private System.Windows.Forms.Label BackDriveLabel;
        private Bulb.LedBulb FatalErrorLED;
        private System.Windows.Forms.Label FatalErrorLabel;
    }
}

