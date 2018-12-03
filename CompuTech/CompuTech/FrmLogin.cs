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
    public partial class FrmLogin : Form
    {
        int error = 0;
        public FrmLogin()
        {
            InitializeComponent();
        }
        public static String user;
        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            user = txtUsuario.Text;
            Llename.user = txtUsuario.Text;
            SqlConnection conectar = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
            conectar.Open();
            SqlCommand loginquery = new SqlCommand("Select log_usuario,log_clave,log_nivel from login where log_usuario = '" + txtUsuario.Text + "' and log_clave =  '" + Seguridad.Encriptar( txtClave.Text) + "'", conectar);
            SqlDataReader ejecuta = loginquery.ExecuteReader();


            if (ejecuta.Read() == true)
            {
                conectar.Close();
                conectar.Open();


                loginquery = new SqlCommand("select log_nivel from login where log_usuario=@log_usuario", conectar);
                loginquery.Parameters.AddWithValue("@log_usuario", txtUsuario.Text);

                string nivel;
                nivel = loginquery.ExecuteScalar().ToString();


                if (nivel == "1")
                {
                    this.Hide();
                    FrmMenuAdmin admin = new FrmMenuAdmin();
                    admin.Show();

                }
                else if (nivel == "2")
                {
                    this.Hide();
                    FrmMenuEmp usu = new FrmMenuEmp();
                    usu.Show();
                }


                this.Hide();
                conectar.Close();
            }

            else
            {
                MessageBox.Show("Datos Incorrectos");
                txtUsuario.Clear();
                txtClave.Clear();
                conectar.Close();

                MessageBox.Show("Error al iniciar Sesion");


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user = txtUsuario.Text;
            Llename.user = txtUsuario.Text;
            SqlConnection conectar = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
            conectar.Open();
            SqlCommand loginquery = new SqlCommand("Select log_usuario,log_clave,log_nivel from login where log_usuario = '" + txtUsuario.Text + "' and log_clave =  '" + Seguridad.Encriptar( txtClave.Text) + "'", conectar);
            SqlDataReader ejecuta = loginquery.ExecuteReader();


            if (ejecuta.Read() == true)
            {
                conectar.Close();
                conectar.Open();



                loginquery = new SqlCommand("select log_nivel from login where log_usuario=@log_usuario", conectar);
                loginquery.Parameters.AddWithValue("@log_usuario", txtUsuario.Text);

                string nivel;
                nivel = loginquery.ExecuteScalar().ToString();


                if (nivel == "1")
                {
                    MessageBox.Show("Se ha loggeado como ADMINISTRADOR");
                    this.Hide();
                    FrmMenuAdmin admin = new FrmMenuAdmin();
                    admin.Show();
                }
                else if (nivel == "2")
                {
                    MessageBox.Show("Se ha loggeado como EMPLEADO");
                    this.Hide();
                    FrmMenuEmp usu = new FrmMenuEmp();
                    usu.Show();
                }


                this.Hide();
                conectar.Close();
            }

            else
            {

                error++;
                MessageBox.Show("Datos Incorrectos" + "\nIntento " + error);
                txtUsuario.Clear();
                txtClave.Clear();

                conectar.Close();
                if (error == 3)
                {
                    button1.Enabled = false;
                    txtUsuario.Enabled = false;
                    txtClave.Enabled = false;

                }




            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtClave.Focus();
            }
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                user = txtUsuario.Text;
                Llename.user = txtUsuario.Text;
                SqlConnection conectar = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
                conectar.Open();
                SqlCommand loginquery = new SqlCommand("Select log_usuario,log_clave,log_nivel from login where log_usuario = '" + txtUsuario.Text + "' and log_clave =  '" + Seguridad.Encriptar( txtClave.Text) + "'", conectar);
                SqlDataReader ejecuta = loginquery.ExecuteReader();


                if (ejecuta.Read() == true)
                {
                    conectar.Close();
                    conectar.Open();



                    loginquery = new SqlCommand("select log_nivel from login where log_usuario=@log_usuario", conectar);
                    loginquery.Parameters.AddWithValue("@log_usuario", txtUsuario.Text);

                    string nivel;
                    nivel = loginquery.ExecuteScalar().ToString();


                    if (nivel == "1")
                    {
                        MessageBox.Show("Se ha loggeado como ADMINISTRADOR");
                        this.Hide();
                        FrmMenuAdmin admin = new FrmMenuAdmin();
                        admin.Show();
                    }
                    else if (nivel == "2")
                    {
                        MessageBox.Show("Se ha loggeado como EMPLEADO");
                        this.Hide();
                        FrmMenuEmp usu = new FrmMenuEmp();
                        usu.Show();
                    }


                    this.Hide();
                    conectar.Close();
                }

                else
                {

                    error++;
                    MessageBox.Show("Datos Incorrectos" + "\nIntento " + error);
                    txtUsuario.Clear();
                    txtClave.Clear();

                    conectar.Close();
                    if (error == 3)
                    {
                        button1.Enabled = false;
                        txtUsuario.Enabled = false;
                        txtClave.Enabled = false;

                    }




                }
            }
        }
    }
}