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
            this.statusTextBox = new System.Windows.Forms.TextBox();
            this.guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnResetGuest = new System.Windows.Forms.Button();
            this.guna2AnimateWindow2 = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ContainerControl1 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAdbPath = new System.Windows.Forms.TextBox();
            this.btnSelectAdb = new System.Windows.Forms.Button();
            this.btnStartMonitoring = new System.Windows.Forms.Button();
            this.txtOutputDir = new System.Windows.Forms.TextBox();
            this.btnSelectOutputDir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.panelCredits = new System.Windows.Forms.Panel();
            this.labelCollaboration = new System.Windows.Forms.Label();
            this.labelCredits = new System.Windows.Forms.Label();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.labelStatus = new System.Windows.Forms.Label();
            this.guna2ContainerControl1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelCredits.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusTextBox
            // 
            this.statusTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.statusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.statusTextBox.Cursor = System.Windows.Forms.Cursors.No;
            this.statusTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.statusTextBox.Location = new System.Drawing.Point(16, 43);
            this.statusTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.statusTextBox.Multiline = true;
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.ReadOnly = true;
            this.statusTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statusTextBox.Size = new System.Drawing.Size(555, 134);
            this.statusTextBox.TabIndex = 6;
            this.statusTextBox.TextChanged += new System.EventHandler(this.statusTextBox_TextChanged);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.label1.Location = new System.Drawing.Point(168, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 41);
            this.label1.TabIndex = 7;
            this.label1.Text = "GuestExtractor";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnResetGuest
            // 
            this.btnResetGuest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetGuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnResetGuest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetGuest.FlatAppearance.BorderSize = 0;
            this.btnResetGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetGuest.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetGuest.ForeColor = System.Drawing.Color.White;
            this.btnResetGuest.Location = new System.Drawing.Point(40, 369);
            this.btnResetGuest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnResetGuest.Name = "btnResetGuest";
            this.btnResetGuest.Size = new System.Drawing.Size(507, 55);
            this.btnResetGuest.TabIndex = 43;
            this.btnResetGuest.Text = "GUEST RESET UID";
            this.btnResetGuest.UseVisualStyleBackColor = false;
            this.btnResetGuest.Click += new System.EventHandler(this.btnResetGuest_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(491, 10);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 30);
            this.btnClear.TabIndex = 44;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.label3.Location = new System.Drawing.Point(12, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 45;
            this.label3.Text = "Created by";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.guna2ControlBox1.Location = new System.Drawing.Point(539, 13);
            this.guna2ControlBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(44, 23);
            this.guna2ControlBox1.TabIndex = 47;
            this.guna2ControlBox1.Click += new System.EventHandler(this.guna2ControlBox1_Click);
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.guna2ControlBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.guna2ControlBox2.Location = new System.Drawing.Point(491, 14);
            this.guna2ControlBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(44, 23);
            this.guna2ControlBox2.TabIndex = 48;
            this.guna2ControlBox2.Click += new System.EventHandler(this.guna2ControlBox2_Click);
            // 
            // guna2ContainerControl1
            // 
            this.guna2ContainerControl1.Controls.Add(this.guna2ControlBox1);
            this.guna2ContainerControl1.Controls.Add(this.guna2ControlBox2);
            this.guna2ContainerControl1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.guna2ContainerControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2ContainerControl1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.guna2ContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.guna2ContainerControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2ContainerControl1.Name = "guna2ContainerControl1";
            this.guna2ContainerControl1.Size = new System.Drawing.Size(587, 45);
            this.guna2ContainerControl1.TabIndex = 49;
            this.guna2ContainerControl1.Text = "guna2ContainerControl1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.label5.Location = new System.Drawing.Point(12, 43);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 20);
            this.label5.TabIndex = 50;
            this.label5.Text = "In collaboration with";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtAdbPath
            // 
            this.txtAdbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdbPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtAdbPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAdbPath.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdbPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.txtAdbPath.Location = new System.Drawing.Point(56, 154);
            this.txtAdbPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAdbPath.Name = "txtAdbPath";
            this.txtAdbPath.ReadOnly = true;
            this.txtAdbPath.Size = new System.Drawing.Size(360, 23);
            this.txtAdbPath.TabIndex = 51;
            // 
            // btnSelectAdb
            // 
            this.btnSelectAdb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAdb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.btnSelectAdb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectAdb.FlatAppearance.BorderSize = 0;
            this.btnSelectAdb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAdb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAdb.ForeColor = System.Drawing.Color.White;
            this.btnSelectAdb.Location = new System.Drawing.Point(424, 142);
            this.btnSelectAdb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectAdb.Name = "btnSelectAdb";
            this.btnSelectAdb.Size = new System.Drawing.Size(123, 43);
            this.btnSelectAdb.TabIndex = 52;
            this.btnSelectAdb.Text = "Browse";
            this.btnSelectAdb.UseVisualStyleBackColor = false;
            this.btnSelectAdb.Click += new System.EventHandler(this.btnSelectAdb_Click);
            // 
            // btnStartMonitoring
            // 
            this.btnStartMonitoring.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartMonitoring.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.btnStartMonitoring.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartMonitoring.Enabled = false;
            this.btnStartMonitoring.FlatAppearance.BorderSize = 0;
            this.btnStartMonitoring.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartMonitoring.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartMonitoring.ForeColor = System.Drawing.Color.White;
            this.btnStartMonitoring.Location = new System.Drawing.Point(40, 295);
            this.btnStartMonitoring.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnStartMonitoring.Name = "btnStartMonitoring";
            this.btnStartMonitoring.Size = new System.Drawing.Size(507, 62);
            this.btnStartMonitoring.TabIndex = 53;
            this.btnStartMonitoring.Text = "Start ADB Monitoring";
            this.btnStartMonitoring.UseVisualStyleBackColor = false;
            this.btnStartMonitoring.Click += new System.EventHandler(this.btnStartMonitoring_Click);
            // 
            // txtOutputDir
            // 
            this.txtOutputDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.txtOutputDir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOutputDir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputDir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.txtOutputDir.Location = new System.Drawing.Point(56, 228);
            this.txtOutputDir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.Size = new System.Drawing.Size(360, 23);
            this.txtOutputDir.TabIndex = 54;
            // 
            // btnSelectOutputDir
            // 
            this.btnSelectOutputDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectOutputDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.btnSelectOutputDir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectOutputDir.FlatAppearance.BorderSize = 0;
            this.btnSelectOutputDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectOutputDir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectOutputDir.ForeColor = System.Drawing.Color.White;
            this.btnSelectOutputDir.Location = new System.Drawing.Point(424, 215);
            this.btnSelectOutputDir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectOutputDir.Name = "btnSelectOutputDir";
            this.btnSelectOutputDir.Size = new System.Drawing.Size(123, 43);
            this.btnSelectOutputDir.TabIndex = 55;
            this.btnSelectOutputDir.Text = "Browse";
            this.btnSelectOutputDir.UseVisualStyleBackColor = false;
            this.btnSelectOutputDir.Click += new System.EventHandler(this.btnSelectOutputDir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.label2.Location = new System.Drawing.Point(40, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 23);
            this.label2.TabIndex = 56;
            this.label2.Text = "ADB Server Path";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.label6.Location = new System.Drawing.Point(40, 197);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 23);
            this.label6.TabIndex = 57;
            this.label6.Text = "Output Folder";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.label6);
            this.panelMain.Controls.Add(this.btnSelectOutputDir);
            this.panelMain.Controls.Add(this.txtOutputDir);
            this.panelMain.Controls.Add(this.btnStartMonitoring);
            this.panelMain.Controls.Add(this.btnSelectAdb);
            this.panelMain.Controls.Add(this.txtAdbPath);
            this.panelMain.Controls.Add(this.btnResetGuest);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(0, 45);
            this.panelMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(587, 449);
            this.panelMain.TabIndex = 58;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelHeader.Controls.Add(this.labelVersion);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(587, 92);
            this.panelHeader.TabIndex = 58;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.labelVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.labelVersion.Location = new System.Drawing.Point(406, 35);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(24, 20);
            this.labelVersion.TabIndex = 8;
            this.labelVersion.Text = "v2";
            // 
            // panelCredits
            // 
            this.panelCredits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelCredits.Controls.Add(this.labelCollaboration);
            this.panelCredits.Controls.Add(this.labelCredits);
            this.panelCredits.Controls.Add(this.label3);
            this.panelCredits.Controls.Add(this.label5);
            this.panelCredits.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCredits.Location = new System.Drawing.Point(0, 702);
            this.panelCredits.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelCredits.Name = "panelCredits";
            this.panelCredits.Size = new System.Drawing.Size(587, 86);
            this.panelCredits.TabIndex = 59;
            // 
            // labelCollaboration
            // 
            this.labelCollaboration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCollaboration.AutoSize = true;
            this.labelCollaboration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelCollaboration.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCollaboration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.labelCollaboration.Location = new System.Drawing.Point(503, 43);
            this.labelCollaboration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCollaboration.Name = "labelCollaboration";
            this.labelCollaboration.Size = new System.Drawing.Size(68, 20);
            this.labelCollaboration.TabIndex = 52;
            this.labelCollaboration.Text = "0xramm";
            this.labelCollaboration.Click += new System.EventHandler(this.label5_Click);
            // 
            // labelCredits
            // 
            this.labelCredits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCredits.AutoSize = true;
            this.labelCredits.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelCredits.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCredits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.labelCredits.Location = new System.Drawing.Point(479, 18);
            this.labelCredits.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCredits.Name = "labelCredits";
            this.labelCredits.Size = new System.Drawing.Size(92, 20);
            this.labelCredits.TabIndex = 51;
            this.labelCredits.Text = "great THUG";
            this.labelCredits.Click += new System.EventHandler(this.label3_Click);
            // 
            // panelStatus
            // 
            this.panelStatus.BackColor = System.Drawing.Color.White;
            this.panelStatus.Controls.Add(this.labelStatus);
            this.panelStatus.Controls.Add(this.btnClear);
            this.panelStatus.Controls.Add(this.statusTextBox);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStatus.Location = new System.Drawing.Point(0, 494);
            this.panelStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(587, 208);
            this.panelStatus.TabIndex = 60;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(99)))));
            this.labelStatus.Location = new System.Drawing.Point(16, 15);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(102, 23);
            this.labelStatus.TabIndex = 58;
            this.labelStatus.Text = "Status Logs";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(587, 788);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.panelCredits);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.guna2ContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(587, 788);
            this.Name = "Form2";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GuestExtractor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.guna2ContainerControl1.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelCredits.ResumeLayout(false);
            this.panelCredits.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TextBox statusTextBox;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnResetGuest;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAdbPath;
        private System.Windows.Forms.Button btnSelectAdb;
        private System.Windows.Forms.Button btnStartMonitoring;
        private System.Windows.Forms.TextBox txtOutputDir;
        private System.Windows.Forms.Button btnSelectOutputDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Panel panelCredits;
        private System.Windows.Forms.Label labelCredits;
        private System.Windows.Forms.Label labelCollaboration;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Label labelStatus;
    }
}