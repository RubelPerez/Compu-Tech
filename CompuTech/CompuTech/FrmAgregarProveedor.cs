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
    public partial class FrmAgregarProveedor : Form
    {
      
        public FrmAgregarProveedor()
        {
            InitializeComponent();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            OpenFileDialog BuscarImagen = new OpenFileDialog(); BuscarImagen.Filter = "Archivos de Imagen|*.jpg";
            //Aquí incluiremos los filtros que queramos.
            BuscarImagen.FileName = "";
            BuscarImagen.Title = "IMAGEN DE PROVEEDOR";
            BuscarImagen.InitialDirectory = @"C:\Users\Public\Pictures\Imagenes Proyecto"; BuscarImagen.FileName = this.txtFoto.Text;
            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {
                /// Si esto se cumple, capturamos la propiedad File Name y la guardamos en el control
                this.txtFoto.Text = BuscarImagen.FileName; String Direccion = BuscarImagen.FileName; this.foto.ImageLocation = Direccion;
                //Pueden usar tambien esta forma para cargar la Imagen solo activenla y comenten la linea donde se cargaba anteriormente 
                //this.pictureBox1.ImageLocation = textBox1.Text;
                foto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();

                // Estableciento propiedades
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO proveedores VALUES (@pro_nombre, @pro_apellido, @pro_telefono, @pro_telefonoemp, @pro_empresa,@pro_codigoperso,@pro_tipo,@pro_numero,@pro_foto)";

                // Creando los parámetros necesarios
                cmd.Parameters.Add("@pro_nombre", System.Data.SqlDbType.VarChar);
                cmd.Parameters.Add("@pro_apellido", System.Data.SqlDbType.VarChar);
                cmd.Parameters.Add("@pro_telefono", System.Data.SqlDbType.VarChar);
                cmd.Parameters.Add("@pro_telefonoemp", System.Data.SqlDbType.VarChar);
                cmd.Parameters.Add("@pro_empresa", System.Data.SqlDbType.VarChar);
                cmd.Parameters.Add("@pro_codigoperso", System.Data.SqlDbType.VarChar);
                cmd.Parameters.Add("@pro_tipo", System.Data.SqlDbType.VarChar);
                cmd.Parameters.Add("@pro_numero", System.Data.SqlDbType.VarChar);
                cmd.Parameters.Add("@pro_foto", System.Data.SqlDbType.Image);
                // Asignando los valores a los atributos
                string tipo = cb_tipo.SelectedItem.ToString();
                cmd.Parameters["@pro_nombre"].Value = nombre.Text;
                cmd.Parameters["@pro_apellido"].Value = txtApellido.Text;
                cmd.Parameters["@pro_telefono"].Value = txtTelefonoPersonal.Text;
                cmd.Parameters["@pro_telefonoemp"].Value = txtTelefonoEmpresa.Text;
                cmd.Parameters["@pro_empresa"].Value = txtEmpresa.Text;
                cmd.Parameters["@pro_codigoperso"].Value = txtCodigoEmpresa.Text;
                cmd.Parameters["@pro_tipo"].Value = tipo;
                cmd.Parameters["@pro_numero"].Value = txtNumero.Text;


                System.IO.MemoryStream ms2 = new System.IO.MemoryStream();
                foto.Image.Save(ms2, System.Drawing.Imaging.ImageFormat.Jpeg);
                cmd.Parameters["@pro_foto"].Value = ms2.GetBuffer();


                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Agregado Correctamente");
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }
              public void Limpiar() {

           nombre.Text = "";
            txtApellido.Text = "";
            txtNumero.Text = "";
            txtTelefonoEmpresa.Text = "";
            cb_tipo.SelectedIndex = -1;
            txtTelefonoPersonal.Text = "";
            txtNumero.Text = "";
            foto.Image = null;
            txtCodigoEmpresa.Text = "";
            txtFoto.Text = "";
            txtEmpresa.Text = "";
        
        }

              private void btnLimpiar_Click(object sender, EventArgs e)
              {
                  Limpiar();
              }

              private void FrmAgregarProveedor_Load(object sender, EventArgs e)
              {

              }

              private void txtNumero_Validated(object sender, EventArgs e)
              {
                  
              }

              private void txtCodigoEmpresa_Validated(object sender, EventArgs e)
              {
                  string sql = @"SELECT COUNT(*)
      FROM proveedores
      WHERE pro_codigoperso = @pro_codigoperso and pro_empresa=@pro_empresa";


                  SqlConnection conn = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");


                  SqlCommand cmd = new SqlCommand(sql, conn);
                  cmd.Parameters.AddWithValue("@pro_codigoperso", txtCodigoEmpresa.Text);
                  cmd.Parameters.AddWithValue("@pro_empresa", txtEmpresa.Text);

                  conn.Open();

                  int count = Convert.ToInt32(cmd.ExecuteScalar());

                  if (count == 0)
                  {
                      pictureBox1.ImageLocation = @"D:\Programacion\400-iconos-varios-programacion\400-iconos-varios\16 (Ok).ico";

                      this.toolTip1.SetToolTip(pictureBox1, "Numero de Codigo exitoso");
                  }
                  else
                  {
                      pictureBox1.ImageLocation = @"D:\Programacion\400-iconos-varios-programacion\302-iconos\nuevos_iconos\varios\stop16.ico";
                      this.toolTip1.SetToolTip(pictureBox1, "Ya existe este Codigo de Documento");
                  }

              }

              private void cb_tipo_Validated(object sender, EventArgs e)
              {
                  if (cb_tipo.SelectedItem.ToString() == "CEDULA")
                  {
                      txtNumero.Mask = "999-9999999-9";
                  }
                  else { txtNumero.Mask = ">?>?>?9999999"; }
              }

              private void txtNumero_Validated_1(object sender, EventArgs e)
              {
                  string sql = @"SELECT COUNT(*)
      FROM proveedores
      WHERE pro_numero = @pro_numero";


                  SqlConnection conn = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");


                  SqlCommand cmd = new SqlCommand(sql, conn);
                  cmd.Parameters.AddWithValue("@pro_numero", txtNumero.Text);


                  conn.Open();

                  int count = Convert.ToInt32(cmd.ExecuteScalar());

                  if (count == 0)
                  {
                      pictureBox1.ImageLocation = @"D:\Programacion\400-iconos-varios-programacion\400-iconos-varios\16 (Ok).ico";

                      this.toolTip1.SetToolTip(pictureBox1, "Numero de Documento exitoso");
                  }
                  else
                  {
                      pictureBox1.ImageLocation = @"D:\Programacion\400-iconos-varios-programacion\302-iconos\nuevos_iconos\varios\stop16.ico";
                      this.toolTip1.SetToolTip(pictureBox1, "Ya existe este numero de Documento");
                  }
              }
        }
    }

