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
    public partial class frmCompany : Form
    {
        private string status = "0";

        private string connectionstring = @"Data Source=DESKTOP-CTCNV5B\SQLEXPRESS;Initial Catalog=DSS;Integrated Security=true;";

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CTCNV5B\SQLEXPRESS;Initial Catalog=DSS;Integrated Security=true;");

        public frmCompany()
        {
            InitializeComponent();
        }

       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, Color.WhiteSmoke, ButtonBorderStyle.Solid);
        }

        private void frmCompany_Load(object sender, EventArgs e)
        {
            MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            WindowState = FormWindowState.Maximized;


            DisplayRecordsCompany();
           DisplayRecordsAddress();

            UserDropDownUser();

            HideAddressColumn();

            //company
            this.dtpDate.Value = DateTime.Now;
            txtCompanyID.Text = "";
            cbUserID.Text = "";
            txtName.Text = "";
            cbStatus.Text = "";
            pictureBox1.Image = null;

            cbUserID.Enabled = false;
            txtName.ReadOnly = true;
            cbStatus.Enabled = false;
            dtpDate.Enabled = false;
            btnImage.Enabled = false;


            btnNew.Enabled = true;
            btnUpdate.Enabled = false;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            //End

            
          
        }

        private void HideAddressColumn() {
            //Address hide column
            this.dataGridViewAddress.Columns["AddressID"].Visible = false;
            this.dataGridViewAddress.Columns["City"].Visible = false;
            this.dataGridViewAddress.Columns["State"].Visible = false;
            this.dataGridViewAddress.Columns["Postcode"].Visible = false;
            this.dataGridViewAddress.Columns["Country"].Visible = false;
            this.dataGridViewAddress.Columns["Telephone"].Visible = false;
            this.dataGridViewAddress.Columns["Street"].Visible = false;
            this.dataGridViewAddress.Columns["Fax"].Visible = false;
            this.dataGridViewAddress.Columns["CompanyID"].Visible = false;
            this.dataGridViewAddress.Columns["Name"].Visible = false;
            dataGridViewAddress.RowHeadersVisible = false;

            //End

            //Readonly and Enable
            txtAddressName.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtPostcode.Text = "";
            txtCountry.Text = "";
            txtTelephone.Text = "";
            txtStreet.Text = "";
            txtFax.Text = "";

            txtAddressName.ReadOnly = true;
            txtCity.ReadOnly = true;
            txtState.ReadOnly = true;
            txtPostcode.ReadOnly = true;
            txtCountry.ReadOnly = true;
            txtTelephone.ReadOnly = true;
            txtStreet.ReadOnly = true;
            txtFax.ReadOnly = true;

            btnANew.Enabled =false ;
            btnASave.Enabled = false;
            btnADelete.Enabled = false;
            btnAUpdate.Enabled = false;

            //End
        }

          private void DisplayRecordsAddress()
        {
            SqlCommand cmd = new SqlCommand("Select *from Address", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);


            dataGridViewAddress.RowTemplate.Height = 28;
           // dataGridViewAddress.AllowUserToAddRows = false;
           dataGridViewAddress.DataSource = table;

          

          

            dataGridViewCompany.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



         

        }

        public void UserDropDownUser()
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


        private void DisplayRecordsCompany()
        {
            SqlCommand cmd = new SqlCommand("Select *from Company", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);


            dataGridViewCompany.RowTemplate.Height = 80;
            dataGridViewCompany.AllowUserToAddRows = false;
            dataGridViewCompany.DataSource = table;

            dataGridViewCompany.Columns[1].HeaderText = "Created By";

            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol = (DataGridViewImageColumn)dataGridViewCompany.Columns[5];
            imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridViewCompany.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            imgCol.Name = "Image";

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmMain mian = new frmMain();
            mian.Show();
            this.Close();
        }

        private void dataGridViewCompany_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewAddress.RowHeadersVisible = true;

            txtCompanyID.Text = dataGridViewCompany.CurrentRow.Cells[0].Value.ToString();
            cbUserID.Text = dataGridViewCompany.CurrentRow.Cells[1].Value.ToString();
            txtName.Text = dataGridViewCompany.CurrentRow.Cells[2].Value.ToString();
            cbStatus.Text = dataGridViewCompany.CurrentRow.Cells[3].Value.ToString();
            dtpDate.Text = dataGridViewCompany.CurrentRow.Cells[4].Value.ToString();

            MemoryStream ms = new MemoryStream((byte[])dataGridViewCompany.CurrentRow.Cells[5].Value);
            pictureBox1.Image = Image.FromStream(ms);

          

            cbUserID.Enabled = false;
            txtName.ReadOnly = true;
            cbStatus.Enabled = false;
            dtpDate.Enabled = false;
            btnImage.Enabled = false;


            cbUserID.Enabled = false;
            txtName.ReadOnly = true;
            cbStatus.Enabled = false;
            dtpDate.Enabled = false;
            btnImage.Enabled = false;

            btnNew.Enabled = true;
            btnSave.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            SearchAddress();

            //Address hide column

          
            this.dataGridViewAddress.Columns["AddressID"].Visible = true;
            this.dataGridViewAddress.Columns["City"].Visible = true;
            this.dataGridViewAddress.Columns["State"].Visible = true;
            this.dataGridViewAddress.Columns["Postcode"].Visible = true;
            this.dataGridViewAddress.Columns["Country"].Visible = true;
            this.dataGridViewAddress.Columns["Telephone"].Visible = true;
            this.dataGridViewAddress.Columns["Street"].Visible = true;
            this.dataGridViewAddress.Columns["Fax"].Visible = true;

           
            //End
            //Readonly and Enable
            txtAddressName.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtPostcode.Text = "";
            txtCountry.Text = "";
            txtTelephone.Text = "";
            txtStreet.Text = "";
            txtFax.Text = "";

            txtAddressName.ReadOnly = true;
            txtCity.ReadOnly = true;
            txtState.ReadOnly = true;
            txtPostcode.ReadOnly = true;
            txtCountry.ReadOnly = true;
            txtTelephone.ReadOnly = true;
            txtStreet.ReadOnly = true;
            txtFax.ReadOnly = true;

            btnANew.Enabled = true;
            btnASave.Enabled = false;
            btnADelete.Enabled = false;
            btnAUpdate.Enabled = false;

            //End
        }

        private void SearchAddress() {
            con = new SqlConnection(connectionstring);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Address where Name like '" + txtName.Text + "%'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridViewAddress.DataSource = dt;
            con.Close();
        
        }


        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Choose Image(*.jpg; *.png; *.gif) | *.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.status.Trim().Equals("0"))
            {

                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("pictureBox is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    pictureBox1.Focus();
                    return;
                }


                if (txtName.Text.ToString().Length == 0)
                {
                    MessageBox.Show("Name is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtName.Focus();
                    return;
                }
                if (cbUserID.Text.ToString().Length == 0)
                {
                    MessageBox.Show("Name is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtName.Focus();
                    return;
                }

                if (cbStatus.Text.ToString().Length == 0)
                {
                    MessageBox.Show("Status is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbStatus.Focus();
                    return;
                }
                if (dtpDate.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Date is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpDate.Focus();
                    return;
                }



                if (MessageBox.Show("Do you want to Save Company info?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {
                        MemoryStream ms = new MemoryStream();
                        pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                        byte[] img = ms.ToArray();

                        SqlConnection connection = new SqlConnection(connectionstring.Trim());

                        string insertStatement = "Insert into Company(CompanyID,UserID,Name,Status,Date,Image) VALUES (@CompanyID,@userid,@name,@status,@date,@img)";

                        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);


                        insertCommand.Parameters.Add("@CompanyID", SqlDbType.VarChar).Value = txtCompanyID.Text;
                        insertCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = cbUserID.Text;
                        insertCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = txtName.Text;
                        insertCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = cbStatus.Text;
                        insertCommand.Parameters.Add("@date", SqlDbType.DateTime).Value = dtpDate.Text;
                        insertCommand.Parameters.Add("@img", SqlDbType.Image).Value = img;

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
                            DisplayRecordsCompany();
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


                this.dtpDate.Value = DateTime.Now;
                txtCompanyID.Text = "";
                cbUserID.Text = null;
                txtName.Text = "";
                cbStatus.Text = null;
                pictureBox1.Image = null;

                cbUserID.Enabled = false;
                txtName.ReadOnly = true;
                cbStatus.Enabled = false;
                dtpDate.Enabled = false;
                btnImage.Enabled = false;

                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;

            }

            else
            {

                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("pictureBox is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    pictureBox1.Focus();
                    return;
                }


                if (txtName.Text.ToString().Length == 0)
                {
                    MessageBox.Show("Name is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtName.Focus();
                    return;
                }
                if (cbUserID.Text.ToString().Length == 0)
                {
                    MessageBox.Show("Name is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtName.Focus();
                    return;
                }

                if (cbStatus.Text.ToString().Length == 0)
                {
                    MessageBox.Show("Status is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cbStatus.Focus();
                    return;
                }
                if (dtpDate.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Date is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dtpDate.Focus();
                    return;
                }




                if (MessageBox.Show("Do you want to update Company info?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {
                        MemoryStream ms = new MemoryStream();
                        pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                        byte[] img = ms.ToArray();

                        SqlConnection connection = new SqlConnection(connectionstring.Trim());

                        string insertStatement = "UPDATE Company SET UserID=@userid,Name=@name,Status=@status,Date=@date,Image=@img WHERE CompanyID=@id";

                        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);


                        insertCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = txtCompanyID.Text;
                        insertCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = cbUserID.Text;
                        insertCommand.Parameters.Add("@name", SqlDbType.VarChar).Value = txtName.Text;
                        insertCommand.Parameters.Add("@status", SqlDbType.VarChar).Value = cbStatus.Text;
                        insertCommand.Parameters.Add("@date", SqlDbType.DateTime).Value = dtpDate.Text;
                        insertCommand.Parameters.Add("@img", SqlDbType.Image).Value = img;

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
                            DisplayRecordsCompany();
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                this.dtpDate.Value = DateTime.Now;
                txtCompanyID.Text = "";
                cbUserID.Text = null;
                txtName.Text = "";
                cbStatus.Text = null;
                pictureBox1.Image = null;

                cbUserID.Enabled = false;
                txtName.ReadOnly = true;
                cbStatus.Enabled = false;
                dtpDate.Enabled = false;
                btnImage.Enabled = false;

                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
            }

            HideAddressColumn();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.status = "1";
    
            cbUserID.Enabled = true;
            txtName.ReadOnly = false;
            cbStatus.Enabled = true;
            dtpDate.Enabled = true;
            btnImage.Enabled = true;

            btnNew.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            HideAddressColumn();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
                HideAddressColumn();

                if (txtCompanyID.Text.Trim().Length > 0)
                {

                    if (MessageBox.Show("Do you want to delete this Company with an OfferID " + txtCompanyID.Text.Trim() + " ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            SqlConnection connection = new SqlConnection(connectionstring.Trim());

                            string insertStatement = "DELETE FROM Company WHERE CompanyID='" + txtCompanyID.Text.Trim() + "'";

                            SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

                            int row = 0;

                            try
                            {
                                connection.Open();
                                row = insertCommand.ExecuteNonQuery();

                                DisplayRecordsCompany();
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

                deladd();


                this.dtpDate.Value = DateTime.Now;
                txtCompanyID.Text = "";
                cbUserID.Text = null;
                txtName.Text = "";
                cbStatus.Text = null;
                pictureBox1.Image = null;
            
                cbUserID.Enabled = false;
                txtName.ReadOnly = true;
                cbStatus.Enabled = false;
                dtpDate.Enabled = false;
                btnImage.Enabled = false;

                btnNew.Enabled = true;
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;

            

        }

        private void deladd() { 
        

               
                  
                        SqlConnection connection = new SqlConnection(connectionstring.Trim());

                        string insertStatement = "DELETE FROM Address WHERE Name='" + txtName.Text.Trim() + "'";

                        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

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
                            SearchAddress();
                            connection.Close();
                        }
                    
                   
                

            
        
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayRecordsCompany();
            HideAddressColumn();
            txtSearch.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(connectionstring);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Company where Name like '" + txtSearch.Text + "%' OR UserID like '" + txtSearch.Text + "%' OR Status like '" + txtSearch.Text + "%'OR Date like '" + txtSearch.Text + "%'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridViewCompany.DataSource = dt;
            con.Close();


            HideAddressColumn();

           
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            con = new SqlConnection(connectionstring);
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select * from Company where Name like '" + txtSearch.Text + "%' OR UserID like '" + txtSearch.Text + "%'OR Status like '" + txtSearch.Text + "%'OR Date like '" + txtSearch.Text + "%'", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            dataGridViewCompany.DataSource = dt;
            con.Close();

           

            HideAddressColumn();
            txtSearch.ForeColor = Color.Black;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            DisplayRecordsCompany();
            HideAddressColumn();
        }

      
        private void btnNew_Click(object sender, EventArgs e)
        {
            this.status = "0";
            
            this.dtpDate.Value = DateTime.Now;
            txtCompanyID.Text = "";
            cbUserID.Text = "";
            txtName.Text = "";
            cbStatus.Text = null;
            pictureBox1.Image = null;

            cbUserID.Enabled = true;
            txtName.ReadOnly = false;
            cbStatus.Enabled = true;
            dtpDate.Enabled = true;
            btnImage.Enabled = true;



            btnNew.Enabled = true;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            HideAddressColumn();

            Comcode();
        }

        public void Comcode()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("Comcode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            object obj = cmd.ExecuteScalar();
            this.txtCompanyID.Text = obj.ToString();


        }
       

     

        private void dataGridViewAddress_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAddressName.Text = dataGridViewAddress.CurrentRow.Cells[0].Value.ToString();
            txtCity.Text = dataGridViewAddress.CurrentRow.Cells[2].Value.ToString();
            txtStreet.Text = dataGridViewAddress.CurrentRow.Cells[7].Value.ToString();
            txtState.Text = dataGridViewAddress.CurrentRow.Cells[3].Value.ToString();
            txtPostcode.Text = dataGridViewAddress.CurrentRow.Cells[4].Value.ToString();
            txtCountry.Text = dataGridViewAddress.CurrentRow.Cells[5].Value.ToString();
            txtTelephone.Text = dataGridViewAddress.CurrentRow.Cells[6].Value.ToString();
            txtFax.Text = dataGridViewAddress.CurrentRow.Cells[8].Value.ToString();


            //function
         

            txtAddressName.ReadOnly = true;
            txtCity.ReadOnly = true;
            txtState.ReadOnly = true;
            txtPostcode.ReadOnly = true;
            txtCountry.ReadOnly = true;
            txtTelephone.ReadOnly = true;
            txtStreet.ReadOnly = true;
            txtFax.ReadOnly = true;

            btnANew.Enabled = true;
            btnASave.Enabled = false;
            btnADelete.Enabled = true;
            btnAUpdate.Enabled = true;
            //end
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Acode();

            this.status = "0";
            txtCity.Text = "";
            txtState.Text = "";
            txtPostcode.Text = "";
            txtCountry.Text = "";
            txtTelephone.Text = "";
            txtStreet.Text = "";
            txtFax.Text = "";

            txtAddressName.ReadOnly = false;
            txtCity.ReadOnly = false;
            txtState.ReadOnly = false;
            txtPostcode.ReadOnly = false;
            txtCountry.ReadOnly = false;
            txtTelephone.ReadOnly = false;
            txtStreet.ReadOnly = false;
            txtFax.ReadOnly = false;

            btnANew.Enabled = false;
            btnASave.Enabled = true;
            btnADelete.Enabled = false;
            btnAUpdate.Enabled = false;
        }

        public void Acode() {

            con.Open();
            SqlCommand cmd = new SqlCommand("Acode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            object obj = cmd.ExecuteScalar();
            this.txtAddressName.Text = obj.ToString();

          
        }

        private void btnASave_Click(object sender, EventArgs e)
        {
            if (this.status.Trim().Equals("0"))
            {




                if (txtAddressName.Text.ToString().Length == 0)
                {
                    MessageBox.Show("AddressID is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtAddressName.Focus();
                    return;
                }
                if (txtCity.Text.ToString().Length == 0)
                {
                    MessageBox.Show("City is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCity.Focus();
                    return;
                }

                if (txtState.Text.ToString().Length == 0)
                {
                    MessageBox.Show("State is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtState.Focus();
                    return;
                }
                if (txtPostcode.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Postcode is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPostcode.Focus();
                    return;
                }
                if (txtCountry.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Country is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCountry.Focus();
                    return;
                }
                if (txtTelephone.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Telephone is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTelephone.Focus();
                    return;
                }
                if (txtStreet.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Street is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtStreet.Focus();
                    return;
                }
                if (txtFax.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Fax is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtFax.Focus();
                    return;
                }



                if (MessageBox.Show("Do you want to Save Company info?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {
                        MemoryStream ms = new MemoryStream();
                        pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                        byte[] img = ms.ToArray();

                        SqlConnection connection = new SqlConnection(connectionstring.Trim());

                        string insertStatement = "Insert into Address(AddressID,CompanyID,City,State,Postcode,Country,Telephone,Street,Fax,Name) VALUES (@AddressID,@CompanyID,@City,@State,@Postcode,@Country,@Telephone,@Street,@Fax,@Name)";

                        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

                        insertCommand.Parameters.Add("@AddressID", SqlDbType.VarChar).Value = txtAddressName.Text;
                        insertCommand.Parameters.Add("@CompanyID", SqlDbType.Int).Value = txtCompanyID.Text;
                        insertCommand.Parameters.Add("@City", SqlDbType.VarChar).Value = txtCity.Text;
                        insertCommand.Parameters.Add("@State", SqlDbType.VarChar).Value = txtState.Text;
                        insertCommand.Parameters.Add("@Postcode", SqlDbType.VarChar).Value = txtPostcode.Text;
                        insertCommand.Parameters.Add("@Country", SqlDbType.VarChar).Value = txtCountry.Text;
                        insertCommand.Parameters.Add("@Telephone", SqlDbType.VarChar).Value = txtTelephone.Text;
                        insertCommand.Parameters.Add("@Street", SqlDbType.VarChar).Value = txtStreet.Text;
                        insertCommand.Parameters.Add("@Fax", SqlDbType.VarChar).Value = txtFax.Text;
                        insertCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtName.Text;
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
                            SearchAddress();
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


                if (txtAddressName.Text.ToString().Length == 0)
                {
                    MessageBox.Show("AddressID is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtAddressName.Focus();
                    return;
                }
                if (txtCity.Text.ToString().Length == 0)
                {
                    MessageBox.Show("City is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCity.Focus();
                    return;
                }

                if (txtState.Text.ToString().Length == 0)
                {
                    MessageBox.Show("State is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtState.Focus();
                    return;
                }
                if (txtPostcode.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Postcode is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPostcode.Focus();
                    return;
                }
                if (txtCountry.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Country is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCountry.Focus();
                    return;
                }
                if (txtTelephone.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Telephone is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTelephone.Focus();
                    return;
                }
                if (txtStreet.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Street is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtStreet.Focus();
                    return;
                }
                if (txtFax.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Fax is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtFax.Focus();
                    return;
                }




                if (MessageBox.Show("Do you want to update Company info?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {
                        MemoryStream ms = new MemoryStream();
                        pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                        byte[] img = ms.ToArray();

                        SqlConnection connection = new SqlConnection(connectionstring.Trim());

                        string insertStatement = "UPDATE Address SET City=@City,State=@State,Postcode=@Postcode,Country=@Country,Telephone=@Telephone,Street=@Street,Fax=@Fax WHERE AddressID=@AddressID";

                        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);


                        insertCommand.Parameters.Add("@AddressID", SqlDbType.VarChar).Value = txtAddressName.Text;
                        insertCommand.Parameters.Add("@City", SqlDbType.VarChar).Value = txtCity.Text;
                        insertCommand.Parameters.Add("@State", SqlDbType.VarChar).Value = txtState.Text;
                        insertCommand.Parameters.Add("@Postcode", SqlDbType.VarChar).Value = txtPostcode.Text;
                        insertCommand.Parameters.Add("@Country", SqlDbType.VarChar).Value = txtCountry.Text;
                        insertCommand.Parameters.Add("@Telephone", SqlDbType.VarChar).Value = txtTelephone.Text;
                        insertCommand.Parameters.Add("@Street", SqlDbType.VarChar).Value = txtStreet.Text;
                        insertCommand.Parameters.Add("@Fax", SqlDbType.VarChar).Value = txtFax.Text;

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
                            SearchAddress();
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

             
            }
            //function
            txtAddressName.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtPostcode.Text = "";
            txtCountry.Text = "";
            txtTelephone.Text = "";
            txtStreet.Text = "";
            txtFax.Text = "";

            txtAddressName.ReadOnly = true;
            txtCity.ReadOnly = true;
            txtState.ReadOnly = true;
            txtPostcode.ReadOnly = true;
            txtCountry.ReadOnly = true;
            txtTelephone.ReadOnly = true;
            txtStreet.ReadOnly = true;
            txtFax.ReadOnly = true;

            btnANew.Enabled = true;
            btnASave.Enabled = false;
            btnADelete.Enabled = false;
            btnAUpdate.Enabled = false;
            //end
        }

        private void btnAUpdate_Click(object sender, EventArgs e)
        {

            this.status = "1";
           
            //function
            

            txtAddressName.ReadOnly = false;
            txtCity.ReadOnly = false;
            txtState.ReadOnly = false;
            txtPostcode.ReadOnly = false;
            txtCountry.ReadOnly = false;
            txtTelephone.ReadOnly = false;
            txtStreet.ReadOnly = false;
            txtFax.ReadOnly = false;

            btnANew.Enabled = true;
            btnASave.Enabled = true;
            btnADelete.Enabled = false;
            btnAUpdate.Enabled = false;
            //end
        }

        private void btnADelete_Click(object sender, EventArgs e)
        {
            if (txtAddressName.Text.Trim().Length > 0)
            {

                if (MessageBox.Show("Do you want to delete this Company with an AddressID " + txtAddressName.Text.Trim() + " ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        SqlConnection connection = new SqlConnection(connectionstring.Trim());

                        string insertStatement = "DELETE FROM Address WHERE AddressID='" + txtAddressName.Text.Trim() + "'";

                        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

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
                            SearchAddress();
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

            //function
            txtAddressName.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtPostcode.Text = "";
            txtCountry.Text = "";
            txtTelephone.Text = "";
            txtStreet.Text = "";
            txtFax.Text = "";

            txtAddressName.ReadOnly = true;
            txtCity.ReadOnly = true;
            txtState.ReadOnly = true;
            txtPostcode.ReadOnly = true;
            txtCountry.ReadOnly = true;
            txtTelephone.ReadOnly = true;
            txtStreet.ReadOnly = true;
            txtFax.ReadOnly = true;

            btnANew.Enabled = true;
            btnASave.Enabled = false;
            btnADelete.Enabled = false;
            btnAUpdate.Enabled = false;
            //end
        }

        private void txtTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtTelephone_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtTelephone.Text, "  ^ [0-9]"))
            {
                txtTelephone.Text = "";
            }
        }

        private void txtFax_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtFax.Text, "  ^ [0-9]"))
            {
                txtFax.Text = "";
            }
        }

        private void txtCompanyID_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbUserID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewAddress_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

      

        

       
    }
}
