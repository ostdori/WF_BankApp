using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAppWF
{
    public partial class HistoryForm : Form
    {
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            BankAppWFEntities db = new BankAppWFEntities();
            decimal b = Convert.ToDecimal(txtAccNum.Text);
            var item1 = (from u in db.Withdrawals
                         where u.AccountNumber == b
                        orderby u.Date ascending
                         select u );
            dataGridView1.DataSource = item1.ToList();
            
            var item = (from u in db.CustomerAccounts
                       where u.AccountNumber == b
                        select u).FirstOrDefault();
            txtBalance.Text = Convert.ToString(item.AccountBalance);
            lblName.Text = item.Firstname + " " + item.Lastname;
            

            var item2 = (from u in db.Deposits
                         where u.AccountNumber == b
                         select u);
            dataGridView2.DataSource = item2.ToList();
            var item3 = (from u in db.Transfers
                         where u.AccountNumber == b
                         select u);
            dataGridView3.DataSource = item3.ToList();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
