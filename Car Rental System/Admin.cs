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
    public partial class Admin : Form
    {
        DBAccess objDbAccess = new DBAccess();
        DataTable dtUsers = new DataTable();

        public Admin()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            string query = "Select * from Users";
            objDbAccess.readDatathroughAdapter(query, dtUsers);
            dataGridView1.DataSource = dtUsers;// the data table which is filled 
            objDbAccess.closeConn();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtName.Text = row.Cells["Name"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPassword.Text = row.Cells["Password"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
              
            }
        }

        private void btnPerformOperation_Click(object sender, EventArgs e)
        {
            string query = "Select * from Users";
            int changes = objDbAccess.executeDataAdapter(dtUsers, query);
            MessageBox.Show("Count =" + changes);

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignIn signIn = new SignIn();
            signIn.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                txtName.Text = row.Cells["Brand"].Value.ToString();
                txtEmail.Text = row.Cells["Model"].Value.ToString();
                txtPassword.Text = row.Cells["NumberPlate"].Value.ToString();
                txtAddress.Text = row.Cells["Color"].Value.ToString();
                txtAddress.Text = row.Cells["Driver"].Value.ToString();
                txtAddress.Text = row.Cells["DriverContactNumber"].Value.ToString();
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
