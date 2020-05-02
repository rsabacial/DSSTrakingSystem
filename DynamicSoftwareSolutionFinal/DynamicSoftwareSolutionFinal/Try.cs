using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace DynamicSoftwareSolutionFinal
{
    public partial class Try : Form
    {

        private string status = "0";
        private string connectionstring = @"Data Source=DESKTOP-CTCNV5B\SQLEXPRESS;Initial Catalog=DSS;Integrated Security=true;";

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CTCNV5B\SQLEXPRESS;Initial Catalog=DSS;Integrated Security=true;");

        public Try()
        {
            InitializeComponent();
        }

       

        private void Try_Load(object sender, EventArgs e)
        {
            DisplayRecords();
        }

        private void DisplayRecords()
        {
            SqlCommand cmd = new SqlCommand("Select *From Customer", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.RowTemplate.Height = 65;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = table;




            // DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            //  imgCol = (DataGridViewImageColumn)dataGridViewUsers.Columns[5];
            //   imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // dataGridViewUsers.Columns[4].Visible = false;

            // imgCol.Name = "Image";

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(connectionstring);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Customer where FirstName like '" + label1.Text + "%' AND Lastname like '" + label2.Text + "%' AND CompanyID like '" + txt3.Text + "%' AND UserID like '" + txt4.Text + "%'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
