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
    public partial class svtakerent : Form
    {
        String userID;
        public svtakerent(String userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            user u = new user(userID);

            u.Show();

            this.Close();

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void svtakerent_Load(object sender, EventArgs e)
        {
            //Initialization:
            //Initiating SQL Connection:
            SqlConnection con = new SqlConnection();

            //ConnectionString:
            con.ConnectionString = "data source = localhost;" +
                                   "database = mydatabase;" +
                                   "integrated security = SSPI";

            //Generating SQL Query
            SqlCommand command = new SqlCommand("select * from svcar", con);

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
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(bunifuMetroTextbox1.Text) || String.IsNullOrEmpty(bunifuMetroTextbox2.Text) || String.IsNullOrEmpty(bunifuMetroTextbox3.Text) || String.IsNullOrEmpty(bunifuMetroTextbox4.Text) || String.IsNullOrEmpty(bunifuMetroTextbox5.Text) || String.IsNullOrEmpty(bunifuMetroTextbox6.Text) || String.IsNullOrEmpty(bunifuMetroTextbox7.Text))
            { MessageBox.Show("please select one car and fill the remaining details"); }

            else
            {//Initiating SQL Connection:
                SqlConnection con = new SqlConnection();

                //ConnectionString:
                con.ConnectionString = "data source = localhost;database = mydatabase;integrated security = SSPI";

                //Generating SQL Query
                string sql = "INSERT svreq(Brand,Model,Numberplate,Color,Driver,Drivercont,Deparature,Destination,Startdt,Enddt,Username) VALUES(@param1,@param2,@param3,@param4,@param5,@param6,@param7,@param8,@param9,@param10,@param11)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //Opening the connection:
                    con.Open();


                    cmd.Parameters.Add("@param1", SqlDbType.VarChar, 50).Value = textBox1.Text;
                    cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).Value = bunifuMetroTextbox1.Text;
                    cmd.Parameters.Add("@param3", SqlDbType.VarChar, 50).Value = bunifuMetroTextbox2.Text;

                    cmd.Parameters.Add("@param4", SqlDbType.VarChar, 50).Value = bunifuMetroTextbox3.Text;
                    cmd.Parameters.Add("@param5", SqlDbType.VarChar, 50).Value = bunifuMetroTextbox4.Text;
                    cmd.Parameters.Add("@param6", SqlDbType.VarChar, 50).Value = bunifuMetroTextbox5.Text;
                    cmd.Parameters.Add("@param7", SqlDbType.VarChar, 50).Value = bunifuMetroTextbox6.Text;
                    cmd.Parameters.Add("@param8", SqlDbType.VarChar, 50).Value = bunifuMetroTextbox7.Text;
                    cmd.Parameters.Add("@param9", SqlDbType.DateTime).Value = dateTimePicker1.Value.Date;
                    cmd.Parameters.Add("@param10", SqlDbType.DateTime).Value = bunifuDatepicker1.Value.Date;
                    cmd.Parameters.Add("@param11", SqlDbType.VarChar, 50).Value = userID;

                    cmd.CommandType = CommandType.Text;






                    cmd.ExecuteNonQuery();



                    //Disconnect
                    con.Close();
                }

                MessageBox.Show("Request Successful you will be called by the driver soon");
            }
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            bunifuMetroTextbox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            bunifuMetroTextbox2.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[3].Value.ToString();
            bunifuMetroTextbox3.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[4].Value.ToString();
            bunifuMetroTextbox4.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[5].Value.ToString();
            bunifuMetroTextbox5.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[6].Value.ToString();
            //textBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            bunifuMetroTextbox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            bunifuMetroTextbox2.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[3].Value.ToString();
            bunifuMetroTextbox3.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[4].Value.ToString();
            bunifuMetroTextbox4.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[5].Value.ToString();
            bunifuMetroTextbox5.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[6].Value.ToString();
            //textBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void bunifuCustomDataGrid1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            bunifuMetroTextbox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            bunifuMetroTextbox2.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[3].Value.ToString();
            bunifuMetroTextbox3.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[4].Value.ToString();
            bunifuMetroTextbox4.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[5].Value.ToString();
            bunifuMetroTextbox5.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[6].Value.ToString();
            //textBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void bunifuCustomDataGrid1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            bunifuMetroTextbox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            bunifuMetroTextbox2.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[3].Value.ToString();
            bunifuMetroTextbox3.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[4].Value.ToString();
            bunifuMetroTextbox4.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[5].Value.ToString();
            bunifuMetroTextbox5.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[6].Value.ToString();
            //textBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void bunifuCustomDataGrid1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            bunifuMetroTextbox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            bunifuMetroTextbox2.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[3].Value.ToString();
            bunifuMetroTextbox3.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[4].Value.ToString();
            bunifuMetroTextbox4.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[5].Value.ToString();
            bunifuMetroTextbox5.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[6].Value.ToString();
            //textBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void bunifuCustomDataGrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[1].Value.ToString();
            bunifuMetroTextbox1.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[2].Value.ToString();
            bunifuMetroTextbox2.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[3].Value.ToString();
            bunifuMetroTextbox3.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[4].Value.ToString();
            bunifuMetroTextbox4.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[5].Value.ToString();
            bunifuMetroTextbox5.Text = bunifuCustomDataGrid1.SelectedRows[0].Cells[6].Value.ToString();
            //textBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }


    }
}
