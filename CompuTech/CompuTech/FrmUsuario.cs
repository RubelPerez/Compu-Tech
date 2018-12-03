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
    public partial class FrmUsuario : Form
    {
        int nivel;
        Usuarios user;
        DataTable tablaMia;
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            txtMclave.UseSystemPasswordChar = true;
            tablaMia = FiltroUsuario.DameDatos();
            user = new Usuarios();
            user.Tables.Add(tablaMia);
            dataGridView1.DataSource = user.Tables[0];
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            user.Tables[0].DefaultView.RowFilter = ("log_usuario like '" + textBox1.Text + "%' or log_nivel like '" + textBox1.Text + "%'");


            dataGridView1.DataSource = user.Tables[0].DefaultView;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //Aqui se pone lo que queremos que se vea en los textbox 
            txtUsuario.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells[1].Value);
            txtClave.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells[2].Value);
            txtNivel.Text = Convert.ToString(this.dataGridView1.CurrentRow.Cells[3].Value);
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (cbNivel.SelectedItem.ToString() == "ADMINISTRADOR")
                {
                    nivel = 1;
                }
                else { nivel = 2; }
                System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
                SqlCommand comando = new SqlCommand("update login set log_usuario='" + txtMusuario.Text + "',log_clave='" +Seguridad.Encriptar( txtMclave.Text) + "',log_nivel='" + nivel+ "'where log_usuario='"+txtUsuario.Text+"'", conn);
                conn.Open();
                comando.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Modificacion Exitosa");
            }
            catch(Exception ex){
                MessageBox.Show("Error al procesar la solicitud");
            
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar(sender,e);
        }
        private void validar(object sender, KeyPressEventArgs e)
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

        private void txtMusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
                if (cbNivel.SelectedItem.ToString() == "ADMINISTRADOR")
                {
                    nivel = 1;
                }
                else { nivel = 2; }
                SqlConnection conectame = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");
                
                SqlCommand comando = new SqlCommand("insert into login(log_usuario,log_clave,log_nivel) values ('"+txtMusuario.Text+"','"+Seguridad.Encriptar(txtMclave.Text)+"','"+nivel.ToString()+"')",conectame);
                conectame.Open();
                comando.ExecuteNonQuery();
                conectame.Close();
                MessageBox.Show("Agregado Exitoso");
            }


            catch (SqlException ex) { MessageBox.Show(ex.Message); }
        }

        private void txtUsuario_Validated(object sender, EventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) {
                txtMclave.UseSystemPasswordChar = false; 
            }
            else if (checkBox1.Checked == false) { txtMclave.UseSystemPasswordChar = true; }
        }
    }
}
