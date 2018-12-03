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
    public partial class FrmMarca : Form
    {
        public FrmMarca()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (cancel != 1)
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
                    SqlCommand cmd = new SqlCommand("insert into combox (marca) values ('" + textBox1.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("exito");
                    textBox1.Clear();
                    textBox1.Focus();
                }
                else if (cancel == 1) { MessageBox.Show("MARCA YA EXISTE"); }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        int cancel;
        private void textBox1_Validated(object sender, EventArgs e)
        {
            string sql = @"SELECT COUNT(*)
      FROM combox
      WHERE marca = @ct_correo";


            SqlConnection conn = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");


            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ct_correo", textBox1.Text);


            conn.Open();

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count == 0)
            {
                pictureBox1.ImageLocation = @"D:\Programacion\400-iconos-varios-programacion\400-iconos-varios\16 (Ok).ico";
                cancel = 2;
                this.toolTip1.SetToolTip(pictureBox1, "Modelo exitoso");
            }
            else
            {
                pictureBox1.ImageLocation = @"D:\Programacion\400-iconos-varios-programacion\302-iconos\nuevos_iconos\varios\stop16.ico";

                this.toolTip1.SetToolTip(pictureBox1, "Ya existe esta Modelo");
                cancel = 1;


            }
        }
        }
    }

