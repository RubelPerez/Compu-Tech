using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CompuTech
{
    public partial class FrmCiudad : Form
    {
        public FrmCiudad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
                SqlCommand cmd = new SqlCommand("insert into combox (ciudad) values ('" + textBox1.Text + "')", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("exito");
                textBox1.Clear();
                textBox1.Focus();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void FrmCiudad_Load(object sender, EventArgs e)
        {

        }
    }
}
