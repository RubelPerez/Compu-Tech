using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace CompuTech
{
    public partial class FrmServicio : Form
    {
        int cancel;
        public FrmServicio()
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
                    SqlCommand cmd = new SqlCommand("insert into servicio (serv_nombre,serv_precio,serv_obra) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("exito");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox1.Focus();
                }
                else if (cancel == 1) { MessageBox.Show("SERVICIO YA EXISTE"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            string sql = @"SELECT COUNT(*)
      FROM servicio
      WHERE serv_nombre = @ct_correo";


            SqlConnection conn = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");


            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ct_correo", textBox1.Text);


            conn.Open();

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count == 0)
            {
                pictureBox1.ImageLocation = @"D:\Programacion\400-iconos-varios-programacion\400-iconos-varios\16 (Ok).ico";
                cancel = 2;
                this.toolTip1.SetToolTip(pictureBox1, "Servicio exitoso");
            }
            else
            {
                pictureBox1.ImageLocation = @"D:\Programacion\400-iconos-varios-programacion\302-iconos\nuevos_iconos\varios\stop16.ico";

                this.toolTip1.SetToolTip(pictureBox1, "Ya existe este Servicio");
                cancel = 1;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            solonumeros(sender, e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            solonumeros(sender, e);

        }
        public void solonumeros(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                }
        }
    }
}
