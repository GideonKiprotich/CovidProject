using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CovidProject
{
    public partial class frmLogin : Form
    {
        public bool IsSucceeded { get; set; }
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.IsSucceeded = false;
            // the validation code goes here

            if(txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("User name required");
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Password required");
                txtPassword.Focus();
                return;
            }

            //further code to come here

            this.IsSucceeded = true;
            this.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.IsSucceeded = false;

        }
    }
}
