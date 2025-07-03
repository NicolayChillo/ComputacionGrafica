using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm.Controller
{
    internal class CAlgorithmBresLines
    {
        //Atributos
        private Point pointStart;
        private Point pointEnd;
        private List<Point> linePoints;
        private int animateInterval = 25;

        public CAlgorithmBresLines()
        {
            pointStart = new Point(0, 0);
            pointEnd = new Point(0, 0);
            linePoints = new List<Point>();
        }

        public List<Point> GetLinePoints() => linePoints;
        public void ReadData(TextBox txtX1, TextBox txtY1, TextBox txtX2, TextBox txtY2)
        {
            if (string.IsNullOrWhiteSpace(txtX1.Text) ||
                string.IsNullOrWhiteSpace(txtY1.Text) ||
                string.IsNullOrWhiteSpace(txtX2.Text) ||
                string.IsNullOrWhiteSpace(txtY2.Text))
            {
                MessageBox.Show("All coordinate fields must be filled.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int x1 = int.Parse(txtX1.Text);
            int y1 = int.Parse(txtY1.Text);
            int x2 = int.Parse(txtX2.Text);
            int y2 = int.Parse(txtY2.Text);

            if (x1 < 0 || y1 < 0 || x2 < 0 || y2 < 0)
            {
                MessageBox.Show("Coordinates must be non-negative integers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.pointStart = new Point(x1, y1);
            this.pointEnd = new Point(x2, y2);
        }

        public void InitializeData(TextBox txtX1, TextBox txtY1, TextBox txtX2, TextBox txtY2, PictureBox picCanvas)
        {
            txtX1.Text = "";
            txtY1.Text = "";
            txtX2.Text = "";
            txtY2.Text = "";
            picCanvas.Refresh();

            pointStart = new Point(0, 0);
            pointEnd = new Point(0, 0);
            linePoints = new List<Point>();
        }

        //Funcion para calcular los puntos de la línea con el algoritmo Bresenham
        private void CalculateLine()
        {
            linePoints.Clear();

            int x1 = pointStart.X;
            int y1 = pointStart.Y;
            int x2 = pointEnd.X;
            int y2 = pointEnd.Y;

            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            int sx = x1 < x2 ? 1 : -1;
            int sy = y1 < y2 ? 1 : -1;
            int err = dx - dy;

            while (true)
            {
                linePoints.Add(new Point(x1, y1));

                if (x1 == x2 && y1 == y2)
                    break;

                int e2 = 2 * err;
                if (e2 > -dy)
                {
                    err -= dy;
                    x1 += sx;
                }

                if (e2 < dx)
                {
                    err += dx;
                    y1 += sy;
                }
            }
        }

        //Función para dibujar la línea y los puntos calculados
        public void PlotShape(Graphics g)
        {
            CalculateLine();

            foreach (var pt in linePoints)
            {
                g.FillRectangle(Brushes.Blue, pt.X, pt.Y, 1, 1);
            }
        }
    }
}
