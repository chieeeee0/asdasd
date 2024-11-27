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
    public partial class History : Form
    {
        BankAccount account = null;
        public History()
        {
            InitializeComponent();
        }
        public History(BankAccount account)
        {
            this.account = account;
            InitializeComponent();
        }
    }
}
