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
    public partial class admin : Form
    {

        public admin()
        {
            InitializeComponent();


        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void admin_Load(object sender, EventArgs e)
        {
            //Initialization:
            //Initiating SQL Connection:
            SqlConnection con = new SqlConnection();

            //ConnectionString:
            con.ConnectionString = "data source = localhost;" +
                                   "database = mydatabase;" +
                                   "integrated security = SSPI";

            //Generating SQL Query
            SqlCommand command = new SqlCommand("select * from uinfo", con);

            //Opening the connection:
            con.Open();

            //Execute SQL Query:
            SqlDataReader DR = command.ExecuteReader();

            //Binding reader to binding source
            BindingSource source = new BindingSource();
            source.DataSource = DR;

            //Binding gridview or control datacsource to binding source:
            bunifuCustomDataGrid1.DataSource = source;

            //Disconnect
            con.Close();

            //int totalRowHeight = dataGridView1.ColumnHeadersHeight;

            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //    totalRowHeight += row.Height;

            //dataGridView1.Height = totalRowHeight;
            //this.Height = dataGridView1.Height + 100;

            SqlConnection conn = new SqlConnection();

            //ConnectionString:
            conn.ConnectionString = "data source = localhost;" +
                                   "database = mydatabase;" +
                                   "integrated security = SSPI";

            //Generating SQL Query
            SqlCommand commanddd = new SqlCommand("select * from sdreq", conn);

            //Opening the connection:
            conn.Open();

            //Execute SQL Query:
            SqlDataReader D = commanddd.ExecuteReader();

            //Binding reader to binding source
            BindingSource sourc = new BindingSource();
            sourc.DataSource = D;

            //Binding gridview or control datacsource to binding source:
            //dataGridView2.DataSource = sourc;
            //source.DataSource = DR;

            var hasItem = D.HasRows;

            if (hasItem)
            {

                //Binding gridview or control datacsource to binding source:
                bunifuCustomDataGrid2.DataSource = sourc;
            }

            //Disconnect
            conn.Close();


            SqlConnection co = new SqlConnection();

            //ConnectionString:
            co.ConnectionString = "data source = localhost;" +
                                   "database = mydatabase;" +
                                   "integrated security = SSPI";

            //Generating SQL Query
            SqlCommand commandd = new SqlCommand("select * from svreq", co);

            //Opening the connection:
            co.Open();

            //Execute SQL Query:
            SqlDataReader DRR = commandd.ExecuteReader();

            //Binding reader to binding source
            BindingSource sourcee = new BindingSource();
            sourcee.DataSource = DRR;

            var hasItemm = DRR.HasRows;

            if (hasItemm)
            {

                //Binding gridview or control datacsource to binding source:
                bunifuCustomDataGrid3.DataSource = sourcee;
            }

            //Binding gridview or control datacsource to binding source:
            //dataGridView3.DataSource = sourcee;

            //Disconnect
            co.Close();

            //int totalRowHeight = dataGridView1.ColumnHeadersHeight;

            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //    totalRowHeight += row.Height;

            //dataGridView1.Height = totalRowHeight;
            //this.Height = dataGridView1.Height + 100;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Login u = new Login();

            u.Show();

            this.Close();


        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) && String.IsNullOrEmpty(bunifuMetroTextbox3.Text) && String.IsNullOrEmpty(bunifuMetroTextbox4.Text) && String.IsNullOrEmpty(bunifuMetroTextbox5.Text) && String.IsNullOrEmpty(bunifuMetroTextbox6.Text))

            { MessageBox.Show("Please Enter all the details first"); }
            
            else{
            //Initiating SQL Connection:
            SqlConnection con = new SqlConnection();

            //ConnectionString:
            con.ConnectionString = "data source = localhost;database = mydatabase;integrated security = SSPI";

            //Generating SQL Query
            string sql = "INSERT uinfo(Fullname,Username,Gender,Dateofbirth,Address,Email,Password) VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7)";
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                //Opening the connection:
                con.Open();


                cmd.Parameters.Add("@param1", SqlDbType.VarChar, 50).Value = textBox1.Text;
                cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = bunifuMetroTextbox3.Text;
                if (radioButton1.Checked)
                {
                    cmd.Parameters.Add("@param3", SqlDbType.VarChar,50).Value = "male";
                }
                else
                {
                    cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = "female";
                }
                cmd.Parameters.Add("@param4", SqlDbType.Date).Value = bunifuDatepicker1.Value.Date;
                cmd.Parameters.Add("@param5", SqlDbType.VarChar, 50).Value = bunifuMetroTextbox4.Text;
                cmd.Parameters.Add("@param6", SqlDbType.VarChar, 50).Value = bunifuMetroTextbox5.Text;
                cmd.Parameters.Add("@param7", SqlDbType.VarChar, 50).Value = bunifuMetroTextbox6.Text;

                cmd.CommandType = CommandType.Text;
                

                

                

                int i =    cmd.ExecuteNonQuery();

                if (i >= 1)
                { MessageBox.Show("Registration Successful"); }

                else { MessageBox.Show("Registration unuccessful");  }



               
                //Disconnect
                con.Close();

                bunifuCustomDataGrid1.DataSource = "data source = localhost;database = mydatabase;integrated security = SSPI";
                bunifuCustomDataGrid1.Refresh();
                SqlCommand commandd = new SqlCommand("select * from uinfo", con);


                con.Open();

                SqlDataReader DR = commandd.ExecuteReader();


                BindingSource source = new BindingSource();
                source.DataSource = DR;


                bunifuCustomDataGrid1.DataSource = source;


                con.Close();
        }
    }
}

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) && String.IsNullOrEmpty(bunifuMetroTextbox3.Text) && String.IsNullOrEmpty(bunifuMetroTextbox4.Text) && String.IsNullOrEmpty(bunifuMetroTextbox5.Text) && String.IsNullOrEmpty(bunifuMetroTextbox6.Text))

            { MessageBox.Show("Please Enter all the details first"); }

            else{


            SqlConnection con = new SqlConnection();

            //ConnectionString:
            con.ConnectionString = "data source = localhost;" +
                                   "database = mydatabase;" +
                                   "integrated security = SSPI";

            SqlCommand cmd = new SqlCommand("update uinfo set Fullname=@param1,Username=@param2,Gender=@param3,Dateofbirth=@param4,Address=@param5,Email=@param6,Password=@param7 where Username = '" + bunifuMetroTextbox3.Text + "'", con);

            con.Open();
            //cmd.Parameters.AddWithValue("@id", ID);  
            cmd.Parameters.AddWithValue("@param1", textBox1.Text);
            cmd.Parameters.AddWithValue("@param2", bunifuMetroTextbox3.Text);

            if (radioButton1.Checked)
            {
                cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = "male";
            }
            else
            {
                cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = "female";
            }
            //cmd.Parameters.AddWithValue("@param3", textBox3.Text);

            cmd.Parameters.Add("@param4", SqlDbType.Date).Value = bunifuDatepicker1.Value.Date;
            //cmd.Parameters.AddWithValue("@param4", textBox4.Text);
            cmd.Parameters.AddWithValue("@param5", bunifuMetroTextbox4.Text);
            cmd.Parameters.AddWithValue("@param6", bunifuMetroTextbox5.Text);
            cmd.Parameters.AddWithValue("@param7", bunifuMetroTextbox6.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
            con.Close();

            //DisplayData();  
            //ClearData();  

            //MessageBox.Show("Please Select Record to Update"); 

            bunifuCustomDataGrid1.DataSource = "data source = localhost;database = mydatabase;integrated security = SSPI";
            bunifuCustomDataGrid1.Refresh();
            SqlCommand commandd = new SqlCommand("select * from uinfo", con);


            con.Open();

            SqlDataReader DR = commandd.ExecuteReader();


            BindingSource source = new BindingSource();
            source.DataSource = DR;


            bunifuCustomDataGrid1.DataSource = source;


            con.Close();
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            //Initiating SQL Connection:
            SqlConnection con = new SqlConnection();

            //ConnectionString:
            con.ConnectionString = "data source = localhost;database = mydatabase;integrated security = SSPI";

            //Generating SQL Query
            SqlCommand command = new SqlCommand("delete uinfo where username = '" + bunifuMetroTextbox3.Text + "' ", con);
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

            bunifuCustomDataGrid1.DataSource = "data source = localhost;database = mydatabase;integrated security = SSPI";
            bunifuCustomDataGrid1.Refresh();
            SqlCommand commandd = new SqlCommand("select * from uinfo", con);


            con.Open();

            SqlDataReader DR = commandd.ExecuteReader();


            BindingSource source = new BindingSource();
            source.DataSource = DR;


            bunifuCustomDataGrid1.DataSource = source;


            con.Close();




        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            bunifuMetroTextbox3.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            //textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            //textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            bunifuMetroTextbox4.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[5].Value.ToString();
            bunifuMetroTextbox5.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[6].Value.ToString();
            bunifuMetroTextbox6.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[7].Value.ToString();


            //        DataGridView grid = new DataGridView();
            //grid.ShowDialog(); 
            if (bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString() == "male")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }
            bunifuDatepicker1.Value = Convert.ToDateTime(bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString());
        }

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            bunifuMetroTextbox3.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            //textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            //textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            bunifuMetroTextbox4.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[5].Value.ToString();
            bunifuMetroTextbox5.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[6].Value.ToString();
            bunifuMetroTextbox6.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[7].Value.ToString();


            //        DataGridView grid = new DataGridView();
            //grid.ShowDialog(); 
            if (bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString() == "male")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }
            bunifuDatepicker1.Value = Convert.ToDateTime(bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString());
        }

        private void bunifuCustomDataGrid1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            bunifuMetroTextbox3.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            //textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            //textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            bunifuMetroTextbox4.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[5].Value.ToString();
            bunifuMetroTextbox5.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[6].Value.ToString();
            bunifuMetroTextbox6.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[7].Value.ToString();


            //        DataGridView grid = new DataGridView();
            //grid.ShowDialog(); 
            if (bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString() == "male")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }
            bunifuDatepicker1.Value = Convert.ToDateTime(bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString());
        }

        private void bunifuCustomDataGrid1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            bunifuMetroTextbox3.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            //textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            //textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            bunifuMetroTextbox4.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[5].Value.ToString();
            bunifuMetroTextbox5.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[6].Value.ToString();
            bunifuMetroTextbox6.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[7].Value.ToString();


            //        DataGridView grid = new DataGridView();
            //grid.ShowDialog(); 
            if (bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString() == "male")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }
            bunifuDatepicker1.Value = Convert.ToDateTime(bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString());
        }

        private void bunifuCustomDataGrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            bunifuMetroTextbox3.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            //textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            //textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            bunifuMetroTextbox4.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[5].Value.ToString();
            bunifuMetroTextbox5.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[6].Value.ToString();
            bunifuMetroTextbox6.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[7].Value.ToString();


            //        DataGridView grid = new DataGridView();
            //grid.ShowDialog(); 
            if (bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString() == "male")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }
            bunifuDatepicker1.Value = Convert.ToDateTime(bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString());
        }

        private void bunifuCustomDataGrid1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            bunifuMetroTextbox3.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            //textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            //textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            bunifuMetroTextbox4.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[5].Value.ToString();
            bunifuMetroTextbox5.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[6].Value.ToString();
            bunifuMetroTextbox6.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[7].Value.ToString();


            //        DataGridView grid = new DataGridView();
            //grid.ShowDialog(); 
            if (bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString() == "male")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }
            bunifuDatepicker1.Value = Convert.ToDateTime(bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString());
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            bunifuMetroTextbox3.Text = "";
            bunifuMetroTextbox4.Text = "";
            bunifuMetroTextbox5.Text = "";
            bunifuMetroTextbox6.Text = "";



        }
    }
}
