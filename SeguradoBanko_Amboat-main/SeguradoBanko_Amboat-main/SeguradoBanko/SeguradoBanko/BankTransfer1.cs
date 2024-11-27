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
    public partial class BankTransfer1 : Form
    {
        BankAccount account = null;

        public BankTransfer1()
        {
            InitializeComponent();
        }
        public BankTransfer1(BankAccount account)
        {
            this.account = account;
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           if (account.BankTransferMethod(cmbPartner.Text, txtTransAccountName.Text, txtTransAccountNumber.Text, Convert.ToInt32(txtTransAmount.Text)))
            {
                DialogResult dialog = MessageBox.Show($"               RECEIPT      \n\n\n\nAccount Holder: {account.Fullname} \nPartner Bank: {cmbPartner.Text} \nSent To: {txtTransAccountName.Text}\nSent Amount: ₱ {txtTransAmount.Text} \n\nNew Balance: ₱ {account.Balance} \n\n\n\nReference No. 209320-2392", "Segurado Banko", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (dialog == DialogResult.OK)
                {
                    cmbPartner.Focus();
                    txtTransAccountName.Clear();
                    txtTransAmount.Clear();
                    txtTransAccountNumber.Focus();
                }
            }
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            History history = new History();
            history.Show();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            BankTransfer banktrans = new BankTransfer(account);
            banktrans.Show();
            this.Hide();
        }
    }
}
