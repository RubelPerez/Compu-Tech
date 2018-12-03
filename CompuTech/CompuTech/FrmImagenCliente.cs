using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CompuTech
{
    public partial class FrmImagenCliente : Form
    {
        public FrmImagenCliente()
        {
            InitializeComponent();
        }

        private void FrmImagenCliente_Load(object sender, EventArgs e)
        {
            SqlConnection conetame4 = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
            SqlCommand comando4 = new SqlCommand("select ct_foto from cliente where ct_id='" + Llename.gridcliente + "'", conetame4);
            SqlDataAdapter adap4 = new SqlDataAdapter(comando4);
            DataSet ds4 = new DataSet("cliente");
            byte[] imagen4 = new byte[0];
            adap4.Fill(ds4, "cliente");
            DataRow DR4 = ds4.Tables["cliente"].Rows[0];
            imagen4 = (byte[])DR4["ct_foto"];
            MemoryStream ms4 = new MemoryStream(imagen4);

            pictureBox1.Image = Image.FromStream(ms4);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
