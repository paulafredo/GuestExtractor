using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuestExtractor
{
    public partial class About2 : Form
    {
        public About2()
        {
            InitializeComponent();
        }

        private void About2_Load(object sender, EventArgs e)
        {

        }

        private void linkPaul_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/paulafredo") { UseShellExecute = true });
        }

        private void linkOxy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/0xramm") { UseShellExecute = true });
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void About2_Load_1(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://discord.gg/awPm5B3QFg") { UseShellExecute = true });
        }
    }
}









