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
    public partial class SignUp : Form
    {
        DBAccess objDBAccess = new DBAccess();
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = txtName.Text;
            string userEmail = txtEmail.Text;
            string userPassword = txtPassword.Text;
            string userAddress = txtAddress.Text;

            if (userName.Equals(""))
            {
                MessageBox.Show("Please enter your Name.");
            }
            else if (userEmail.Equals(""))
            {
                MessageBox.Show("Please enter your Email.");
            }
            else if (userPassword.Equals(""))
            {
                MessageBox.Show("Please enter your Password.");
            }
            else if (userAddress.Equals(""))
            {
                MessageBox.Show("Please enter your Address.");
            }
            else
            {
                SqlCommand insertCommand = new SqlCommand("insert into Users " +
                   "(Name,Email,Password,Address) " +
                   "Values (@userName,@userEmail,@userPassword,@userAddress)");

                insertCommand.Parameters.AddWithValue("@userName", userName);
                insertCommand.Parameters.AddWithValue("@userEmail", userEmail);
                insertCommand.Parameters.AddWithValue("@userPassword", userPassword);
                insertCommand.Parameters.AddWithValue("@userAddress", userAddress);

                int row = objDBAccess.executeQuery(insertCommand);

                if (row == 1)
                {
                    MessageBox.Show("Account created successfully. Please log in now.");

                    this.Hide();
                    SignIn signIn = new SignIn();
                    signIn.Show();
                }
                else
                {
                    MessageBox.Show("Error occured. Try again and again.");
                }

            }
        }
    }
}
