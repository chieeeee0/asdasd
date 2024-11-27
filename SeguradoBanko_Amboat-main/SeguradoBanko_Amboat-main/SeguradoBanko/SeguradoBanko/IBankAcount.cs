using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeguradoBanko
{
    public interface IBankAcount
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        string EmailAddress { get; set; }
        string PINCode { get; set; }
        string SecretAns { get; set; }
        string SecretQues { get; set; }
        string PasswordHash { get; set; }
        string PasswordSalt { get; set; }
        string Fullname { get; set; }


        bool BankTransferMethod(string method, string accountName, string accountNumber, int amount);
        bool PayBillsMethod(string biller, string accountID, int amount);
        bool RegisterMethod(BankAccount account, string firstname, string lastname, string email, string PIN, string SecretAns, string secretQues);
        bool ForgotPasswordMethod(string email, string secretAns, string secretQues);
        bool ChangePasswordMethod(string newPIN, string confirmNewPIN);
        bool GetFullName(string firstname, string lastname);
        void CreatePasswordHash(string PIN, out byte[] passwordHash, out byte[] passwordSalt);
        bool VerifyPasswordHash(string PIN, string storedHash, string storedSalt);
        void SetPINCode(byte[] passwordHash, byte[] passwordSalt);
    }
}
