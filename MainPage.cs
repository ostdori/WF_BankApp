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
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void newAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewAccount addNewAcc = new AddNewAccount();
            addNewAcc.MdiParent = this;
            addNewAcc.Show();
        }

        private void searchEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchEdit se = new SearchEdit();
            se.MdiParent = this;
            se.Show();
        }

        private void customersListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomersList cl = new CustomersList();
            cl.MdiParent = this;
            cl.Show();
        }

        private void depositToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepositForm df = new DepositForm();
            df.MdiParent = this;
            df.Show();
        }

        private void withdrawalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WithdrawalForm wf = new WithdrawalForm();
            wf.MdiParent = this;
            wf.Show();
        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransferForm tf = new TransferForm();
            tf.MdiParent = this;
            tf.Show();

        }

        private void accountHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoryForm hf = new HistoryForm();
            hf.MdiParent = this;
            hf.Show();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
