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
    public partial class WithdrawalForm : Form
    {
        public WithdrawalForm()
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
            decimal b = Convert.ToDecimal(txtAccNum.Text);
            var item = (from u in db.CustomerAccounts
                        where u.AccountNumber == b
                        select u).FirstOrDefault();
            txtName.Text = item.Firstname + " " + item.Lastname;
            txtBalance.Text = Convert.ToString(item.AccountBalance);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BankAppWFEntities db = new BankAppWFEntities();
            CustomerAccount acc = new CustomerAccount();
            Withdrawal dw = new Withdrawal();
            dw.Date = dateTimePicker1.Value.Date;
            dw.AccountNumber = (int)Convert.ToDecimal(txtAccNum.Text);
            dw.Fullname = txtName.Text;
            dw.OldBalance = Convert.ToDecimal(txtBalance.Text);
            dw.WithdrawalAmount = Convert.ToDecimal(txtWamount.Text);
            db.Withdrawals.Add(dw);
            db.SaveChanges();

            decimal b = Convert.ToDecimal(txtAccNum.Text);
            var item = (from u in db.CustomerAccounts
                        where u.AccountNumber == b
                        select u).FirstOrDefault();

            item.AccountBalance = item.AccountBalance - (float)Convert.ToDecimal(txtWamount.Text);
            db.SaveChanges();
            DialogResult result =  MessageBox.Show("Successful Withdrawal!","Withdrawal Confirmation", MessageBoxButtons.OK);
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
