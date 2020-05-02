using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DynamicSoftwareSolutionFinal
{
    public partial class frmProcessBar : Form
    {
        public frmProcessBar()
        {
            InitializeComponent();
        }

        private void frmProcessBar_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            label1.Text = progressBar1.Value.ToString()+"%";

            progressBar1.Maximum = 100;
          //  progressBar1.PerformStep();
            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;   //Add this line
                frmMain main = new frmMain();
                main.Show();
                this.Hide();
            }



          

        }
    }
}
