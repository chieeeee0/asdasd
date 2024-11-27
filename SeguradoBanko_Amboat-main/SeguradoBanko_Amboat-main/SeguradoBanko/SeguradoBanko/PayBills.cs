using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeguradoBanko
{
      public partial class PayBills : Form
    {
        BankAccount account = null;
        public PayBills(BankAccount account)
        {
            this.account = account;
            InitializeComponent();
        }
        public PayBills()
        {
            InitializeComponent();
        }

        private void PayBills_Load(object sender, EventArgs e)
        {
            lblBillsFullname.Text = account.Fullname;
            lblBillsBalance.Text += "₱ " + Convert.ToString(account.Balance);
        }

        private void guna2Panel1_Click(object sender, EventArgs e)
        {
            PayBills1 pay1 = new PayBills1(account);
            pay1.Show();
            this.Hide();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            HomeScreen home = new HomeScreen(account);
            home.Show();
            this.Hide();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            PayBills payBills = new PayBills(account);
            payBills.Show();
            this.Hide();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            BankTransfer transfer = new BankTransfer(account);
            transfer.Show();
            this.Hide();
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            History history = new History();
            history.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HomeScreen home = new HomeScreen(account);
            home.Show();
            this.Hide();
        }
    }
}
