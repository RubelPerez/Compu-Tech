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
    public partial class FrmAgregarCliente : Form

    {
        SqlDataAdapter adp = null;
        Combo combo;
        private DataSet ds = new DataSet(); 
        int boton = 0;
        public FrmAgregarCliente()
        {
            InitializeComponent();
        }

      

        private void FrmAgregarCliente_Load(object sender, EventArgs e)
        {
            llenacomboboxOrigen();
            llenacomboboxCiudad();
            llenacomboboxProvincia();
            llenacomboboxEstadoCivil();
            llenacomboboxSangre();
            txtNumero.Enabled = false;
            button6.Enabled = false;
            txtFecha.Text = DateTime.Now.ToShortDateString();
            txtFecha.Enabled = false;
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text == "" || txtCorreo.Text == "" || txtDireccion.Text == ""
                || txtNombre.Text == "" || txtTelefono.Text == "" || txtNumero.Text == "")
            {
                MessageBox.Show("No puede dejar campos vacios");
            }
            else
            {
                try
                {
                    if (boton == 0)
                    {
                        SqlConnection conn = Filtro.DameConexion();
                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();


                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO cliente VALUES (@ct_nombre, @ct_apellido, @ct_telefono,@ct_origen, @ct_tipodocumento, @ct_documento,@ct_direccion,@ct_ciudad,@ct_provincia,@ct_fechaingreso,@ct_fechanacimiento,@ct_correo,@ct_estadocivil,@ct_sangre,@ct_sexo,@ct_ocupacion,@ct_foto)";


                        cmd.Parameters.Add("@ct_nombre", System.Data.SqlDbType.VarChar);
                        cmd.Parameters.Add("@ct_apellido", System.Data.SqlDbType.VarChar);
                        cmd.Parameters.Add("@ct_telefono", System.Data.SqlDbType.VarChar);
                        cmd.Parameters.Add("@ct_origen", System.Data.SqlDbType.VarChar);
                        cmd.Parameters.Add("@ct_tipodocumento", System.Data.SqlDbType.VarChar);
                        cmd.Parameters.Add("@ct_documento", System.Data.SqlDbType.VarChar);
                        cmd.Parameters.Add("@ct_direccion", System.Data.SqlDbType.VarChar);
                        cmd.Parameters.Add("@ct_ciudad", System.Data.SqlDbType.VarChar);
                        cmd.Parameters.Add("@ct_provincia", System.Data.SqlDbType.VarChar);
                        cmd.Parameters.Add("@ct_fechaingreso", System.Data.SqlDbType.VarChar);
                        cmd.Parameters.Add("@ct_fechanacimiento", System.Data.SqlDbType.VarChar);
                        cmd.Parameters.Add("@ct_correo", System.Data.SqlDbType.VarChar);
                        cmd.Parameters.Add("@ct_estadocivil", System.Data.SqlDbType.VarChar);
                        cmd.Parameters.Add("@ct_sangre", System.Data.SqlDbType.VarChar);
                        cmd.Parameters.Add("@ct_sexo", System.Data.SqlDbType.VarChar);
                        cmd.Parameters.Add("@ct_ocupacion", System.Data.SqlDbType.VarChar);
                        cmd.Parameters.Add("@ct_foto", System.Data.SqlDbType.Image);

                        string tipo = cb_tipo.SelectedItem.ToString();

                        string provincia = cb_provincia.SelectedValue.ToString();
                        string estado = cbEstado.SelectedValue.ToString();
                        string sangre = cbSangre.SelectedValue.ToString();
                        string sexo = cbSexo.SelectedItem.ToString();

                        string ciudad = cb_ciudad.SelectedValue.ToString();
                        string origen = cb_origen.SelectedValue.ToString();
                        cmd.Parameters["@ct_nombre"].Value = txtNombre.Text;
                        cmd.Parameters["@ct_apellido"].Value = txtApellido.Text;
                        cmd.Parameters["@ct_telefono"].Value = txtTelefono.Text;
                        cmd.Parameters["@ct_origen"].Value = origen;
                        cmd.Parameters["@ct_tipodocumento"].Value = tipo;
                        cmd.Parameters["@ct_documento"].Value = txtNumero.Text;
                        cmd.Parameters["@ct_direccion"].Value = txtDireccion.Text;
                        cmd.Parameters["@ct_ciudad"].Value = ciudad;
                        cmd.Parameters["@ct_provincia"].Value = provincia;
                        cmd.Parameters["@ct_fechaingreso"].Value = txtFecha.Text;
                        cmd.Parameters["@ct_fechanacimiento"].Value = txtNacimiento.Text;

                        cmd.Parameters["@ct_correo"].Value = txtCorreo.Text;
                        cmd.Parameters["@ct_estadocivil"].Value = estado;
                        cmd.Parameters["@ct_sangre"].Value = sangre;
                        cmd.Parameters["@ct_sexo"].Value = sexo;
                        cmd.Parameters["@ct_ocupacion"].Value = txtOcupacion.Text;



                        System.IO.MemoryStream ms = new System.IO.MemoryStream();

                        foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                        cmd.Parameters["@ct_foto"].Value = ms.GetBuffer();

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Agregado Correctamente");
                        Limpiar();
                    }
                    else if (boton == 2)
                    {
                        button6.Enabled = true;
                        try
                        {

                            string tipo = cb_tipo.SelectedItem.ToString();
                            String ciudad = cb_ciudad.SelectedValue.ToString();
                            string provincia = cb_provincia.Text;
                            string estado = cbEstado.Text;
                            string sangre = cbSangre.Text;
                            string sexo = cbSexo.Text;
                            string origen = cb_origen.SelectedValue.ToString();
                            SqlConnection conn = Filtro.DameConexion();
                            SqlCommand comando = new SqlCommand("update cliente set ct_nombre='" + txtNombre.Text + "',ct_apellido='" + txtApellido.Text + "',ct_telefono='" + txtTelefono.Text + "',ct_origen='" + origen + "',ct_tipodocumento='" + tipo + "',ct_documento='" + txtNumero.Text + "',ct_direccion='" + txtDireccion.Text + "',ct_ciudad='" + ciudad + "',ct_provincia='" + provincia + "',ct_fechaingreso='" + txtFecha.Text + "',ct_fechanacimiento='" + txtNacimiento.Text + "',ct_correo='" + txtCorreo.Text + "',ct_estadocivil='" + estado + "',ct_sangre='" + sangre + "',ct_sexo='" + sexo + "',ct_ocupacion='" + txtOcupacion.Text + "'where ct_documento='"+txtNumero.Text+"'", conn);
                            conn.Open();
                            comando.ExecuteNonQuery();
                            conn.Close();
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());

                }
            }
        }
        public void Limpiar() {
            cb_ciudad.SelectedIndex = -1;
            cb_origen.SelectedIndex = -1;
            cb_provincia.SelectedIndex = -1;
            cbEstado.SelectedIndex = -1;
            boton = 0;
            cbSangre.SelectedIndex = -1;
            cbSexo.SelectedIndex = -1;
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            cb_tipo.SelectedIndex = -1;
            txtCorreo.Text = "";
            
            txtNumero.Text = "";
            foto.Image = null;
            txtTelefono.Text = "";
            txtOcupacion.Text = "";
            txtNacimiento.Text = "";
            txtFoto.Text = "";
            
        
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        private void txtCorreo_Validated(object sender, EventArgs e)
        {
            if (txtCorreo.Text.Contains("@"))
            {
                string sql = @"SELECT COUNT(*)
      FROM cliente
      WHERE ct_correo = @ct_correo";

                SqlConnection conn = Filtro.DameConexion();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ct_correo", txtCorreo.Text);


                conn.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 0)
                {
                    pictureBox1.ImageLocation = @"D:\Programacion\400-iconos-varios-programacion\400-iconos-varios\16 (Ok).ico";

                    this.toolTip1.SetToolTip(pictureBox1, "Correo exitoso");
                }
                else
                {
                    pictureBox1.ImageLocation = @"D:\Programacion\400-iconos-varios-programacion\302-iconos\nuevos_iconos\varios\stop16.ico";
                    this.toolTip1.SetToolTip(pictureBox1, "Ya existe este Correo");
                }
            }
            else { MessageBox.Show("Correo erroneo");
            txtCorreo.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_tipo_Validated(object sender, EventArgs e)
        {

          if (cb_tipo.SelectedItem.ToString() == "CEDULA") {
              txtNumero.Enabled = true;
                txtNumero.Mask = "000-0000000-0";
            }
          else if (cb_tipo.SelectedItem.ToString() == "PASAPORTE")
          {
              txtNumero.Enabled = true;
              txtNumero.Mask = ">?>?00000";
          }
        }

        private void txtNumero_Validated_1(object sender, EventArgs e)
        {
            if (txtNumero.MaskFull == true)
            {
                string sql = @"SELECT COUNT(*) FROM cliente WHERE ct_documento = @ct_documento";


                SqlConnection conn = Filtro.DameConexion();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ct_documento", txtNumero.Text);


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

                        txtNacimiento.Mask = "00&>?>?>?&00";
                        try
                        {
                            button6.Enabled = true;
                            btnAgregar.Text = "Modificar";
                            boton = 2;
                            // Creando objetos de datos.
                            System.Data.DataSet ds = new System.Data.DataSet();
                            System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM cliente WHERE ct_documento = @ct_documento", @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");

                            // Añadiendo el parámetro
                            da.SelectCommand.Parameters.Add("@ct_documento", System.Data.SqlDbType.VarChar);
                            // Estableciendo el valor del parámetro
                            da.SelectCommand.Parameters["@ct_documento"].Value = txtNumero.Text;                 // Se recuperan los datos
                            da.Fill(ds, "cliente");

                            // Se verifica la existencia del registro
                            if (ds.Tables["cliente"].Rows.Count != 0)
                            {
                                // Se establecen los valores en el formulario
                                txtNombre.Text = ds.Tables["cliente"].Rows[0]["ct_nombre"].ToString();
                                txtApellido.Text = ds.Tables["cliente"].Rows[0]["ct_apellido"].ToString();
                                txtTelefono.Text = ds.Tables["cliente"].Rows[0]["ct_telefono"].ToString();
                                cb_origen.Text = ds.Tables["cliente"].Rows[0]["ct_origen"].ToString();
                                cb_tipo.Text = ds.Tables["cliente"].Rows[0]["ct_tipodocumento"].ToString();
                                txtNumero.Text = ds.Tables["cliente"].Rows[0]["ct_documento"].ToString();
                                txtDireccion.Text = ds.Tables["cliente"].Rows[0]["ct_direccion"].ToString();
                                cb_ciudad.Text = ds.Tables["cliente"].Rows[0]["ct_ciudad"].ToString();
                                cb_provincia.Text = ds.Tables["cliente"].Rows[0]["ct_provincia"].ToString();
                                txtFecha.Text = ds.Tables["cliente"].Rows[0]["ct_fechaingreso"].ToString();
                                txtNacimiento.Text = ds.Tables["cliente"].Rows[0]["ct_fechanacimiento"].ToString();
                                txtCorreo.Text = ds.Tables["cliente"].Rows[0]["ct_correo"].ToString();
                                cbEstado.Text = ds.Tables["cliente"].Rows[0]["ct_estadocivil"].ToString();
                                cbSangre.Text = ds.Tables["cliente"].Rows[0]["ct_sangre"].ToString();
                                cbSexo.Text = ds.Tables["cliente"].Rows[0]["ct_sexo"].ToString();
                                txtOcupacion.Text = ds.Tables["cliente"].Rows[0]["ct_ocupacion"].ToString();



                                //la imagen

                                SqlConnection conetame4 = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
                                SqlCommand comando4 = new SqlCommand("select ct_foto from cliente where ct_documento=@ct_documento", conetame4);
                                SqlDataAdapter adap4 = new SqlDataAdapter(comando4);
                                adap4.SelectCommand.Parameters.Add("@ct_documento", System.Data.SqlDbType.VarChar);
                                // Estableciendo el valor del parámetro
                                adap4.SelectCommand.Parameters["@ct_documento"].Value = txtNumero.Text;


                                DataSet ds4 = new DataSet("cliente");
                                byte[] imagen4 = new byte[0];
                                adap4.Fill(ds4, "cliente");
                                DataRow DR4 = ds4.Tables["cliente"].Rows[0];
                                imagen4 = (byte[])DR4["ct_foto"];
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
            else { MessageBox.Show("NO puede dejar este CAMPO VACIO o INCOMPLETO");
            txtNumero.Focus();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmPais pa = new FrmPais();
            pa.Show();
            
        }

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void cb_origen_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
        

       

       public void llenacomboboxOrigen()
        {
            //se declara una variable de tipo SqlConnection
            SqlConnection conexion = new SqlConnection();
             //se indica la cadena de conexion
            conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
            //código para llenar el comboBox
             DataSet ds = new DataSet();
             //indicamos la consulta en SQL
             SqlDataAdapter da = new SqlDataAdapter("SELECT origen from combox  WHERE origen IS not NULL", conexion);
            //se indica el nombre de la tabla
             da.Fill(ds, "combox");
            cb_origen.DataSource = ds.Tables[0].DefaultView;
             //se especifica el campo de la tabla
            cb_origen.ValueMember = "origen";
            
        }
       public void llenacomboboxCiudad(){
           //se declara una variable de tipo SqlConnection
           SqlConnection conexion = new SqlConnection();
           //se indica la cadena de conexion
           conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
           //código para llenar el comboBox
           DataSet ds = new DataSet();
           //indicamos la consulta en SQL
           SqlDataAdapter da = new SqlDataAdapter("SELECT ciudad from combox where ciudad is not null", conexion);
           //se indica el nombre de la tabla
           da.Fill(ds, "combox");
           cb_ciudad.DataSource = ds.Tables[0].DefaultView;
           //se especifica el campo de la tabla
           cb_ciudad.ValueMember = "ciudad";
       }
      
        public void    llenacomboboxProvincia(){
             //se declara una variable de tipo SqlConnection
             SqlConnection conexion = new SqlConnection();
             //se indica la cadena de conexion
             conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
             //código para llenar el comboBox
             DataSet ds = new DataSet();
             //indicamos la consulta en SQL
             SqlDataAdapter da = new SqlDataAdapter("SELECT provincia from combox where provincia is not null", conexion);
             //se indica el nombre de la tabla
             da.Fill(ds, "combox");
             cb_provincia.DataSource = ds.Tables[0].DefaultView;
             //se especifica el campo de la tabla
             cb_provincia.ValueMember = "provincia";
         }
          public void   llenacomboboxEstadoCivil(){
              //se declara una variable de tipo SqlConnection
              SqlConnection conexion = new SqlConnection();
              //se indica la cadena de conexion
              conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
              //código para llenar el comboBox
              DataSet ds = new DataSet();
              //indicamos la consulta en SQL
              SqlDataAdapter da = new SqlDataAdapter("SELECT estadocivil from combox where estadocivil IS not NULL", conexion);
              //se indica el nombre de la tabla
              da.Fill(ds, "combox");
              cbEstado.DataSource = ds.Tables[0].DefaultView;
              //se especifica el campo de la tabla
              cbEstado.ValueMember = "estadocivil";
          }
          public void   llenacomboboxSangre(){
              //se declara una variable de tipo SqlConnection
              SqlConnection conexion = new SqlConnection();
              //se indica la cadena de conexion
              conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
              //código para llenar el comboBox
              DataSet ds = new DataSet();
              //indicamos la consulta en SQL
              SqlDataAdapter da = new SqlDataAdapter("SELECT sangre from combox where sangre is not null", conexion);
              //se indica el nombre de la tabla
              da.Fill(ds, "combox");
              cbSangre.DataSource = ds.Tables[0].DefaultView;
              //se especifica el campo de la tabla
              cbSangre.ValueMember = "sangre";
          }

       private void cb_origen_MouseClick(object sender, MouseEventArgs e)
       {
          llenacomboboxOrigen();
           
       }

       private void button1_Click_1(object sender, EventArgs e)
       {
           FrmCiudad c = new FrmCiudad();
           c.Show();
       }

       private void button2_Click(object sender, EventArgs e)
       {
           FrmProvincia pro = new FrmProvincia();
           pro.Show();
       }

       private void button3_Click(object sender, EventArgs e)
       {
           FrmEstadoCivil est = new FrmEstadoCivil();
           est.Show();
       }

       private void button4_Click(object sender, EventArgs e)
       {
           FrmSangre san = new FrmSangre();
           san.Show();
       }

       private void cb_ciudad_MouseClick(object sender, MouseEventArgs e)
       {
           llenacomboboxCiudad();
       }

       private void cb_provincia_MouseClick(object sender, MouseEventArgs e)
       {
           llenacomboboxProvincia();
       }

       private void cbEstado_MouseClick(object sender, MouseEventArgs e)
       {
           llenacomboboxEstadoCivil();
       }

       private void cbSangre_MouseClick(object sender, MouseEventArgs e)
       {
           llenacomboboxSangre();
       }

       private void cb_origen_Validated(object sender, EventArgs e)
       {
           
       }

       private void button6_Click(object sender, EventArgs e)
       {
           try
           {
               SqlConnection conn = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
               SqlCommand cmd = new SqlCommand("delete from cliente where ct_documento='" + txtNumero.Text + "'", conn);
               conn.Open();
               cmd.ExecuteNonQuery();
               conn.Close();
               MessageBox.Show("exito");
               Limpiar();
               
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);


           }
       }

       private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
       {
           sololetras(sender, e);
       }

       private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
       {
           sololetras(sender, e);
       }

       private void txtOcupacion_KeyPress(object sender, KeyPressEventArgs e)
       {
           sololetras( sender,  e);
       }
       public static void sololetras(object sender, KeyPressEventArgs e)
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

       private void txtNacimiento_Validated(object sender, EventArgs e)
       {
           if (txtNacimiento.MaskFull == false) {
               MessageBox.Show("NO PUEDE DEJAR ESTE CAMPO VACIO O INCOMPLETO");
               txtNacimiento.Focus();
           
           }
       }

       private void txtNumero_KeyDown(object sender, KeyEventArgs e)
       {
           
           
           }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar))
            {
                e.KeyChar = (char)Keys.Back;
                //e.Handled = true;
                MessageBox.Show("No se permite tecla espacio");
                e.Handled = true;
        }
       }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar))
            {
                e.KeyChar = (char)Keys.Back;
                //e.Handled = true;
                MessageBox.Show("No se permite tecla espacio");
                e.Handled = true;
            }
        }

        private void txtNacimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsSeparator(e.KeyChar))
            {
                e.KeyChar = (char)Keys.Back;
                //e.Handled = true;
                MessageBox.Show("No se permite tecla espacio");
                e.Handled = true;
            }
        }

        private void txtTelefono_Validated(object sender, EventArgs e)
        {
            if (txtTelefono.MaskFull == false) {

                MessageBox.Show("NO PUEDE DEJAR ESTE CAMPO VACIO O INCOMPLETO");
                txtTelefono.Focus();
            }
        }

        private void FrmAgregarCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
}

       
    }
