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
    public partial class takerent : Form
    {
        String userID;
        public takerent(String userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                sdtakerent s = new sdtakerent(userID);
                s.Show();
                this.Close();


            }

            else {
                svtakerent s1 = new svtakerent(userID);
                s1.Show();
                this.Close();
            }
        }
    }
}
