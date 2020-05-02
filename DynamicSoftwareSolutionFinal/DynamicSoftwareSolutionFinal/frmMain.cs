using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DynamicSoftwareSolutionFinal
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            frmUsers user = new frmUsers();
            user.Show();
            this.Hide();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmCustomer cus = new frmCustomer();
            cus.Show();
            this.Hide();
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            frmCompany com = new frmCompany();
            com.Show();
            this.Hide();
        }

       

        private void btntry_Click(object sender, EventArgs e)
        {

            Try com = new Try();
            com.Show();
            this.Hide();
        }
    }
}
