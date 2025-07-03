using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Algorithm.Controller
{
    internal class CAlgorithmBezier
    {
        private List<Point> controlPoints = new List<Point>();
        private List<Point> curvePoints = new List<Point>();

        public List<Point> GetCurvePoints() => curvePoints;
        public List<Point> GetControlPoints() => controlPoints;

        public void AddControlPoint(Point p)
        {
            controlPoints.Add(p);
        }

        public void ClearData(PictureBox canvas)
        {
            controlPoints.Clear();
            curvePoints.Clear();
            canvas.Refresh();
        }

        private void CalculateBezier()
        {
            curvePoints.Clear();
            int n = controlPoints.Count - 1;

            if (n < 1) return;

            for (float t = 0; t <= 1.0; t += 0.001f)
            {
                float x = 0;
                float y = 0;

                for (int i = 0; i <= n; i++)
                {
                    double binomial = Factorial(n) / (Factorial(i) * Factorial(n - i));
                    double term = binomial * Math.Pow(1 - t, n - i) * Math.Pow(t, i);
                    x += (float)(term * controlPoints[i].X);
                    y += (float)(term * controlPoints[i].Y);
                }

                curvePoints.Add(new Point((int)x, (int)y));
            }
        }

        private double Factorial(int n)
        {
            if (n == 0 || n == 1) return 1;
            double result = 1;
            for (int i = 2; i <= n; i++) result *= i;
            return result;
        }


        public void PlotShape(Graphics g)
        {
            if (controlPoints.Count < 1) return;

            CalculateBezier();

            // Dibuja la curva
            foreach (Point pt in curvePoints)
            {
                g.FillRectangle(Brushes.Red, pt.X, pt.Y, 1, 1);
            }

            // Dibuja líneas entre puntos de control
            for (int i = 0; i < controlPoints.Count - 1; i++)
            {
                g.DrawLine(Pens.Gray, controlPoints[i], controlPoints[i + 1]);
            }

            // Dibuja puntos de control
            foreach (var pt in controlPoints)
            {
                g.FillEllipse(Brushes.Blue, pt.X - 4, pt.Y - 4, 8, 8);
            }
        }

        // Permite mover un punto cercano al mouse
        public void MovePoint(Point mousePos)
        {
            for (int i = 0; i < controlPoints.Count; i++)
            {
                Rectangle r = new Rectangle(controlPoints[i].X - 6, controlPoints[i].Y - 6, 12, 12);
                if (r.Contains(mousePos))
                {
                    controlPoints[i] = mousePos;
                    break;
                }
            }
        }
    }
}
