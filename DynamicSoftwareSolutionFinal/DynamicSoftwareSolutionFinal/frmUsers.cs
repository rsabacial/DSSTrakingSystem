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
    public partial class frmUsers : Form
    {
        private string connectionstring = @"Data Source=DESKTOP-CTCNV5B\SQLEXPRESS;Initial Catalog=DSS;Integrated Security=true;";

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CTCNV5B\SQLEXPRESS;Initial Catalog=DSS;Integrated Security=true;");
        public frmUsers()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewUser use = new NewUser();
            use.ShowDialog();

            
            label2.Text = "";
              
                pictureBox1.Image = null;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string UserID = dataGridViewUsers.SelectedRows[0].Cells["UserID"].Value.ToString();
            string firstname = dataGridViewUsers.SelectedRows[0].Cells["Firstname"].Value.ToString();
            string lastname = dataGridViewUsers.SelectedRows[0].Cells["Lastname"].Value.ToString();
            string password = dataGridViewUsers.SelectedRows[0].Cells["Password"].Value.ToString();
            string user = dataGridViewUsers.SelectedRows[0].Cells["Username"].Value.ToString();

            MemoryStream ms = new MemoryStream((byte[])dataGridViewUsers.CurrentRow.Cells[5].Value);
            Image img = Image.FromStream(ms);

            
           UpdateUser input = new UpdateUser(UserID, firstname, lastname, password, user, img);
           input.ShowDialog();


            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Close();
        }

      

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle,Color.WhiteSmoke,ButtonBorderStyle.Solid);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        private void frmUsers_Load(object sender, EventArgs e)

        {

            MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            WindowState = FormWindowState.Maximized;

            DisplayRecords();
        }

        private void DisplayRecords()
        {
            SqlCommand cmd = new SqlCommand("Select *From Users", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridViewUsers.RowTemplate.Height = 80;
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.DataSource = table;

            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol = (DataGridViewImageColumn)dataGridViewUsers.Columns[5];
            imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

             dataGridViewUsers.Columns[2].Visible = false;

            imgCol.Name = "Image";

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "delete Users  where UserID=@UserID";
            SqlParameter parm = new SqlParameter("@UserID", SqlDbType.VarChar);
            cmd.Parameters.Add(parm);

            foreach (DataGridViewRow row in dataGridViewUsers.SelectedRows)
            {
                parm.Value = row.Cells["UserID"].Value;
                cmd.ExecuteNonQuery();



            }
            con.Close();
            DisplayRecords();
            MessageBox.Show("deleted");


            label2.Text = "";
              
                pictureBox1.Image = null;
        }

        private void frmUsers_Activated(object sender, EventArgs e)
        {
            DisplayRecords();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(connectionstring);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Users where FirstName like '" + txtSearch.Text + "%' OR Lastname like '" + txtSearch.Text + "%' ", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridViewUsers.DataSource = dt;
            con.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayRecords();
            txtSearch.Text = "";
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            con = new SqlConnection(connectionstring);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Users where FirstName like '" + txtSearch.Text + "%' OR Lastname like '" + txtSearch.Text + "%' ", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridViewUsers.DataSource = dt;
            con.Close();

            txtSearch.ForeColor = Color.Black;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            DisplayRecords();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == " Search....")
            {
                txtSearch.Text = "";
              

            }
            
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                txtSearch.Text = " Search....";
                txtSearch.ForeColor = Color.Gray;

            }
        }

        private void dataGridViewUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            label2.Text = dataGridViewUsers.CurrentRow.Cells[1].Value.ToString();
          

            MemoryStream ms = new MemoryStream((byte[])dataGridViewUsers.CurrentRow.Cells[5].Value);
            pictureBox1.Image = Image.FromStream(ms);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

     

      

       
    }
}
