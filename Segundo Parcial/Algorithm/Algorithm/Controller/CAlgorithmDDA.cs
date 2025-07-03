using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm.Controller
{
    internal class CAlgorithmDDA
    {
        //Atributos
        private Point pointStart;
        private Point pointEnd;
        private List<Point> linePoints;
        private int animateInterval = 25;

        public CAlgorithmDDA()
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
                MessageBox.Show("Todos los campos de coordenadas deben estar llenos.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int x1 = int.Parse(txtX1.Text);
            int y1 = int.Parse(txtY1.Text);
            int x2 = int.Parse(txtX2.Text);
            int y2 = int.Parse(txtY2.Text);

            if (x1 < 0 || y1 < 0 || x2 < 0 || y2 < 0)
            {
                MessageBox.Show("Las coordenadas deben ser enteros no negativos.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // Funcion para calcular los puntos de la línea con el algoritmo DDA
        private void CalculateLine()
        {
            linePoints.Clear();

            int dx = pointEnd.X - pointStart.X;
            int dy = pointEnd.Y - pointStart.Y;

            int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));

            float xIncrement = dx / (float)steps;
            float yIncrement = dy / (float)steps;

            float x = pointStart.X;
            float y = pointStart.Y;

            for (int i = 0; i <= steps; i++)
            {
                int scaledX = (int)Math.Round(x);
                int scaledY = (int)Math.Round(y);
                linePoints.Add(new Point(scaledX, scaledY));
                x += xIncrement;
                y += yIncrement;
            }
        }

        //Funcion para dibujar la línea y los puntos calculados
        public void PlotShape(Graphics g)
        {
            CalculateLine();

            foreach (var pt in linePoints)
            {
                g.FillRectangle(Brushes.Blue, pt.X, pt.Y, 1, 1);
                Application.DoEvents();
            }

        }
    }
}
