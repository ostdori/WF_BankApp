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
    public partial class TransferForm : Form
    {
        public TransferForm()
        {
            InitializeComponent();
            CurrentData();
        }

        private void CurrentData()
        {
            lblDate.Text = DateTime.UtcNow.ToString("MM/dd/yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BankAppWFEntities db = new BankAppWFEntities();
            float b = (float)Convert.ToDecimal(txtAccNum.Text);
            var item = (from u in db.CustomerAccounts
                        where u.AccountNumber == b
                        select u).FirstOrDefault();

            txtName.Text = item.Firstname + " " + item.Lastname;
            txtBalance.Text = Convert.ToString(item.AccountBalance);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BankAppWFEntities db = new BankAppWFEntities();
            float b = (float)Convert.ToDecimal(txtAccNum.Text);
            var item = (from u in db.CustomerAccounts
                        where u.AccountNumber == b
                        select u).FirstOrDefault();

            float b1 = (float)Convert.ToDecimal(item.AccountBalance);
            float transferAmount = (float)Convert.ToDecimal(txtTamount.Text);
            float transferTo = (float)Convert.ToDecimal(txtTransferTo.Text);

            if (b1 > transferAmount)
            {
                CustomerAccount item2 = (from u in db.CustomerAccounts
                                         where u.AccountNumber == transferTo
                                         select u).FirstOrDefault();

                item2.AccountBalance = item2.AccountBalance + transferAmount;
                item.AccountBalance = item.AccountBalance - transferAmount;
                Transfer transf = new Transfer();
                transf.AccountNumber = (int)Convert.ToDecimal(txtAccNum.Text);
                transf.TransferTo = (int)Convert.ToDecimal(txtTransferTo.Text);
                transf.TransferAmount = (float)Convert.ToDecimal(txtTamount.Text);
                transf.Date = dateTimePicker1.Value.Date;
                transf.Fullname = txtName.Text;
                transf.Balance = (float)Convert.ToDecimal(txtBalance.Text);



                db.Transfers.Add(transf);
                db.SaveChanges();
               
                DialogResult result = MessageBox.Show("Successful Transfer!", "Transfer Confirmation", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    this.Close();
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
