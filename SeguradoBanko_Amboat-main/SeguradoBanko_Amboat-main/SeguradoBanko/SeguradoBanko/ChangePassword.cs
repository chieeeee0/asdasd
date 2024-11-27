using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeguradoBanko
{
    public partial class ChangePassword : Form
    {
        BankAccount account = null;
        public ChangePassword()
        {
            InitializeComponent();
        }
        public ChangePassword(BankAccount account)
        {
            this.account = account;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (account.ChangePasswordMethod(txtNewPIN.Text, txtConfirmNewPIN.Text))
            {
                DialogResult dialog = MessageBox.Show("Password changed successfully! Try Signing In", "Segurado Banko", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (dialog == DialogResult.OK)
                {
                    SignIn signin = new SignIn(account);
                    signin.Show();
                    this.Hide();
                }

            }
        }
    }
}
