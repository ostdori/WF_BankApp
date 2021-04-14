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
    public partial class SearchEdit : Form
    {
        BankAppWFEntities db;
        BindingList<CustomerAccount> bi;

        public SearchEdit()
        {
            InitializeComponent();
            CurrentDate();
        }
        private void CurrentDate()
        {
            lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bi = new BindingList<CustomerAccount>();
            db = new BankAppWFEntities();
            decimal accNum = Convert.ToDecimal(txtAccNum.Text);
            var acc = db.CustomerAccounts.Where(a => a.AccountNumber == accNum);
            foreach (var item in acc)
            {
                bi.Add(item);
            }
            dataGridView1.DataSource = bi;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bi = new BindingList<CustomerAccount>();
            db = new BankAppWFEntities();
            //var acc = db.CustomerAccounts.Where(a => a.Firstname == txtFname.Text);
            string b = txtName.Text;


            var acc = (from u in db.CustomerAccounts
                       where u.Firstname == b || u.Lastname == b
                       select u);


            foreach (var item in acc)
            {
                bi.Add(item);
            }
            dataGridView1.DataSource = bi;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db = new BankAppWFEntities();
            decimal accNum = Convert.ToDecimal(txtAccNum.Text);
            CustomerAccount custacc = db.CustomerAccounts.First(s => s.AccountNumber == accNum);
            custacc.AccountNumber = (int)Convert.ToDecimal(txtAccNum.Text);
            custacc.Firstname = txtFname.Text;
            custacc.Lastname = txtLname.Text;
            custacc.Birthdate = dateTimePicker1.Value.Date;
            custacc.Address = txtAddress.Text;
            custacc.Mobile = txtMobile.Text;
            custacc.AccountBalance = (float)Convert.ToDecimal(txtBalance.Text);

            db.SaveChanges();

            DialogResult result = MessageBox.Show("Successful Update!", "Edit Confirmation", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                this.Close();
            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            bi.RemoveAt(dataGridView1.CurrentCell.RowIndex);
            db = new BankAppWFEntities();
            decimal b = Convert.ToDecimal(txtAccNum.Text);
            CustomerAccount acc = db.CustomerAccounts.First(s => s.AccountNumber == b);
            db.CustomerAccounts.Remove(acc);
            db.SaveChanges();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            db = new BankAppWFEntities();
            decimal accNum = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            var acc = db.CustomerAccounts.Where(a => a.AccountNumber == accNum).FirstOrDefault();
            txtAccNum.Text = acc.AccountNumber.ToString();
            txtFname.Text = acc.Firstname;
            txtLname.Text = acc.Lastname;
            txtAddress.Text = acc.Address;
            txtMobile.Text = acc.Mobile;
            txtBalance.Text = Convert.ToString(acc.AccountBalance);
            dateTimePicker1.Text = acc.Birthdate.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
