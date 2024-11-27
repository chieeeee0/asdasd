using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeguradoBanko
{
    public partial class PayBills1 : Form
    {
        BankAccount account = null;
        public PayBills1()
        {
            InitializeComponent();
        }
        public PayBills1(BankAccount account)
        {
            this.account = account;
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (account.PayBillsMethod(chkBiller.Text, txtBillsAccountID.Text, Convert.ToInt32(txtBillsAmount.Text)))
            {
               DialogResult dialog =  MessageBox.Show($"               RECEIPT      \n\n\n\nAccount Holder: {account.Fullname} \nBiller: {chkBiller.Text} \nAmount: ₱ {txtBillsAmount.Text} \n\nNew Balance: ₱ {account.Balance} \n\n\n\nReference No. 209320-2392", "Segurado Banko", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialog == DialogResult.OK)
                {
                    txtBillsAccountID.Clear();
                    txtBillsAmount.Clear();
                    chkBiller.Focus();
                }
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            HomeScreen home = new HomeScreen(account);
            home.Show();
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
            PayBills pay = new PayBills(account);
            pay.Show();
            this.Hide();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            PayBills1 payBills1 = new PayBills1(account);
            payBills1.Show();
            this.Hide();
        }
    }
}
