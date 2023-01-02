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
using Controllers;

namespace View
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int iparam);

        private void txt_user_Enter(object sender, EventArgs e)
        {
            if(this.txt_user.Text == "Usuário") {
                this.txt_user.Text = "";
                this.txt_user.ForeColor = Color.DarkBlue;
            }
        }

        private void txt_user_Leave(object sender, EventArgs e)
        {
            if (this.txt_user.Text == "")
            {
                this.txt_user.Text = "Usuário";
                this.txt_user.ForeColor = Color.DimGray;
            }
        }

        private void txt_password_Enter(object sender, EventArgs e) {
            if (txt_password.Text == "Password") {
                txt_password.Text = "";
                txt_password.ForeColor = Color.DarkBlue;
                txt_password.UseSystemPasswordChar = true;
            }
        }

        private void txt_password_Leave(object sender, EventArgs e) {
            if (txt_password.Text == "") {
                txt_password.Text = "Password";
                txt_password.ForeColor = Color.DimGray;
                txt_password.UseSystemPasswordChar = false;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_minimized_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.txt_user.Text != "Usuário")
            {
                if (this.txt_password.Text != "Password") {
                    UserController userController = new UserController();
                    var isValidLogin = userController.LoginUser(this.txt_user.Text, this.txt_password.Text);

                    if (isValidLogin == true)
                    {
                        FormPrincipal formPrincipal = new FormPrincipal();
                        formPrincipal.Show();
                        formPrincipal.FormClosed += logOut;
                        this.Hide();
                    }
                    else {
                        msgError("Incorrect Username or Password Entered. Please try again!");
                        this.txt_password.Text ="Password";
                        this.txt_user.Focus();
                    }
                }
                else msgError("Please Enter Password!");
            }
            else msgError("Please Enter Username!");
        }

        private void msgError(string msg) {
            this.lblErrorMessage.Text = "      " + msg;
            this.lblErrorMessage.Visible = true;
        }

        private void logOut(object sender, FormClosedEventArgs e) {
            txt_user.Clear();
            txt_password.Text = "Password";
            txt_password.UseSystemPasswordChar = false;
            txt_user.Text = "Usuário";
            lblErrorMessage.Visible = false;
            this.Show();
            // txt_user.Focus();
        }
    }
}
