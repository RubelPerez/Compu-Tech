using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace CompuTech
{
    public partial class FrmAgregarEmpleado : Form
    {
        int boton;
        public FrmAgregarEmpleado()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtApellido.Text == "" || txtCargo.Text == "" || txtDireccion.Text == ""
                || txtTelefono.Text == "") { MessageBox.Show("No puede dejar campos vacio"); }

            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
                    System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();


                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO empleados VALUES (@emp_tipodocumento,@emp_documento,@emp_nombre, @emp_apellido, @emp_cargo, @emp_direccion, @emp_telefono,@emp_estado,@emp_foto)";

                    cmd.Parameters.Add("@emp_tipodocumento", System.Data.SqlDbType.VarChar);
                    cmd.Parameters.Add("@emp_documento", System.Data.SqlDbType.VarChar);

                    cmd.Parameters.Add("@emp_nombre", System.Data.SqlDbType.VarChar);
                    cmd.Parameters.Add("@emp_apellido", System.Data.SqlDbType.VarChar);
                    cmd.Parameters.Add("@emp_cargo", System.Data.SqlDbType.VarChar);
                    cmd.Parameters.Add("@emp_direccion", System.Data.SqlDbType.VarChar);
                    cmd.Parameters.Add("@emp_telefono", System.Data.SqlDbType.VarChar);
                    cmd.Parameters.Add("@emp_estado", System.Data.SqlDbType.VarChar);
                    cmd.Parameters.Add("@emp_foto", System.Data.SqlDbType.Image);

                    string estado = cbEstado.SelectedItem.ToString();
                    string tipo = cbDocumento.SelectedItem.ToString();
                    cmd.Parameters["@emp_tipodocumento"].Value = cbDocumento.Text;
                    cmd.Parameters["@emp_documento"].Value = txtDocumento.Text;
                    cmd.Parameters["@emp_nombre"].Value = txtNombre.Text;
                    cmd.Parameters["@emp_apellido"].Value = txtApellido.Text;
                    cmd.Parameters["@emp_cargo"].Value = txtCargo.Text;
                    cmd.Parameters["@emp_direccion"].Value = txtDireccion.Text;
                    cmd.Parameters["@emp_telefono"].Value = txtTelefono.Text;
                    cmd.Parameters["@emp_estado"].Value = estado;

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();

                    foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                    cmd.Parameters["@emp_foto"].Value = ms.GetBuffer();

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Agregado Correctamente");
                    Limpiar();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog BuscarImagen = new OpenFileDialog(); BuscarImagen.Filter = "Archivos de Imagen|*.jpg";
            //Aquí incluiremos los filtros que queramos.
            BuscarImagen.FileName = "";
            BuscarImagen.Title = "IMAGEN CLIENTE";
            BuscarImagen.InitialDirectory = @"C:\Users\Public\Pictures\Imagenes Proyecto"; BuscarImagen.FileName = this.txtFoto.Text;
            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {

                this.txtFoto.Text = BuscarImagen.FileName; String Direccion = BuscarImagen.FileName; this.foto.ImageLocation = Direccion;

                foto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            
        }
        public void Limpiar() {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCargo.Text = "";
            cbDocumento.SelectedIndex = -1;
            txtDireccion.Text = "";
            txtDocumento.Text = "";
            cbEstado.SelectedIndex = -1;
        
            foto.Image = null;
            txtTelefono.Text = "";
            txtFoto.Text = "";
        
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void FrmAgregarEmpleado_Load(object sender, EventArgs e)
        {

        }

        private void cbDocumento_Validated(object sender, EventArgs e)
        {
            if (cbDocumento.SelectedItem.ToString() == "CEDULA")
            {
                txtDocumento.Mask = "000-0000000-0";

            }
            else if (cbDocumento.SelectedItem.ToString() == "PASAPORTE")
            {

                txtDocumento.Mask = ">?>?>?0000000";
            }
        }

        private void txtDocumento_Validated(object sender, EventArgs e)
        {
            if (!txtDocumento.MaskFull == false)
            {
                string sql = @"SELECT COUNT(*) FROM empleados WHERE emp_documento = @emp_documento";


                SqlConnection conn = Filtro.DameConexion();


                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@emp_documento", txtDocumento.Text);


                conn.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 0)
                {
                    pbDocumento.ImageLocation = @"D:\Programacion\400-iconos-varios-programacion\400-iconos-varios\16 (Ok).ico";

                    this.toolTip1.SetToolTip(pbDocumento, "Numero de Documento exitoso");
                }
                else
                {
                    pbDocumento.ImageLocation = @"D:\Programacion\400-iconos-varios-programacion\302-iconos\nuevos_iconos\varios\stop16.ico";
                    this.toolTip1.SetToolTip(pbDocumento, "Ya existe este numero de Documento");

                    DialogResult respuende = MessageBox.Show("YA EXISTE NUMERO DE CEDULA, DESEA CARGARLO?", "ADVERTENCIA", MessageBoxButtons.OKCancel);
                    if (respuende == DialogResult.OK)
                    {


                        try
                        {


                            boton = 2;
                            // Creando objetos de datos.
                            System.Data.DataSet ds = new System.Data.DataSet();
                            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM empleados WHERE emp_documento = @emp_documento", @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");

                            // Añadiendo el parámetro
                            da.SelectCommand.Parameters.Add("@emp_documento", System.Data.SqlDbType.VarChar);
                            // Estableciendo el valor del parámetro
                            da.SelectCommand.Parameters["@emp_documento"].Value = txtDocumento.Text;                 // Se recuperan los datos
                            da.Fill(ds, "empleados");

                            // Se verifica la existencia del registro
                            if (ds.Tables["empleados"].Rows.Count != 0)
                            {
                                // Se establecen los valores en el formulario
                                cbDocumento.Text = ds.Tables["empleados"].Rows[0]["emp_tipodocumento"].ToString();
                                txtDocumento.Text = ds.Tables["empleados"].Rows[0]["emp_documento"].ToString();
                                txtNombre.Text = ds.Tables["empleados"].Rows[0]["emp_nombre"].ToString();
                                txtApellido.Text = ds.Tables["empleados"].Rows[0]["emp_apellido"].ToString();
                                txtCargo.Text = ds.Tables["empleados"].Rows[0]["emp_cargo"].ToString();
                                txtDireccion.Text = ds.Tables["empleados"].Rows[0]["emp_direccion"].ToString();
                                txtTelefono.Text = ds.Tables["empleados"].Rows[0]["emp_telefono"].ToString();
                                cbEstado.Text = ds.Tables["empleados"].Rows[0]["emp_estado"].ToString();



                                //la imagen

                                SqlConnection conetame4 = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
                                SqlCommand comando4 = new SqlCommand("select emp_foto from empleados where emp_documento=@emp_documento", conetame4);
                                SqlDataAdapter adap4 = new SqlDataAdapter(comando4);
                                adap4.SelectCommand.Parameters.Add("@emp_documento", System.Data.SqlDbType.VarChar);
                                // Estableciendo el valor del parámetro
                                adap4.SelectCommand.Parameters["@emp_documento"].Value = txtDocumento.Text;


                                DataSet ds4 = new DataSet("empleados");
                                byte[] imagen4 = new byte[0];
                                adap4.Fill(ds4, "empleados");
                                DataRow DR4 = ds4.Tables["empleados"].Rows[0];
                                imagen4 = (byte[])DR4["emp_foto"];
                                MemoryStream ms4 = new MemoryStream(imagen4);

                                foto.Image = Image.FromStream(ms4);
                            }
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }

                    else
                    {


                        boton = 0;
                        btnAgregar.Text = "Agregar";
                    }

                }
            }
            else { MessageBox.Show("NO puede DEJAR ESTE CAMPO VACIO o INCOMPLETO");
            txtDocumento.Focus();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
                SqlCommand cmd = new SqlCommand("delete from empleados where emp_documento='"+txtDocumento.Text+"'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("exito");
                Limpiar();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                  
                    try
                    {

                        string estado=cbEstado.SelectedItem.ToString();
                        string tipo = cbDocumento.SelectedItem.ToString();
                        System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
                        SqlCommand comando = new SqlCommand("update empleados set emp_tipodocumento='" + tipo + "',emp_documento='" + txtDocumento.Text + "',emp_nombre='" + txtNombre.Text + "',emp_apellido='" + txtApellido.Text + "',emp_cargo='" + txtCargo.Text + "',emp_direccion='" + txtDireccion.Text + "',emp_telefono='" + txtTelefono.Text + "',emp_estado='" + estado + "'where emp_documento='"+txtDocumento.Text+"'", conn);
                        conn.Open();
                        comando.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Modificacion Exitosa");
                        
                        Limpiar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
        }
        public static void validartxt(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo acepta letras y espacios");
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validartxt(sender,e);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            validartxt(sender, e);
        }

        private void txtCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validartxt(sender, e);
        }
    }
}
