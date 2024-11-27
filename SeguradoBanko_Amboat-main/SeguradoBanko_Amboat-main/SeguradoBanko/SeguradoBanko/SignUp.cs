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
    public partial class SignUp : Form
    {
        BankAccount account = new BankAccount();
        public SignUp()
        {
            InitializeComponent();
        }
        public SignUp(BankAccount account)
        {
            this.account = account;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Start start = new Start();
            start.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            BankAccount bAccount = new BankAccount();
            
            bAccount.Firstname = txtRegisterFirstname.Text;
            bAccount.Lastname = txtRegisterLastname.Text;
            bAccount.EmailAddress = txtRegisterEmailAddress.Text;
            bAccount.PINCode = txtRegisterPINCode.Text;
            bAccount.SecretQues = txtRegisterSecretQuestion.Text;
            bAccount.SecretAns = txtRegisterSecretAnswer.Text;

            account.GetFullName(txtRegisterFirstname.Text, txtRegisterLastname.Text);  
            if (account.RegisterMethod(bAccount, txtRegisterFirstname.Text, txtRegisterLastname.Text, txtRegisterEmailAddress.Text, txtRegisterPINCode.Text, txtRegisterSecretAnswer.Text, txtRegisterSecretQuestion.Text))
            {
                DialogResult dialog = MessageBox.Show("Successful Sign Up! \n\nBank to the Fullest with Segurado Banko!", "Segurado Banko", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialog == DialogResult.OK)
                {
                    SignIn signin = new SignIn(account);
                    signin.Show();
                    this.Hide();
                }
            }
                

            
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
