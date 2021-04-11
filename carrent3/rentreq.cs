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
    public partial class rentreq : Form
    {
        String userID;
        public rentreq(String userID)
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
    }
}
