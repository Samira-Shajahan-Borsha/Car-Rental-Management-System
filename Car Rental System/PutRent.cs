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
    public partial class PutRent : Form
    {
        DBAccess objDBAccess = new DBAccess();
        public PutRent()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string brand = txtBrand.Text;
            string model = txtModel.Text;
            string numberPlate = txtNumberPlate.Text;
            string color = txtColor.Text;
            string driver = txtDriver.Text;
            string driverContactNumber = txtDriverContactNumber.Text;

            SqlCommand insertCommand = new SqlCommand("insert into TakeRent " +
                   "(Brand,Model,NumberPlate,Color,Driver,DriverContactNumber) " +
                   "Values (@brand,@model,@numberPlate,@color,@driver,@driverContactNumber)");

            insertCommand.Parameters.AddWithValue("@brand", brand);
            insertCommand.Parameters.AddWithValue("@model", model);
            insertCommand.Parameters.AddWithValue("@numberPlate", numberPlate);
            insertCommand.Parameters.AddWithValue("@color", color);
            insertCommand.Parameters.AddWithValue("@driver", driver);
            insertCommand.Parameters.AddWithValue("@driverContactNumber", driverContactNumber);

            int row = objDBAccess.executeQuery(insertCommand);

            if (row == 1)
            {
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error Occured.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home admin = new Home();
            admin.Show();
        }
    }
}
