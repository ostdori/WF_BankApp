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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BankAppWFEntities dbBank = new BankAppWFEntities();
            if (txtUser.Text != string.Empty || txtPass.Text != string.Empty)
            {
                var admin = dbBank.Admins.FirstOrDefault(a => a.username.Equals(txtUser.Text));
                if (admin != null)
                {
                    if (admin.password.Equals(txtPass.Text))
                    {
                        MainPage mp = new MainPage();
                        mp.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Password");
                    }
                }
                else
                {
                    MessageBox.Show("Null Value!");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Username and Password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
