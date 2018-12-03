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
    public partial class FrmFiltroEmpresa : Form
    {
        Empresa empleados;
        DataTable tablaMia;
        public FrmFiltroEmpresa()
        {
            InitializeComponent();
        }

        private void FrmFiltroEmpresa_Load(object sender, EventArgs e)
        {
            label2.Text = Llename.nfc;
            label3.Text = Llename.nfcnombre;
            tablaMia = FiltroRedes.DameDatos();
            empleados = new Empresa();
            empleados.Tables.Add(tablaMia);
            dataGridViewX1.DataSource = empleados.Tables[0];
            try
            {
                empleados.Tables[0].DefaultView.RowFilter = ("mant_NFC like '" + label2.Text +"'");


                dataGridViewX1.DataSource = empleados.Tables[0].DefaultView;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
