using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SeguradoBanko
{
    public class BankAccount : IBankAcount
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmailAddress { get; set; }
        public string PINCode { get; set; }
        public string SecretAns { get; set; }
        public string SecretQues { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Fullname { get; set; }

        public int Balance = 50000;

        public BankAccount(BankAccount account)
        {
            this.Firstname = account.Firstname;
            this.Lastname = account.Lastname;
            this.EmailAddress = account.EmailAddress;
            byte[] passwordHash, passwordSalt;
            this.PINCode = account.PINCode;
            this.SecretAns = account.SecretAns;
            this.SecretQues = account.SecretQues;
        }

        public BankAccount()
        {

        }

        public bool BankTransferMethod(string partner, string accountName, string accountNumber, int amount)
        {
            if (partner.Length == 0)
            {
                MessageBox.Show("Please choose a partner to transfer", "Segurado Banko", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (amount > Balance || amount <= 0)
            {
                MessageBox.Show("Enter valid amount", "Segurado Banko", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (accountName.Length == 0)
            {
                MessageBox.Show("Please enter valid Account Name", "Segurado Banko", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (accountName.Length == 0)
            {
                MessageBox.Show("Please enter valid Account Number", "Segurado Banko", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                Balance = Balance - amount;
                return true;
            }
        }

        public bool PayBillsMethod(string biller, string accountID, int amount)
        {
            if (biller.Length == 0)
            {
                MessageBox.Show("Please choose a biller", "Segurado Banko", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (amount > Balance || amount <= 0)
            {
                MessageBox.Show("Enter valid amount", "Segurado Banko", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (accountID.Length == 0)
            {
                MessageBox.Show("Please enter valid Account ID", "Segurado Banko", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else 
            {
                Balance = Balance - amount;
                return true;

            }
        }

       
        public bool RegisterMethod(BankAccount account ,string firstname, string lastname, string email, string PIN, string secretAns, string secretQues)
        {
            if (firstname.Length == 0 || lastname.Length == 0 || email.Length == 0 || secretAns.Length == 0)
            {
                MessageBox.Show("Please fill out the Form", "Segurado Banko", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (PIN.Length != 6)
            {
                MessageBox.Show("PIN Code must be 6 digits", "Segurado Banko", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (!email.EndsWith("@gmail.com"))
            {
                MessageBox.Show("Invalid Email Address", "Segurado Banko", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                Firstname = firstname;
                Lastname = lastname;
                EmailAddress = email;
                PINCode = PIN;  
                SecretAns = secretAns;
                SecretQues = secretQues;
                byte[] passwordHash, salt;
                CreatePasswordHash(PIN, out passwordHash, out salt);
                SetPINCode(passwordHash, salt);

                return true;
            }
        }

    
        public bool GetFullName(string firstname, string lastname)
        {
            this.Fullname = firstname + " " + lastname;  

            return true;
        }

        public bool ForgotPasswordMethod(string enteredEmail, string secretAns, string secretQues)
        {
            if (enteredEmail != EmailAddress)
            {
                MessageBox.Show("Invalid Email Address", "Segurado Banko", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
           
            else if (secretQues != SecretQues)
            {
                MessageBox.Show("Invalid Secret Answer", "Segurado Banko", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (secretQues == SecretQues)
            {
                if (secretAns != SecretAns)
                {
                    MessageBox.Show("Invalid Secret Answer", "Segurado Banko", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        

        public bool ChangePasswordMethod(string newPIN, string confirmNewPIN)
        {

            byte[] newPasswordHash, newSalt;
            CreatePasswordHash(newPIN, out newPasswordHash, out newSalt);


            SetPINCode(newPasswordHash, newSalt);


            return true;
        }

        public void CreatePasswordHash(string PIN, out byte[] passwordHash, out byte[] passwordSalt)
        {

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(PIN));
            }
        }

        public bool VerifyPasswordHash(string PIN, string storedHash, string storedSalt)
        {
            byte[] salt = Convert.FromBase64String(storedSalt);
            byte[] hash = Convert.FromBase64String(storedHash);

            using (var hmac = new System.Security.Cryptography.HMACSHA512(salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(PIN));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != hash[i])
                    {
                        MessageBox.Show("Invalid PIN Code", "Segurado Banko", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }

        public void SetPINCode(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = Convert.ToBase64String(passwordHash);
            PasswordSalt = Convert.ToBase64String(passwordSalt);
        }
    }
}
