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
    public partial class HomeScreen : Form
    {
        BankAccount account = null;
        public HomeScreen()
        {
            InitializeComponent();
        }
        

        public HomeScreen(BankAccount account)
        {
            InitializeComponent(); 
            this.account = account;
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

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            
            lblUser.Text = "Hi, " + account.Firstname + "!";
            lblHomeFullname.Text = account.Fullname;
            lblHomeBalance.Text = "₱ " + Convert.ToString(account.Balance);

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            UserProfile user = new UserProfile(account);
            user.Show();
            this.Hide();
        }
    }
}
