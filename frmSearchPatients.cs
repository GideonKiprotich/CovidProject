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
    public partial class frmSearchPatients : Form
    {
        public int selInt { get; set; }
        public frmSearchPatients()
        {
            InitializeComponent();
        }

        private void frmSearchPatients_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = DESKTOP-ONB45I9; Initial Catalog = CovidPatients; User ID =Gideon; Password = 1234";

            conn.Open();


            string sql = "";
            sql = "SELECT * FROM  tblPatients";



            SqlCommand comm = new SqlCommand(sql, conn);

            SqlDataReader rd = comm.ExecuteReader();

            while (rd.Read())
            {
                ListViewItem item = new ListViewItem(rd[0].ToString());
                item.SubItems.Add(rd[1].ToString());
                item.SubItems.Add(rd[2].ToString());
                item.SubItems.Add(rd[3].ToString());
                item.SubItems.Add(rd[4].ToString());
                item.SubItems.Add(rd[5].ToString());
                item.SubItems.Add(rd[6].ToString());

                lvwList.Items.Add(item);


            }




            conn.Close();
        }

        private void lvwList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwList.FocusedItem == null) return;
            int i = lvwList.FocusedItem.Index;
            label1.Text = lvwList.Items[i].Text + "Name:" + lvwList.Items[i].SubItems[1].Text + "IdNo:" + lvwList.Items[i].SubItems[2].Text;

            this.selInt = int.Parse(lvwList.Items[i].Text);

        }

        private void lvwList_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSearchPatients_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

