using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Car_Rental_System
{
    public partial class TakeRent : Form
    {
        
        DBAccess objDBAccess = new DBAccess();

        DataTable dtUsers = new DataTable();

        public TakeRent()
        {
            InitializeComponent();
        }

        private void SedanTakeRent_Load(object sender, EventArgs e)
        {
            string query = "Select * from PutRent";
            objDBAccess.readDatathroughAdapter(query,dtUsers);
            dataGridView1.DataSource = dtUsers;// the data table which is filled 
            objDBAccess.closeConn();
            
        }

        private void btnRequestForRent_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Request sent Successfully.");
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtBrand.Text = row.Cells["Brand"].Value.ToString();
                txtModel.Text = row.Cells["Model"].Value.ToString();
                txtNumberPlate.Text = row.Cells["NumberPlate"].Value.ToString();
                txtColor.Text = row.Cells["Color"].Value.ToString();
                txtDriver.Text = row.Cells["Driver"].Value.ToString();
                txtDriverContactNumber.Text = row.Cells["DriverContactNumber"].Value.ToString();
            }
        }
    }
}
