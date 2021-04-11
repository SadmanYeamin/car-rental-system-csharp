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
    public partial class myprofile : Form
    {
        String userID;
        public myprofile(String userID)
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

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            user u = new user(userID);
            u.Show();
            this.Close();
        }

        private void myprofile_Load(object sender, EventArgs e)
        {
            //Initialization:
            //Initiating SQL Connection:
            SqlConnection con = new SqlConnection();

            //ConnectionString:
            con.ConnectionString = "data source = localhost;" +
                                   "database = mydatabase;" +
                                   "integrated security = SSPI";

            //Generating SQL Query
            SqlCommand command = new SqlCommand("select * from uinfo where Username = '" + userID + "'", con);

            //Opening the connection:
            con.Open();

            //Execute SQL Query:
            SqlDataReader DR = command.ExecuteReader();


            while (DR.Read())
            {
                textBox1.Text = (DR["Fullname"].ToString());
                bunifuMetroTextbox1.Text = (DR["Username"].ToString());

                //textBox3.Text = (DR["Gender"].ToString());
                //textBox4.Text = (DR["Dateofbirth"].ToString());
                bunifuMetroTextbox2.Text = (DR["Address"].ToString());
                bunifuMetroTextbox3.Text = (DR["Email"].ToString());
                bunifuMetroTextbox4.Text = (DR["Password"].ToString());
                dateTimePicker1.Value = Convert.ToDateTime(DR["Dateofbirth"].ToString());
                if (DR["Gender"].ToString() == "male")
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                }
                else
                {
                    radioButton2.Checked = true;
                    radioButton1.Checked = false;
                }


            }

            ////Binding reader to binding source
            //BindingSource source = new BindingSource();
            //source.DataSource = DR;

            ////Binding gridview or control datacsource to binding source:
            //dataGridView1.DataSource = source;

            //Disconnect
            con.Close();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();

            //ConnectionString:
            con.ConnectionString = "data source = localhost;" +
                                   "database = mydatabase;" +
                                   "integrated security = SSPI";

            SqlCommand cmd = new SqlCommand("update uinfo set Fullname=@param1,Username=@param2,Gender=@param3,Dateofbirth=@param4,Address=@param5,Email=@param6,Password=@param7 where Username = '" + userID + "'", con);

            con.Open();
            //cmd.Parameters.AddWithValue("@id", ID);  
            cmd.Parameters.AddWithValue("@param1", textBox1.Text);
            cmd.Parameters.AddWithValue("@param2", bunifuMetroTextbox1.Text);

            if (radioButton1.Checked)
            {
                cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = "male";
            }
            else
            {
                cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = "female";
            }
            //cmd.Parameters.AddWithValue("@param3", textBox3.Text);

            cmd.Parameters.Add("@param4", SqlDbType.Date).Value = dateTimePicker1.Value.Date;
            //cmd.Parameters.AddWithValue("@param4", textBox4.Text);
            cmd.Parameters.AddWithValue("@param5", bunifuMetroTextbox2.Text);
            cmd.Parameters.AddWithValue("@param6", bunifuMetroTextbox3.Text);
            cmd.Parameters.AddWithValue("@param7", bunifuMetroTextbox4.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
            con.Close();

            //DisplayData();  
            //ClearData();  

            //MessageBox.Show("Please Select Record to Update"); 
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            //Initiating SQL Connection:
            SqlConnection con = new SqlConnection();

            //ConnectionString:
            con.ConnectionString = "data source = localhost;database = mydatabase;integrated security = SSPI";

            //Generating SQL Query
            SqlCommand command = new SqlCommand("delete uinfo where username = '" + userID + "' ", con);
            //using (SqlCommand cmd = new SqlCommand(sql, con))
            //{
            //Opening the connection:
            con.Open();


            

            command.CommandType = CommandType.Text;






            int i = command.ExecuteNonQuery();

            if (i >= 1)
            { MessageBox.Show("Delete Successfull"); }

            else { MessageBox.Show("Delete unuccessful"); }




            //Disconnect
            con.Close();

            Login l = new Login();
            l.Show();
            this.Close();
        }
    }
}
