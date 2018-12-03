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
    public partial class FrmConsultaEmpleados : Form
    {
        Empleados empleados;
        DataTable tablaMia;
        public FrmConsultaEmpleados()
        {
            InitializeComponent();
        }

        private void FrmConsultaEmpleados_Load(object sender, EventArgs e)
        {

            tablaMia = FiltroEmpleados.DameDatos();
            empleados = new Empleados();
            empleados.Tables.Add(tablaMia);
            dataGridView1.DataSource = empleados.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            empleados.Tables[0].DefaultView.RowFilter = ("emp_nombre like '" + textBox1.Text + "%' or emp_apellido like '" + textBox1.Text + "%' or emp_cargo like '" + textBox1.Text + "%'");


            dataGridView1.DataSource = empleados.Tables[0].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Llename.gridempleado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            FrmImagenEmpleado ima = new FrmImagenEmpleado();
            ima.Show();
        }
    }
}
