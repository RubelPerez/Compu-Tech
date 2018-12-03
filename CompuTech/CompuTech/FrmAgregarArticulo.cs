using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CompuTech
{
    public partial class FrmAgregarArticulo : Form
    {
        string nivel = "";
        string pagado;
        string deuda;
        int presion = 0;
        public FrmAgregarArticulo()
        {

            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnBuscarImagen_Click(object sender, EventArgs e)
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
            try
            {
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();


                cmd.Connection = conn;

                cmd.CommandText = "INSERT INTO articulos VALUES (@art_cedula,@art_cliente,@art_nombre,@art_marca,@art_modelo, @art_descripcion, @art_categoria, @art_estado,@art_fechaingreso,@art_problema,@art_formapago,@art_precio,@art_pagado,@art_deuda,@art_foto)";

                cmd.Parameters.Add("@art_cedula", System.Data.SqlDbType.VarChar);
                cmd.Parameters.Add("@art_cliente", System.Data.SqlDbType.VarChar);

                cmd.Parameters.Add("@art_nombre", System.Data.SqlDbType.VarChar);
                cmd.Parameters.Add("@art_marca", System.Data.SqlDbType.VarChar);
                cmd.Parameters.Add("@art_modelo", System.Data.SqlDbType.VarChar);
                cmd.Parameters.Add("@art_descripcion", System.Data.SqlDbType.VarChar);
                cmd.Parameters.Add("@art_categoria", System.Data.SqlDbType.VarChar);
                cmd.Parameters.Add("@art_estado", System.Data.SqlDbType.VarChar);

                cmd.Parameters.Add("@art_fechaingreso", System.Data.SqlDbType.VarChar);
                cmd.Parameters.Add("@art_problema", System.Data.SqlDbType.VarChar);
                cmd.Parameters.Add("@art_formapago", System.Data.SqlDbType.VarChar);
                cmd.Parameters.Add("@art_precio", System.Data.SqlDbType.Int);
                cmd.Parameters.Add("@art_pagado", System.Data.SqlDbType.Int);
                cmd.Parameters.Add("@art_deuda", System.Data.SqlDbType.Int);
                cmd.Parameters.Add("@art_foto", System.Data.SqlDbType.Image);

                String tipo = cbEstado.SelectedItem.ToString();
                String categoria = cb_categoria.SelectedItem.ToString();
                String marca = cbMarca.SelectedValue.ToString();
                String modelo = cbModelo.SelectedValue.ToString();
                String producto = cbProducto.SelectedValue.ToString();

                cmd.Parameters["@art_cedula"].Value = txtDocumentoCliente.Text;
                cmd.Parameters["@art_cliente"].Value = txtNombreCliente.Text;

                cmd.Parameters["@art_nombre"].Value = producto;
                cmd.Parameters["@art_marca"].Value = marca;
                cmd.Parameters["@art_modelo"].Value = modelo;
                cmd.Parameters["@art_descripcion"].Value = txtDescripcion.Text;
                cmd.Parameters["@art_categoria"].Value = categoria;
                cmd.Parameters["@art_estado"].Value = tipo;

                cmd.Parameters["@art_fechaingreso"].Value = txtFechaIngreso.Text;
                cmd.Parameters["@art_problema"].Value = txtProblema.Text;
                cmd.Parameters["@art_formapago"].Value = cbForma.SelectedItem.ToString(); ;
                cmd.Parameters["@art_precio"].Value = Convert.ToInt32(txtTotalData.Text);
                cmd.Parameters["@art_pagado"].Value = Convert.ToInt32(txtPagado.Text);
                cmd.Parameters["@art_deuda"].Value = Convert.ToInt32(txtDeuda.Text);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                foto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                cmd.Parameters["@art_foto"].Value = ms.GetBuffer();

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Agregado Correctamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void FrmAgregarArticulo_Load(object sender, EventArgs e)
        {
            label24.Visible = false;
            label25.Visible = false;
            txtPagar.Visible = false;
            txtDevuelta.Visible = false;
            txtDescuento.Enabled = false;
            txtTotalData.ReadOnly = true;
            llenacomboServicio();
            llenacomboboalmacen();
            llenarModelo();
            llenaMarca();
            llenarProducto();
            txtDocumentoCliente.AutoCompleteCustomSource = AutoCompletArticulos.Autocomplete();
            txtDocumentoCliente.AutoCompleteMode = AutoCompleteMode.Append;
            txtDocumentoCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;



            foto.ImageLocation = @"C:\Users\Joanna\Desktop\articulos\articulos-gif.gif";
            txtFechaIngreso.Text = DateTime.Now.ToShortDateString().ToString();
            txtDocumentoCliente.Focus();
        }
        public void Limpiar()
        {
            cbMarca.SelectedIndex = -1;
            cbModelo.SelectedIndex = -1;
            cbEstado.SelectedIndex = -1;
            cbProducto.SelectedIndex = -1;
            txtDescripcion.Text = "";
            cb_categoria.SelectedIndex = -1;

            cbEstado.SelectedIndex = -1;


            foto.Image = null;

            txtFoto.Text = "";


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarImagen_Click_1(object sender, EventArgs e)
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

        private void txtDocumentoCliente_Validated(object sender, EventArgs e)
        {
            try
            {
                // Creando objetos de datos.
                System.Data.DataSet ds = new System.Data.DataSet();
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM cliente WHERE ct_documento = @ct_documento", @"Data Source=DANIEL-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True");

                // Añadiendo el parámetro
                da.SelectCommand.Parameters.Add("@ct_documento", System.Data.SqlDbType.VarChar);
                // Estableciendo el valor del parámetro
                da.SelectCommand.Parameters["@ct_documento"].Value = txtDocumentoCliente.Text;                 // Se recuperan los datos
                da.Fill(ds, "cliente");

                // Se verifica la existencia del registro
                if (ds.Tables["cliente"].Rows.Count != 0)
                {
                    // Se establecen los valores en el formulario
                    txtNombreCliente.Text = ds.Tables["cliente"].Rows[0]["ct_nombre"].ToString();

                }
            }
            catch (Exception ex)
            {
            }
        }
        public void llenaMarca()
        {
            //se declara una variable de tipo SqlConnection
            SqlConnection conexion = new SqlConnection();
            //se indica la cadena de conexion
            conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
            //código para llenar el comboBox
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter("SELECT marca from combox  WHERE marca IS not NULL", conexion);
            //se indica el nombre de la tabla
            da.Fill(ds, "combox");
            cbMarca.DataSource = ds.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            cbMarca.ValueMember = "marca";

        }
        public void llenarModelo()
        {
            //se declara una variable de tipo SqlConnection
            SqlConnection conexion = new SqlConnection();
            //se indica la cadena de conexion
            conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
            //código para llenar el comboBox
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter("SELECT modelo from combox  WHERE modelo IS not NULL", conexion);
            //se indica el nombre de la tabla
            da.Fill(ds, "combox");
            cbModelo.DataSource = ds.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            cbModelo.ValueMember = "modelo";
        }
        public void llenarProducto()
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
            cbProducto.DataSource = ds.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            cbProducto.ValueMember = "producto";
        }
        private void cbMarca_MouseClick(object sender, MouseEventArgs e)
        {
            llenaMarca();
        }

        private void cbModelo_MouseClick(object sender, MouseEventArgs e)
        {
            llenarModelo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMarca mar = new FrmMarca();
            mar.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FrmModelo mol = new FrmModelo();
            mol.Show();
        }

        private void cbProducto_MouseClick(object sender, MouseEventArgs e)
        {
            llenarProducto();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmProducto pro = new FrmProducto();
            pro.Show();
        }

        private void txtDocumentoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNombreCliente.Focus();

            }
        }

        private void txtNombreCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbProducto.Focus();

            }
        }

        private void cbProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbMarca.Focus();

            }

        }

        private void cbMarca_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                cbModelo.Focus();

            }
        }

        private void cbModelo_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                txtDescripcion.Focus();

            }
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                cb_categoria.Focus();

            }
        }

        private void cb_categoria_MouseDown(object sender, MouseEventArgs e)
        {


        }

        private void cb_categoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbEstado.Focus();

            }
        }

        private void cbEstado_KeyDown(object sender, KeyEventArgs e)
        {
            txtFoto.Focus();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                // Creando objetos de datos.
                System.Data.DataSet ds = new System.Data.DataSet();
                System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM articulos WHERE art_cedula = @art_cedula", @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");

                // Añadiendo el parámetro
                da.SelectCommand.Parameters.Add("@art_cedula", System.Data.SqlDbType.VarChar);
                // Estableciendo el valor del parámetro
                da.SelectCommand.Parameters["@art_cedula"].Value = txtDocumentoCliente.Text;                 // Se recuperan los datos
                da.Fill(ds, "articulos");

                // Se verifica la existencia del registro
                if (ds.Tables["articulos"].Rows.Count != 0)
                {
                    // Se establecen los valores en el formulario
                    txtDocumentoCliente.Text = ds.Tables["articulos"].Rows[0]["art_cedula"].ToString();
                    txtNombreCliente.Text = ds.Tables["articulos"].Rows[0]["art_cliente"].ToString();
                    cbProducto.Text = ds.Tables["articulos"].Rows[0]["art_nombre"].ToString();
                    cbMarca.Text = ds.Tables["articulos"].Rows[0]["art_marca"].ToString();
                    cbModelo.Text = ds.Tables["articulos"].Rows[0]["art_modelo"].ToString();
                    txtDescripcion.Text = ds.Tables["articulos"].Rows[0]["art_descripcion"].ToString();
                    cb_categoria.Text = ds.Tables["articulos"].Rows[0]["art_categoria"].ToString();
                    cbEstado.Text = ds.Tables["articulos"].Rows[0]["art_estado"].ToString();

                    txtFechaIngreso.Text = ds.Tables["articulos"].Rows[0]["art_fechaingreso"].ToString();
                    txtProblema.Text = ds.Tables["articulos"].Rows[0]["art_problema"].ToString();
                    cbForma.Text = ds.Tables["articulos"].Rows[0]["art_formapago"].ToString();
                    txtTotalData.Text = ds.Tables["articulos"].Rows[0]["art_precio"].ToString();

                    txtPagado.Text = ds.Tables["articulos"].Rows[0]["art_pagado"].ToString();
                    txtDeuda.Text = ds.Tables["articulos"].Rows[0]["art_deuda"].ToString();

                    //la imagen

                    SqlConnection conetame4 = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
                    SqlCommand comando4 = new SqlCommand("select art_foto from articulos where art_cedula=@art_cedula", conetame4);
                    SqlDataAdapter adap4 = new SqlDataAdapter(comando4);
                    adap4.SelectCommand.Parameters.Add("@art_cedula", System.Data.SqlDbType.VarChar);
                    // Estableciendo el valor del parámetro
                    adap4.SelectCommand.Parameters["@art_cedula"].Value = txtDocumentoCliente.Text;


                    DataSet ds4 = new DataSet("articulos");
                    byte[] imagen4 = new byte[0];
                    adap4.Fill(ds4, "articulos");
                    DataRow DR4 = ds4.Tables["articulos"].Rows[0];
                    imagen4 = (byte[])DR4["art_foto"];
                    MemoryStream ms4 = new MemoryStream(imagen4);

                    foto.Image = Image.FromStream(ms4);

                    //cedula cliente
                    //la imagen

                    SqlConnection conetame5 = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
                    SqlCommand comando5 = new SqlCommand("select ct_foto from cliente where ct_documento=@ct_documento", conetame5);
                    SqlDataAdapter adap5 = new SqlDataAdapter(comando5);
                    adap5.SelectCommand.Parameters.Add("@ct_documento", System.Data.SqlDbType.VarChar);
                    // Estableciendo el valor del parámetro
                    adap5.SelectCommand.Parameters["@ct_documento"].Value = txtDocumentoCliente.Text;


                    DataSet ds5 = new DataSet("cliente");
                    byte[] imagen5 = new byte[0];
                    adap5.Fill(ds5, "cliente");
                    DataRow DR5 = ds5.Tables["cliente"].Rows[0];
                    imagen5 = (byte[])DR5["ct_foto"];
                    MemoryStream ms5 = new MemoryStream(imagen5);

                    pbCedula.Image = Image.FromStream(ms5);

                }
                else {  DialogResult respuende = MessageBox.Show("NO EXISTE NUMERO DE CEDULA, DESEA CREARLO?", "ADVERTENCIA", MessageBoxButtons.OKCancel);
                if (respuende == DialogResult.OK) { this.Hide();
                FrmAgregarCliente agrega = new FrmAgregarCliente();

                agrega.Show();
                }
                else if (respuende == DialogResult.Cancel) { 
                    
                    
                    txtDocumentoCliente.Clear(); txtDocumentoCliente.Focus(); }
                }
                    
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string producto = cbProducto.SelectedValue.ToString();
                string marca = cbMarca.SelectedValue.ToString();
                string modelo = cbModelo.SelectedValue.ToString();
                string estado = cbEstado.SelectedItem.ToString();
                string categoria = cb_categoria.SelectedItem.ToString();

                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
                SqlCommand comando = new SqlCommand("update articulos set art_cedula='" + txtDocumentoCliente.Text + "',art_cliente='" + txtNombreCliente.Text + "',art_nombre='" + producto + "',art_marca='" + marca + "',art_modelo='" + modelo + "',art_descripcion='" + txtDescripcion.Text + "',art_categoria='" + categoria + "',art_estado='" + estado + "',art_fechaingreso='" + txtFechaIngreso.Text + "',art_problema='"+txtProblema.Text+"',art_formapago='"+cbForma.SelectedItem.ToString()+"',art_precio='"+txtTotalData.Text+"',art_pagado='"+txtPagado.Text+"',art_deuda='"+txtDeuda.Text+"' where art_cedula='"+txtDocumentoCliente.Text+"'", conn);
                conn.Open();
                comando.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Modificacion Exitosa");

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
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
        public void llenacomboboalmacen()
        {
            //se declara una variable de tipo SqlConnection
            SqlConnection conexion = new SqlConnection();
            //se indica la cadena de conexion
            conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
            //código para llenar el comboBox
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter("SELECT alm_nombre from almacen  WHERE alm_nombre IS not NULL", conexion);

            //se indica el nombre de la tabla
            da.Fill(ds, "almacen");
            cb_articulo.DataSource = ds.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            cb_articulo.ValueMember = "alm_nombre";


        
       
           

        }
        private void cb_articulo_MouseClick(object sender, MouseEventArgs e)
        {
            llenacomboboalmacen();
        }

        private void cb_articulo_Click(object sender, EventArgs e)
        {
            llenacomboboalmacen();
        }

        private void cb_articulo_Validated(object sender, EventArgs e)
        {

           


        }

        private void button7_Click(object sender, EventArgs e)
        {
           
            sumame();
            

        }

        private void rbContado_Validated(object sender, EventArgs e)
        {
        }

        private void rbCredito_Validated(object sender, EventArgs e)
        {



        }

        private void rbAbono_Validated(object sender, EventArgs e)
        {

        }

        private void txtPAbono_Validated(object sender, EventArgs e)
        {





        }

        private void cbForma_Validated(object sender, EventArgs e)
        {
            if (cbForma.SelectedItem.ToString() == "CREDITO")
            {
                label24.Visible = false;
                label25.Visible = false;
                txtPagar.Visible = false;
                txtDevuelta.Visible = false;
                txtPagado.Text = "0";
                txtDeuda.Text = txtTotalData.Text;
                txtPagado.ReadOnly = false;
                txtDeuda.ReadOnly = false;
                label17.Visible = true;
                label16.Visible = true;
                txtNombregarante.Visible = true;
                txtCedulaGarante.Visible = true;
                label23.Visible = false;
                checkBox1.Visible = false;
                txtDescuento.Visible = false;


            }
            else if (cbForma.SelectedItem.ToString() == "CONTADO")
            {
                txtDescuento.Enabled = false;
                label24.Visible = true;
                label25.Visible = true;
                txtPagar.Visible = true;
                txtDevuelta.Visible = true;
                txtNombregarante.Visible = false;
                txtCedulaGarante.Visible = false;
                txtPagado.Text = txtTotalData.Text;
                txtDeuda.Text = "0";
                txtPagado.ReadOnly = false;
                txtDeuda.ReadOnly = false;
                checkBox1.Visible = true;
                label23.Visible = true;
                label17.Visible = false;
                label16.Visible = false;
                txtDescuento.Visible = true;
            }
            else if (cbForma.SelectedItem.ToString() == "ABONANDO")
            {
                label24.Visible = false;
                label25.Visible = false;
                txtPagar.Visible = false;
                txtDevuelta.Visible = false;
                label23.Visible = false;
                txtDeuda.ReadOnly = true;
                txtPagado.Enabled = true;
                checkBox1.Visible = false;
                txtDescuento.Visible = false;
                label17.Visible = false;
                label16.Visible = false;
                txtNombregarante.Visible = false;
                txtCedulaGarante.Visible = false;
            }

        }

        private void txtPagado_Validated(object sender, EventArgs e)
        {
            try
            {
                int resuelve = Convert.ToInt32(txtTotalData.Text) - Convert.ToInt32(txtPagado.Text);
                txtDeuda.Text = resuelve.ToString();
            }
            catch (Exception ex)
            {
                
                button7.Focus();

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
        public void llenacomboServicio()
        {
            //se declara una variable de tipo SqlConnection
            SqlConnection conexion = new SqlConnection();
            //se indica la cadena de conexion
            conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
            //código para llenar el comboBox
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter("SELECT serv_nombre from servicio  WHERE serv_nombre IS not NULL", conexion);

            //se indica el nombre de la tabla
            da.Fill(ds, "servicio");
            cbServicio.DataSource = ds.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            cbServicio.ValueMember = "serv_nombre";


        
        

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                ClFactura.cedulaCliente = txtDocumentoCliente.Text;
                ClFactura.nombreCliente = txtNombreCliente.Text;
                ClFactura.tipodeproducto = cbProducto.SelectedValue.ToString();
                ClFactura.marca = cbMarca.SelectedValue.ToString();
                ClFactura.modelo = cbModelo.SelectedValue.ToString();
                ClFactura.estado = cbEstado.SelectedItem.ToString();
                ClFactura.fechaIngreso = txtFechaIngreso.Text;
                ClFactura.problema = txtProblema.Text;
                 ClFactura.precio = txtTotalData.Text;
                ClFactura.impuesto = txtImpuesto.Text;
                ClFactura.total = txtTotalData.Text;
                ClFactura.formadepago = cbForma.SelectedItem.ToString();
                ClFactura.pagado = txtPagado.Text;
                ClFactura.deuda = txtDeuda.Text;
                ClFactura.descripcion = txtDescripcion.Text;
                FrmFactura f = new FrmFactura();
                DataGridViewRow row = new DataGridViewRow();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    row = dataGridView1.Rows[i];


                    string a, b,c;
                    a = row.Cells["Column1"].Value.ToString();
                    b = row.Cells["NOMBRE"].Value.ToString();
                    c = row.Cells["IMPUESTO"].Value.ToString();
                    f.dataGridView1.Rows.Add(a, b,c);
                    //        //int id = Convert.ToInt16(row.Cells[1].Value);
                    //        //dataGridView1.Rows.Add();



                }

                f.ShowDialog();

                
            }
            catch (Exception ex) { MessageBox.Show("HAY CAMPOS OBLIGATORIOS VACIO"); }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }
        string imp2;
        private void button9_Click(object sender, EventArgs e)
        {


            try
            {
                SqlConnection connection = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");

                SqlCommand loginquery = new SqlCommand("select alm_precio from almacen where alm_nombre='" + cb_articulo.SelectedValue.ToString() + "'", connection);
                SqlCommand loginquery2 = new SqlCommand("select alm_obra from almacen where alm_nombre='" + cb_articulo.SelectedValue.ToString() + "'", connection);
               
                connection.Open();
                String y;


                int yo;
                nivel = loginquery.ExecuteScalar().ToString();
                imp2 = loginquery2.ExecuteScalar().ToString();

                this.dataGridView1.Rows.Add(cb_articulo.SelectedValue.ToString(), nivel,imp2);



                connection.Close();
                
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }
        String imp;
        private void button10_Click_1(object sender, EventArgs e)
        {

            try
            {
                SqlConnection connection = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");

                SqlCommand loginquery = new SqlCommand("select serv_precio from servicio where serv_nombre='" + cbServicio.SelectedValue.ToString() + "'", connection);
                SqlCommand loginquery2 = new SqlCommand("select serv_obra from servicio where serv_nombre='" + cbServicio.SelectedValue.ToString() + "'", connection);
                
                connection.Open();
                String y;


                int yo;
                nivel = loginquery.ExecuteScalar().ToString();
                imp = loginquery2.ExecuteScalar().ToString();

                this.dataGridView1.Rows.Add(cbServicio.SelectedValue.ToString(), nivel,imp);
                

                connection.Close();
               
            }
            catch (SqlException ex) { MessageBox.Show(ex.Message); }

        }
        int suma = 0;
        /// <summary>
        /// metodo que suma datagridview
        /// </summary>
        public void sumame()
        {
            try
            {
                int result = dataGridView1.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToInt32(x.Cells["Column1"].Value));
                txtSubTotal.Text = result.ToString();
                int otro = dataGridView1.Rows.Cast<DataGridViewRow>().Sum(x => Convert.ToInt32(x.Cells["IMPUESTO"].Value));
                txtImpuesto.Text = otro.ToString();
                suma = result + otro;
                txtTotalData.Text = suma.ToString();
            }
            catch (Exception ex) { }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
               
            
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            sumame();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            FrmFactura f = new FrmFactura();
            DataGridViewRow row = new DataGridViewRow();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                row = dataGridView1.Rows[i];
               

                    string a, b;
                    a = row.Cells["Column1"].Value.ToString();
                    b = row.Cells["NOMBRE"].Value.ToString();

                    f.dataGridView1.Rows.Add(a, b);
                    //        //int id = Convert.ToInt16(row.Cells[1].Value);
                    //        //dataGridView1.Rows.Add();
                    this.Hide();

                





            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) {
                txtDescuento.Enabled = true;
            
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            try
            {
                Decimal descuento = Convert.ToDecimal(txtDescuento.Text) / 100;
                Decimal aplicar = Convert.ToDecimal(txtPagado.Text) * descuento;
                Decimal total = Convert.ToDecimal(txtPagado.Text) - aplicar;
                txtPagado.Text = total.ToString();
            }
            catch (Exception ex) { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmCompra c = new FrmCompra();
            c.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmServicio s = new FrmServicio();
            s.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cbServicio_MouseClick(object sender, MouseEventArgs e)
        {
            llenacomboServicio();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        Decimal pagado2=0;
        Decimal otro;
        private void txtPagar_Validated(object sender, EventArgs e)
        {
            try
            {

                otro = Convert.ToDecimal(txtPagar.Text) - Convert.ToDecimal(txtPagado.Text);
                txtDevuelta.Text = otro.ToString();
            }
            catch (Exception ex) { }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
}}

