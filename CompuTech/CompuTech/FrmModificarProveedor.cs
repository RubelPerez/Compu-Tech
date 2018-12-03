using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace CompuTech
{
    public partial class FrmModificarProveedor : Form
    {
        SqlConnection conetame4 = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
        public FrmModificarProveedor()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
            try
            {
                txtNumero.Enabled = false;
              
                    
               // Creando objetos de datos.
       System.Data.DataSet ds = new System.Data.DataSet();
       System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM proveedores WHERE pro_numero = @numero", @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
 
       // Añadiendo el parámetro
       da.SelectCommand.Parameters.Add("@numero", System.Data.SqlDbType.VarChar);
       // Estableciendo el valor del parámetro
       da.SelectCommand.Parameters["@numero"].Value = int.Parse(txtNumero.Text);
 
       // Se recuperan los datos
       da.Fill(ds, "proveedores");
 
       // Se verifica la existencia del registro
       if (ds.Tables["proveedores"].Rows.Count != 0)
       {
          // Se establecen los valores en el formulario
           nombre.Text = ds.Tables["proveedores"].Rows[0]["pro_nombre"].ToString();
           txtApellido.Text = ds.Tables["proveedores"].Rows[0]["pro_apellido"].ToString();
           txtTelefonoPersonal.Text = ds.Tables["proveedores"].Rows[0]["pro_telefono"].ToString();
           txtTelefonoEmpresa.Text = ds.Tables["proveedores"].Rows[0]["pro_telefonoemp"].ToString();
           txtEmpresa.Text = ds.Tables["proveedores"].Rows[0]["pro_empresa"].ToString();
           txtCodigoEmpresa.Text = ds.Tables["proveedores"].Rows[0]["pro_codigoperso"].ToString();
           
           txtNumero.Text = ds.Tables["proveedores"].Rows[0]["pro_numero"].ToString();
         //la imagen

          
           SqlCommand comando4 = new SqlCommand("select pro_foto from proveedores where pro_numero=@numero",conetame4);
           SqlDataAdapter adap4 = new SqlDataAdapter(comando4);
           adap4.SelectCommand.Parameters.Add("@numero", System.Data.SqlDbType.VarChar);
           // Estableciendo el valor del parámetro
           adap4.SelectCommand.Parameters["@numero"].Value = int.Parse(txtNumero.Text);
        
           
           DataSet ds4 = new DataSet("proveedores");
           byte[] imagen4 = new byte[0];
           adap4.Fill(ds4, "proveedores");
           DataRow DR4 = ds4.Tables["proveedores"].Rows[0];
           imagen4 = (byte[])DR4["pro_foto"];
           MemoryStream ms4 = new MemoryStream(imagen4);
           foto.Image = Image.FromStream(ms4);
       }
       else
       {
          MessageBox.Show("El producto no existe");
       }
    }
    catch (System.Exception ex)
    {
       MessageBox.Show(ex.Message);
    }

        }

        private void button1_Click(object sender, EventArgs e)
        { 
            
        

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que quiere modificar?", "MODIFICAR", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                try
                {

                    SqlCommand comando = new SqlCommand("Update proveedores set pro_nombre='" + nombre.Text + "',pro_apellido='" + txtApellido.Text + "',pro_telefono='" + txtTelefonoPersonal.Text + "',pro_telefonoemp='" + txtTelefonoEmpresa.Text + "',pro_empresa='" + txtEmpresa.Text + "',pro_codigoperso='" + txtCodigoEmpresa.Text + "'where pro_numero='" + txtNumero.Text + "'", conetame4);
                    conetame4.Open();
                    comando.ExecuteNonQuery();
                    conetame4.Close();
                    MessageBox.Show("Modificacion Exitosa");
                    txtNumero.Enabled = true;
                    Limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }
        private void txtCodigoEmpresa_TextChanged(object sender, EventArgs e)
        {

        }
        public void Limpiar() {
            txtNumero.Text = "";
            foto.Image = null;
            txtApellido.Text = "";
            txtTelefonoEmpresa.Text = "";
            txtTelefonoPersonal.Text = "";
            txtCodigoEmpresa.Text = "";
            txtNumero.Text = "";
            nombre.Text = "";
            txtEmpresa.Text = "";
        
        }

        private void FrmModificarProveedor_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que quiere borrar?", "BORRAR", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {

                    SqlCommand comando = new SqlCommand("delete from proveedores where pro_numero='" + txtNumero.Text + "'", conetame4);
                    conetame4.Open();
                    comando.ExecuteNonQuery();
                    conetame4.Close();
                    MessageBox.Show("Borrado Exitoso");
                    txtNumero.Enabled = true;
                    Limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }
    }
}
