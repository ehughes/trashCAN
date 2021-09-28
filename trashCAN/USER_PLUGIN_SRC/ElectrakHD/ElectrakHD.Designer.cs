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
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.BackDriveLabel = new System.Windows.Forms.Label();
            this.FatalErrorLabel = new System.Windows.Forms.Label();
            this.PositionNUD = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.CurrentLimitNUD = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.SpeedNUD = new System.Windows.Forms.NumericUpDown();
            this.MotionEnableCB = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.MotorControlGroupBox = new System.Windows.Forms.GroupBox();
            this.StreamCommandCB = new System.Windows.Forms.CheckBox();
            this.AcutatorFeedbackGroupBox = new System.Windows.Forms.GroupBox();
            this.PlotCurrentCB = new System.Windows.Forms.CheckBox();
            this.PlotPositionCB = new System.Windows.Forms.CheckBox();
            this.PlotButton = new System.Windows.Forms.Button();
            this.FatalErrorLED = new Bulb.LedBulb();
            this.BackDriveLED = new Bulb.LedBulb();
            this.OverloadLED = new Bulb.LedBulb();
            this.SaturationLED = new Bulb.LedBulb();
            this.ParameterLED = new Bulb.LedBulb();
            this.MotionLED = new Bulb.LedBulb();
            this.ActivityLED = new Bulb.LedBulb();
            ((System.ComponentModel.ISupportInitialize)(this.ActuatorAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PositionNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentLimitNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedNUD)).BeginInit();
            this.MotorControlGroupBox.SuspendLayout();
            this.AcutatorFeedbackGroupBox.SuspendLayout();
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
            this.AddressLabel.Location = new System.Drawing.Point(22, 25);
            this.AddressLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(92, 13);
            this.AddressLabel.TabIndex = 4;
            this.AddressLabel.Text = "Address (Decimal)";
            // 
            // ActuatorAddress
            // 
            this.ActuatorAddress.Location = new System.Drawing.Point(119, 25);
            this.ActuatorAddress.Margin = new System.Windows.Forms.Padding(2);
            this.ActuatorAddress.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.ActuatorAddress.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ActuatorAddress.Name = "ActuatorAddress";
            this.ActuatorAddress.Size = new System.Drawing.Size(60, 20);
            this.ActuatorAddress.TabIndex = 5;
            this.ActuatorAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ActuatorAddress.Value = new decimal(new int[] {
            19,
            0,
            0,
            0});
            this.ActuatorAddress.ValueChanged += new System.EventHandler(this.ActuatorAddress_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(390, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Acutator Feedback Active";
            // 
            // MeasuredPositionTextBox
            // 
            this.MeasuredPositionTextBox.Enabled = false;
            this.MeasuredPositionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MeasuredPositionTextBox.Location = new System.Drawing.Point(114, 96);
            this.MeasuredPositionTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.MeasuredPositionTextBox.Name = "MeasuredPositionTextBox";
            this.MeasuredPositionTextBox.Size = new System.Drawing.Size(72, 23);
            this.MeasuredPositionTextBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Measured Position";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(196, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "mm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 133);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 128);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Measured Current";
            // 
            // MeasuredCurrentTextBox
            // 
            this.MeasuredCurrentTextBox.Enabled = false;
            this.MeasuredCurrentTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MeasuredCurrentTextBox.Location = new System.Drawing.Point(114, 128);
            this.MeasuredCurrentTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.MeasuredCurrentTextBox.Name = "MeasuredCurrentTextBox";
            this.MeasuredCurrentTextBox.Size = new System.Drawing.Size(72, 23);
            this.MeasuredCurrentTextBox.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(196, 161);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "%";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 161);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Running Speed";
            // 
            // RunningSpeedTextBox
            // 
            this.RunningSpeedTextBox.Enabled = false;
            this.RunningSpeedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunningSpeedTextBox.Location = new System.Drawing.Point(114, 156);
            this.RunningSpeedTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.RunningSpeedTextBox.Name = "RunningSpeedTextBox";
            this.RunningSpeedTextBox.Size = new System.Drawing.Size(72, 23);
            this.RunningSpeedTextBox.TabIndex = 16;
            // 
            // VoltageErrorTextBox
            // 
            this.VoltageErrorTextBox.Enabled = false;
            this.VoltageErrorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VoltageErrorTextBox.Location = new System.Drawing.Point(114, 196);
            this.VoltageErrorTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.VoltageErrorTextBox.Name = "VoltageErrorTextBox";
            this.VoltageErrorTextBox.Size = new System.Drawing.Size(386, 23);
            this.VoltageErrorTextBox.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 200);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Voltage Error";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 230);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Temperature Error";
            // 
            // TemperatureErrorTextBox
            // 
            this.TemperatureErrorTextBox.Enabled = false;
            this.TemperatureErrorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TemperatureErrorTextBox.Location = new System.Drawing.Point(114, 225);
            this.TemperatureErrorTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.TemperatureErrorTextBox.Name = "TemperatureErrorTextBox";
            this.TemperatureErrorTextBox.Size = new System.Drawing.Size(386, 23);
            this.TemperatureErrorTextBox.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(337, 74);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Motion";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(319, 110);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Parameter";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(320, 156);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Saturation";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(474, 74);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Overload";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // BackDriveLabel
            // 
            this.BackDriveLabel.AutoSize = true;
            this.BackDriveLabel.Location = new System.Drawing.Point(474, 119);
            this.BackDriveLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BackDriveLabel.Name = "BackDriveLabel";
            this.BackDriveLabel.Size = new System.Drawing.Size(55, 13);
            this.BackDriveLabel.TabIndex = 31;
            this.BackDriveLabel.Text = "Backdrive";
            // 
            // FatalErrorLabel
            // 
            this.FatalErrorLabel.AutoSize = true;
            this.FatalErrorLabel.Location = new System.Drawing.Point(454, 156);
            this.FatalErrorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FatalErrorLabel.Name = "FatalErrorLabel";
            this.FatalErrorLabel.Size = new System.Drawing.Size(73, 13);
            this.FatalErrorLabel.TabIndex = 33;
            this.FatalErrorLabel.Text = "FatalErrorLED";
            // 
            // PositionNUD
            // 
            this.PositionNUD.DecimalPlaces = 1;
            this.PositionNUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.PositionNUD.Location = new System.Drawing.Point(97, 47);
            this.PositionNUD.Margin = new System.Windows.Forms.Padding(2);
            this.PositionNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PositionNUD.Name = "PositionNUD";
            this.PositionNUD.Size = new System.Drawing.Size(77, 20);
            this.PositionNUD.TabIndex = 35;
            this.PositionNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PositionNUD.Value = new decimal(new int[] {
            450,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 48);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Position";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(5, 77);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 13);
            this.label16.TabIndex = 38;
            this.label16.Text = "CurrentLimit";
            // 
            // CurrentLimitNUD
            // 
            this.CurrentLimitNUD.DecimalPlaces = 1;
            this.CurrentLimitNUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.CurrentLimitNUD.Location = new System.Drawing.Point(97, 77);
            this.CurrentLimitNUD.Margin = new System.Windows.Forms.Padding(2);
            this.CurrentLimitNUD.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.CurrentLimitNUD.Name = "CurrentLimitNUD";
            this.CurrentLimitNUD.Size = new System.Drawing.Size(77, 20);
            this.CurrentLimitNUD.TabIndex = 37;
            this.CurrentLimitNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CurrentLimitNUD.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 104);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 13);
            this.label17.TabIndex = 40;
            this.label17.Text = "Speed";
            // 
            // SpeedNUD
            // 
            this.SpeedNUD.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.SpeedNUD.Location = new System.Drawing.Point(97, 103);
            this.SpeedNUD.Margin = new System.Windows.Forms.Padding(2);
            this.SpeedNUD.Name = "SpeedNUD";
            this.SpeedNUD.Size = new System.Drawing.Size(74, 20);
            this.SpeedNUD.TabIndex = 39;
            this.SpeedNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SpeedNUD.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // MotionEnableCB
            // 
            this.MotionEnableCB.AutoSize = true;
            this.MotionEnableCB.Location = new System.Drawing.Point(128, 20);
            this.MotionEnableCB.Margin = new System.Windows.Forms.Padding(2);
            this.MotionEnableCB.Name = "MotionEnableCB";
            this.MotionEnableCB.Size = new System.Drawing.Size(94, 17);
            this.MotionEnableCB.TabIndex = 42;
            this.MotionEnableCB.Text = "Motion Enable";
            this.MotionEnableCB.UseVisualStyleBackColor = true;
            this.MotionEnableCB.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(185, 104);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(15, 13);
            this.label18.TabIndex = 45;
            this.label18.Text = "%";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(185, 78);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(14, 13);
            this.label19.TabIndex = 44;
            this.label19.Text = "A";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(185, 50);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(23, 13);
            this.label20.TabIndex = 43;
            this.label20.Text = "mm";
            // 
            // MotorControlGroupBox
            // 
            this.MotorControlGroupBox.Controls.Add(this.StreamCommandCB);
            this.MotorControlGroupBox.Controls.Add(this.label18);
            this.MotorControlGroupBox.Controls.Add(this.label19);
            this.MotorControlGroupBox.Controls.Add(this.label20);
            this.MotorControlGroupBox.Controls.Add(this.MotionEnableCB);
            this.MotorControlGroupBox.Controls.Add(this.label17);
            this.MotorControlGroupBox.Controls.Add(this.SpeedNUD);
            this.MotorControlGroupBox.Controls.Add(this.label16);
            this.MotorControlGroupBox.Controls.Add(this.CurrentLimitNUD);
            this.MotorControlGroupBox.Controls.Add(this.label7);
            this.MotorControlGroupBox.Controls.Add(this.PositionNUD);
            this.MotorControlGroupBox.Location = new System.Drawing.Point(6, 294);
            this.MotorControlGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.MotorControlGroupBox.Name = "MotorControlGroupBox";
            this.MotorControlGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.MotorControlGroupBox.Size = new System.Drawing.Size(580, 195);
            this.MotorControlGroupBox.TabIndex = 52;
            this.MotorControlGroupBox.TabStop = false;
            this.MotorControlGroupBox.Text = "Actuator Control";
            // 
            // StreamCommandCB
            // 
            this.StreamCommandCB.AutoSize = true;
            this.StreamCommandCB.Location = new System.Drawing.Point(8, 20);
            this.StreamCommandCB.Margin = new System.Windows.Forms.Padding(2);
            this.StreamCommandCB.Name = "StreamCommandCB";
            this.StreamCommandCB.Size = new System.Drawing.Size(109, 17);
            this.StreamCommandCB.TabIndex = 54;
            this.StreamCommandCB.Text = "Stream Command";
            this.StreamCommandCB.UseVisualStyleBackColor = true;
            this.StreamCommandCB.CheckedChanged += new System.EventHandler(this.StreamCommandCB_CheckedChanged);
            // 
            // AcutatorFeedbackGroupBox
            // 
            this.AcutatorFeedbackGroupBox.Controls.Add(this.PlotCurrentCB);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.PlotPositionCB);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.PlotButton);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.FatalErrorLED);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.FatalErrorLabel);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.BackDriveLED);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.BackDriveLabel);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.OverloadLED);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.label15);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.SaturationLED);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.label14);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.ParameterLED);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.label13);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.MotionLED);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.label12);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.label11);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.TemperatureErrorTextBox);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.label10);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.VoltageErrorTextBox);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.label8);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.label9);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.RunningSpeedTextBox);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.label5);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.label6);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.MeasuredCurrentTextBox);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.label4);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.label3);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.label2);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.MeasuredPositionTextBox);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.label1);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.ActivityLED);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.ActuatorAddress);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.AddressLabel);
            this.AcutatorFeedbackGroupBox.Location = new System.Drawing.Point(6, 6);
            this.AcutatorFeedbackGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.AcutatorFeedbackGroupBox.Name = "AcutatorFeedbackGroupBox";
            this.AcutatorFeedbackGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.AcutatorFeedbackGroupBox.Size = new System.Drawing.Size(580, 279);
            this.AcutatorFeedbackGroupBox.TabIndex = 53;
            this.AcutatorFeedbackGroupBox.TabStop = false;
            this.AcutatorFeedbackGroupBox.Text = "Acutator Feedback";
            // 
            // PlotCurrentCB
            // 
            this.PlotCurrentCB.AutoSize = true;
            this.PlotCurrentCB.Checked = true;
            this.PlotCurrentCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PlotCurrentCB.Location = new System.Drawing.Point(260, 128);
            this.PlotCurrentCB.Margin = new System.Windows.Forms.Padding(2);
            this.PlotCurrentCB.Name = "PlotCurrentCB";
            this.PlotCurrentCB.Size = new System.Drawing.Size(15, 14);
            this.PlotCurrentCB.TabIndex = 49;
            this.PlotCurrentCB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.PlotCurrentCB.UseVisualStyleBackColor = true;
            // 
            // PlotPositionCB
            // 
            this.PlotPositionCB.AutoSize = true;
            this.PlotPositionCB.Checked = true;
            this.PlotPositionCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PlotPositionCB.Location = new System.Drawing.Point(260, 99);
            this.PlotPositionCB.Margin = new System.Windows.Forms.Padding(2);
            this.PlotPositionCB.Name = "PlotPositionCB";
            this.PlotPositionCB.Size = new System.Drawing.Size(15, 14);
            this.PlotPositionCB.TabIndex = 48;
            this.PlotPositionCB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.PlotPositionCB.UseVisualStyleBackColor = true;
            // 
            // PlotButton
            // 
            this.PlotButton.BackgroundImage = global::ElectrakHD.Properties.Resources.PLot;
            this.PlotButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PlotButton.Location = new System.Drawing.Point(232, 16);
            this.PlotButton.Margin = new System.Windows.Forms.Padding(2);
            this.PlotButton.Name = "PlotButton";
            this.PlotButton.Size = new System.Drawing.Size(73, 72);
            this.PlotButton.TabIndex = 47;
            this.PlotButton.UseVisualStyleBackColor = true;
            this.PlotButton.Click += new System.EventHandler(this.PlotCurrentButton_Click);
            // 
            // FatalErrorLED
            // 
            this.FatalErrorLED.Color = System.Drawing.Color.Red;
            this.FatalErrorLED.Location = new System.Drawing.Point(530, 148);
            this.FatalErrorLED.Margin = new System.Windows.Forms.Padding(2);
            this.FatalErrorLED.Name = "FatalErrorLED";
            this.FatalErrorLED.On = true;
            this.FatalErrorLED.Size = new System.Drawing.Size(24, 26);
            this.FatalErrorLED.TabIndex = 34;
            this.FatalErrorLED.Text = "FatalErrorLED";
            // 
            // BackDriveLED
            // 
            this.BackDriveLED.Color = System.Drawing.Color.Red;
            this.BackDriveLED.Location = new System.Drawing.Point(530, 110);
            this.BackDriveLED.Margin = new System.Windows.Forms.Padding(2);
            this.BackDriveLED.Name = "BackDriveLED";
            this.BackDriveLED.On = true;
            this.BackDriveLED.Size = new System.Drawing.Size(24, 26);
            this.BackDriveLED.TabIndex = 32;
            this.BackDriveLED.Text = "BackDriveLED";
            // 
            // OverloadLED
            // 
            this.OverloadLED.Color = System.Drawing.Color.Red;
            this.OverloadLED.Location = new System.Drawing.Point(530, 69);
            this.OverloadLED.Margin = new System.Windows.Forms.Padding(2);
            this.OverloadLED.Name = "OverloadLED";
            this.OverloadLED.On = true;
            this.OverloadLED.Size = new System.Drawing.Size(24, 26);
            this.OverloadLED.TabIndex = 30;
            this.OverloadLED.Text = "OverloadLED";
            this.OverloadLED.Click += new System.EventHandler(this.ledBulb3_Click);
            // 
            // SaturationLED
            // 
            this.SaturationLED.Color = System.Drawing.Color.Red;
            this.SaturationLED.Location = new System.Drawing.Point(380, 148);
            this.SaturationLED.Margin = new System.Windows.Forms.Padding(2);
            this.SaturationLED.Name = "SaturationLED";
            this.SaturationLED.On = true;
            this.SaturationLED.Size = new System.Drawing.Size(24, 26);
            this.SaturationLED.TabIndex = 28;
            this.SaturationLED.Text = "SaturationLED";
            // 
            // ParameterLED
            // 
            this.ParameterLED.Color = System.Drawing.Color.Yellow;
            this.ParameterLED.Location = new System.Drawing.Point(380, 110);
            this.ParameterLED.Margin = new System.Windows.Forms.Padding(2);
            this.ParameterLED.Name = "ParameterLED";
            this.ParameterLED.On = true;
            this.ParameterLED.Size = new System.Drawing.Size(24, 26);
            this.ParameterLED.TabIndex = 26;
            this.ParameterLED.Text = "ParameterLED";
            this.ParameterLED.Click += new System.EventHandler(this.ledBulb2_Click);
            // 
            // MotionLED
            // 
            this.MotionLED.Color = System.Drawing.Color.Lime;
            this.MotionLED.Location = new System.Drawing.Point(380, 69);
            this.MotionLED.Margin = new System.Windows.Forms.Padding(2);
            this.MotionLED.Name = "MotionLED";
            this.MotionLED.On = true;
            this.MotionLED.Size = new System.Drawing.Size(24, 26);
            this.MotionLED.TabIndex = 24;
            this.MotionLED.Text = "MotionLED";
            // 
            // ActivityLED
            // 
            this.ActivityLED.Location = new System.Drawing.Point(530, 16);
            this.ActivityLED.Margin = new System.Windows.Forms.Padding(2);
            this.ActivityLED.Name = "ActivityLED";
            this.ActivityLED.On = true;
            this.ActivityLED.Size = new System.Drawing.Size(24, 26);
            this.ActivityLED.TabIndex = 6;
            this.ActivityLED.Text = "ledBulb1";
            this.ActivityLED.Click += new System.EventHandler(this.ledBulb1_Click);
            // 
            // ElectrakHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 499);
            this.Controls.Add(this.AcutatorFeedbackGroupBox);
            this.Controls.Add(this.MotorControlGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1045, 785);
            this.MinimumSize = new System.Drawing.Size(408, 435);
            this.Name = "ElectrakHD";
            this.Text = "Electrak HD Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ElectrakHD_FormClosing);
            this.Load += new System.EventHandler(this.ElectrakHD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ActuatorAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PositionNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentLimitNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedNUD)).EndInit();
            this.MotorControlGroupBox.ResumeLayout(false);
            this.MotorControlGroupBox.PerformLayout();
            this.AcutatorFeedbackGroupBox.ResumeLayout(false);
            this.AcutatorFeedbackGroupBox.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.NumericUpDown PositionNUD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown CurrentLimitNUD;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown SpeedNUD;
        private System.Windows.Forms.CheckBox MotionEnableCB;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox MotorControlGroupBox;
        private System.Windows.Forms.GroupBox AcutatorFeedbackGroupBox;
        private System.Windows.Forms.Button PlotButton;
        private System.Windows.Forms.CheckBox StreamCommandCB;
        private System.Windows.Forms.CheckBox PlotCurrentCB;
        private System.Windows.Forms.CheckBox PlotPositionCB;
    }
}

