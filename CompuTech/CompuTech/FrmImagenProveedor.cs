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
    public partial class FrmImagenProveedor : Form
    {
        public FrmImagenProveedor()
        {
            InitializeComponent();
        }

        private void FrmImagenProveedor_Load(object sender, EventArgs e)
        {
            SqlConnection conetame4 = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
            SqlCommand comando4 = new SqlCommand("select pro_foto from proveedores where pro_id='" + Llename.gridprovedor + "'", conetame4);
            SqlDataAdapter adap4 = new SqlDataAdapter(comando4);
            DataSet ds4 = new DataSet("proveedores");
            byte[] imagen4 = new byte[0];
            adap4.Fill(ds4, "proveedores");
            DataRow DR4 = ds4.Tables["proveedores"].Rows[0];
            imagen4 = (byte[])DR4["pro_foto"];
            MemoryStream ms4 = new MemoryStream(imagen4);

            pictureBox1.Image = Image.FromStream(ms4);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
