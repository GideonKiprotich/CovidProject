using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CovidProject
{
    public partial class frmPatient : Form
    {
        int curId = 0;
        public frmPatient()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            curId = 0;
            clearText();
            txtName.Focus();
       
        }
        private void clearText()
        {
            txtName.Text = "";
            txtIdNo.Text = "";
            txtCountry.Text = "";
            dtpDOB.Value = DateTime.Today;
            cmbGender.SelectedIndex = -1;
            chkIsActive.Checked = true;
        }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if(txtName.Text.Trim() == "")
            {

                MessageBox.Show("Please enter the patient name");
                txtName.Focus();
                return;
            }
            if (txtIdNo.Text.Trim() == "")
            {

                MessageBox.Show("Please enter the Id No");
                txtIdNo.Focus();
                return;
            }

            //do the database connection from here...

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = DESKTOP-ONB45I9; Initial Catalog = CovidPatients; User ID =Gideon; Password = 1234";

            conn.Open();

            //code goes here..

            int val = 0;
            if (chkIsActive.Checked) val = 1;

            string sql = "";
            if(curId == 0){ 
            sql = "INSERT INTO tblPatients (Name, IDNO, DOB,Gender,Country,IsActive)VALUES('" + txtName.Text + "'," + txtIdNo.Text + ",'" + dtpDOB.Value.ToString("yyyyMMdd") + "','" + cmbGender.Text + "','" + txtCountry.Text + "'," + val + ")";
            }
            else
            {
                sql = "UPDATE tblPatients SET Name= '" + txtName.Text + "', IdNo = " + txtIdNo.Text + ", DOB = '" + dtpDOB.Value.ToString("yyyyMMdd") + "', Gender = '" + cmbGender.Text + "', Country = '" + txtCountry.Text + "', IsActive = " + val + " WHERE PatientId = " + curId;
            }

            MessageBox.Show(sql);



            SqlCommand comm = new SqlCommand(sql, conn);
            comm.ExecuteNonQuery();

            
       

            conn.Close();

            MessageBox.Show("Process Completed");




        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            frmSearchPatients frm = new frmSearchPatients();
            frm.ShowDialog();
            displayinfo(frm.selInt);
            curId = frm.selInt;
        }

        private void displayinfo(int id)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = DESKTOP-ONB45I9; Initial Catalog = CovidPatients; User ID =Gideon; Password = 1234";

            conn.Open();


            string sql = "";
            sql = "SELECT * FROM  tblPatients WHERE PatientId = " + id;



            SqlCommand comm = new SqlCommand(sql, conn);

            SqlDataReader rd = comm.ExecuteReader();

            if (rd.Read())
            {
                
                txtName.Text = rd[1].ToString();
                txtIdNo.Text = rd[2].ToString();
                dtpDOB.Value = DateTime.Parse(rd[3].ToString());
                cmbGender.Text = rd[4].ToString();
                txtCountry.Text = rd[5].ToString();
                chkIsActive.Checked = bool.Parse(rd[6].ToString());

                }
            
            conn.Close();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            if(curId <= 0)
            {
                MessageBox.Show("Please select an item to Delete", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult dresult = MessageBox.Show("Are you sure you want to delete the selected item?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dresult == DialogResult.No)
                return;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = DESKTOP-ONB45I9; Initial Catalog = CovidPatients; User ID =Gideon; Password = 1234";

            conn.Open();

            //code goes here..

            string sql = "";
           
                sql = "DELETE FROM tblPatients  WHERE PatientId = " + curId;
            

            MessageBox.Show(sql);



            SqlCommand comm = new SqlCommand(sql, conn);
            comm.ExecuteNonQuery();




            conn.Close();

            MessageBox.Show("Process succeeded");
            curId = 0;

            clearText();
            txtName.Focus();

        }
    }
}
