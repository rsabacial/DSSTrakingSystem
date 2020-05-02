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
    public partial class UpdateUser : Form
    {
        private string connectionstring = @"Data Source=DESKTOP-CTCNV5B\SQLEXPRESS;Initial Catalog=DSS;Integrated Security=true;";

        public UpdateUser(string UserID, string firstname, string lastname, string password, string user, Image img)
        {
            InitializeComponent();
            txtUserID.Text = UserID;
            txtFirstname.Text = firstname;
            txtLastname.Text = lastname;
            txtPassword.Text = password;
            txtUsername.Text = user;
            pictureBox1.Image = img;
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

            if (MessageBox.Show("Do you want to update Users info?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] img = ms.ToArray();

                    SqlConnection connection = new SqlConnection(connectionstring.Trim());

                    string insertStatement = "UPDATE Users SET Firstname=@first,Lastname=@last,Password=@pass,Username=@user,Image=@img WHERE UserID=@id";

                    SqlCommand insertCommand = new SqlCommand(insertStatement, connection);


                    insertCommand.Parameters.Add("@id", SqlDbType.VarChar).Value = txtUserID.Text;
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
            }

            this.Close();
        }

        private void UpdateUser_Load(object sender, EventArgs e)
        {
            txtUserID.Enabled = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
