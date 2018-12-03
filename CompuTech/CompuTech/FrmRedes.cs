using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CompuTech
{
    public partial class FrmRedes : Form
    {
        public FrmRedes()
        {
            InitializeComponent();
        }

        private void FrmRedes_Load(object sender, EventArgs e)
        {

            llenacomboREd();
            llenaComboCable();
            llenaComboServidor();
            llenaComboSwitch();
            llenacomboRoceta();
            llenatipo();
        }
        public void llenatipo()
        {
            //se declara una variable de tipo SqlConnection
            SqlConnection conexion = new SqlConnection();
            //se indica la cadena de conexion
            conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
            //código para llenar el comboBox
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter("SELECT tipo from combox  WHERE tipo IS not NULL", conexion);

            //se indica el nombre de la tabla
            da.Fill(ds, "combox");
            comboBox2.DataSource = ds.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox2.ValueMember = "tipo";






        }
        public void llenacomboRoceta()
        {
            //se declara una variable de tipo SqlConnection
            SqlConnection conexion = new SqlConnection();
            //se indica la cadena de conexion
            conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
            //código para llenar el comboBox
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter("SELECT nombre_rocetas from red  WHERE nombre_rocetas IS not NULL", conexion);

            //se indica el nombre de la tabla
            da.Fill(ds, "red");
            cbRoceta.DataSource = ds.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            cbRoceta.ValueMember = "nombre_rocetas";


        }
        public void llenaComboSwitch()
        {
            //se declara una variable de tipo SqlConnection
            SqlConnection conexion = new SqlConnection();
            //se indica la cadena de conexion
            conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
            //código para llenar el comboBox
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter("SELECT nombre_switch from red  WHERE nombre_switch IS not NULL", conexion);

            //se indica el nombre de la tabla
            da.Fill(ds, "red");
            cbSwitch.DataSource = ds.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            cbSwitch.ValueMember = "nombre_switch";


        }
        public void llenacomboREd()
        {
            //se declara una variable de tipo SqlConnection
            SqlConnection conexion = new SqlConnection();
            //se indica la cadena de conexion
            conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
            //código para llenar el comboBox
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter("SELECT nombre_tarjetared from red  WHERE nombre_tarjetared IS not NULL", conexion);

            //se indica el nombre de la tabla
            da.Fill(ds, "red");
            cbModelo.DataSource = ds.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            cbModelo.ValueMember = "nombre_tarjetared";


        }
        public void llenaComboCable()
        {
            //se declara una variable de tipo SqlConnection
            SqlConnection conexion = new SqlConnection();
            //se indica la cadena de conexion
            conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
            //código para llenar el comboBox
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter("SELECT cable_maquina from red  WHERE cable_maquina IS not NULL", conexion);

            //se indica el nombre de la tabla
            da.Fill(ds, "red");
            comboBox1.DataSource = ds.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            comboBox1.ValueMember = "cable_maquina";


        }
        public void llenaComboServidor()
        {
            //se declara una variable de tipo SqlConnection
            SqlConnection conexion = new SqlConnection();
            //se indica la cadena de conexion
            conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
            //código para llenar el comboBox
            DataSet ds = new DataSet();
            //indicamos la consulta en SQL
            SqlDataAdapter da = new SqlDataAdapter("SELECT nombre_servidor from red  WHERE nombre_servidor IS not NULL", conexion);

            //se indica el nombre de la tabla
            da.Fill(ds, "red");
            cbServidor.DataSource = ds.Tables[0].DefaultView;
            //se especifica el campo de la tabla
            cbServidor.ValueMember = "nombre_servidor";


        }
        int valor;
        private void integerInput1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();

                conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
                SqlCommand loginquery = new SqlCommand("select precio_tarjetared from red where nombre_tarjetared='" + cbModelo.SelectedValue.ToString() + "'", conexion);
                conexion.Open();


                valor = Convert.ToInt32(loginquery.ExecuteScalar().ToString()) * Convert.ToInt32(integerInput1.Value.ToString()); ;
                labelX5.Text = valor.ToString() + ".00";
                conexion.Close();
                try
                {
                    todo = Convert.ToDecimal(labelX5.Text) + Convert.ToDecimal(labelX28.Text) + Convert.ToDecimal(labelX30.Text) + Convert.ToDecimal(labelX32.Text);
                    labelX26.Text = todo.ToString();
                }
                catch (Exception ex) { }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmTarjeta t = new FrmTarjeta();
            t.Show();
        }
        int valor2;
        Decimal todo;
        Decimal todito;
        private void integerInput2_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();

                conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
                SqlCommand loginquery = new SqlCommand("select precio_maquina from red where redes_id='" + 1 + "'", conexion);
                conexion.Open();


                valor2 = Convert.ToInt32(loginquery.ExecuteScalar().ToString()) * Convert.ToInt32(integerInput2.Value.ToString()); ;
                labelX11.Text = valor2.ToString() + ".00";
                conexion.Close();
                try
                {
                    todito = Convert.ToDecimal(labelX11.Text) + Convert.ToDecimal(labelX14.Text);
                    labelX16.Text = todito.ToString();
                }
                catch (Exception ex) { }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void cbModelo_MouseClick(object sender, MouseEventArgs e)
        {
            llenacomboREd();
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            llenaComboCable();
        }
        int valor3;
        private void integerInput3_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();

                conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
                SqlCommand loginquery = new SqlCommand("select cable_precio from red where cable_maquina='" + comboBox1.SelectedValue.ToString() + "'", conexion);
                conexion.Open();


                valor3 = Convert.ToInt32(loginquery.ExecuteScalar().ToString()) * Convert.ToInt32(integerInput3.Value.ToString()); ;
                labelX14.Text = valor3.ToString() + ".00";
                conexion.Close();
                try
                {
                    todito = Convert.ToDecimal(labelX11.Text) + Convert.ToDecimal(labelX14.Text);
                    labelX16.Text = todito.ToString();
                }
                catch (Exception ex) { }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmCable cab = new FrmCable();
            cab.Show();
        }
        int valor4;
        private void integerInput4_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();

                conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
                SqlCommand loginquery = new SqlCommand("select precio_servidor from red where nombre_servidor='" + cbServidor.SelectedValue.ToString() + "'", conexion);
                conexion.Open();


                valor4 = Convert.ToInt32(loginquery.ExecuteScalar().ToString()) * Convert.ToInt32(integerInput4.Value.ToString()); ;
                labelX28.Text = valor4.ToString() + ".00";
                conexion.Close();
                try
                {
                    todo = Convert.ToDecimal(labelX5.Text) + Convert.ToDecimal(labelX28.Text) + Convert.ToDecimal(labelX30.Text) + Convert.ToDecimal(labelX32.Text);
                    labelX26.Text = todo.ToString();
                }
                catch (Exception ex) { }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        int valor5;
        private void integerInput5_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();

                conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
                SqlCommand loginquery = new SqlCommand("select precio_switch from red where nombre_switch='" + cbSwitch.SelectedValue.ToString() + "'", conexion);
                conexion.Open();


                valor5 = Convert.ToInt32(loginquery.ExecuteScalar().ToString()) * Convert.ToInt32(integerInput5.Value.ToString()); ;
                labelX30.Text = valor5.ToString() + ".00";
                conexion.Close();
                //5,28,30,32
                try
                {
                    todo = Convert.ToDecimal(labelX5.Text) + Convert.ToDecimal(labelX28.Text) + Convert.ToDecimal(labelX30.Text) + Convert.ToDecimal(labelX32.Text);
                    labelX26.Text = todo.ToString();
                }
                catch (Exception ex) { }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        //rocetas
        int valor6;
        private void integerInput6_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexion = new SqlConnection();

                conexion.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
                SqlCommand loginquery = new SqlCommand("select precio_rocetas from red where nombre_rocetas='" + cbRoceta.SelectedValue.ToString() + "'", conexion);
                conexion.Open();


                valor6 = Convert.ToInt32(loginquery.ExecuteScalar().ToString()) * Convert.ToInt32(integerInput6.Value.ToString()); ;
                labelX32.Text = valor6.ToString() + ".00";
                conexion.Close();
                try
                {
                    todo = Convert.ToDecimal(labelX5.Text) + Convert.ToDecimal(labelX28.Text) + Convert.ToDecimal(labelX30.Text) + Convert.ToDecimal(labelX32.Text);
                    labelX26.Text = todo.ToString();
                }
                catch (Exception ex) { }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void cbServidor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panelEx2_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox2_Validated(object sender, EventArgs e)
        {
            try
            {
                txtDeuda.Text = (Convert.ToDecimal(labelX26.Text) + Convert.ToDecimal(labelX16.Text) + Convert.ToDecimal(labelX47.Text)).ToString();
            }
            catch (Exception ex) { }
        }

        private void panelEx5_Click(object sender, EventArgs e)
        {

        }
        Decimal eso;

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {/**12 MESES
24 MESES
36 MESES**/
            try
            {
                if (cbTiempoPago.SelectedItem.ToString() == "12 MESES")
                {
                    eso = Convert.ToDecimal(txtDeuda.Text) / 12;
                    txtMensualidad.Text = eso.ToString(".##");
                }
                else if (cbTiempoPago.SelectedItem.ToString() == "24 MESES")
                {
                    eso = Convert.ToDecimal(txtDeuda.Text) / 24;
                    txtMensualidad.Text = eso.ToString(".##");
                }
                else if (cbTiempoPago.SelectedItem.ToString() == "36 MESES")
                {
                    eso = Convert.ToDecimal(txtDeuda.Text) / 36;
                    txtMensualidad.Text = eso.ToString(".##");
                }
            }
            catch (Exception ex) { }
        }

        private void txtManoObra_Validated(object sender, EventArgs e)
        {
            labelX47.Text = txtManoObra.Text;
        }

        private void txtDeuda_MouseClick(object sender, MouseEventArgs e)
        {

            try
            {
                txtDeuda.Text = (Convert.ToDecimal(labelX26.Text) + Convert.ToDecimal(labelX16.Text) + Convert.ToDecimal(labelX47.Text)).ToString();
            }
            catch (Exception ex) { }
        }
        public void verIguala()
        {
            button8.Visible = true;
            labelX24.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            txtDocumento.Visible = true;
            txtDeuda.Visible = true;
            txtMensualidad.Visible = true;
            labelX44.Visible = true;
            labelX43.Visible = true;
            labelX46.Visible = true;
            groupBox5.Visible = true;
            cbTiempoPago.Visible = true;
            labelX42.Visible = true;
            txtNombreEmp.Visible = true;
            labelX53.Visible = true;
            labelX42.Text = "DOCUMENTO EMPLEADO";
        }
        public void noverIguala()
        {
            button8.Visible = false;
            labelX42.Visible = false;
            cbTiempoPago.Visible = false;
            labelX24.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            txtDocumento.Visible = false;
            txtDeuda.Visible = false;
            txtMensualidad.Visible = false;
            labelX44.Visible = false;
            labelX43.Visible = false;
            labelX46.Visible = false;
            txtNombreEmp.Visible = false;
            labelX53.Visible = false;

        }
        public void verContado()
        {
            labelX42.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            txtDocumento.Visible = true;
            txtDeuda.Visible = true;
            labelX48.Visible = true;
            labelX49.Visible = true;
            txtPago.Visible = true;
            txtMenudo.Visible = true;
            labelX44.Visible = true;
            labelX42.Text = "DOCUMENTO CLIENTE";

        }
        public void noverContado()
        {
            labelX42.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            txtDocumento.Visible = false;
            txtDeuda.Visible = false;
            labelX48.Visible = false;
            labelX49.Visible = false;
            txtPago.Visible = false;
            txtMenudo.Visible = false;
            labelX44.Visible = false;
        }


        public void verCredito()
        {
            labelX50.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            txtDocumento.Visible = true;
            labelX51.Visible = true;
            radioButton5.Visible = true;
            radioButton6.Visible = true;
            labelX52.Visible = true;
            dateTimePicker1.Visible = true;
            txtDocumentoGarante.Visible = true;
            labelX44.Visible = true;
            txtDeuda.Visible = true;

        }
        public void noverCredito()
        {
            txtDocumentoGarante.Visible = false;
            labelX50.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            txtDocumento.Visible = false;
            labelX51.Visible = false;
            radioButton5.Visible = false;
            radioButton6.Visible = false;
            labelX52.Visible = false;
            dateTimePicker1.Visible = false;

        }
        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            /**CONTADO
CREDITO
IGUALA**/
            if (comboBox3.SelectedItem.ToString() == "IGUALA")
            {
                groupBox5.Text = "IGUALA";
                noverContado();
                noverCredito();
                verIguala();

            }
            else if (comboBox3.SelectedItem.ToString() == "CREDITO")
            {
                groupBox5.Text = "CREDITO";
                groupBox5.Visible = true;

                noverIguala();
                noverContado();
                verCredito();
            }
            else if (comboBox3.SelectedItem.ToString() == "CONTADO")
            {
                groupBox5.Text = "CONTADO";
                groupBox5.Visible = true;
                noverIguala();
                noverCredito();
                verContado();
            }
        }
        int pasa = 0;
        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (pasa != 1)
            {
                MessageBox.Show("No puede generar factura sin opciones de pago");
                buttonX1.Focus();
            }
            else
            {
                try
                {
                    SqlConnection conectame = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
                    SqlCommand comando = new SqlCommand("insert into facturaredes values ('" + textBox2.Text + "','" + comboBox2.SelectedValue.ToString() + "','" + textBox1.Text + "','" + EncargoPagame.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox3.SelectedItem.ToString() + "','" + txtDocumento.Text + "','" + txtDocumentoGarante.Text + "','" + txtPago.Text + "','" + txtMenudo.Text + "','" + txtMensualidad.Text + "','" + txtDeuda.Text + "','" + cbModelo.SelectedValue.ToString() + "','" + cbSwitch.SelectedValue.ToString() + "','" + cbServidor.SelectedValue.ToString() + "','" + cbRoceta.SelectedValue.ToString() + "','" + integerInput2.Value.ToString() + "','" + comboBox1.SelectedValue.ToString() + "','" + integerInput3.Value.ToString() + "','" + txtManoObra.Text + "','" + dateTimePicker1.Value.ToString() + "')", conectame);
                    conectame.Open();
                    comando.ExecuteNonQuery();
                    conectame.Close();
                    MessageBox.Show("EXITO");

                    if (comboBox3.SelectedItem.ToString() == "IGUALA")
                    {
                        try
                        {//24 variables
                            FacturaRedes.nfc = textBox2.Text;
                            FacturaRedes.tipo = comboBox2.SelectedValue.ToString();
                            FacturaRedes.nombre = textBox1.Text;
                            FacturaRedes.enc_documento = EncargoPagame.Text;
                            FacturaRedes.enc_nombre = textBox3.Text;
                            FacturaRedes.enc_apellido = textBox4.Text;
                            FacturaRedes.enc_formadepago = comboBox3.SelectedItem.ToString();
                            //IGUALA
                            FacturaRedes.igua_miempleado = txtDocumento.Text;
                            FacturaRedes.igua_nombreempleado = txtNombreEmp.Text;
                            FacturaRedes.igua_deuda = txtDeuda.Text;
                            FacturaRedes.igua_tiempodepago = cbTiempoPago.SelectedItem.ToString();
                            FacturaRedes.igua_pagomensual = txtMensualidad.Text;

                            //dispositivos de red
                            FacturaRedes.disp_red = cbModelo.SelectedValue.ToString();
                            FacturaRedes.disp_preciored = labelX5.Text;

                            //switch
                            FacturaRedes.disp_switch = cbSwitch.SelectedValue.ToString();
                            FacturaRedes.disp_precioswitch = labelX30.Text;
                            //servidor
                            FacturaRedes.disp_servidor = cbServidor.SelectedValue.ToString();
                            FacturaRedes.disp_precioservidor = labelX28.Text;
                            //rocetas
                            FacturaRedes.disp_rocetas = cbRoceta.SelectedValue.ToString();
                            FacturaRedes.disp_preciorocetas = labelX32.Text;

                            //maquinas y cables
                            FacturaRedes.maqui_instalara = integerInput2.Value.ToString();
                            FacturaRedes.maqui_precioinstalara = labelX11.Text;
                            FacturaRedes.maqui_cableusar = comboBox1.SelectedValue.ToString();
                            FacturaRedes.maqui_distancia = integerInput3.Value.ToString();
                            FacturaRedes.maqui_preciodistancia = labelX14.Text;
                            //mano de obra
                            FacturaRedes.manodeobra = txtManoObra.Text;

                            FacturaIguala iguala = new FacturaIguala();
                            iguala.Show();



                        }
                        catch (Exception ex) { MessageBox.Show("Error palomoto"); }
                    }
                    else if (comboBox3.SelectedItem.ToString() == "CREDITO")
                    {
                        try
                        {
                            FacturaRedes.nfc = textBox2.Text;
                            FacturaRedes.tipo = comboBox2.SelectedValue.ToString();
                            FacturaRedes.nombre = textBox1.Text;
                            FacturaRedes.enc_documento = EncargoPagame.Text;
                            FacturaRedes.enc_nombre = textBox3.Text;
                            FacturaRedes.enc_apellido = textBox4.Text;
                            FacturaRedes.enc_formadepago = comboBox3.SelectedItem.ToString();

                            //credito
                            FacturaRedes.cre_documentopersonal = txtDocumento.Text;
                            FacturaRedes.cre_documentogarante = txtDocumentoGarante.Text;
                            FacturaRedes.cre_deuda = txtDeuda.Text;
                            FacturaRedes.cre_pagaraen = dateTimePicker1.Value.ToString();


                            //dispositivos de red
                            FacturaRedes.disp_red = cbModelo.SelectedValue.ToString();
                            FacturaRedes.disp_preciored = labelX5.Text;

                            //switch
                            FacturaRedes.disp_switch = cbSwitch.SelectedValue.ToString();
                            FacturaRedes.disp_precioswitch = labelX30.Text;
                            //servidor
                            FacturaRedes.disp_servidor = cbServidor.SelectedValue.ToString();
                            FacturaRedes.disp_precioservidor = labelX28.Text;
                            //rocetas
                            FacturaRedes.disp_rocetas = cbRoceta.SelectedValue.ToString();
                            FacturaRedes.disp_preciorocetas = labelX32.Text;

                            //maquinas y cables
                            FacturaRedes.maqui_instalara = integerInput2.Value.ToString();
                            FacturaRedes.maqui_precioinstalara = labelX11.Text;
                            FacturaRedes.maqui_cableusar = comboBox1.SelectedValue.ToString();
                            FacturaRedes.maqui_distancia = integerInput3.Value.ToString();
                            FacturaRedes.maqui_preciodistancia = labelX14.Text;
                            //mano de obra
                            FacturaRedes.manodeobra = txtManoObra.Text;
                            FrmFacturaCredito credi = new FrmFacturaCredito();
                            credi.Show();
                        }
                        catch (Exception ex) { MessageBox.Show("errol"); }
                    }
                    else if (comboBox3.SelectedItem.ToString() == "CONTADO")
                    {
                        FacturaRedes.nfc = textBox2.Text;
                        FacturaRedes.tipo = comboBox2.SelectedValue.ToString();
                        FacturaRedes.nombre = textBox1.Text;
                        FacturaRedes.enc_documento = EncargoPagame.Text;
                        FacturaRedes.enc_nombre = textBox3.Text;
                        FacturaRedes.enc_apellido = textBox4.Text;
                        FacturaRedes.enc_formadepago = comboBox3.SelectedItem.ToString();

                        //CONTADO
                        FacturaRedes.cont_documento = txtDocumento.Text;
                        FacturaRedes.cont_deuda = txtDeuda.Text;
                        FacturaRedes.cont_pagocon = txtPago.Text;
                        FacturaRedes.cont_devuelta = txtMenudo.Text;

                        //dispositivos de red
                        FacturaRedes.disp_red = cbModelo.SelectedValue.ToString();
                        FacturaRedes.disp_preciored = labelX5.Text;

                        //switch
                        FacturaRedes.disp_switch = cbSwitch.SelectedValue.ToString();
                        FacturaRedes.disp_precioswitch = labelX30.Text;
                        //servidor
                        FacturaRedes.disp_servidor = cbServidor.SelectedValue.ToString();
                        FacturaRedes.disp_precioservidor = labelX28.Text;
                        //rocetas
                        FacturaRedes.disp_rocetas = cbRoceta.SelectedValue.ToString();
                        FacturaRedes.disp_preciorocetas = labelX32.Text;
                        //maquinas y cables
                        FacturaRedes.maqui_instalara = integerInput2.Value.ToString();
                        FacturaRedes.maqui_precioinstalara = labelX11.Text;
                        FacturaRedes.maqui_cableusar = comboBox1.SelectedValue.ToString();
                        FacturaRedes.maqui_distancia = integerInput3.Value.ToString();
                        FacturaRedes.maqui_preciodistancia = labelX14.Text;
                        //mano de obra
                        FacturaRedes.manodeobra = txtManoObra.Text;
                        FrmFacturaContado contado = new FrmFacturaContado();
                        contado.Show();
                    }

                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }


            }
        }

        private void txtMenudo_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                txtMenudo.Text = (Convert.ToDecimal(txtPago.Text) - Convert.ToDecimal(txtDeuda.Text)).ToString();
            }
            catch (Exception ex) { }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                txtDocumento.ReadOnly = false;
                txtDocumento.Mask = "000-0000000-0";
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                txtDocumento.ReadOnly = false;
                txtDocumento.Mask = ">?>?>?0000000";
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                txtDocumentoGarante.ReadOnly = false;
                txtDocumentoGarante.Mask = "000-0000000-0";
            }

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                txtDocumentoGarante.ReadOnly = false;
                txtDocumentoGarante.Mask = ">?>?>?0000000";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                EncargoPagame.ReadOnly = false;
                EncargoPagame.Mask = "000-0000000-0";
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                EncargoPagame.ReadOnly = false;
                EncargoPagame.Mask = ">?>?>?0000000";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmServidor s = new FrmServidor();
            s.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmSwitch sw = new FrmSwitch();
            sw.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmRocetas r = new FrmRocetas();
            r.Show();
        }

        private void cbSwitch_MouseClick(object sender, MouseEventArgs e)
        {
            llenaComboSwitch();
        }

        private void cbRoceta_MouseClick(object sender, MouseEventArgs e)
        {
            llenacomboRoceta();
        }

        private void cbServidor_MouseClick(object sender, MouseEventArgs e)
        {
            llenaComboServidor();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog BuscarImagen = new OpenFileDialog(); BuscarImagen.Filter = "Archivos de Imagen|*.jpg";
            //Aquí incluiremos los filtros que queramos.
            BuscarImagen.FileName = "";
            BuscarImagen.Title = "IMAGEN CLIENTE";
            BuscarImagen.InitialDirectory = @"C:\Users\Public\Pictures\Imagenes Proyecto"; BuscarImagen.FileName = this.textBox5.Text;
            if (BuscarImagen.ShowDialog() == DialogResult.OK)
            {

                this.textBox5.Text = BuscarImagen.FileName; String Direccion = BuscarImagen.FileName; this.pictureBox1.ImageLocation = Direccion;

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            pasa = 1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FrmConsultaEmpleadoRed red = new FrmConsultaEmpleadoRed();
            red.Show();
        }

        private void FrmRedes_Click(object sender, EventArgs e)
        {

        }

        private void FrmRedes_MouseClick(object sender, MouseEventArgs e)
        {
            txtDocumento.Mask = "????????????";
            txtNombreEmp.Text = Llename.redcedula;
        }

        private void txtDocumento_MouseClick(object sender, MouseEventArgs e)
        {
            txtDocumento.Text = Llename.redcedula;
        }

        private void txtNombreEmp_MouseClick(object sender, MouseEventArgs e)
        {
            txtNombreEmp.Text = Llename.rednombre;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            sololetras(sender, e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            sololetras(sender, e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            sololetras(sender, e);
        }

        private void txtManoObra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                }
        }
        public void sololetras(object sender, KeyPressEventArgs e)
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

        private void textBox2_Validated(object sender, EventArgs e)
        {
            try
            {
                string sql = @"SELECT COUNT(*) FROM facturaredes WHERE fac_nfc = @ct_documento";


                SqlConnection conn = Filtro.DameConexion();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ct_documento", textBox2.Text);


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

                    DialogResult respuende = MessageBox.Show("YA EXISTE NUMERO DE CEDULA, DESEA ENVIARLO A MANTENIMIENTO?", "ADVERTENCIA", MessageBoxButtons.OKCancel);
                    if (respuende == DialogResult.OK) { FrmMantenimientoRed red = new FrmMantenimientoRed(); red.Show();this.Hide(); }
                    else { textBox2.Clear(); }

                }

            }
            catch (Exception ex) { }
    }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelEx6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

