namespace ElectrakHDx2
{
    partial class ElectrakHDx2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElectrakHDx2));
            this.MsgCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.FormUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.AddressA_Label = new System.Windows.Forms.Label();
            this.ActuatorAddressA = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.BackDriveLabel = new System.Windows.Forms.Label();
            this.FatalErrorLabel = new System.Windows.Forms.Label();
            this.PositionNUD = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.CurrentLimitNUD = new System.Windows.Forms.NumericUpDown();
            this.TargetMaxSpeedLabel = new System.Windows.Forms.Label();
            this.SpeedNUD = new System.Windows.Forms.NumericUpDown();
            this.MotionEnableCB = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.MotorControlGroupBox = new System.Windows.Forms.GroupBox();
            this.EnableSyncCheckBox = new System.Windows.Forms.CheckBox();
            this.KILL = new System.Windows.Forms.Button();
            this.AcutatorFeedbackGroupBox = new System.Windows.Forms.GroupBox();
            this.ControlStateTextBox = new System.Windows.Forms.TextBox();
            this.ActuatorAddressB = new System.Windows.Forms.NumericUpDown();
            this.AddressB_Label = new System.Windows.Forms.Label();
            this.RetractNUD = new System.Windows.Forms.NumericUpDown();
            this.ExtendNUD = new System.Windows.Forms.NumericUpDown();
            this.ExtendButton = new System.Windows.Forms.Button();
            this.RetractButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.OffsetA_NUD = new System.Windows.Forms.NumericUpDown();
            this.OffsetB_NUD = new System.Windows.Forms.NumericUpDown();
            this.OffsetALabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.P_NUD = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ActuatorAddressA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PositionNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentLimitNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedNUD)).BeginInit();
            this.MotorControlGroupBox.SuspendLayout();
            this.AcutatorFeedbackGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ActuatorAddressB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetractNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExtendNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetA_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetB_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P_NUD)).BeginInit();
            this.SuspendLayout();
            // 
            // MsgCheckTimer
            // 
            this.MsgCheckTimer.Enabled = true;
            this.MsgCheckTimer.Interval = 1;
            this.MsgCheckTimer.Tick += new System.EventHandler(this.MsgCheckTimer_Tick);
            // 
            // FormUpdateTimer
            // 
            this.FormUpdateTimer.Enabled = true;
            this.FormUpdateTimer.Interval = 50;
            this.FormUpdateTimer.Tick += new System.EventHandler(this.FormUpdateTimer_Tick);
            // 
            // AddressA_Label
            // 
            this.AddressA_Label.AutoSize = true;
            this.AddressA_Label.Location = new System.Drawing.Point(18, 41);
            this.AddressA_Label.Name = "AddressA_Label";
            this.AddressA_Label.Size = new System.Drawing.Size(208, 25);
            this.AddressA_Label.TabIndex = 4;
            this.AddressA_Label.Text = "Address A (Decimal)";
            // 
            // ActuatorAddressA
            // 
            this.ActuatorAddressA.Location = new System.Drawing.Point(23, 69);
            this.ActuatorAddressA.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.ActuatorAddressA.Minimum = new decimal(new int[] {
            19,
            0,
            0,
            0});
            this.ActuatorAddressA.Name = "ActuatorAddressA";
            this.ActuatorAddressA.Size = new System.Drawing.Size(120, 31);
            this.ActuatorAddressA.TabIndex = 5;
            this.ActuatorAddressA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ActuatorAddressA.Value = new decimal(new int[] {
            19,
            0,
            0,
            0});
            this.ActuatorAddressA.ValueChanged += new System.EventHandler(this.ActuatorAddress_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 9;
            // 
            // BackDriveLabel
            // 
            this.BackDriveLabel.AutoSize = true;
            this.BackDriveLabel.Location = new System.Drawing.Point(947, 228);
            this.BackDriveLabel.Name = "BackDriveLabel";
            this.BackDriveLabel.Size = new System.Drawing.Size(107, 25);
            this.BackDriveLabel.TabIndex = 31;
            this.BackDriveLabel.Text = "Backdrive";
            // 
            // FatalErrorLabel
            // 
            this.FatalErrorLabel.AutoSize = true;
            this.FatalErrorLabel.Location = new System.Drawing.Point(907, 300);
            this.FatalErrorLabel.Name = "FatalErrorLabel";
            this.FatalErrorLabel.Size = new System.Drawing.Size(148, 25);
            this.FatalErrorLabel.TabIndex = 33;
            this.FatalErrorLabel.Text = "FatalErrorLED";
            // 
            // PositionNUD
            // 
            this.PositionNUD.DecimalPlaces = 1;
            this.PositionNUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionNUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.PositionNUD.Location = new System.Drawing.Point(148, 253);
            this.PositionNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.PositionNUD.Name = "PositionNUD";
            this.PositionNUD.Size = new System.Drawing.Size(154, 38);
            this.PositionNUD.TabIndex = 35;
            this.PositionNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PositionNUD.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.PositionNUD.ValueChanged += new System.EventHandler(this.PositionNUD_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(800, 212);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(162, 31);
            this.label16.TabIndex = 38;
            this.label16.Text = "CurrentLimit";
            // 
            // CurrentLimitNUD
            // 
            this.CurrentLimitNUD.DecimalPlaces = 1;
            this.CurrentLimitNUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentLimitNUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.CurrentLimitNUD.Location = new System.Drawing.Point(968, 210);
            this.CurrentLimitNUD.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.CurrentLimitNUD.Name = "CurrentLimitNUD";
            this.CurrentLimitNUD.Size = new System.Drawing.Size(154, 38);
            this.CurrentLimitNUD.TabIndex = 37;
            this.CurrentLimitNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CurrentLimitNUD.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // TargetMaxSpeedLabel
            // 
            this.TargetMaxSpeedLabel.AutoSize = true;
            this.TargetMaxSpeedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TargetMaxSpeedLabel.Location = new System.Drawing.Point(820, 255);
            this.TargetMaxSpeedLabel.Name = "TargetMaxSpeedLabel";
            this.TargetMaxSpeedLabel.Size = new System.Drawing.Size(142, 31);
            this.TargetMaxSpeedLabel.TabIndex = 40;
            this.TargetMaxSpeedLabel.Text = "MaxSpeed";
            // 
            // SpeedNUD
            // 
            this.SpeedNUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpeedNUD.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.SpeedNUD.Location = new System.Drawing.Point(968, 262);
            this.SpeedNUD.Name = "SpeedNUD";
            this.SpeedNUD.Size = new System.Drawing.Size(154, 38);
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
            this.MotionEnableCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MotionEnableCB.Location = new System.Drawing.Point(735, 30);
            this.MotionEnableCB.Name = "MotionEnableCB";
            this.MotionEnableCB.Size = new System.Drawing.Size(396, 65);
            this.MotionEnableCB.TabIndex = 42;
            this.MotionEnableCB.Text = "Motion Enable";
            this.MotionEnableCB.UseVisualStyleBackColor = true;
            this.MotionEnableCB.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(1128, 269);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 31);
            this.label18.TabIndex = 45;
            this.label18.Text = "%";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(1128, 217);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 31);
            this.label19.TabIndex = 44;
            this.label19.Text = "A";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(308, 252);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 37);
            this.label20.TabIndex = 43;
            this.label20.Text = "mm";
            // 
            // MotorControlGroupBox
            // 
            this.MotorControlGroupBox.Controls.Add(this.label4);
            this.MotorControlGroupBox.Controls.Add(this.P_NUD);
            this.MotorControlGroupBox.Controls.Add(this.label5);
            this.MotorControlGroupBox.Controls.Add(this.OffsetALabel);
            this.MotorControlGroupBox.Controls.Add(this.OffsetB_NUD);
            this.MotorControlGroupBox.Controls.Add(this.OffsetA_NUD);
            this.MotorControlGroupBox.Controls.Add(this.button1);
            this.MotorControlGroupBox.Controls.Add(this.label3);
            this.MotorControlGroupBox.Controls.Add(this.label1);
            this.MotorControlGroupBox.Controls.Add(this.RetractButton);
            this.MotorControlGroupBox.Controls.Add(this.ExtendButton);
            this.MotorControlGroupBox.Controls.Add(this.ExtendNUD);
            this.MotorControlGroupBox.Controls.Add(this.RetractNUD);
            this.MotorControlGroupBox.Controls.Add(this.EnableSyncCheckBox);
            this.MotorControlGroupBox.Controls.Add(this.KILL);
            this.MotorControlGroupBox.Controls.Add(this.label18);
            this.MotorControlGroupBox.Controls.Add(this.label19);
            this.MotorControlGroupBox.Controls.Add(this.label20);
            this.MotorControlGroupBox.Controls.Add(this.MotionEnableCB);
            this.MotorControlGroupBox.Controls.Add(this.TargetMaxSpeedLabel);
            this.MotorControlGroupBox.Controls.Add(this.SpeedNUD);
            this.MotorControlGroupBox.Controls.Add(this.label16);
            this.MotorControlGroupBox.Controls.Add(this.CurrentLimitNUD);
            this.MotorControlGroupBox.Controls.Add(this.PositionNUD);
            this.MotorControlGroupBox.Location = new System.Drawing.Point(12, 565);
            this.MotorControlGroupBox.Name = "MotorControlGroupBox";
            this.MotorControlGroupBox.Size = new System.Drawing.Size(1160, 495);
            this.MotorControlGroupBox.TabIndex = 52;
            this.MotorControlGroupBox.TabStop = false;
            this.MotorControlGroupBox.Text = "Actuator Control x2";
            // 
            // EnableSyncCheckBox
            // 
            this.EnableSyncCheckBox.AutoSize = true;
            this.EnableSyncCheckBox.Checked = true;
            this.EnableSyncCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnableSyncCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnableSyncCheckBox.Location = new System.Drawing.Point(790, 315);
            this.EnableSyncCheckBox.Name = "EnableSyncCheckBox";
            this.EnableSyncCheckBox.Size = new System.Drawing.Size(355, 65);
            this.EnableSyncCheckBox.TabIndex = 47;
            this.EnableSyncCheckBox.Text = "Enable Sync";
            this.EnableSyncCheckBox.UseVisualStyleBackColor = true;
            // 
            // KILL
            // 
            this.KILL.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KILL.Location = new System.Drawing.Point(6, 320);
            this.KILL.Name = "KILL";
            this.KILL.Size = new System.Drawing.Size(412, 148);
            this.KILL.TabIndex = 46;
            this.KILL.Text = "STOP";
            this.KILL.UseVisualStyleBackColor = true;
            this.KILL.Click += new System.EventHandler(this.KILL_Click);
            // 
            // AcutatorFeedbackGroupBox
            // 
            this.AcutatorFeedbackGroupBox.Controls.Add(this.ControlStateTextBox);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.ActuatorAddressB);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.AddressB_Label);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.label2);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.ActuatorAddressA);
            this.AcutatorFeedbackGroupBox.Controls.Add(this.AddressA_Label);
            this.AcutatorFeedbackGroupBox.Location = new System.Drawing.Point(12, 12);
            this.AcutatorFeedbackGroupBox.Name = "AcutatorFeedbackGroupBox";
            this.AcutatorFeedbackGroupBox.Size = new System.Drawing.Size(1160, 536);
            this.AcutatorFeedbackGroupBox.TabIndex = 53;
            this.AcutatorFeedbackGroupBox.TabStop = false;
            this.AcutatorFeedbackGroupBox.Text = "Acutator Feedback x2";
            // 
            // ControlStateTextBox
            // 
            this.ControlStateTextBox.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ControlStateTextBox.Font = new System.Drawing.Font("Consolas", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlStateTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.ControlStateTextBox.Location = new System.Drawing.Point(23, 137);
            this.ControlStateTextBox.Multiline = true;
            this.ControlStateTextBox.Name = "ControlStateTextBox";
            this.ControlStateTextBox.Size = new System.Drawing.Size(1108, 373);
            this.ControlStateTextBox.TabIndex = 52;
            // 
            // ActuatorAddressB
            // 
            this.ActuatorAddressB.Location = new System.Drawing.Point(349, 81);
            this.ActuatorAddressB.Maximum = new decimal(new int[] {
            26,
            0,
            0,
            0});
            this.ActuatorAddressB.Minimum = new decimal(new int[] {
            19,
            0,
            0,
            0});
            this.ActuatorAddressB.Name = "ActuatorAddressB";
            this.ActuatorAddressB.Size = new System.Drawing.Size(120, 31);
            this.ActuatorAddressB.TabIndex = 51;
            this.ActuatorAddressB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ActuatorAddressB.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // AddressB_Label
            // 
            this.AddressB_Label.AutoSize = true;
            this.AddressB_Label.Location = new System.Drawing.Point(344, 41);
            this.AddressB_Label.Name = "AddressB_Label";
            this.AddressB_Label.Size = new System.Drawing.Size(208, 25);
            this.AddressB_Label.TabIndex = 50;
            this.AddressB_Label.Text = "Address B (Decimal)";
            // 
            // RetractNUD
            // 
            this.RetractNUD.DecimalPlaces = 1;
            this.RetractNUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RetractNUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.RetractNUD.Location = new System.Drawing.Point(271, 91);
            this.RetractNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.RetractNUD.Name = "RetractNUD";
            this.RetractNUD.Size = new System.Drawing.Size(154, 38);
            this.RetractNUD.TabIndex = 48;
            this.RetractNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RetractNUD.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            // 
            // ExtendNUD
            // 
            this.ExtendNUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtendNUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ExtendNUD.Location = new System.Drawing.Point(2, 91);
            this.ExtendNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ExtendNUD.Name = "ExtendNUD";
            this.ExtendNUD.Size = new System.Drawing.Size(154, 38);
            this.ExtendNUD.TabIndex = 49;
            this.ExtendNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ExtendNUD.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // ExtendButton
            // 
            this.ExtendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExtendButton.Location = new System.Drawing.Point(2, 34);
            this.ExtendButton.Name = "ExtendButton";
            this.ExtendButton.Size = new System.Drawing.Size(147, 51);
            this.ExtendButton.TabIndex = 50;
            this.ExtendButton.Text = "Extend";
            this.ExtendButton.UseVisualStyleBackColor = true;
            // 
            // RetractButton
            // 
            this.RetractButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RetractButton.Location = new System.Drawing.Point(271, 34);
            this.RetractButton.Name = "RetractButton";
            this.RetractButton.Size = new System.Drawing.Size(147, 51);
            this.RetractButton.TabIndex = 51;
            this.RetractButton.Text = "Retract";
            this.RetractButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(159, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 37);
            this.label1.TabIndex = 52;
            this.label1.Text = "mm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(431, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 37);
            this.label3.TabIndex = 53;
            this.label3.Text = "mm";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(112, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 70);
            this.button1.TabIndex = 54;
            this.button1.Text = "Set Position";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // OffsetA_NUD
            // 
            this.OffsetA_NUD.DecimalPlaces = 1;
            this.OffsetA_NUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OffsetA_NUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.OffsetA_NUD.Location = new System.Drawing.Point(968, 101);
            this.OffsetA_NUD.Name = "OffsetA_NUD";
            this.OffsetA_NUD.Size = new System.Drawing.Size(154, 38);
            this.OffsetA_NUD.TabIndex = 55;
            this.OffsetA_NUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OffsetB_NUD
            // 
            this.OffsetB_NUD.DecimalPlaces = 1;
            this.OffsetB_NUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OffsetB_NUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.OffsetB_NUD.Location = new System.Drawing.Point(968, 152);
            this.OffsetB_NUD.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.OffsetB_NUD.Name = "OffsetB_NUD";
            this.OffsetB_NUD.Size = new System.Drawing.Size(154, 38);
            this.OffsetB_NUD.TabIndex = 56;
            this.OffsetB_NUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // OffsetALabel
            // 
            this.OffsetALabel.AutoSize = true;
            this.OffsetALabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OffsetALabel.Location = new System.Drawing.Point(847, 108);
            this.OffsetALabel.Name = "OffsetALabel";
            this.OffsetALabel.Size = new System.Drawing.Size(113, 31);
            this.OffsetALabel.TabIndex = 57;
            this.OffsetALabel.Text = "Offset A";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(847, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 31);
            this.label5.TabIndex = 58;
            this.label5.Text = "Offset B";
            // 
            // P_NUD
            // 
            this.P_NUD.DecimalPlaces = 1;
            this.P_NUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P_NUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.P_NUD.Location = new System.Drawing.Point(948, 386);
            this.P_NUD.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.P_NUD.Name = "P_NUD";
            this.P_NUD.Size = new System.Drawing.Size(139, 38);
            this.P_NUD.TabIndex = 59;
            this.P_NUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.P_NUD.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(910, 388);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 31);
            this.label4.TabIndex = 60;
            this.label4.Text = "P";
            // 
            // ElectrakHDx2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 1095);
            this.Controls.Add(this.AcutatorFeedbackGroupBox);
            this.Controls.Add(this.MotorControlGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximumSize = new System.Drawing.Size(2074, 1473);
            this.MinimumSize = new System.Drawing.Size(800, 800);
            this.Name = "ElectrakHDx2";
            this.Text = "Electrak HD Controller x2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ElectrakHD_FormClosing);
            this.Load += new System.EventHandler(this.ElectrakHD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ActuatorAddressA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PositionNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentLimitNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedNUD)).EndInit();
            this.MotorControlGroupBox.ResumeLayout(false);
            this.MotorControlGroupBox.PerformLayout();
            this.AcutatorFeedbackGroupBox.ResumeLayout(false);
            this.AcutatorFeedbackGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ActuatorAddressB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RetractNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExtendNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetA_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetB_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P_NUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer MsgCheckTimer;
        private System.Windows.Forms.Timer FormUpdateTimer;
        private System.Windows.Forms.Label AddressA_Label;
        private System.Windows.Forms.NumericUpDown ActuatorAddressA;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label BackDriveLabel;

        private System.Windows.Forms.Label FatalErrorLabel;
        private System.Windows.Forms.NumericUpDown PositionNUD;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown CurrentLimitNUD;
        private System.Windows.Forms.Label TargetMaxSpeedLabel;
        private System.Windows.Forms.NumericUpDown SpeedNUD;
        private System.Windows.Forms.CheckBox MotionEnableCB;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox MotorControlGroupBox;
        private System.Windows.Forms.GroupBox AcutatorFeedbackGroupBox;
        private System.Windows.Forms.NumericUpDown ActuatorAddressB;
        private System.Windows.Forms.Label AddressB_Label;
        private System.Windows.Forms.Button KILL;
        private System.Windows.Forms.TextBox ControlStateTextBox;
        private System.Windows.Forms.CheckBox EnableSyncCheckBox;
        private System.Windows.Forms.NumericUpDown ExtendNUD;
        private System.Windows.Forms.NumericUpDown RetractNUD;
        private System.Windows.Forms.Button RetractButton;
        private System.Windows.Forms.Button ExtendButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown P_NUD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label OffsetALabel;
        private System.Windows.Forms.NumericUpDown OffsetB_NUD;
        private System.Windows.Forms.NumericUpDown OffsetA_NUD;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}

