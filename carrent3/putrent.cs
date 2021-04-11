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
    public partial class putrent : Form
    {
        String userID;
        public putrent(String userID)
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
            if (radioButton1.Checked == true)
            {
                sdputrent s = new sdputrent(userID);
                s.Show();
                this.Close();
            }

            if (radioButton2.Checked == true)
            {
                svputrent s1 = new svputrent(userID);
                s1.Show();
                this.Close();
            }


        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            user u = new user(userID);
            u.Show();
            this.Close();

        }
    }
}
