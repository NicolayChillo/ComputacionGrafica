using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Algorithm.Controller
{
    internal class CAlgorithmBSpline
    {
        private List<Point> controlPoints = new List<Point>();
        private List<Point> curvePoints = new List<Point>();

        public List<Point> GetCurvePoints() => curvePoints;
        public List<Point> GetControlPoints() => controlPoints;

        public void AddControlPoint(Point p)
        {
            if (controlPoints.Count < 100)
                controlPoints.Add(p);
        }

        public void ClearData(PictureBox canvas)
        {
            controlPoints.Clear();
            curvePoints.Clear();
            canvas.Refresh();
        }

        private void CalculateBSpline()
        {
            curvePoints.Clear();
            int n = controlPoints.Count;

            if (n < 2) return;

            if (n == 2)
            {
                // Interpolación lineal
                Point p0 = controlPoints[0];
                Point p1 = controlPoints[1];

                for (float t = 0; t <= 1; t += 0.01f)
                {
                    int x = (int)((1 - t) * p0.X + t * p1.X);
                    int y = (int)((1 - t) * p0.Y + t * p1.Y);
                    curvePoints.Add(new Point(x, y));
                }
            }
            else if (n == 3)
            {
                // Curva cuadrática
                for (float t = 0; t <= 1; t += 0.01f)
                {
                    float x = (1 - t) * (1 - t) * controlPoints[0].X +
                              2 * (1 - t) * t * controlPoints[1].X +
                              t * t * controlPoints[2].X;

                    float y = (1 - t) * (1 - t) * controlPoints[0].Y +
                              2 * (1 - t) * t * controlPoints[1].Y +
                              t * t * controlPoints[2].Y;

                    curvePoints.Add(new Point((int)x, (int)y));
                }
            }
            else
            {
                // B-spline cúbica uniforme
                for (int i = 0; i <= n - 4; i++)
                {
                    for (float t = 0; t <= 1; t += 0.01f)
                    {
                        float t2 = t * t;
                        float t3 = t2 * t;

                        float b0 = (-t3 + 3 * t2 - 3 * t + 1) / 6f;
                        float b1 = (3 * t3 - 6 * t2 + 4) / 6f;
                        float b2 = (-3 * t3 + 3 * t2 + 3 * t + 1) / 6f;
                        float b3 = t3 / 6f;

                        float x = b0 * controlPoints[i].X +
                                  b1 * controlPoints[i + 1].X +
                                  b2 * controlPoints[i + 2].X +
                                  b3 * controlPoints[i + 3].X;

                        float y = b0 * controlPoints[i].Y +
                                  b1 * controlPoints[i + 1].Y +
                                  b2 * controlPoints[i + 2].Y +
                                  b3 * controlPoints[i + 3].Y;

                        curvePoints.Add(new Point((int)x, (int)y));
                    }
                }
            }
        }

        public void PlotShape(Graphics g)
        {
            if (controlPoints.Count < 2) return;

            CalculateBSpline();

            foreach (Point pt in curvePoints)
            {
                g.FillRectangle(Brushes.Red, pt.X, pt.Y, 1, 1);
            }

            for (int i = 0; i < controlPoints.Count - 1; i++)
            {
                g.DrawLine(Pens.Gray, controlPoints[i], controlPoints[i + 1]);
            }

            for (int i = 0; i < controlPoints.Count; i++)
            {
                var pt = controlPoints[i];
                g.FillEllipse(Brushes.Blue, pt.X - 4, pt.Y - 4, 8, 8);
            }
        }

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
