using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CompuTech
{
    public partial class FrmFactura : Form
    {
        Point formPosition;
        Boolean mouseAction;

        private Button btImprimir;
        private Button btVistaPrevia;
        private PrintDocument DocumentoParaImprimir = new PrintDocument();
        private PrintDialog Impresora = new PrintDialog();
        private PrintPreviewDialog VistaPrevia = new PrintPreviewDialog();
        private Bitmap bmp;
        public FrmFactura()
        {this.btImprimir = new System.Windows.Forms.Button();
        this.btImprimir.Location = new System.Drawing.Point(309, 368);
            this.btImprimir.Size = new System.Drawing.Size(75, 23);
            this.btImprimir.Text = "Imprimir";
            this.btImprimir.Click += new System.EventHandler(this.button1_Click);
            this.Controls.Add(this.btImprimir);
 
            this.btVistaPrevia = new System.Windows.Forms.Button();
            this.btVistaPrevia.Location = new System.Drawing.Point(309, 399);
            this.btVistaPrevia.Size = new System.Drawing.Size(75, 23);
            this.btVistaPrevia.Text = "Vista Previa";
            this.btVistaPrevia.Click += new System.EventHandler(this.button2_Click);
            this.Controls.Add(this.btVistaPrevia);
 
            DocumentoParaImprimir.PrintPage +=
                new PrintPageEventHandler(DocumentoParaImprimir_PrintPage);
        
            InitializeComponent();
        }

        private void FrmFactura_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
                

            
            /**
          * public static string cedulaCliente;        public static string nombreCliente;
        public static string tipodeproducto;
        public static string marca;
        public static string modelo;
        public static string estado;
        public static string fechaIngreso;
        public static string problema;
        public static string servicioArticulo;
        public static string precio;
        public static string impuesto;
        public static string total;
        public static string formadepago;
        public static string pagado;
        public static string deuda;
          *
          * **/
            label1.Text = ClFactura.cedulaCliente;
            label2.Text = ClFactura.nombreCliente;
            label3.Text = ClFactura.tipodeproducto;
            label4.Text = ClFactura.marca;
            label5.Text = ClFactura.modelo;
            label6.Text = ClFactura.estado;
            label7.Text = ClFactura.fechaIngreso;
            label8.Text = ClFactura.problema;
          
           // label10.Text = ClFactura.precio;
            label11.Text = ClFactura.impuesto;
            label12.Text = ClFactura.total;
            label13.Text = ClFactura.formadepago;
            Decimal vaina = Convert.ToDecimal(ClFactura.total) - Convert.ToDecimal(ClFactura.pagado);
            labelasd.Text = vaina.ToString();
            label9.Text = ClFactura.descripcion;
            label14.Text = ClFactura.pagado;
            label15.Text = ClFactura.deuda;
            label19.Text = DateTime.Now.ToLongDateString();
            label20.Text = DateTime.Now.ToLongTimeString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

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

        private void FrmFactura_Click(object sender, EventArgs e)
        {
            btImprimir.Visible = true;
            btVistaPrevia.Visible = true;
        }

        private void FrmFactura_MouseDown(object sender, MouseEventArgs e)
        {
            formPosition = new Point(Cursor.Position.X - Location.X, Cursor.Position.Y - Location.Y);
            mouseAction = true;

        }

        private void FrmFactura_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseAction == true)
            {
                Location = new Point(Cursor.Position.X - formPosition.X, Cursor.Position.Y - formPosition.Y);
            }

        }

        private void FrmFactura_MouseUp(object sender, MouseEventArgs e)
        {
            mouseAction = false;

        }

        private void FrmFactura_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }
    }
        
    }

