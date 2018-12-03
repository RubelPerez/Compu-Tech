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
    public partial class FrmConsultaProveedores : Form
    {
        Proveedores proveedores;
        DataTable tablaMia;
        public FrmConsultaProveedores()
        {
            InitializeComponent();
        }

        private void FrmConsultaProveedores_Load(object sender, EventArgs e)
        {

            tablaMia = FiltroProveedores.DameDatos();
            proveedores = new Proveedores();
            proveedores.Tables.Add(tablaMia);
            dataGridView1.DataSource = proveedores.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                proveedores.Tables[0].DefaultView.RowFilter = ("pro_nombre like '" + textBox1.Text + "%' or pro_apellido like '" + textBox1.Text + "%' or pro_empresa like '" + textBox1.Text + "%'");


                dataGridView1.DataSource = proveedores.Tables[0].DefaultView;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Llename.gridprovedor = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            FrmImagenProveedor ima = new FrmImagenProveedor();
            ima.Show();
        }
    }
}
