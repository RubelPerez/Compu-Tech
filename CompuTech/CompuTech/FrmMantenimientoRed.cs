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
    public partial class FrmMantenimientoRed : Form
    {
        public FrmMantenimientoRed()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
                txtProblema.ReadOnly = false;
            button2.Enabled = true;
            button3.Enabled = false;
            limpiar(); try
            {
                SqlConnection connection = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");

                SqlCommand loginquery = new SqlCommand("select fac_nombre from facturaredes where fac_nfc='" + txtNCF.Text + "'", connection);
                SqlCommand loginquery2 = new SqlCommand("select fac_cedpago from facturaredes where fac_nfc='" + txtNCF.Text + "'", connection);
                SqlCommand loginquery3 = new SqlCommand("select fac_nombrepaga from facturaredes where fac_nfc='" + txtNCF.Text + "'", connection);
                SqlCommand loginquery4 = new SqlCommand("select fac_apellidopaga from facturaredes where fac_nfc='" + txtNCF.Text + "'", connection);
                connection.Open();
                string nombrecompleto = loginquery3.ExecuteScalar().ToString() + " " + loginquery4.ExecuteScalar().ToString();


                String y;


                int yo;
                txtNombreEmp.Text = loginquery.ExecuteScalar().ToString();
                txtDocumentoCargo.Text = loginquery2.ExecuteScalar().ToString();
                txtPersonaCargo.Text = nombrecompleto;

                connection.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }


        }

        private void txtEmpleado_MouseClick(object sender, MouseEventArgs e)
        {
            txtEmpleado.Text = Llename.mantnombre;
        }

        private void txtCedulaEmp_MouseClick(object sender, MouseEventArgs e)
        {
            txtCedulaEmp.Text = Llename.mantcedula;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmConsultaEmpleadoRed red = new FrmConsultaEmpleadoRed();
            red.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlConnection connection = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
                SqlCommand comando = new SqlCommand("insert into mantredes values ('" + txtNCF.Text + "','" + txtNombreEmp.Text + "','" + txtPersonaCargo.Text + "','" + txtDocumentoCargo.Text + "','" + txtProblema.Text + "','" + txtEmpleado.Text + "','" + txtCedulaEmp.Text + "','" + cbSolucionado.SelectedItem.ToString() + "')", connection);

                connection.Open();
                comando.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("exito");
                limpiar();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void limpiar() {
           // txtNCF.Clear();
            txtNombreEmp.Clear();
            txtPersonaCargo.Clear();
            txtDocumentoCargo.Clear();
            txtProblema.Clear();
            txtEmpleado.Clear();
            txtCedulaEmp.Clear();
            cbSolucionado.SelectedIndex = -1;
        }
        int modi=0;
        private void button3_Click(object sender, EventArgs e)
        {
           
                try
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
                    SqlCommand comando = new SqlCommand("update mantredes set mant_solucionado='" + cbSolucionado.SelectedItem.ToString() + "' where mant_NFC='" + txtNCF.Text +"' AND mant_problema='"+txtProblema.Text+"'",connection);

                    connection.Open();
                    comando.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("exito");

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        

        private void button5_Click(object sender, EventArgs e)
        {
            limpiar();
            button2.Enabled = false;
            button3.Enabled = true;
            modi = 1;
            txtProblema.ReadOnly = true;
            button1.Enabled = false;
            try
            {
                
                SqlConnection connection = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");

                SqlCommand loginquery2 = new SqlCommand("select mant_nombreemp from mantredes where mant_nfc='" + txtNCF.Text + "' order by mant_id desc", connection);
                SqlCommand loginquery3 = new SqlCommand("select mant_personacargo from mantredes where mant_nfc='" + txtNCF.Text + "' order by mant_id desc", connection);
                SqlCommand loginquery4 = new SqlCommand("select mant_documento from mantredes where mant_nfc='" + txtNCF.Text + "' order by mant_id desc", connection);
                SqlCommand loginquery5 = new SqlCommand("select mant_problema from mantredes where mant_nfc='" + txtNCF.Text + "' order by mant_id desc", connection);
                SqlCommand loginquery6 = new SqlCommand("select mant_empleadosol from mantredes where mant_nfc='" + txtNCF.Text + "' order by mant_id desc", connection);
                SqlCommand loginquery7 = new SqlCommand("select mant_cedulaempleadosol from mantredes where mant_nfc='" + txtNCF.Text + "' order by mant_id desc", connection);
                SqlCommand loginquery8 = new SqlCommand("select mant_solucionado from mantredes where mant_nfc='" + txtNCF.Text + "' order by mant_id desc", connection);

                connection.Open(); 
                txtNombreEmp.Text = loginquery2.ExecuteScalar().ToString();
                txtPersonaCargo.Text = loginquery3.ExecuteScalar().ToString();
                txtDocumentoCargo.Text = loginquery4.ExecuteScalar().ToString();
                txtProblema.Text = loginquery5.ExecuteScalar().ToString();
                txtEmpleado.Text = loginquery6.ExecuteScalar().ToString();
                txtCedulaEmp.Text = loginquery7.ExecuteScalar().ToString();
                cbSolucionado.SelectedItem = loginquery8.ExecuteScalar().ToString();

                connection.Close();
               
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Llename.nfc = txtNCF.Text;
            Llename.nfcnombre = txtNombreEmp.Text;
            FrmFiltroEmpresa filtro = new FrmFiltroEmpresa();
            filtro.Show();
        }
    }
}
