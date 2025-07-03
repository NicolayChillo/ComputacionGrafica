using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm.Controller
{
    internal class CCohen
    {
        private const int INSIDE = 0; // 0000
        private const int LEFT = 1;   // 0001
        private const int RIGHT = 2;  // 0010
        private const int BOTTOM = 4; // 0100
        private const int TOP = 8;    // 1000

        private Rectangle clipWindow;
        private Point startPoint, endPoint;
        private Point clippedStart, clippedEnd;
        private bool lineVisible;

        private List<Point> clippedPoints = new List<Point>();
        public List<Point> GetClippedPoints() => clippedPoints;

        public CCohen()
        {
            startPoint = Point.Empty;
            endPoint = Point.Empty;
            clippedStart = Point.Empty;
            clippedEnd = Point.Empty;
            clipWindow = Rectangle.Empty;
            lineVisible = false;
        }

        public void ReadData(TextBox txtX1, TextBox txtY1, TextBox txtX2, TextBox txtY2)
        {
            startPoint = new Point(int.Parse(txtX1.Text), int.Parse(txtY1.Text));
            endPoint = new Point(int.Parse(txtX2.Text), int.Parse(txtY2.Text));
        }

        public void InitializeData(TextBox txtX1, TextBox txtY1, TextBox txtX2, TextBox txtY2, PictureBox picCanvas)
        {
            txtX1.Text = txtY1.Text = txtX2.Text = txtY2.Text = "";
            picCanvas.Refresh();
            startPoint = endPoint = clippedStart = clippedEnd = Point.Empty;
            lineVisible = false;
        }

        public void SetClippingWindow(int xmin, int ymin, int xmax, int ymax)
        {
            clipWindow = new Rectangle(xmin, ymin, xmax - xmin, ymax - ymin);
        }

        private int ComputeOutCode(Point p)
        {
            int code = INSIDE;

            if (p.X < clipWindow.Left) code |= LEFT;
            else if (p.X > clipWindow.Right) code |= RIGHT;

            if (p.Y < clipWindow.Top) code |= TOP;
            else if (p.Y > clipWindow.Bottom) code |= BOTTOM;

            return code;
        }

        public void ClipLine()
        {
            int outcode1 = ComputeOutCode(startPoint);
            int outcode2 = ComputeOutCode(endPoint);
            bool done = false;

            Point p1 = startPoint, p2 = endPoint;

            while (!done)
            {
                if ((outcode1 | outcode2) == 0)
                {
                    lineVisible = true;
                    clippedStart = p1;
                    clippedEnd = p2;

                    clippedPoints.Clear();
                    int dx = clippedEnd.X - clippedStart.X;
                    int dy = clippedEnd.Y - clippedStart.Y;
                    int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
                    float xInc = dx / (float)steps;
                    float yInc = dy / (float)steps;

                    float x = clippedStart.X;
                    float y = clippedStart.Y;

                    for (int i = 0; i <= steps; i++)
                    {
                        int px = (int)Math.Round(x);
                        int py = (int)Math.Round(y);
                        clippedPoints.Add(new Point(px, py));
                        x += xInc;
                        y += yInc;
                    }

                    done = true;
                }
                else if ((outcode1 & outcode2) != 0)
                {
                    // Trivial Rejection
                    lineVisible = false;
                    done = true;
                }
                else
                {
                    int outcodeOut = (outcode1 != 0) ? outcode1 : outcode2;
                    int x = 0, y = 0;

                    if ((outcodeOut & TOP) != 0)
                    {
                        x = p1.X + (p2.X - p1.X) * (clipWindow.Top - p1.Y) / (p2.Y - p1.Y);
                        y = clipWindow.Top;
                    }
                    else if ((outcodeOut & BOTTOM) != 0)
                    {
                        x = p1.X + (p2.X - p1.X) * (clipWindow.Bottom - p1.Y) / (p2.Y - p1.Y);
                        y = clipWindow.Bottom;
                    }
                    else if ((outcodeOut & RIGHT) != 0)
                    {
                        y = p1.Y + (p2.Y - p1.Y) * (clipWindow.Right - p1.X) / (p2.X - p1.X);
                        x = clipWindow.Right;
                    }
                    else if ((outcodeOut & LEFT) != 0)
                    {
                        y = p1.Y + (p2.Y - p1.Y) * (clipWindow.Left - p1.X) / (p2.X - p1.X);
                        x = clipWindow.Left;
                    }

                    if (outcodeOut == outcode1)
                    {
                        p1 = new Point(x, y);
                        outcode1 = ComputeOutCode(p1);
                    }
                    else
                    {
                        p2 = new Point(x, y);
                        outcode2 = ComputeOutCode(p2);
                    }
                }
            }
        }

        public void PlotShape(Graphics g)
        {
            Pen originalPen = new Pen(Color.Red, 1);
            Pen clippedPen = new Pen(Color.LimeGreen, 2);
            Pen borderPen = new Pen(Color.Blue, 1);

            // Dibuja ventana de recorte
            g.DrawRectangle(borderPen, clipWindow);

            // Dibuja línea original
            g.DrawLine(originalPen, startPoint, endPoint);

            // Dibuja línea recortada si es visible
            if (lineVisible)
            {
                g.DrawLine(clippedPen, clippedStart, clippedEnd);
            }

            originalPen.Dispose();
            clippedPen.Dispose();
            borderPen.Dispose();
        }
    }
}
