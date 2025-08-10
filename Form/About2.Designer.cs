namespace GuestExtractor
{
    partial class About2
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
        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // About2
        //    // 
        //    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.ClientSize = new System.Drawing.Size(800, 450);
        //    this.Name = "About2";
        //    this.Text = "About2";
        //    this.Load += new System.EventHandler(this.About2_Load);
        //    this.ResumeLayout(false);

        //}


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelMain = new System.Windows.Forms.Panel();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelDesc = new System.Windows.Forms.Label();
            this.linkPaul = new System.Windows.Forms.LinkLabel();
            this.linkOxy = new System.Windows.Forms.LinkLabel();
            this.labelFooter = new System.Windows.Forms.Label();
            this.cuiControlDrag10 = new CuoreUI.cuiControlDrag(this.components);
            this.cuiControlDrag1 = new CuoreUI.cuiControlDrag(this.components);
            this.cuiControlDrag2 = new CuoreUI.cuiControlDrag(this.components);
            this.cuiControlDrag3 = new CuoreUI.cuiControlDrag(this.components);
            this.cuiControlDrag4 = new CuoreUI.cuiControlDrag(this.components);
            this.cuiControlDrag5 = new CuoreUI.cuiControlDrag(this.components);
            this.cuiControlDrag6 = new CuoreUI.cuiControlDrag(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.linkLabel1);
            this.panelMain.Controls.Add(this.guna2ControlBox2);
            this.panelMain.Controls.Add(this.labelTitle);
            this.panelMain.Controls.Add(this.labelDesc);
            this.panelMain.Controls.Add(this.linkPaul);
            this.panelMain.Controls.Add(this.linkOxy);
            this.panelMain.Controls.Add(this.labelFooter);
            this.panelMain.Location = new System.Drawing.Point(17, 17);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(310, 210);
            this.panelMain.TabIndex = 0;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(272, 3);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(33, 19);
            this.guna2ControlBox2.TabIndex = 48;
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.labelTitle.Location = new System.Drawing.Point(0, 17);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(309, 26);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "GuestExtractor 2.0.1";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelDesc
            // 
            this.labelDesc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.labelDesc.ForeColor = System.Drawing.Color.Black;
            this.labelDesc.Location = new System.Drawing.Point(0, 48);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(309, 22);
            this.labelDesc.TabIndex = 1;
            this.labelDesc.Text = "Simple project to extract guest accounts";
            this.labelDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkPaul
            // 
            this.linkPaul.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.linkPaul.Location = new System.Drawing.Point(0, 87);
            this.linkPaul.Name = "linkPaul";
            this.linkPaul.Size = new System.Drawing.Size(309, 17);
            this.linkPaul.TabIndex = 2;
            this.linkPaul.TabStop = true;
            this.linkPaul.Text = "Credits: paulalfredo";
            this.linkPaul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkPaul.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPaul_LinkClicked);
            // 
            // linkOxy
            // 
            this.linkOxy.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.linkOxy.Location = new System.Drawing.Point(0, 113);
            this.linkOxy.Name = "linkOxy";
            this.linkOxy.Size = new System.Drawing.Size(309, 17);
            this.linkOxy.TabIndex = 3;
            this.linkOxy.TabStop = true;
            this.linkOxy.Text = "Contributors: 0xramm";
            this.linkOxy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkOxy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOxy_LinkClicked);
            // 
            // labelFooter
            // 
            this.labelFooter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelFooter.ForeColor = System.Drawing.Color.Gray;
            this.labelFooter.Location = new System.Drawing.Point(0, 191);
            this.labelFooter.Name = "labelFooter";
            this.labelFooter.Size = new System.Drawing.Size(309, 17);
            this.labelFooter.TabIndex = 4;
            this.labelFooter.Text = "GuestExtractor © 2025";
            this.labelFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cuiControlDrag10
            // 
            this.cuiControlDrag10.TargetControl = this.panelMain;
            // 
            // cuiControlDrag1
            // 
            this.cuiControlDrag1.TargetControl = this;
            // 
            // cuiControlDrag2
            // 
            this.cuiControlDrag2.TargetControl = this.labelFooter;
            // 
            // cuiControlDrag3
            // 
            this.cuiControlDrag3.TargetControl = this.guna2ControlBox2;
            // 
            // cuiControlDrag4
            // 
            this.cuiControlDrag4.TargetControl = this.labelTitle;
            // 
            // cuiControlDrag5
            // 
            this.cuiControlDrag5.TargetControl = this;
            // 
            // cuiControlDrag6
            // 
            this.cuiControlDrag6.TargetControl = this.labelDesc;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.linkLabel1.Location = new System.Drawing.Point(0, 163);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(309, 17);
            this.linkLabel1.TabIndex = 49;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Discord";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // About2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(350, 250);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "About2";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About2_Load_1);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelDesc;
        private System.Windows.Forms.LinkLabel linkPaul;
        private System.Windows.Forms.LinkLabel linkOxy;
        private System.Windows.Forms.Label labelFooter;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private CuoreUI.cuiControlDrag cuiControlDrag10;
        private CuoreUI.cuiControlDrag cuiControlDrag1;
        private CuoreUI.cuiControlDrag cuiControlDrag2;
        private CuoreUI.cuiControlDrag cuiControlDrag3;
        private CuoreUI.cuiControlDrag cuiControlDrag4;
        private CuoreUI.cuiControlDrag cuiControlDrag5;
        private CuoreUI.cuiControlDrag cuiControlDrag6;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }


}
