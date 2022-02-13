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
    public partial class MyProfile : Form

    {
        DBAccess objDBAccess = new DBAccess();
        public MyProfile()
        {
            InitializeComponent();
        }

        private void MyProfile_Load(object sender, EventArgs e)
        {
           
            txtNameHome.Text = SignIn.name;
            txtEmailHome.Text = SignIn.email;
            txtPasswordHome.Text = SignIn.password;
            txtAddressHome.Text = SignIn.address;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string newUserName = txtNameHome.Text;
            string newUserEmail = txtEmailHome.Text;
            string newUserPassword = txtPasswordHome.Text;
            string newUserAddress = txtAddressHome.Text;
            if (newUserName.Equals(""))
            {
                MessageBox.Show("Please write your name.");
            }
            else if (newUserEmail.Equals(""))
            {
                MessageBox.Show("Please write your email.");
            }
            else if (newUserPassword.Equals(""))
            {
                MessageBox.Show("Please write your password.");
            }
            else if (newUserAddress.Equals(""))
            {
                MessageBox.Show("Please write your address.");
            }
            else
            {
                string query = "Update Users SET Name = '" + @newUserName + "', Email = '" + @newUserEmail + "', Password = '" + @newUserPassword + "', Address = '" + @newUserAddress + "' Where Id = '"+SignIn.id+"'";

                SqlCommand updateCommand = new SqlCommand(query);

                updateCommand.Parameters.AddWithValue("@userName", newUserName);
                updateCommand.Parameters.AddWithValue("@userEmail", newUserEmail);
                updateCommand.Parameters.AddWithValue("@userPassword", newUserPassword);
                updateCommand.Parameters.AddWithValue("@userAddress", newUserAddress);

                int row = objDBAccess.executeQuery(updateCommand);
                if (row == 1)
                {
                    MessageBox.Show("Account information updated successfully.");

                    this.Hide();
                    SignIn sign = new SignIn();
                    sign.Show();
                }
                else
                {
                    MessageBox.Show("Error occured. Try again and again.");
                }
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure ?", "Delete Account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(dialog == DialogResult.Yes)
            {
                string query = "Delete From Users Where ID ='" +SignIn.id+ "'";

                SqlCommand deleteCommand = new SqlCommand(query);
                int row = objDBAccess.executeQuery(deleteCommand);
                if (row == 1)
                {
                    MessageBox.Show("Account deleted successfully.");

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

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home admin = new Home();
            admin.Show();
        }
    }
}
