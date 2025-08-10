namespace GuestExtractor
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnResetGuest = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.cmbEmulatorSelection = new System.Windows.Forms.ComboBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtOutputDir = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAdbPath = new Guna.UI2.WinForms.Guna2TextBox();
            this.textPort = new Guna.UI2.WinForms.Guna2TextBox();
            this.labelAccount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStartMonitoring = new System.Windows.Forms.Button();
            this.btnSelectOutputDir = new System.Windows.Forms.Button();
            this.btnSelectAdb = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.cuiControlDrag1 = new CuoreUI.cuiControlDrag(this.components);
            this.cuiControlDrag2 = new CuoreUI.cuiControlDrag(this.components);
            this.cuiControlDrag3 = new CuoreUI.cuiControlDrag(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.cuiControlDrag4 = new CuoreUI.cuiControlDrag(this.components);
            this.cuiControlDrag5 = new CuoreUI.cuiControlDrag(this.components);
            this.cuiControlDrag6 = new CuoreUI.cuiControlDrag(this.components);
            this.cuiControlDrag7 = new CuoreUI.cuiControlDrag(this.components);
            this.cuiControlDrag8 = new CuoreUI.cuiControlDrag(this.components);
            this.guna2ContainerControl1 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.cuiControlDrag9 = new CuoreUI.cuiControlDrag(this.components);
            this.cuiControlDrag10 = new CuoreUI.cuiControlDrag(this.components);
            this.cuiControlDrag11 = new CuoreUI.cuiControlDrag(this.components);
            this.cuiControlDrag12 = new CuoreUI.cuiControlDrag(this.components);
            this.about = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.panelMain.SuspendLayout();
            this.guna2ContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnResetGuest
            // 
            this.btnResetGuest.Location = new System.Drawing.Point(12, 197);
            this.btnResetGuest.Name = "btnResetGuest";
            this.btnResetGuest.Size = new System.Drawing.Size(100, 30);
            this.btnResetGuest.TabIndex = 61;
            this.btnResetGuest.Text = "GUEST RESET";
            this.btnResetGuest.Click += new System.EventHandler(this.btnResetGuest_Click_1);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.cmbEmulatorSelection);
            this.panelMain.Controls.Add(this.btnCheck);
            this.panelMain.Controls.Add(this.txtOutputDir);
            this.panelMain.Controls.Add(this.txtAdbPath);
            this.panelMain.Controls.Add(this.textPort);
            this.panelMain.Controls.Add(this.labelAccount);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.btnStartMonitoring);
            this.panelMain.Controls.Add(this.btnSelectOutputDir);
            this.panelMain.Controls.Add(this.btnSelectAdb);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.btnResetGuest);
            this.panelMain.Controls.Add(this.statusTextBox);
            this.panelMain.Location = new System.Drawing.Point(12, 44);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(404, 423);
            this.panelMain.TabIndex = 58;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // cmbEmulatorSelection
            // 
            this.cmbEmulatorSelection.FormattingEnabled = true;
            this.cmbEmulatorSelection.Location = new System.Drawing.Point(12, 83);
            this.cmbEmulatorSelection.Name = "cmbEmulatorSelection";
            this.cmbEmulatorSelection.Size = new System.Drawing.Size(300, 21);
            this.cmbEmulatorSelection.TabIndex = 79;
            this.cmbEmulatorSelection.SelectedIndexChanged += new System.EventHandler(this.cmbEmulatorSelection_SelectedIndexChanged_1);
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.Transparent;
            this.btnCheck.Location = new System.Drawing.Point(12, 161);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(100, 30);
            this.btnCheck.TabIndex = 78;
            this.btnCheck.Text = "CHECK ";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtOutputDir
            // 
            this.txtOutputDir.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.txtOutputDir.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOutputDir.DefaultText = "";
            this.txtOutputDir.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtOutputDir.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtOutputDir.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOutputDir.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOutputDir.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOutputDir.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtOutputDir.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOutputDir.Location = new System.Drawing.Point(12, 116);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.PlaceholderText = "FOLDER OUTPUT";
            this.txtOutputDir.SelectedText = "";
            this.txtOutputDir.Size = new System.Drawing.Size(300, 30);
            this.txtOutputDir.TabIndex = 77;
            // 
            // txtAdbPath
            // 
            this.txtAdbPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAdbPath.DefaultText = "";
            this.txtAdbPath.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAdbPath.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAdbPath.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAdbPath.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAdbPath.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAdbPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAdbPath.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAdbPath.Location = new System.Drawing.Point(12, 46);
            this.txtAdbPath.Name = "txtAdbPath";
            this.txtAdbPath.PlaceholderText = "ADB PATCH";
            this.txtAdbPath.SelectedText = "";
            this.txtAdbPath.Size = new System.Drawing.Size(300, 30);
            this.txtAdbPath.TabIndex = 76;
            // 
            // textPort
            // 
            this.textPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textPort.DefaultText = "";
            this.textPort.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textPort.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textPort.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textPort.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textPort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textPort.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textPort.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textPort.Location = new System.Drawing.Point(152, 197);
            this.textPort.Name = "textPort";
            this.textPort.PlaceholderText = "PORT";
            this.textPort.SelectedText = "";
            this.textPort.Size = new System.Drawing.Size(100, 30);
            this.textPort.TabIndex = 75;
            this.textPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelAccount
            // 
            this.labelAccount.AutoSize = true;
            this.labelAccount.ForeColor = System.Drawing.Color.Black;
            this.labelAccount.Location = new System.Drawing.Point(281, 239);
            this.labelAccount.Name = "labelAccount";
            this.labelAccount.Size = new System.Drawing.Size(106, 13);
            this.labelAccount.TabIndex = 73;
            this.labelAccount.Text = "ACCOUNTS : NONE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "CONSOLE LOGS";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnStartMonitoring
            // 
            this.btnStartMonitoring.BackColor = System.Drawing.Color.Transparent;
            this.btnStartMonitoring.Location = new System.Drawing.Point(287, 197);
            this.btnStartMonitoring.Name = "btnStartMonitoring";
            this.btnStartMonitoring.Size = new System.Drawing.Size(100, 30);
            this.btnStartMonitoring.TabIndex = 67;
            this.btnStartMonitoring.Text = "START ADB";
            this.btnStartMonitoring.UseVisualStyleBackColor = false;
            this.btnStartMonitoring.Click += new System.EventHandler(this.btnStartMonitoring_Click_1);
            // 
            // btnSelectOutputDir
            // 
            this.btnSelectOutputDir.Location = new System.Drawing.Point(319, 116);
            this.btnSelectOutputDir.Name = "btnSelectOutputDir";
            this.btnSelectOutputDir.Size = new System.Drawing.Size(68, 30);
            this.btnSelectOutputDir.TabIndex = 64;
            this.btnSelectOutputDir.Text = "...";
            this.btnSelectOutputDir.Click += new System.EventHandler(this.btnSelectOutputDir_Click_1);
            // 
            // btnSelectAdb
            // 
            this.btnSelectAdb.Location = new System.Drawing.Point(319, 46);
            this.btnSelectAdb.Name = "btnSelectAdb";
            this.btnSelectAdb.Size = new System.Drawing.Size(68, 30);
            this.btnSelectAdb.TabIndex = 63;
            this.btnSelectAdb.Text = "...";
            this.btnSelectAdb.Click += new System.EventHandler(this.btnSelectAdb_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(141, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 21);
            this.label1.TabIndex = 62;
            this.label1.Text = "GuestExtractor";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // statusTextBox
            // 
            this.statusTextBox.Location = new System.Drawing.Point(12, 255);
            this.statusTextBox.Multiline = true;
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.statusTextBox.Size = new System.Drawing.Size(380, 153);
            this.statusTextBox.TabIndex = 60;
            this.statusTextBox.TextChanged += new System.EventHandler(this.statusTextBox_TextChanged);
            // 
            // cuiControlDrag1
            // 
            this.cuiControlDrag1.TargetControl = this.statusTextBox;
            // 
            // cuiControlDrag2
            // 
            this.cuiControlDrag2.TargetControl = this.panelMain;
            // 
            // cuiControlDrag3
            // 
            this.cuiControlDrag3.TargetControl = this.btnClear;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(329, 473);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 68;
            this.btnClear.Text = "CLEAR";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            // 
            // cuiControlDrag4
            // 
            this.cuiControlDrag4.TargetControl = this.btnResetGuest;
            // 
            // cuiControlDrag5
            // 
            this.cuiControlDrag5.TargetControl = this.btnSelectAdb;
            // 
            // cuiControlDrag6
            // 
            this.cuiControlDrag6.TargetControl = this.btnSelectOutputDir;
            // 
            // cuiControlDrag7
            // 
            this.cuiControlDrag7.TargetControl = this.btnStartMonitoring;
            // 
            // cuiControlDrag8
            // 
            this.cuiControlDrag8.TargetControl = this.guna2ContainerControl1;
            // 
            // guna2ContainerControl1
            // 
            this.guna2ContainerControl1.Controls.Add(this.guna2ControlBox1);
            this.guna2ContainerControl1.Controls.Add(this.guna2ControlBox2);
            this.guna2ContainerControl1.FillColor = System.Drawing.Color.LightGray;
            this.guna2ContainerControl1.Location = new System.Drawing.Point(13, 12);
            this.guna2ContainerControl1.Name = "guna2ContainerControl1";
            this.guna2ContainerControl1.Size = new System.Drawing.Size(403, 26);
            this.guna2ContainerControl1.TabIndex = 59;
            this.guna2ContainerControl1.Text = "guna2ContainerControl1";
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(370, 3);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(33, 19);
            this.guna2ControlBox1.TabIndex = 47;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Black;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(331, 3);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(33, 19);
            this.guna2ControlBox2.TabIndex = 48;
            // 
            // cuiControlDrag9
            // 
            this.cuiControlDrag9.TargetControl = this;
            // 
            // cuiControlDrag10
            // 
            this.cuiControlDrag10.TargetControl = this;
            // 
            // cuiControlDrag11
            // 
            this.cuiControlDrag11.TargetControl = this.statusTextBox;
            // 
            // cuiControlDrag12
            // 
            this.cuiControlDrag12.TargetControl = this.panelMain;
            // 
            // about
            // 
            this.about.Location = new System.Drawing.Point(24, 473);
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(75, 23);
            this.about.TabIndex = 69;
            this.about.Text = "ABOUT";
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(194, 477);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 16);
            this.label5.TabIndex = 70;
            this.label5.Text = "v2.0.1";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_VER_POSITIVE;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.ShadowColor = System.Drawing.Color.Blue;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(428, 500);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.about);
            this.Controls.Add(this.guna2ContainerControl1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GuestExtractor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.guna2ContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Button btnResetGuest;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TextBox statusTextBox;
        private System.Windows.Forms.Button btnSelectOutputDir;
        private System.Windows.Forms.Button btnSelectAdb;
        private System.Windows.Forms.Button btnStartMonitoring;
        private CuoreUI.cuiControlDrag cuiControlDrag1;
        private CuoreUI.cuiControlDrag cuiControlDrag2;
        private CuoreUI.cuiControlDrag cuiControlDrag3;
        private CuoreUI.cuiControlDrag cuiControlDrag4;
        private CuoreUI.cuiControlDrag cuiControlDrag5;
        private CuoreUI.cuiControlDrag cuiControlDrag6;
        private CuoreUI.cuiControlDrag cuiControlDrag7;
        private CuoreUI.cuiControlDrag cuiControlDrag8;
        private CuoreUI.cuiControlDrag cuiControlDrag9;
        private CuoreUI.cuiControlDrag cuiControlDrag10;
        private CuoreUI.cuiControlDrag cuiControlDrag11;
        private CuoreUI.cuiControlDrag cuiControlDrag12;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button about;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private System.Windows.Forms.Label labelAccount;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox textPort;
        private Guna.UI2.WinForms.Guna2TextBox txtOutputDir;
        private Guna.UI2.WinForms.Guna2TextBox txtAdbPath;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.ComboBox cmbEmulatorSelection;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}