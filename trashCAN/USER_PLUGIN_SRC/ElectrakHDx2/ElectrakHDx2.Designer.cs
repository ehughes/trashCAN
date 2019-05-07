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
            this.AdjustPositionInPlotsW_OffsetCheckBox = new System.Windows.Forms.CheckBox();
            this.EnableCurrentPlotCheckBox = new System.Windows.Forms.CheckBox();
            this.AppliedOffsetBTextBox = new System.Windows.Forms.TextBox();
            this.AppliedOffsetATextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.RaiseOffsetB_NUD = new System.Windows.Forms.NumericUpDown();
            this.RaiseOffsetA_NUD = new System.Windows.Forms.NumericUpDown();
            this.EnablePositionPlotCB = new System.Windows.Forms.CheckBox();
            this.ShowPlotsButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.P_NUD = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.PositionSetpointLabel = new System.Windows.Forms.Label();
            this.LowerOffsetB_NUD = new System.Windows.Forms.NumericUpDown();
            this.LowerOffsetA_NUD = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RaisePlatformButton = new System.Windows.Forms.Button();
            this.LowerPlatformButton = new System.Windows.Forms.Button();
            this.LowerNUD = new System.Windows.Forms.NumericUpDown();
            this.RaiseNUD = new System.Windows.Forms.NumericUpDown();
            this.EnableSyncCheckBox = new System.Windows.Forms.CheckBox();
            this.KILL = new System.Windows.Forms.Button();
            this.AcutatorFeedbackGroupBox = new System.Windows.Forms.GroupBox();
            this.ControlStateTextBox = new System.Windows.Forms.TextBox();
            this.ActuatorAddressB = new System.Windows.Forms.NumericUpDown();
            this.AddressB_Label = new System.Windows.Forms.Label();
            this.OffsetGroupBox = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ActuatorAddressA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PositionNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentLimitNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedNUD)).BeginInit();
            this.MotorControlGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RaiseOffsetB_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RaiseOffsetA_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowerOffsetB_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowerOffsetA_NUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowerNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RaiseNUD)).BeginInit();
            this.AcutatorFeedbackGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ActuatorAddressB)).BeginInit();
            this.OffsetGroupBox.SuspendLayout();
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
            this.PositionNUD.Location = new System.Drawing.Point(348, 446);
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
            this.label16.Location = new System.Drawing.Point(720, 92);
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
            this.CurrentLimitNUD.Location = new System.Drawing.Point(888, 92);
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
            this.TargetMaxSpeedLabel.Location = new System.Drawing.Point(740, 146);
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
            this.SpeedNUD.Location = new System.Drawing.Point(888, 144);
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
            this.MotionEnableCB.Font = new System.Drawing.Font("Consolas", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MotionEnableCB.Location = new System.Drawing.Point(707, 30);
            this.MotionEnableCB.Name = "MotionEnableCB";
            this.MotionEnableCB.Size = new System.Drawing.Size(311, 47);
            this.MotionEnableCB.TabIndex = 42;
            this.MotionEnableCB.Text = "Motion Enable";
            this.MotionEnableCB.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(1048, 151);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(38, 31);
            this.label18.TabIndex = 45;
            this.label18.Text = "%";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(1048, 99);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 31);
            this.label19.TabIndex = 44;
            this.label19.Text = "A";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(522, 446);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 37);
            this.label20.TabIndex = 43;
            this.label20.Text = "mm";
            // 
            // MotorControlGroupBox
            // 
            this.MotorControlGroupBox.Controls.Add(this.OffsetGroupBox);
            this.MotorControlGroupBox.Controls.Add(this.AdjustPositionInPlotsW_OffsetCheckBox);
            this.MotorControlGroupBox.Controls.Add(this.EnableCurrentPlotCheckBox);
            this.MotorControlGroupBox.Controls.Add(this.EnablePositionPlotCB);
            this.MotorControlGroupBox.Controls.Add(this.ShowPlotsButton);
            this.MotorControlGroupBox.Controls.Add(this.label4);
            this.MotorControlGroupBox.Controls.Add(this.P_NUD);
            this.MotorControlGroupBox.Controls.Add(this.PositionSetpointLabel);
            this.MotorControlGroupBox.Controls.Add(this.label3);
            this.MotorControlGroupBox.Controls.Add(this.label1);
            this.MotorControlGroupBox.Controls.Add(this.RaisePlatformButton);
            this.MotorControlGroupBox.Controls.Add(this.LowerPlatformButton);
            this.MotorControlGroupBox.Controls.Add(this.LowerNUD);
            this.MotorControlGroupBox.Controls.Add(this.RaiseNUD);
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
            this.MotorControlGroupBox.Size = new System.Drawing.Size(1104, 705);
            this.MotorControlGroupBox.TabIndex = 52;
            this.MotorControlGroupBox.TabStop = false;
            this.MotorControlGroupBox.Text = "Actuator Control x2";
            // 
            // AdjustPositionInPlotsW_OffsetCheckBox
            // 
            this.AdjustPositionInPlotsW_OffsetCheckBox.AutoSize = true;
            this.AdjustPositionInPlotsW_OffsetCheckBox.Checked = true;
            this.AdjustPositionInPlotsW_OffsetCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AdjustPositionInPlotsW_OffsetCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdjustPositionInPlotsW_OffsetCheckBox.Location = new System.Drawing.Point(658, 627);
            this.AdjustPositionInPlotsW_OffsetCheckBox.Name = "AdjustPositionInPlotsW_OffsetCheckBox";
            this.AdjustPositionInPlotsW_OffsetCheckBox.Size = new System.Drawing.Size(371, 41);
            this.AdjustPositionInPlotsW_OffsetCheckBox.TabIndex = 71;
            this.AdjustPositionInPlotsW_OffsetCheckBox.Text = " Plot Position w/ Offset";
            this.AdjustPositionInPlotsW_OffsetCheckBox.UseVisualStyleBackColor = true;
            // 
            // EnableCurrentPlotCheckBox
            // 
            this.EnableCurrentPlotCheckBox.AutoSize = true;
            this.EnableCurrentPlotCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnableCurrentPlotCheckBox.Location = new System.Drawing.Point(658, 580);
            this.EnableCurrentPlotCheckBox.Name = "EnableCurrentPlotCheckBox";
            this.EnableCurrentPlotCheckBox.Size = new System.Drawing.Size(328, 41);
            this.EnableCurrentPlotCheckBox.TabIndex = 70;
            this.EnableCurrentPlotCheckBox.Text = "Enable Current Plot";
            this.EnableCurrentPlotCheckBox.UseVisualStyleBackColor = true;
            // 
            // AppliedOffsetBTextBox
            // 
            this.AppliedOffsetBTextBox.Enabled = false;
            this.AppliedOffsetBTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppliedOffsetBTextBox.Location = new System.Drawing.Point(264, 147);
            this.AppliedOffsetBTextBox.Name = "AppliedOffsetBTextBox";
            this.AppliedOffsetBTextBox.Size = new System.Drawing.Size(132, 31);
            this.AppliedOffsetBTextBox.TabIndex = 69;
            // 
            // AppliedOffsetATextBox
            // 
            this.AppliedOffsetATextBox.Enabled = false;
            this.AppliedOffsetATextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppliedOffsetATextBox.Location = new System.Drawing.Point(264, 88);
            this.AppliedOffsetATextBox.Name = "AppliedOffsetATextBox";
            this.AppliedOffsetATextBox.Size = new System.Drawing.Size(132, 31);
            this.AppliedOffsetATextBox.TabIndex = 68;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 31);
            this.label8.TabIndex = 67;
            this.label8.Text = "A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(607, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 31);
            this.label7.TabIndex = 66;
            this.label7.Text = "A";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(607, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 31);
            this.label6.TabIndex = 65;
            this.label6.Text = "B";
            // 
            // RaiseOffsetB_NUD
            // 
            this.RaiseOffsetB_NUD.DecimalPlaces = 1;
            this.RaiseOffsetB_NUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RaiseOffsetB_NUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.RaiseOffsetB_NUD.Location = new System.Drawing.Point(447, 145);
            this.RaiseOffsetB_NUD.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.RaiseOffsetB_NUD.Name = "RaiseOffsetB_NUD";
            this.RaiseOffsetB_NUD.Size = new System.Drawing.Size(154, 38);
            this.RaiseOffsetB_NUD.TabIndex = 64;
            this.RaiseOffsetB_NUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RaiseOffsetA_NUD
            // 
            this.RaiseOffsetA_NUD.DecimalPlaces = 1;
            this.RaiseOffsetA_NUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RaiseOffsetA_NUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.RaiseOffsetA_NUD.Location = new System.Drawing.Point(447, 88);
            this.RaiseOffsetA_NUD.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.RaiseOffsetA_NUD.Name = "RaiseOffsetA_NUD";
            this.RaiseOffsetA_NUD.Size = new System.Drawing.Size(154, 38);
            this.RaiseOffsetA_NUD.TabIndex = 63;
            this.RaiseOffsetA_NUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EnablePositionPlotCB
            // 
            this.EnablePositionPlotCB.AutoSize = true;
            this.EnablePositionPlotCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnablePositionPlotCB.Location = new System.Drawing.Point(658, 533);
            this.EnablePositionPlotCB.Name = "EnablePositionPlotCB";
            this.EnablePositionPlotCB.Size = new System.Drawing.Size(335, 41);
            this.EnablePositionPlotCB.TabIndex = 62;
            this.EnablePositionPlotCB.Text = "Enable Position Plot";
            this.EnablePositionPlotCB.UseVisualStyleBackColor = true;
            this.EnablePositionPlotCB.CheckedChanged += new System.EventHandler(this.EnablePositionPlotCB_CheckedChanged);
            // 
            // ShowPlotsButton
            // 
            this.ShowPlotsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowPlotsButton.Location = new System.Drawing.Point(439, 533);
            this.ShowPlotsButton.Name = "ShowPlotsButton";
            this.ShowPlotsButton.Size = new System.Drawing.Size(195, 149);
            this.ShowPlotsButton.TabIndex = 61;
            this.ShowPlotsButton.Text = "Show Plots";
            this.ShowPlotsButton.UseVisualStyleBackColor = true;
            this.ShowPlotsButton.Click += new System.EventHandler(this.ShowPlotsButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(701, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(260, 31);
            this.label4.TabIndex = 60;
            this.label4.Text = "Proporational Factor";
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
            this.P_NUD.Location = new System.Drawing.Point(967, 259);
            this.P_NUD.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.P_NUD.Name = "P_NUD";
            this.P_NUD.Size = new System.Drawing.Size(113, 38);
            this.P_NUD.TabIndex = 59;
            this.P_NUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.P_NUD.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 31);
            this.label5.TabIndex = 58;
            this.label5.Text = "B";
            // 
            // PositionSetpointLabel
            // 
            this.PositionSetpointLabel.AutoSize = true;
            this.PositionSetpointLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PositionSetpointLabel.Location = new System.Drawing.Point(8, 439);
            this.PositionSetpointLabel.Name = "PositionSetpointLabel";
            this.PositionSetpointLabel.Size = new System.Drawing.Size(312, 42);
            this.PositionSetpointLabel.TabIndex = 57;
            this.PositionSetpointLabel.Text = "Position Set Point";
            // 
            // LowerOffsetB_NUD
            // 
            this.LowerOffsetB_NUD.DecimalPlaces = 1;
            this.LowerOffsetB_NUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LowerOffsetB_NUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.LowerOffsetB_NUD.Location = new System.Drawing.Point(52, 138);
            this.LowerOffsetB_NUD.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.LowerOffsetB_NUD.Name = "LowerOffsetB_NUD";
            this.LowerOffsetB_NUD.Size = new System.Drawing.Size(154, 38);
            this.LowerOffsetB_NUD.TabIndex = 56;
            this.LowerOffsetB_NUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LowerOffsetA_NUD
            // 
            this.LowerOffsetA_NUD.DecimalPlaces = 1;
            this.LowerOffsetA_NUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LowerOffsetA_NUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.LowerOffsetA_NUD.Location = new System.Drawing.Point(52, 82);
            this.LowerOffsetA_NUD.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.LowerOffsetA_NUD.Name = "LowerOffsetA_NUD";
            this.LowerOffsetA_NUD.Size = new System.Drawing.Size(154, 38);
            this.LowerOffsetA_NUD.TabIndex = 55;
            this.LowerOffsetA_NUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(610, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 37);
            this.label3.TabIndex = 53;
            this.label3.Text = "mm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(209, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 37);
            this.label1.TabIndex = 52;
            this.label1.Text = "mm";
            // 
            // RaisePlatformButton
            // 
            this.RaisePlatformButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RaisePlatformButton.Location = new System.Drawing.Point(423, 34);
            this.RaisePlatformButton.Name = "RaisePlatformButton";
            this.RaisePlatformButton.Size = new System.Drawing.Size(195, 93);
            this.RaisePlatformButton.TabIndex = 51;
            this.RaisePlatformButton.Text = "Raise Platform";
            this.RaisePlatformButton.UseVisualStyleBackColor = true;
            this.RaisePlatformButton.Click += new System.EventHandler(this.RetractButton_Click);
            // 
            // LowerPlatformButton
            // 
            this.LowerPlatformButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LowerPlatformButton.Location = new System.Drawing.Point(23, 34);
            this.LowerPlatformButton.Name = "LowerPlatformButton";
            this.LowerPlatformButton.Size = new System.Drawing.Size(204, 93);
            this.LowerPlatformButton.TabIndex = 50;
            this.LowerPlatformButton.Text = "Lower Platform";
            this.LowerPlatformButton.UseVisualStyleBackColor = true;
            this.LowerPlatformButton.Click += new System.EventHandler(this.ExtendButton_Click);
            // 
            // LowerNUD
            // 
            this.LowerNUD.DecimalPlaces = 1;
            this.LowerNUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LowerNUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.LowerNUD.Location = new System.Drawing.Point(47, 133);
            this.LowerNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.LowerNUD.Name = "LowerNUD";
            this.LowerNUD.Size = new System.Drawing.Size(154, 38);
            this.LowerNUD.TabIndex = 49;
            this.LowerNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LowerNUD.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // RaiseNUD
            // 
            this.RaiseNUD.DecimalPlaces = 1;
            this.RaiseNUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RaiseNUD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.RaiseNUD.Location = new System.Drawing.Point(439, 133);
            this.RaiseNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.RaiseNUD.Name = "RaiseNUD";
            this.RaiseNUD.Size = new System.Drawing.Size(154, 38);
            this.RaiseNUD.TabIndex = 48;
            this.RaiseNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RaiseNUD.Value = new decimal(new int[] {
            458,
            0,
            0,
            0});
            // 
            // EnableSyncCheckBox
            // 
            this.EnableSyncCheckBox.AutoSize = true;
            this.EnableSyncCheckBox.Checked = true;
            this.EnableSyncCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnableSyncCheckBox.Font = new System.Drawing.Font("Consolas", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnableSyncCheckBox.Location = new System.Drawing.Point(707, 192);
            this.EnableSyncCheckBox.Name = "EnableSyncCheckBox";
            this.EnableSyncCheckBox.Size = new System.Drawing.Size(271, 47);
            this.EnableSyncCheckBox.TabIndex = 47;
            this.EnableSyncCheckBox.Text = "Enable Sync";
            this.EnableSyncCheckBox.UseVisualStyleBackColor = true;
            // 
            // KILL
            // 
            this.KILL.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KILL.Location = new System.Drawing.Point(15, 534);
            this.KILL.Name = "KILL";
            this.KILL.Size = new System.Drawing.Size(384, 148);
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
            this.AcutatorFeedbackGroupBox.Size = new System.Drawing.Size(1104, 536);
            this.AcutatorFeedbackGroupBox.TabIndex = 53;
            this.AcutatorFeedbackGroupBox.TabStop = false;
            this.AcutatorFeedbackGroupBox.Text = "Acutator Feedback x2";
            // 
            // ControlStateTextBox
            // 
            this.ControlStateTextBox.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ControlStateTextBox.Font = new System.Drawing.Font("Consolas", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlStateTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.ControlStateTextBox.Location = new System.Drawing.Point(15, 118);
            this.ControlStateTextBox.Multiline = true;
            this.ControlStateTextBox.Name = "ControlStateTextBox";
            this.ControlStateTextBox.Size = new System.Drawing.Size(1045, 412);
            this.ControlStateTextBox.TabIndex = 52;
            // 
            // ActuatorAddressB
            // 
            this.ActuatorAddressB.Location = new System.Drawing.Point(279, 69);
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
            this.AddressB_Label.Location = new System.Drawing.Point(274, 41);
            this.AddressB_Label.Name = "AddressB_Label";
            this.AddressB_Label.Size = new System.Drawing.Size(208, 25);
            this.AddressB_Label.TabIndex = 50;
            this.AddressB_Label.Text = "Address B (Decimal)";
            // 
            // OffsetGroupBox
            // 
            this.OffsetGroupBox.Controls.Add(this.label11);
            this.OffsetGroupBox.Controls.Add(this.label10);
            this.OffsetGroupBox.Controls.Add(this.label9);
            this.OffsetGroupBox.Controls.Add(this.AppliedOffsetATextBox);
            this.OffsetGroupBox.Controls.Add(this.LowerOffsetA_NUD);
            this.OffsetGroupBox.Controls.Add(this.LowerOffsetB_NUD);
            this.OffsetGroupBox.Controls.Add(this.AppliedOffsetBTextBox);
            this.OffsetGroupBox.Controls.Add(this.label5);
            this.OffsetGroupBox.Controls.Add(this.RaiseOffsetA_NUD);
            this.OffsetGroupBox.Controls.Add(this.label8);
            this.OffsetGroupBox.Controls.Add(this.RaiseOffsetB_NUD);
            this.OffsetGroupBox.Controls.Add(this.label7);
            this.OffsetGroupBox.Controls.Add(this.label6);
            this.OffsetGroupBox.Location = new System.Drawing.Point(7, 205);
            this.OffsetGroupBox.Name = "OffsetGroupBox";
            this.OffsetGroupBox.Size = new System.Drawing.Size(674, 208);
            this.OffsetGroupBox.TabIndex = 72;
            this.OffsetGroupBox.TabStop = false;
            this.OffsetGroupBox.Text = "Offset";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(277, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 31);
            this.label9.TabIndex = 73;
            this.label9.Text = "Current";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(82, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 31);
            this.label10.TabIndex = 74;
            this.label10.Text = "Lower";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(481, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 31);
            this.label11.TabIndex = 74;
            this.label11.Text = "Upper";
            // 
            // ElectrakHDx2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 1289);
            this.Controls.Add(this.AcutatorFeedbackGroupBox);
            this.Controls.Add(this.MotorControlGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximumSize = new System.Drawing.Size(1160, 1360);
            this.MinimumSize = new System.Drawing.Size(1160, 1360);
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
            ((System.ComponentModel.ISupportInitialize)(this.RaiseOffsetB_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RaiseOffsetA_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowerOffsetB_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowerOffsetA_NUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LowerNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RaiseNUD)).EndInit();
            this.AcutatorFeedbackGroupBox.ResumeLayout(false);
            this.AcutatorFeedbackGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ActuatorAddressB)).EndInit();
            this.OffsetGroupBox.ResumeLayout(false);
            this.OffsetGroupBox.PerformLayout();
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
        private System.Windows.Forms.NumericUpDown LowerNUD;
        private System.Windows.Forms.NumericUpDown RaiseNUD;
        private System.Windows.Forms.Button RaisePlatformButton;
        private System.Windows.Forms.Button LowerPlatformButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown P_NUD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label PositionSetpointLabel;
        private System.Windows.Forms.NumericUpDown LowerOffsetB_NUD;
        private System.Windows.Forms.NumericUpDown LowerOffsetA_NUD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ShowPlotsButton;
        private System.Windows.Forms.CheckBox EnablePositionPlotCB;
        private System.Windows.Forms.NumericUpDown RaiseOffsetB_NUD;
        private System.Windows.Forms.NumericUpDown RaiseOffsetA_NUD;
        private System.Windows.Forms.CheckBox EnableCurrentPlotCheckBox;
        private System.Windows.Forms.TextBox AppliedOffsetBTextBox;
        private System.Windows.Forms.TextBox AppliedOffsetATextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox AdjustPositionInPlotsW_OffsetCheckBox;
        private System.Windows.Forms.GroupBox OffsetGroupBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}

