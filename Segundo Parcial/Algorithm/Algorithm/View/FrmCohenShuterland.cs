using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithm.Controller;

namespace Algorithm.View
{
    public partial class FrmCohenShuterland : Form
    {
        private CCohen cohen = new CCohen();
        private int clickCount = 0;
        public FrmCohenShuterland()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            try
            {
                cohen.ReadData(txtX1, txtY1, txtX2, txtY2);
                cohen.ClipLine();
                picCanvas.Refresh();

                using (Graphics g = picCanvas.CreateGraphics())
                {
                    cohen.PlotShape(g);
                }

            }
            catch
            {
                MessageBox.Show("Error al dibujar la línea. Verifica que todos los campos estén correctamente llenos.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cohen.InitializeData(txtX1, txtY1, txtX2, txtY2, picCanvas);

            txtXmin.Text = txtYmin.Text = txtXmax.Text = txtYmax.Text = "";
            clickCount = 0;
        }

        private void btnSetWindow_Click(object sender, EventArgs e)
        {
            try
            {
                int xmin = int.Parse(txtXmin.Text);
                int ymin = int.Parse(txtYmin.Text);
                int xmax = int.Parse(txtXmax.Text);
                int ymax = int.Parse(txtYmax.Text);

                cohen.SetClippingWindow(xmin, ymin, xmax, ymax);
                picCanvas.Refresh();

                // Dibuja solo la ventana
                using (Graphics g = picCanvas.CreateGraphics())
                {
                    g.DrawRectangle(Pens.Blue, xmin, ymin, xmax - xmin, ymax - ymin);
                }
            }
            catch
            {
                MessageBox.Show("Verifica que los valores de la ventana de recorte sean válidos.");
            }
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (clickCount == 0)
            {
                txtX1.Text = e.X.ToString();
                txtY1.Text = e.Y.ToString();
                txtX2.Text = "";
                txtY2.Text = "";

                // Dibuja punto inicial
                using (Graphics g = picCanvas.CreateGraphics())
                {
                    g.FillRectangle(Brushes.Red, e.X, e.Y, 2, 2);
                }

                clickCount = 1;
            }
            else if (clickCount == 1)
            {
                txtX2.Text = e.X.ToString();
                txtY2.Text = e.Y.ToString();

                // Dibuja punto final
                using (Graphics g = picCanvas.CreateGraphics())
                {
                    g.FillRectangle(Brushes.Red, e.X, e.Y, 2, 2);
                }

                clickCount = 0;
            }
        }


    }
}
