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
    public partial class FrmFacturaIguala : Form
    {
        Point formPosition;
        Boolean mouseAction;
        public FrmFacturaIguala()
        {
            InitializeComponent();
        }

        private void FrmFacturaIguala_Load(object sender, EventArgs e)
        {
            label54.Text = DateTime.Now.ToLongDateString().ToString();
            label27.Text = FacturaRedes.nfc;
            label28.Text = FacturaRedes.tipo;
            label29.Text = FacturaRedes.nombre;
            label30.Text = FacturaRedes.enc_documento;
            label31.Text = FacturaRedes.enc_nombre;
            label32.Text = FacturaRedes.enc_apellido;
            label33.Text = FacturaRedes.enc_formadepago;

            //igualas
            label34.Text = FacturaRedes.igua_miempleado;
            label35.Text = FacturaRedes.igua_nombreempleado;
            label36.Text = FacturaRedes.igua_deuda;
            label37.Text = FacturaRedes.igua_tiempodepago;
            label38.Text = FacturaRedes.igua_pagomensual;
            //fin

            //dispositivos
            label39.Text = FacturaRedes.disp_red;
            label40.Text = FacturaRedes.disp_preciored;
            label41.Text = FacturaRedes.disp_switch;
            label42.Text = FacturaRedes.disp_precioswitch;
            label43.Text = FacturaRedes.disp_servidor;
            label44.Text = FacturaRedes.disp_precioservidor;
            label45.Text = FacturaRedes.disp_rocetas;
            label46.Text = FacturaRedes.disp_preciorocetas;
            label47.Text = FacturaRedes.maqui_instalara;
            label48.Text = FacturaRedes.maqui_precioinstalara;
            label49.Text = FacturaRedes.maqui_cableusar;
            label50.Text = FacturaRedes.maqui_distancia;
            label51.Text = FacturaRedes.maqui_preciodistancia;
            label52.Text = FacturaRedes.manodeobra;
        }

        private void FrmFacturaIguala_MouseDown(object sender, MouseEventArgs e)
        {
            formPosition = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
            mouseAction = true;



        }

        private void FrmFacturaIguala_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseAction == true)
            {
                Location = new Point(Cursor.Position.X - formPosition.X, Cursor.Position.Y - formPosition.Y);

            }
        }

        private void FrmFacturaIguala_MouseUp(object sender, MouseEventArgs e)
        {
            mouseAction = false;

        }

        private void FrmFacturaIguala_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label53.Text = DateTime.Now.ToShortTimeString().ToString();
        }


    }
}
