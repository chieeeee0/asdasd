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
    public partial class Start : Form
    {
        BankAccount account = null;
        public Start()
        {
            InitializeComponent();
        }
        public Start(BankAccount account)
        {
            this.account = account;
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SignUp sign = new SignUp();
            sign.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SignIn signin = new SignIn(account);   
            signin.Show();
            this.Hide();
        }
    }
}
