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
    public partial class CustomersList : Form
    {
        public CustomersList()
        {
            InitializeComponent();
            BindingList();
        }

        private void BindingList()
        {
            dataGridView1.AutoGenerateColumns = false;
            BankAppWFEntities db = new BankAppWFEntities();
            var item = db.CustomerAccounts.ToList();
            dataGridView1.DataSource = item;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
