using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;   

namespace DynamicSoftwareSolutionFinal
{
    public partial class NewUser : Form
    {
        private string connectionstring = @"Data Source=DESKTOP-CTCNV5B\SQLEXPRESS;Initial Catalog=DSS;Integrated Security=true;";
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CTCNV5B\SQLEXPRESS;Initial Catalog=DSS;Integrated Security=true;");

        public NewUser()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("pictureBox is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                pictureBox1.Focus();
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

            if (txtPassword.Text.ToString().Length == 0)
            {
                MessageBox.Show("Password is empty!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtPassword.Focus();
                return;
            }


            if (MessageBox.Show("Do you want to save new Users info?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] img = ms.ToArray();

                    SqlConnection connection = new SqlConnection(connectionstring.Trim());

                    string insertStatement = "Insert into Users(UserID,Firstname,Lastname,Password,Username,Image) VALUES (@userid,@first,@last,@pass,@user,@img)";

                    SqlCommand insertCommand = new SqlCommand(insertStatement, connection);

                    insertCommand.Parameters.Add("@userid", SqlDbType.VarChar).Value = txtUserID.Text;
                    insertCommand.Parameters.Add("@first", SqlDbType.VarChar).Value = txtFirstname.Text;
                    insertCommand.Parameters.Add("@last", SqlDbType.VarChar).Value = txtLastname.Text;
                    insertCommand.Parameters.Add("@pass", SqlDbType.VarChar).Value = txtPassword.Text;
                    insertCommand.Parameters.Add("@user", SqlDbType.VarChar).Value = txtUsername.Text;
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
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Close();
            }
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
          

            con.Open();
            SqlCommand cmd = new SqlCommand("Ucode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            object obj = cmd.ExecuteScalar();
            this.txtUserID.Text = obj.ToString();

            txtUserID.Enabled = false;
        }

        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstname_Enter(object sender, EventArgs e)
        {
            if(txtFirstname.Text == " Firstname...."){
                txtFirstname.Text = "";
            }
        }

        private void txtFirstname_Leave(object sender, EventArgs e)
        {
            if (txtFirstname.Text == "")
            {
                txtFirstname.Text = " Firstname....";
                txtFirstname.ForeColor = Color.Gray;
                
            }
        }

        private void txtFirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtFirstname.ForeColor = Color.Black;
        }

        private void txtLastname_Enter(object sender, EventArgs e)
        {
            if (txtLastname.Text == " Lastname....")
            {
                txtLastname.Text = "";
            }
        }

        private void txtLastname_Leave(object sender, EventArgs e)
        {
            if (txtLastname.Text == "")
            {
                txtLastname.Text = " Lastname....";
                txtLastname.ForeColor = Color.Gray;
            }
        }

        private void txtLastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtLastname.ForeColor = Color.Black;
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == " Username....")
            {
                txtUsername.Text = "";
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = " Username....";
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtUsername.ForeColor = Color.Black;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == " Password....")
            {
                txtPassword.Text = "";
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = " Password....";
                txtPassword.ForeColor = Color.Gray;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPassword.ForeColor = Color.Black;
        }

        private void txtUserID_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
