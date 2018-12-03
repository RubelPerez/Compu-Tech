using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CompuTech
{
    public partial class FrmParametro : Form
    {
        public string Mask { get; set; }


        public FrmParametro()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            String a = cbNombre.SelectedValue.ToString();
            String b = txtDocumento.Text;

            if (cbNombre.SelectedValue.ToString()== "" && txtDocumento.Text == "") { MessageBox.Show("Debe llenar al menos un campo");
            cbNombre.Focus();
            }
            else
            {
                FrmReporteNuevo parametro = new FrmReporteNuevo();
                parametro.filtramedatos(a, b);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_Validated(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                txtDocumento.Mask = "??0000000";
            }
            
        }

        private void radioButton2_Validated(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                txtDocumento.Mask = "000-0000000-0";

            }
        }

        private void FrmParametro_Load(object sender, EventArgs e)
        {
            llenacomboboxNombre();

        }
        public void llenacomboboxNombre()
        {
            //se declara una variable de tipo SqlConnection
            SqlConnection conexion = new SqlConnection();
            //se indica la cadena de conexion
            conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
            //código para llenar el comboBox
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter("SELECT producto from combox  WHERE producto IS not NULL", conexion);
            //se indica el nombre de la tabla
            da.Fill(ds, "combox");
            cbNombre.DataSource = ds.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            cbNombre.ValueMember = "producto";

        }
        }
    
}
