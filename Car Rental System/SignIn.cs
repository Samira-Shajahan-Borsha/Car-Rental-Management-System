using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental_System
{
    public partial class SignIn : Form
    {
        public static string id, name, email, password, address;

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp signUp = new SignUp();
            signUp.Show();
        }

        DBAccess objDbAccess = new DBAccess();
        DataTable dtUsers = new DataTable();
        public SignIn()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string userEmail = txtEmailLogIn.Text;
            string userPassword = txtPasswordLogIn.Text;

            if (userEmail.Equals(""))
            {
                MessageBox.Show("Please enter your email..");
            }
            else if (userPassword.Equals(""))
            {
                MessageBox.Show("Please eneter your password..");
            }
           
            else
            {
                string query = "Select * from Users where Email = '" + userEmail + "' AND Password = '" + userPassword + "'";

                objDbAccess.readDatathroughAdapter(query, dtUsers);

                if (dtUsers.Rows.Count == 1)
                {
                    id = dtUsers.Rows[0]["ID"].ToString();
                    name = dtUsers.Rows[0]["Name"].ToString();
                    email = dtUsers.Rows[0]["Email"].ToString();
                    password = dtUsers.Rows[0]["Password"].ToString();
                    address = dtUsers.Rows[0]["Address"].ToString();

                    MessageBox.Show("Congratulations, you are logged in ..");
                    objDbAccess.closeConn();
                    this.Hide();
                    MyProfile myP = new MyProfile();
                    myP.Show();
                }
                else
                {
                    MessageBox.Show("Invalid credentials, Provide correct email and password.");
                }
            }
        }
    }
}
