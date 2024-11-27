using Microsoft.SqlServer.Server;
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
    public partial class SignIn : Form
    {
        BankAccount account = null;
        public SignIn()
        {
            InitializeComponent();
        }
        public SignIn(BankAccount account)
        {
            InitializeComponent();
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
            txtTruePIN.Text += "1";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            txtTruePIN.Text += "2";
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            txtTruePIN.Text += "3";
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            txtTruePIN.Text += "4";
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            txtTruePIN.Text += "5";
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            txtTruePIN.Text += "6";
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            txtTruePIN.Text += "7";
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            txtTruePIN.Text += "8";
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            txtTruePIN.Text += "9";
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            txtTruePIN.Text += "0";
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            if (txtTruePIN.Text.Length > 0)
            {
                txtTruePIN.Text = txtTruePIN.Text.Substring(0, txtTruePIN.Text.Length - 1);
            }
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            if (txtTruePIN.Text.Length != 0)
            {
               

                if (account.VerifyPasswordHash(txtTruePIN.Text, account.PasswordHash, account.PasswordSalt))
                {
                    DialogResult dialog = MessageBox.Show("Successful Sign In! \n\nBank to the Fullest!", "Segurado Banko", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (dialog == DialogResult.OK)
                    {
                        HomeScreen home = new HomeScreen(account);
                        home.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void txtTruePIN_TextChanged(object sender, EventArgs e)
        {
            if (txtTruePIN.Text.Length < 6)
            {
               

                guna2Button1.Enabled = true;
                guna2Button2.Enabled = true;
                guna2Button3.Enabled = true;
                guna2Button4.Enabled = true;
                guna2Button5.Enabled = true;
                guna2Button6.Enabled = true;
                guna2Button7.Enabled = true;
                guna2Button8.Enabled = true;
                guna2Button9.Enabled = true;
                guna2Button11.Enabled = true;

                if (txtTruePIN.Text.Length == 0)
                {
                    lblBullet.Text = "○ ○ ○ ○ ○ ○";
                }
                else if (txtTruePIN.Text.Length == 1)
                {
                    lblBullet.Text = " •  ○ ○ ○ ○ ○";
                }
                else if (txtTruePIN.Text.Length == 2)
                {
                    lblBullet.Text = " •  •  ○ ○ ○ ○";
                }
                else if (txtTruePIN.Text.Length == 3)
                {
                    lblBullet.Text = " •  •  •  ○ ○ ○";
                }
                else if (txtTruePIN.Text.Length == 4)
                {
                    lblBullet.Text = " •  •  •  •  ○ ○";
                }
                else if (txtTruePIN.Text.Length == 5)
                {
                    lblBullet.Text = " •  •  •  •  •  ○";
                }
                else if (txtTruePIN.Text.Length == 6)
                {
                    lblBullet.Text = " •  •  •  •  •  •";
                }
            }
            else
            {
                lblBullet.Text = " •  •  •  •  •  •";
                guna2Button1.Enabled = false;
                guna2Button2.Enabled = false;
                guna2Button3.Enabled = false;
                guna2Button4.Enabled = false;
                guna2Button5.Enabled = false;
                guna2Button6.Enabled = false;
                guna2Button7.Enabled = false;
                guna2Button8.Enabled = false;
                guna2Button9.Enabled = false;
                guna2Button11.Enabled = false;
            }
           
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotpass = new ForgotPassword(account);
            forgotpass.Show();
            this.Hide();
        }
    }
}
