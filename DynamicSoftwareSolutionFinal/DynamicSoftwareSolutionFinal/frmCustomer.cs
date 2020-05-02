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
    public partial class frmCustomer : Form
    {
        private string status = "0";
        private string connectionstring = @"Data Source=DESKTOP-CTCNV5B\SQLEXPRESS;Initial Catalog=DSS;Integrated Security=true;";

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CTCNV5B\SQLEXPRESS;Initial Catalog=DSS;Integrated Security=true;");

       

        public frmCustomer()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Close();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            main.Show();
            this.Close();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        public void FillCompanyID() {


            SqlCommand cmd = new SqlCommand("Select  Name From Company", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            cbCompanyID.Items.Clear();
            cbCompanyID.Items.Add("---SELECT---");
            foreach (DataRow Row in table.Rows)
            {
                cbCompanyID.Items.Add(Row["Name"].ToString());
            }
        
        }


        private void frmCustomer_Load(object sender, EventArgs e)
        {


            MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            WindowState = FormWindowState.Maximized;
          



            DisplayRecords();
            UserDropDown();
            FillCompanyID();



            this.dtpDate.Value = DateTime.Now;

            txtCustomerID.Text = "";
            txtFirstname.Text = "";
            txtLastname.Text = "";
            cbGender.Text = "";
            txtPosition.Text = "";
            txtEmail.Text = "";
            cbCompanyID.Text = "";
            cbAddressID.Text = "";
            cbStatus.Text = "";
            cbUserID.Text = "";
            txtLink.Text = "";


            txtFirstname.ReadOnly = true;
            txtLastname.ReadOnly = true;
            cbGender.Enabled = false;
            txtPosition.ReadOnly = true;
            txtEmail.ReadOnly = true;
            cbCompanyID.Enabled = false;
            cbAddressID.Enabled = false;
            cbStatus.Enabled = false;
            cbUserID.Enabled = false;
            txtLink.ReadOnly = true;

            btnNew.Enabled = true;
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }

     

        public void UserDropDown()
        {

            SqlConnection con = new SqlConnection(connectionstring);

            con.Open();
            SqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Firstname ++ ' '  ++ Lastname AS FullName FROM Users";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                cbUserID.Items.Add(dr["FullName"].ToString());

            }
            con.Close();





        }

        private void DisplayRecords()
        {
            SqlCommand cmd = new SqlCommand("Select *From Customer", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridViewCustomer.RowTemplate.Height = 65;

            dataGridViewCustomer.AllowUserToAddRows = false;
            dataGridViewCustomer.DataSource = table;        




            // DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            //  imgCol = (DataGridViewImageColumn)dataGridViewUsers.Columns[5];
            //   imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

              dataGridViewCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // dataGridViewUsers.Columns[4].Visible = false;

            // imgCol.Name = "Image";

        }

        private void dataGridViewCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //gets a collection that contains all the rows
            DataGridViewRow row = this.dataGridViewCustomer.Rows[e.RowIndex];
            //populate the textbox from specific value of the coordinates of column and row.
            txtCustomerID.Text = row.Cells[0].Value.ToString();
            txtFirstname.Text = row.Cells[1].Value.ToString();
            txtLastname.Text = row.Cells[2].Value.ToString();
            cbGender.Text = row.Cells[3].Value.ToString();
            txtPosition.Text = row.Cells[4].Value.ToString();
            txtEmail.Text = row.Cells[5].Value.ToString();
            cbCompanyID.Text = row.Cells[6].Value.ToString();
            cbAddressID.Text = row.Cells[7].Value.ToString();
            cbStatus.Text = row.Cells[8].Value.ToString();
            cbUserID.Text = row.Cells[9].Value.ToString();
            dtpDate.Text = row.Cells[10].Value.ToString();
            txtLink.Text = row.Cells[11].Value.ToString();


            txtFirstname.ReadOnly = true;
            txtLastname.ReadOnly = true;
            cbGender.Enabled = false;
            txtPosition.ReadOnly = true;
            txtEmail.ReadOnly = true;
            cbCompanyID.Enabled = false;
            cbAddressID.Enabled = false;
            cbStatus.Enabled = false;
            cbUserID.Enabled = false;
            txtLink.ReadOnly = true;


            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.status.Trim().Equals("0"))
            {

                if (txtCustomerID.Text.ToString().Length == 0)
                {
                    MessageBox.Show("CustomerID is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCustomerID.Focus();
                    return;
                }

                if (txtFirstname.Text.ToString().Length == 0)
                {
                    MessageBox.Show("Firstname is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtFirstname.Focus();
                    return;
                }

                if (txtLastname.Text.ToString().Length == 0)
                {
                    MessageBox.Show("Lastname is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtLastname.Focus();
                    return;
                }

                if (cbGender.Text.ToString().Length == 0)
                {
                    MessageBox.Show("Gender Date is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbGender.Focus();
                    return;
                }

                if (txtPosition.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Position is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPosition.Focus();
                    return;
                }

                if (txtEmail.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Email is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtEmail.Focus();
                    return;
                }

                if (cbCompanyID.Text.Trim().Length == 0)
                {
                    MessageBox.Show("CompanyID is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbCompanyID.Focus();
                    return;
                }

                if (cbAddressID.Text.Trim().Length == 0)
                {
                    MessageBox.Show("AddressID is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbAddressID.Focus();
                    return;
                }


                if (cbStatus.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Status is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbStatus.Focus();
                    return;
                }

                if (cbUserID.Text.Trim().Length == 0)
                {
                    MessageBox.Show("UserID is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbUserID.Focus();
                    return;
                }
                if (dtpDate.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Date is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpDate.Focus();
                    return;
                }
                if (txtLink.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Link is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtLink.Focus();
                    return;
                }



                if (MessageBox.Show("Do you want to save new Customers info?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {


                        SqlConnection connection = new SqlConnection(connectionstring.Trim());

                        string insertStatement = "Insert into Customer(CustomerID,Firstname,Lastname,Gender,Position,Email,CompanyID,AddressID,Status,UserID,Date,Link) VALUES (@CustomerID,@Firstname,@Lastname,@Gender,@Position,@Email,@CompanyID,@AddressID,@Status,@UserID,@Date,@Link)";

                        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);


                        insertCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text;
                        insertCommand.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = txtFirstname.Text;
                        insertCommand.Parameters.Add("@Lastname", SqlDbType.VarChar).Value = txtLastname.Text;
                        insertCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = cbGender.Text;
                        insertCommand.Parameters.Add("@Position", SqlDbType.VarChar).Value = txtPosition.Text;
                        insertCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
                        insertCommand.Parameters.Add("@CompanyID", SqlDbType.VarChar).Value = cbCompanyID.Text;
                        insertCommand.Parameters.Add("@AddressID", SqlDbType.VarChar).Value = cbAddressID.Text;
                        insertCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = cbStatus.Text;
                        insertCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = cbUserID.Text;
                        insertCommand.Parameters.Add("@Date", SqlDbType.DateTime).Value = dtpDate.Text;
                        insertCommand.Parameters.Add("@Link", SqlDbType.VarChar).Value = txtLink.Text;


                        int row = 0;

                        try
                        {
                            connection.Open();
                            row = insertCommand.ExecuteNonQuery();


                        }
                        catch (SqlException ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            DisplayRecords();
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

            else
            {

                if (txtCustomerID.Text.ToString().Length == 0)
                {
                    MessageBox.Show("CustomerID is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCustomerID.Focus();
                    return;
                }

                if (txtFirstname.Text.ToString().Length == 0)
                {
                    MessageBox.Show("Firstname is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtFirstname.Focus();
                    return;
                }

                if (txtLastname.Text.ToString().Length == 0)
                {
                    MessageBox.Show("Lastname is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtLastname.Focus();
                    return;
                }

                if (cbGender.Text.ToString().Length == 0)
                {
                    MessageBox.Show("Gender Date is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbGender.Focus();
                    return;
                }

                if (txtPosition.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Position is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPosition.Focus();
                    return;
                }

                if (txtEmail.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Email is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtEmail.Focus();
                    return;
                }

                if (cbCompanyID.Text.Trim().Length == 0)
                {
                    MessageBox.Show("CompanyID is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbCompanyID.Focus();
                    return;
                }

                if (cbAddressID.Text.Trim().Length == 0)
                {
                    MessageBox.Show("AddressID is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbAddressID.Focus();
                    return;
                }


                if (cbStatus.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Status is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbStatus.Focus();
                    return;
                }

                if (cbUserID.Text.Trim().Length == 0)
                {
                    MessageBox.Show("UserID is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbUserID.Focus();
                    return;
                }
                if (dtpDate.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Date is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpDate.Focus();
                    return;
                }
                if (txtLink.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Link is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtLink.Focus();
                    return;
                }



                if (MessageBox.Show("Do you want to update Customers info?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {


                        SqlConnection connection = new SqlConnection(connectionstring.Trim());

                        string insertStatement = "UPDATE Customer SET CustomerID=@CustomerID,Firstname=@Firstname,Lastname=@Lastname,Gender=@Gender,Position=@Position,Email=@Email,CompanyID=@CompanyID,AddressID=@AddressID,Status=@Status,UserID=@UserID,Date=@Date,Link=@Link WHERE CustomerID=@CustomerID";

                        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);


                        insertCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = txtCustomerID.Text;
                        insertCommand.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = txtFirstname.Text;
                        insertCommand.Parameters.Add("@Lastname", SqlDbType.VarChar).Value = txtLastname.Text;
                        insertCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = cbGender.Text;
                        insertCommand.Parameters.Add("@Position", SqlDbType.VarChar).Value = txtPosition.Text;
                        insertCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
                        insertCommand.Parameters.Add("@CompanyID", SqlDbType.VarChar).Value = cbCompanyID.Text;
                        insertCommand.Parameters.Add("@AddressID", SqlDbType.VarChar).Value = cbAddressID.Text;
                        insertCommand.Parameters.Add("@Status", SqlDbType.VarChar).Value = cbStatus.Text;
                        insertCommand.Parameters.Add("@UserID", SqlDbType.VarChar).Value = cbUserID.Text;
                        insertCommand.Parameters.Add("@Date", SqlDbType.DateTime).Value = dtpDate.Text;
                        insertCommand.Parameters.Add("@Link", SqlDbType.VarChar).Value = txtLink.Text;

                        int row = 0;

                        try
                        {
                            connection.Open();
                            row = insertCommand.ExecuteNonQuery();


                        }
                        catch (SqlException ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            DisplayRecords();
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


            this.dtpDate.Value = DateTime.Now;
            txtCustomerID.Text = "";
            txtFirstname.Text = "";
            txtLastname.Text = "";
            //cbGender.Text = "";
            cbGender.Text = null;
            cbUserID.Text = null;
            cbCompanyID.Text = null;
            txtPosition.Text = "";
            txtEmail.Text = "";
          //  cbCompanyID.Text = null;
            //cbAddressID.Text = null;
            cbStatus.Text = "";
            cbUserID.Text = "";
            txtLink.Text = "";


            txtFirstname.ReadOnly = true;
            txtLastname.ReadOnly = true;
            cbGender.Enabled = false;
            txtPosition.ReadOnly = true;
            txtEmail.ReadOnly = true;
            cbCompanyID.Enabled = false;
            cbAddressID.Enabled = false;
            cbStatus.Enabled = false;
            cbUserID.Enabled = false;
            txtLink.ReadOnly = true;

            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.status = "0";

            this.dtpDate.Value = DateTime.Now; 
            txtCustomerID.Text = "";
            txtFirstname.Text = "";
            txtLastname.Text = "";
            // cbGender.Text = "";
            cbGender.Text = null;
            cbUserID.Text = null;
            cbCompanyID.Text = null;
            cbGender.SelectedIndex = -1;
            // cbUserID.SelectedIndex = -1;
            // cbCompanyID.SelectedIndex = -1;
            cbCompanyID.Refresh();
            txtPosition.Text = "";
            txtEmail.Text = "";
           // cbCompanyID.Text = null;
           // cbAddressID.Text = null;
            cbStatus.Text = "";
            cbUserID.Text = "";
            txtLink.Text = "";


            txtFirstname.ReadOnly = false;
            txtLastname.ReadOnly = false;
            cbGender.Enabled = true;
            txtPosition.ReadOnly = false;
            txtEmail.ReadOnly = false;
            cbCompanyID.Enabled = true;
            cbAddressID.Enabled = true;
            cbStatus.Enabled = true;
            cbUserID.Enabled = true;
            txtLink.ReadOnly = false;

            btnNew.Enabled = true;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

            Ccode();

        }
        private void Ccode()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("Ccode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            object obj = cmd.ExecuteScalar();
            this.txtCustomerID.Text = obj.ToString();
            con.Close();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.status = "1";
            this.dtpDate.Value = DateTime.Now;
            txtFirstname.ReadOnly = false;
            txtLastname.ReadOnly = false;
            cbGender.Enabled = true;
            txtPosition.ReadOnly = false;
            txtEmail.ReadOnly = false;
            cbCompanyID.Enabled = true;
            cbAddressID.Enabled = true;
            cbStatus.Enabled = true;
            cbUserID.Enabled = true;
            txtLink.ReadOnly = false;

            btnNew.Enabled = false;
            btnUpdate.Enabled = true;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Text.Trim().Length > 0)
            {

                if (MessageBox.Show("Do you want to delete this Customer with an OfferID " + txtCustomerID.Text.Trim() + " ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection connection = new SqlConnection(connectionstring.Trim());

                        string insertStatement = "Delete FROM Customer WHERE CustomerID ='" + txtCustomerID.Text.Trim() + "'";

                        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

                        int row = 0;

                        try
                        {
                            connection.Open();
                            row = insertCommand.ExecuteNonQuery();

                            DisplayRecords();
                        }
                        catch (SqlException ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

            this.dtpDate.Value = DateTime.Now;
            txtCustomerID.Text = "";
            txtFirstname.Text = "";
            txtLastname.Text = "";
            //cbGender.Text = "";
            cbGender.SelectedIndex = -1;
            cbUserID.SelectedIndex = -1;
            cbCompanyID.SelectedIndex = -1;
            txtPosition.Text = "";
            txtEmail.Text = "";
            //  cbCompanyID.Text = null;
            // cbAddressID.Text = null;
            cbStatus.Text = "";
            cbUserID.Text = "";
            txtLink.Text = "";


            txtFirstname.ReadOnly = true;
            txtLastname.ReadOnly = true;
            cbGender.Enabled = false;
            txtPosition.ReadOnly = true;
            txtEmail.ReadOnly = true;
            cbCompanyID.Enabled = false;
            cbAddressID.Enabled = false;
            cbStatus.Enabled = false;
            cbUserID.Enabled = false;
            txtLink.ReadOnly = true;


            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            con = new SqlConnection(connectionstring);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Customer where FirstName like '" + txtSearch.Text + "%' OR Lastname like '" + txtSearch.Text + "%' OR CompanyID like '" + txtSearch.Text + "%' OR UserID like '" + txtSearch.Text + "%'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridViewCustomer.DataSource = dt;
            con.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayRecords();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            con = new SqlConnection(connectionstring);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Customer where FirstName like '" + txtSearch.Text + "%' OR Lastname like '" + txtSearch.Text + "%' OR CompanyID like '" + txtSearch.Text + "%' OR UserID like '" + txtSearch.Text + "%'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridViewCustomer.DataSource = dt;
            con.Close();

            txtSearch.ForeColor = Color.Black;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            DisplayRecords();
        }

        private void cbCompanyID_SelectedIndexChanged(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("Select  City From Address where Name = '" + cbCompanyID.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            cbAddressID.Items.Clear();
            foreach (DataRow ab in table.Rows)
            {
                cbAddressID.Items.Add(ab["City"].ToString());
            }
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

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {

        }

     

      

       

     
    }
}
