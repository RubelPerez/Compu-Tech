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
    public partial class FrmMenuEmp : Form
    {
        public FrmMenuEmp()
        {
            InitializeComponent();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarCliente agrega = new FrmAgregarCliente();
            agrega.Show();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaCliente cliente = new FrmConsultaCliente();
            cliente.Show();
        }

        private void mantenimientoImpresorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaProveedores prove = new FrmConsultaProveedores();
            prove.Show();
        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAgregarArticulo art = new FrmAgregarArticulo();
            art.Show();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaArticulos a = new FrmConsultaArticulos();
            a.Show();
        }

        private void FrmMenuEmp_Load(object sender, EventArgs e)
        {
            label3.Text = Llename.user;
            label2.Text = DateTime.Now.ToLongDateString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        private void mERCANCIASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmParametro para = new FrmParametro();
            para.Show();
        }

        private void dESLOGUEARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin log = new FrmLogin();
            log.Show();
            this.Hide();
        }
    }
}
