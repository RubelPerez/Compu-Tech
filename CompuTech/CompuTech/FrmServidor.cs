using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace CompuTech
{
    public partial class FrmServidor : Form
    {
        int cancel;
        public FrmServidor()
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
                    SqlCommand cmd = new SqlCommand("insert into red (nombre_servidor,precio_servidor) values ('" + textBox1.Text + "','" + textBox2.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("exito");
                    textBox1.Clear();
                    textBox2.Clear();

                    textBox1.Focus();
                }
                else if (cancel == 1) { MessageBox.Show("SERVICIO YA EXISTE"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmServidor_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            string sql = @"SELECT COUNT(*)
      FROM red
      WHERE nombre_servidor = @ct_correo";


            SqlConnection conn = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");


            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ct_correo", textBox1.Text);


            conn.Open();

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            if (count == 0)
            {
                pictureBox1.ImageLocation = @"D:\Programacion\400-iconos-varios-programacion\400-iconos-varios\16 (Ok).ico";
                cancel = 2;
                this.toolTip1.SetToolTip(pictureBox1, "MODELO exitoso");
            }
            else
            {
                pictureBox1.ImageLocation = @"D:\Programacion\400-iconos-varios-programacion\302-iconos\nuevos_iconos\varios\stop16.ico";

                this.toolTip1.SetToolTip(pictureBox1, "Ya existe este MODELO");
                cancel = 1;

            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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
