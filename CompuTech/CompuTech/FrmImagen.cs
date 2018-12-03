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
namespace CompuTech
{
    public partial class FrmImagen : Form
    {
        public FrmImagen()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void FrmImagen_Load(object sender, EventArgs e)
        {
            SqlConnection conetame4 = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
            SqlCommand comando4 = new SqlCommand("select art_foto from articulos where art_id='" + Llename.grid + "'", conetame4);
            SqlDataAdapter adap4 = new SqlDataAdapter(comando4);
            DataSet ds4 = new DataSet("articulos");
            byte[] imagen4 = new byte[0];
            adap4.Fill(ds4, "articulos");
            DataRow DR4 = ds4.Tables["articulos"].Rows[0];
            imagen4 = (byte[])DR4["art_foto"];
            MemoryStream ms4 = new MemoryStream(imagen4);

            pictureBox1.Image = Image.FromStream(ms4);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }
    }
}
