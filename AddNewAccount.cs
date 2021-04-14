using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAppWF
{
    public partial class AddNewAccount : Form
    {
        float num;
        BankAppWFEntities bankDb;
       
        public AddNewAccount()
        {
            InitializeComponent();
            LoadAccountNumber();
            CurrentDate();
        }


        private void LoadAccountNumber()
        {
            bankDb = new BankAppWFEntities();
            var item = bankDb.CustomerAccounts.ToArray();
            num = item.LastOrDefault().AccountNumber + 1;
            txtAccNum.Text = Convert.ToString(num);
        }

        private void CurrentDate()
        {
            lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bankDb = new BankAppWFEntities();
            CustomerAccount acc = new CustomerAccount();
            acc.AccountNumber = (int)Convert.ToDecimal(txtAccNum.Text);
            acc.Firstname = txtFname.Text;
            acc.Lastname = txtLname.Text;
            acc.Birthdate = dateTimePicker1.Value.Date;
            acc.Address = txtAddress.Text;
            acc.Mobile = txtMobil.Text;
            acc.AccountBalance = (float)Convert.ToDecimal(txtBalance.Text);

            bankDb.CustomerAccounts.Add(acc);
            bankDb.SaveChanges();
            DialogResult result =  MessageBox.Show("New Account Has Been Added!","Successful",MessageBoxButtons.OK);
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
