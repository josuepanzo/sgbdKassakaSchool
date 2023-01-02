using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Common.Cache;

namespace View
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int iparam);

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (pnlMenuVertical.Width == 250)
            {
                pnlMenuVertical.Width = 70;
            }
            else {
                pnlMenuVertical.Width = 250;
            }
        }

        private void pnlBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to close this application?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnMinimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMiximized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.btnNormal.Visible = true;
            this.btnMiximized.Visible = false;
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.btnNormal.Visible = false;
            this.btnMiximized.Visible = true;
        }

        private void abrirForm(object childForm) {
            if (this.pnlContainer.Controls.Count > 0)
                this.pnlContainer.Controls.RemoveAt(0);
            Form cf = childForm as Form;
            cf.TopLevel = false;
            cf.Dock = DockStyle.Fill;
            this.pnlContainer.Controls.Add(cf);
            this.pnlContainer.Tag = cf;
            cf.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to close this Session?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            loadUserData();
        }

        private void loadUserData() {
            lblName.Text = UserLoginCache.FirstName+"  "+UserLoginCache.LastName;
            lblCargo.Text = UserLoginCache.Cargo;
            lblEmail.Text = UserLoginCache.Email;
        }
    }
}
