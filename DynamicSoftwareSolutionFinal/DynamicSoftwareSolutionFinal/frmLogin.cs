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

namespace DynamicSoftwareSolutionFinal
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CTCNV5B\SQLEXPRESS;Initial Catalog=DSS;Integrated Security=true;");
            string query = "Select *from Users where Username= '" + txtUsername.Text.Trim() + "' and Password= '" + txtPassword.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count == 1)
            {

                frmProcessBar pro = new frmProcessBar();
                pro.Show();
                this.Hide();
               
            }
            else
            {
                MessageBox.Show("Incorrect username or password");
            }

            txtPassword.Clear();
            txtUsername.Clear();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
        }
    }
}
