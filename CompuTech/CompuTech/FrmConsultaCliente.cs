using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CompuTech
{
    public partial class FrmConsultaCliente : Form
    {
        Cliente cliente;
        DataTable tablaMia;
        public FrmConsultaCliente()
        {
            InitializeComponent();
        }

        private void FrmConsultaCliente_Load(object sender, EventArgs e)
        {
            tablaMia = FiltroCliente.DameDatos();
            cliente = new Cliente();
            cliente.Tables.Add(tablaMia);
            dataGridView1.DataSource = cliente.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            cliente.Tables[0].DefaultView.RowFilter = ("ct_nombre like '" + textBox1.Text + "%' or ct_documento like '" + textBox1.Text + "%' or ct_telefono like '" + textBox1.Text + "%'");


            dataGridView1.DataSource = cliente.Tables[0].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Llename.gridcliente = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            FrmImagenCliente ima = new FrmImagenCliente();
            ima.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
