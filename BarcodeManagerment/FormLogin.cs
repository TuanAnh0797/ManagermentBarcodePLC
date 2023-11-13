using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeManagerment
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txb_user.Text.ToUpper() == "PE" && txb_password.Text == "123456")
            {
                Form1 p = new Form1();
                txb_user.Text = "";
                txb_password.Text = "";
                p.ShowDialog();
            }
            else
            {
                txb_user.Text = "";
                txb_password.Text = "";
                txb_user.Focus();
                MessageBox.Show("Đăng nhập thất bại");
            }
        }

        private void txb_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txb_password.Focus();
            }
        }

        private void txb_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btn_login.Focus();
            }
        }
    }
}
