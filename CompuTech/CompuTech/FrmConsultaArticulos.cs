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
    public partial class FrmConsultaArticulos : Form
    {
        int IDValor;
        Articulos articulos;
        DataTable tablaMia;
        public FrmConsultaArticulos()
        {
            InitializeComponent();
        }

        private void FrmConsultaArticulos_Load(object sender, EventArgs e)
        {
           
            tablaMia = Filtro.DameDatos();
            articulos = new Articulos();
            articulos.Tables.Add(tablaMia);
            dataGridView1.DataSource = articulos.Tables[0];
         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            articulos.Tables[0].DefaultView.RowFilter = ("art_nombre like '" + textBox1.Text + "%' or art_descripcion like '" + textBox1.Text + "%' or art_estado like '" + textBox1.Text + "%' or art_cliente like '" + textBox1.Text + "%'or art_cedula like '" + textBox1.Text + "%'");
          
            
            dataGridView1.DataSource = articulos.Tables[0].DefaultView;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Llename.grid= Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            FrmImagen ima = new FrmImagen();
            ima.Show();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
