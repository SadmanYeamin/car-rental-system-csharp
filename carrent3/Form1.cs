using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace carrent3
{
    public partial class Login : Form
    {
        

        private SqlConnection con = new SqlConnection();

        public Login()
        {
            InitializeComponent();
            con.ConnectionString = "data source = localhost;" +
                       "database = mydatabase;" +
                       "integrated security = SSPI";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            signup s = new signup();
            s.Show();
            this.Hide();
        }

        private void bunifuTextbox1_Enter(object sender, EventArgs e)
        {
            if (usertext._TextBox.Text == "Enter Username")
            { usertext._TextBox.Text = ""; }
        }

        private void usertext_Leave(object sender, EventArgs e)
        {
            if (usertext._TextBox.Text == "")
            { usertext._TextBox.Text = "Enter Username"; }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //passtext._TextBox.PasswordChar = '*';
        }

        private void passtext_OnTextChange(object sender, EventArgs e)
        {
            passtext._TextBox.PasswordChar = '*';
        }

        private void passtext_Enter(object sender, EventArgs e)
        {
            if (passtext._TextBox.Text == "Enter Password")
            { passtext._TextBox.Text = ""; }
        }

        private void passtext_Leave(object sender, EventArgs e)
        {
            if (passtext._TextBox.Text == "")
            { passtext._TextBox.Text = "Enter Password"; }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            //this.OnMaximumSizeChanged();

            this.WindowState = FormWindowState.Maximized;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (usertext._TextBox.Text == "Admin" || usertext._TextBox.Text == "admin")
            {
                //Opening the connection:
                con.Open();

                //Execute SQL Query:

                SqlCommand command = new SqlCommand("select * from uinfo where username = '" + usertext._TextBox.Text + "' and password = '" + passtext._TextBox.Text + "' ", con);

                SqlDataReader DR = command.ExecuteReader();

                int count = 0;

                while (DR.Read())
                {
                    count = count + 1;
                }

                if (count == 1)
                {
                    MessageBox.Show("Login Successful");


                    admin f1 = new admin();
                    f1.Show();
                    this.Hide();
                }

                if (count == 0)
                {
                    MessageBox.Show("Please Enter Username and password correctly");
                }




                //Disconnect
                con.Close();
            }

            else
            {
                //Opening the connection:
                con.Open();

                //Execute SQL Query:

                SqlCommand command = new SqlCommand("select * from uinfo where username = '" + usertext._TextBox.Text + "' and password = '" + passtext._TextBox.Text + "' ", con);

                SqlDataReader DR = command.ExecuteReader();

                int count = 0;

                while (DR.Read())
                {
                    count = count + 1;
                }

                if (count == 1)
                {
                    MessageBox.Show("Login Successful");


                    user f2 = new user(usertext._TextBox.Text);
                    f2.ShowDialog();
                    this.Hide();
                }

                if (count == 0)
                {
                    MessageBox.Show("Please Enter Username and password correctly");
                }




                //Disconnect
                con.Close();
            }



        }
    }
}
