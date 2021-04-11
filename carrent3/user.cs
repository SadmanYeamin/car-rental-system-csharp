using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carrent3
{
    public partial class user : Form
    {
        String userID;
        public user(string userID)
        {
            InitializeComponent();
            this.userID = userID;
            label1.Text = "Welcome ," + userID;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Close();

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                takerent t = new takerent(userID);
                t.Show();
                this.Close();
            }

            if (radioButton2.Checked == true)
            {
                putrent p = new putrent(userID);
                p.Show();
                this.Close();
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            myprofile m = new myprofile(userID);
            m.Show();
            this.Close();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            rentreq r = new rentreq(userID);
            r.Show();
            this.Close();
        }


    }
}
