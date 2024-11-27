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
    public partial class ForgotPassword : Form
    {
        BankAccount account = null;
        public ForgotPassword()
        {
            InitializeComponent();
        }
        public ForgotPassword(BankAccount account)
        {
            this.account = account;
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (account.ForgotPasswordMethod(txtForgotEmailAddress.Text, cmbForgotAnswer.Text, cmbForgotQuestion.Text))
            {
                DialogResult dialog = MessageBox.Show("Would you like to change password?", "Segurado Banko", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                
                if (dialog == DialogResult.Yes)
                {
                    ChangePassword changepass = new ChangePassword(account);
                    changepass.Show();
                    this.Hide();
                }
                else if (dialog == DialogResult.No)
                {
                    SignIn signin = new SignIn(account);
                    signin.Show();
                    this.Hide();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SignIn signin = new SignIn(account);
            signin.Show();
            this.Hide();
        }
    }
}
