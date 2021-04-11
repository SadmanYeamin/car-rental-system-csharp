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
    public partial class sdputrent : Form
    {
        String userID;
        public sdputrent(String userID)
        {
            InitializeComponent();

            this.userID = userID;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            user u = new user(userID);

            u.Show();

            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            putrent p = new putrent(userID);
            p.Show();

            this.Close();

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(bunifuMetroTextbox1.Text) || String.IsNullOrEmpty(bunifuMetroTextbox2.Text) || String.IsNullOrEmpty(bunifuMetroTextbox3.Text) || String.IsNullOrEmpty(bunifuMetroTextbox4.Text) || String.IsNullOrEmpty(bunifuMetroTextbox5.Text))
            { MessageBox.Show("please fill the remaining details"); }

            else
            {
                //Initiating SQL Connection:
                SqlConnection con = new SqlConnection();

                //ConnectionString:
                con.ConnectionString = "data source = localhost;database = mydatabase;integrated security = SSPI";

                //Generating SQL Query
                string sql = "INSERT sdcar(Brand,Model,Numberplate,Color,Driver,Drivercont) VALUES(@param1,@param2,@param3,@param4,@param5,@param6)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //Opening the connection:
                    con.Open();


                    cmd.Parameters.Add("@param1", SqlDbType.VarChar, 50).Value = textBox1.Text;
                    cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = bunifuMetroTextbox3.Text;
                    cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = bunifuMetroTextbox1.Text;

                    cmd.Parameters.Add("@param4", SqlDbType.VarChar, 50).Value = bunifuMetroTextbox4.Text;
                    cmd.Parameters.Add("@param5", SqlDbType.VarChar, 50).Value = bunifuMetroTextbox2.Text;
                    cmd.Parameters.Add("@param6", SqlDbType.VarChar, 50).Value = bunifuMetroTextbox5.Text;

                    cmd.CommandType = CommandType.Text;






                    cmd.ExecuteNonQuery();



                    //Disconnect
                    con.Close();
                }

                MessageBox.Show("Thank you , Your Driver will be contacted soon after a rent request");
            }
        }
    }
}
