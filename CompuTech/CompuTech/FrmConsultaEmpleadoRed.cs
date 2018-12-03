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
    public partial class FrmConsultaEmpleadoRed : Form
    {
        Empleados empleados;
        DataTable tablaMia;
        public FrmConsultaEmpleadoRed()
        {
            InitializeComponent();
        }

        private void FrmConsultaClienteRed_Load(object sender, EventArgs e)
        {
            tablaMia = FiltroEmpleados.DameDatos();
            empleados = new Empleados();
            empleados.Tables.Add(tablaMia);
            dataGridView1.DataSource = empleados.Tables[0];
        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            empleados.Tables[0].DefaultView.RowFilter = ("emp_nombre like '" + textBox1.Text + "%' or emp_apellido like '" + textBox1.Text + "%' or emp_cargo like '" + textBox1.Text + "%'");


            dataGridView1.DataSource = empleados.Tables[0].DefaultView;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try{FrmRedes Form = new FrmRedes();
            Llename.redcedula = Convert.ToString(this.dataGridView1.CurrentRow.Cells[2].Value);
            Llename.rednombre= Convert.ToString(this.dataGridView1.CurrentRow.Cells[3].Value) + " " + Convert.ToString(this.dataGridView1.CurrentRow.Cells[4].Value);
            FrmMantenimientoRed man = new FrmMantenimientoRed();
            Llename.mantcedula = Convert.ToString(this.dataGridView1.CurrentRow.Cells[2].Value);
            Llename.mantnombre= Convert.ToString(this.dataGridView1.CurrentRow.Cells[3].Value) + " " + Convert.ToString(this.dataGridView1.CurrentRow.Cells[4].Value);
            
                this.Hide(); 

            }
            catch(Exception ex){}
            
        }

        private void FrmConsultaEmpleadoRed_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
