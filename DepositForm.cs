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
    public partial class DepositForm : Form
    {
        public DepositForm()
        {
            InitializeComponent();
            CurrentDate();
        }

        private void CurrentDate()
        {
            lblDate.Text = DateTime.UtcNow.ToString("MM/dd/yyyy");
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
           

            BankAppWFEntities db = new BankAppWFEntities();
            float b = (float)Convert.ToDecimal(txtAccNum.Text);
            var item = (from u in db.CustomerAccounts
                        where u.AccountNumber == b
                        select u).FirstOrDefault();

            txtName.Text = item.Firstname + " " + item.Lastname;
            txtBalance.Text = Convert.ToString(item.AccountBalance);


        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {

            BankAppWFEntities db = new BankAppWFEntities();
            CustomerAccount acc = new CustomerAccount();
            Deposit dp = new Deposit();
            dp.Date = dateTimePicker1.Value.Date;
            dp.AccountNumber = (int)Convert.ToDecimal(txtAccNum.Text);
            dp.Fullname = txtName.Text;
            dp.OldBalance = (float)Convert.ToDecimal(txtBalance.Text);
            dp.DepositAmount = (float)Convert.ToDecimal(txtDepAmount.Text);
            db.Deposits.Add(dp);
            db.SaveChanges();
            float b = (float)Convert.ToDecimal(txtAccNum.Text);
            var item = (from u in db.CustomerAccounts
                        where u.AccountNumber == b
                        select u).FirstOrDefault();

            item.AccountBalance = item.AccountBalance + (float)Convert.ToDecimal(txtDepAmount.Text);
            db.SaveChanges();
            
            DialogResult result = MessageBox.Show("Successful Deposit!", "Successful", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
