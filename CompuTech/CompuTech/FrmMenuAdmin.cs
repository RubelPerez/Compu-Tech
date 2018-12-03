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
    public partial class FrmMenuAdmin : Form
    {
        public FrmMenuAdmin()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {

        }

        private void agregarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAgregarCliente agrega = new FrmAgregarCliente();
            agrega.Show();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarProveedor prove = new FrmAgregarProveedor();
            prove.Show();
        }

        private void sALIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin log = new FrmLogin();
            log.Show();
        }

        private void metroTileItem1_Click(object sender, EventArgs e)
        {
            FrmAgregarProveedor pro = new FrmAgregarProveedor();
            pro.Show();
        }

        private void agregarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmAgregarEmpleado fae = new FrmAgregarEmpleado();
            fae.Show();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            FrmAgregarArticulo art = new FrmAgregarArticulo();
            art.Show();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModificarProveedor modi = new FrmModificarProveedor();
            modi.Show();
        }

        private void sALIRToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void aRTICULOSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aGREGARToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmAgregarArticulo ag = new FrmAgregarArticulo();
            ag.Show();
        }

        private void cONSULTARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaArticulos fm = new FrmConsultaArticulos();
            fm.Show();
        }

        private void pROVEEDORESToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void verToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmConsultaProveedores pro = new FrmConsultaProveedores();
            pro.Show();
        }

        private void verToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmConsultaCliente cliente = new FrmConsultaCliente();
            cliente.Show();
        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultaEmpleados emp = new FrmConsultaEmpleados();
            emp.Show();
        }

        private void nuevosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmParametro para = new FrmParametro();
            para.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        private void FrmMenuAdmin_Load(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToLongDateString();
            label3.Text = Llename.user;
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void eMPLEADOSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void uSUARIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario user = new FrmUsuario();
            user.Show();
        }

        private void rEDESToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aGREGARToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FrmRedes red = new FrmRedes();
            red.Show();
        }

        private void dARMANTENIMIENTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMantenimientoRed mr = new FrmMantenimientoRed();
            mr.Show();
        }
    }
}
