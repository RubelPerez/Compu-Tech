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
    public partial class FrmImagenEmpleado : Form
    {
        public FrmImagenEmpleado()
        {
            InitializeComponent();
        }

        private void FrmImagenEmpleado_Load(object sender, EventArgs e)
        {
            SqlConnection conetame4 = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
            SqlCommand comando4 = new SqlCommand("select emp_foto from empleados where emp_codigo='" + Llename.gridempleado + "'", conetame4);
            SqlDataAdapter adap4 = new SqlDataAdapter(comando4);
            DataSet ds4 = new DataSet("empleados");
            byte[] imagen4 = new byte[0];
            adap4.Fill(ds4, "empleados");
            DataRow DR4 = ds4.Tables["empleados"].Rows[0];
            imagen4 = (byte[])DR4["emp_foto"];
            MemoryStream ms4 = new MemoryStream(imagen4);

            pictureBox1.Image = Image.FromStream(ms4);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
