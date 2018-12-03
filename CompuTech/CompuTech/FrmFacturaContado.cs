using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
namespace CompuTech
{
    public partial class FrmFacturaContado : Form
    {
        private Button btImprimir;
        private Button btVistaPrevia;
        private PrintDocument DocumentoParaImprimir = new PrintDocument();
        private PrintDialog Impresora = new PrintDialog();
        private PrintPreviewDialog VistaPrevia = new PrintPreviewDialog();
        private Bitmap bmp;
        Point formPosition;
        Boolean mouseAction;
        public FrmFacturaContado()
        {
            this.btImprimir = new System.Windows.Forms.Button();
            this.btImprimir.Location = new System.Drawing.Point(349, 559);
            this.btImprimir.Size = new System.Drawing.Size(75, 23);
            this.btImprimir.Text = "Imprimir";
            this.btImprimir.Click += new System.EventHandler(this.button1_Click);
            this.Controls.Add(this.btImprimir);

            this.btVistaPrevia = new System.Windows.Forms.Button();
            this.btVistaPrevia.Location = new System.Drawing.Point(448, 559);
            this.btVistaPrevia.Size = new System.Drawing.Size(75, 23);
            this.btVistaPrevia.Text = "Vista Previa";
            this.btVistaPrevia.Click += new System.EventHandler(this.button2_Click);
            this.Controls.Add(this.btVistaPrevia);

            DocumentoParaImprimir.PrintPage +=
                new PrintPageEventHandler(DocumentoParaImprimir_PrintPage);
            InitializeComponent();
        }

        private void FrmFacturaContado_MouseDown(object sender, MouseEventArgs e)
        {
            formPosition = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
            mouseAction = true;

       

        }

        private void FrmFacturaContado_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseAction == true)
            {
                Location = new Point(Cursor.Position.X - formPosition.X, Cursor.Position.Y - formPosition.Y);
            }

        }

        private void FrmFacturaContado_MouseUp(object sender, MouseEventArgs e)
        {
            mouseAction = false;

        }

        private void FrmFacturaContado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void FrmFacturaContado_Load(object sender, EventArgs e)
        {
            label54.Text = DateTime.Now.ToLongDateString().ToString();
            label27.Text = FacturaRedes.nfc;
            label28.Text = FacturaRedes.tipo;
            label29.Text = FacturaRedes.nombre;
            label30.Text = FacturaRedes.enc_documento;
            label31.Text = FacturaRedes.enc_nombre;
            label32.Text = FacturaRedes.enc_apellido;
            label33.Text = FacturaRedes.enc_formadepago;

            //contado
            label34.Text = FacturaRedes.cont_documento;
            label35.Text = FacturaRedes.cont_deuda;
            label36.Text = FacturaRedes.cont_pagocon;
            label37.Text = FacturaRedes.cont_devuelta;
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
        void DocumentoParaImprimir_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);
        }
        private void CapturaFormulario()
        {
            btImprimir.Visible = false;
            btVistaPrevia.Visible = false;
            Graphics mygraphics = this.CreateGraphics();
            Size sz = this.ClientRectangle.Size;
            bmp = new Bitmap(sz.Width, sz.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(bmp);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, this.ClientRectangle.Width,
                   this.ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);

            //bmp.Save("prueba.bmp", ImageFormat.Bmp);
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest,
            int nXDest,
            int nYDest,
            int nWidth,
            int nHeight,
            IntPtr hdcSrc,
            int nXSrc,
            int nYSrc,
            int dwRop);

        private void button1_Click(object sender, EventArgs e)
        {

            CapturaFormulario();

            Impresora.Document = DocumentoParaImprimir;
            DialogResult Result = Impresora.ShowDialog();

            if (Result == DialogResult.OK)
            {
                DocumentoParaImprimir.DefaultPageSettings.Landscape = false;
                DocumentoParaImprimir.Print();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CapturaFormulario();

            VistaPrevia.Document = DocumentoParaImprimir;
            VistaPrevia.ShowDialog();

        }

        private void FrmFacturaContado_MouseClick(object sender, MouseEventArgs e)
        {
            btImprimir.Visible = true;
            btVistaPrevia.Visible = true;
        }
    }
}
