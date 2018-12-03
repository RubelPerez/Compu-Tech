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
    public partial class FrmReporteNuevo : Form
    {
        public FrmReporteNuevo()
        {
            InitializeComponent();
        }

        private void FrmReporteNuevo_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DSParametro.articulos' Puede moverla o quitarla según sea necesario.
          //  this.articulosTableAdapter.Filli(this.DSParametro.articulos);
            // TODO: esta línea de código carga datos en la tabla 'DSParametro.articulos' Puede moverla o quitarla según sea necesario.
            //this.articulosTableAdapter.Filli(this.DSParametro.articulos);
            // TODO: esta línea de código carga datos en la tabla 'DSParametro.articulos' Puede moverla o quitarla según sea necesario.
          //  this.articulosTableAdapter.Filli(this.DSParametro.articulos);
            // TODO: esta línea de código carga datos en la tabla 'DSParametro.articulos' Puede moverla o quitarla según sea necesario.
           // this.articulosTableAdapter.Fill(this.DSParametro.articulos);
            // TODO: esta línea de código carga datos en la tabla 'DSParametro.articulos' Puede moverla o quitarla según sea necesario.
         //   this.articulosTableAdapter.Fill(this.DSParametro.articulos);
            // TODO: esta línea de código carga datos en la tabla 'DSnuevo.articulos' Puede moverla o quitarla según sea necesario.
          //  this.articulosTableAdapter.Fill(this.DSnuevo.articulos);

            //this.reportViewer1.RefreshReport();
            //this.reportViewer1.RefreshReport();
           // this.reportViewer1.RefreshReport();
        }
        public void filtramedatos(String a,string b) {
          try {

              this.articulosTableAdapter.Filli(this.DSParametro.articulos,b,a);
                reportViewer1.RefreshReport();
                this.Show();
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }
        
        }
    }
}
