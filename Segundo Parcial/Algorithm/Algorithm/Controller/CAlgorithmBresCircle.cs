using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm.Controller
{
    internal class CAlgorithmBresCircle
    {
        //Atributos
        private int radius;
        private List<Point> pointsCircle;
        private Point center;

        public CAlgorithmBresCircle()
        {
            radius = 0;
            center = new Point(0, 0);
            pointsCircle = new List<Point>();
        }

        public List<Point> GetCirclePoints() => pointsCircle;

        public void ReadData(TextBox txtRadius, PictureBox picCanvas)
        {
            if (string.IsNullOrWhiteSpace(txtRadius.Text))
            {
                MessageBox.Show("El radio debe llenarse.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtRadius.Text, out radius) || radius <= 0)
            {
                MessageBox.Show("El radio no debe ser negativo", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            center = new Point(picCanvas.Width / 2, picCanvas.Height / 2);
        }

        public void InitializeData(TextBox txtRadius, PictureBox picCanvas)
        {
            txtRadius.Text = "";
            picCanvas.Refresh();

            radius = 0;
            center = new Point(0, 0);
            pointsCircle = new List<Point>();
        }

        //Función para calcular los puntos del círculo con simetría de 8 octantes
        private void CalculateCircle()
        {
            pointsCircle.Clear();

            int x = 0;
            int y = radius;
            int d = 3 - 2 * radius;

            while (x <= y)
            {
                AddSymmetricPoints(center.X, center.Y, x, y);
                if (d < 0)
                {
                    d += 2 * x + 3;
                }
                else
                {
                    d += 2 * (x - y) + 5;
                    y--;
                }
                x++;
            }
        }

        //Función para agregar los 8 puntos simétricos del círculo
        private void AddSymmetricPoints(int cx, int cy, int x, int y)
        {
            pointsCircle.Add(new Point(cx + x, cy + y));
            pointsCircle.Add(new Point(cx - x, cy + y));
            pointsCircle.Add(new Point(cx + x, cy - y));
            pointsCircle.Add(new Point(cx - x, cy - y));
            pointsCircle.Add(new Point(cx + y, cy + x));
            pointsCircle.Add(new Point(cx - y, cy + x));
            pointsCircle.Add(new Point(cx + y, cy - x));
            pointsCircle.Add(new Point(cx - y, cy - x));
        }

        //Función para dibuja los puntos del círculo
        public void PlotShape(Graphics g)
        {
            CalculateCircle();

            foreach (var pt in pointsCircle)
            {
                g.FillRectangle(Brushes.Blue, pt.X, pt.Y, 1, 1);
            }
        }
    }
}
