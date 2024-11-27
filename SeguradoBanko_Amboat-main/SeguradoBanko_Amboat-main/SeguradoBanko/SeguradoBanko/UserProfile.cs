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
    public partial class UserProfile : Form
    {
        BankAccount account = null;
        public UserProfile()
        {
            InitializeComponent();
        }
        public UserProfile(BankAccount account)
        {
            this.account = account;
            InitializeComponent();
            
        }
        private void UserProfile_Load(object sender, EventArgs e)
        {
            lblFullname.Text = account.Fullname;
            lblEmailAddress.Text = account.EmailAddress;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HomeScreen home = new HomeScreen(account);
            home.Show();
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
            PayBills paybills = new PayBills(account);
            paybills.Show();
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
            History history = new History(account);
            history.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Start start = new Start(account);
            start.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            ChangePassword changepass = new ChangePassword(account);
            changepass.Show();
            this.Hide();
        }
    }
}
