using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CompuTech
{
    public partial class FrmSplash : Form
    {
        public FrmSplash()
        { 
           
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 3950;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            
            timer1.Stop();

            
            this.DialogResult = DialogResult.OK;
            this.Hide();
            FrmLogin login = new FrmLogin();
            login.Show();
        }

        private void circularProgress1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void circularProgress1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmSplash_Load(object sender, EventArgs e)
        {
           
        }

        private void letras_Tick(object sender, EventArgs e)
        {

        }
            
        }
    }

