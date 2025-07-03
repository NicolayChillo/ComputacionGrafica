using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm.Controller
{
    internal class CAlgorithmBresElipse
    {
        // Atributos
        private int rx, ry;
        private List<Point> pointsEllipse;
        private Point center;

        public CAlgorithmBresElipse()
        {
            rx = ry = 0;
            center = new Point(0, 0);
            pointsEllipse = new List<Point>();
        }

        public List<Point> GetEllipsePoints() => pointsEllipse;

        public void ReadData(TextBox txtRx, TextBox txtRy, PictureBox picCanvas)
        {
            if (string.IsNullOrWhiteSpace(txtRx.Text) || string.IsNullOrWhiteSpace(txtRy.Text))
            {
                MessageBox.Show("Debe ingresar ambos radios (Rx y Ry).", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtRx.Text, out rx) || rx <= 0 || !int.TryParse(txtRy.Text, out ry) || ry <= 0)
            {
                MessageBox.Show("Los radios deben ser números positivos.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            center = new Point(picCanvas.Width / 2, picCanvas.Height / 2);
        }

        public void InitializeData(TextBox txtRx, TextBox txtRy, PictureBox picCanvas)
        {
            txtRx.Text = "";
            txtRy.Text = "";
            picCanvas.Refresh();

            rx = ry = 0;
            center = new Point(0, 0);
            pointsEllipse = new List<Point>();
        }

        private void CalculateEllipse()
        {
            pointsEllipse.Clear();

            int x = 0;
            int y = ry;

            double rx2 = rx * rx;
            double ry2 = ry * ry;
            double dx = 2 * ry2 * x;
            double dy = 2 * rx2 * y;

            // Región 1
            double p1 = ry2 - (rx2 * ry) + (0.25 * rx2);
            while (dx < dy)
            {
                AddSymmetricPoints(center.X, center.Y, x, y);
                if (p1 < 0)
                {
                    x++;
                    dx = 2 * ry2 * x;
                    p1 += dx + ry2;
                }
                else
                {
                    x++;
                    y--;
                    dx = 2 * ry2 * x;
                    dy = 2 * rx2 * y;
                    p1 += dx - dy + ry2;
                }
            }

            // Región 2
            double p2 = ry2 * Math.Pow(x + 0.5, 2) + rx2 * Math.Pow(y - 1, 2) - rx2 * ry2;
            while (y >= 0)
            {
                AddSymmetricPoints(center.X, center.Y, x, y);
                if (p2 > 0)
                {
                    y--;
                    dy = 2 * rx2 * y;
                    p2 += rx2 - dy;
                }
                else
                {
                    y--;
                    x++;
                    dx = 2 * ry2 * x;
                    dy = 2 * rx2 * y;
                    p2 += dx - dy + rx2;
                }
            }
        }

        private void AddSymmetricPoints(int cx, int cy, int x, int y)
        {
            pointsEllipse.Add(new Point(cx + x, cy + y));
            pointsEllipse.Add(new Point(cx - x, cy + y));
            pointsEllipse.Add(new Point(cx + x, cy - y));
            pointsEllipse.Add(new Point(cx - x, cy - y));
        }

        public void PlotShape(Graphics g)
        {
            CalculateEllipse();

            foreach (var pt in pointsEllipse)
            {
                g.FillRectangle(Brushes.Blue, pt.X, pt.Y, 1, 1);
            }
        }
    }
}