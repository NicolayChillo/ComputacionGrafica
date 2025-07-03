using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm.Controller
{
    internal class CHodgman
    {
        private Rectangle clipWindow;
        private List<Point> subjectPolygon = new List<Point>();
        private List<Point> clippedPolygon = new List<Point>();

        public List<Point> GetClippedPolygon() => clippedPolygon;

        public CHodgman()
        {
            clipWindow = Rectangle.Empty;
            subjectPolygon.Clear();
            clippedPolygon.Clear();
        }

        public void SetClippingWindow(int xmin, int ymin, int xmax, int ymax)
        {
            clipWindow = new Rectangle(xmin, ymin, xmax - xmin, ymax - ymin);
        }

        public void SetSubjectPolygon(List<Point> polygon)
        {
            subjectPolygon = new List<Point>(polygon);
        }

        private bool Inside(Point p, int edge)
        {
            switch (edge)
            {
                case 0: // Left
                    return p.X >= clipWindow.Left;
                case 1: // Right
                    return p.X <= clipWindow.Right;
                case 2: // Bottom
                    return p.Y <= clipWindow.Bottom;
                case 3: // Top
                    return p.Y >= clipWindow.Top;
            }
            return false;
        }

        private Point Intersection(Point p1, Point p2, int edge)
        {
            float x = 0, y = 0;

            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;

            switch (edge)
            {
                case 0: // Left
                    x = clipWindow.Left;
                    y = p1.Y + dy * (clipWindow.Left - p1.X) / dx;
                    break;
                case 1: // Right
                    x = clipWindow.Right;
                    y = p1.Y + dy * (clipWindow.Right - p1.X) / dx;
                    break;
                case 2: // Bottom
                    y = clipWindow.Bottom;
                    x = p1.X + dx * (clipWindow.Bottom - p1.Y) / dy;
                    break;
                case 3: // Top
                    y = clipWindow.Top;
                    x = p1.X + dx * (clipWindow.Top - p1.Y) / dy;
                    break;
            }

            return new Point((int)Math.Round(x), (int)Math.Round(y));
        }

        public void ClipPolygon()
        {
            clippedPolygon = new List<Point>(subjectPolygon);

            // Edge order: Left(0), Right(1), Bottom(2), Top(3)
            for (int edge = 0; edge < 4; edge++)
            {
                List<Point> inputList = new List<Point>(clippedPolygon);
                clippedPolygon.Clear();

                if (inputList.Count == 0)
                    return;

                Point S = inputList[inputList.Count - 1];

                foreach (Point E in inputList)
                {
                    if (Inside(E, edge))
                    {
                        if (!Inside(S, edge))
                        {
                            // intersection point
                            Point intersect = Intersection(S, E, edge);
                            clippedPolygon.Add(intersect);
                        }
                        clippedPolygon.Add(E);
                    }
                    else if (Inside(S, edge))
                    {
                        // intersection point
                        Point intersect = Intersection(S, E, edge);
                        clippedPolygon.Add(intersect);
                    }
                    S = E;
                }
            }
        }

        public void PlotShape(Graphics g)
        {
            Pen clipPen = new Pen(Color.Blue, 1);
            Pen subjectPen = new Pen(Color.Red, 1);
            Pen clippedPen = new Pen(Color.LimeGreen, 2);

            // Dibuja ventana de recorte
            g.DrawRectangle(clipPen, clipWindow);

            // Dibuja polígono original
            if (subjectPolygon.Count > 1)
            {
                g.DrawPolygon(subjectPen, subjectPolygon.ToArray());
            }

            // Dibuja polígono recortado
            if (clippedPolygon.Count > 1)
            {
                g.DrawPolygon(clippedPen, clippedPolygon.ToArray());
            }

            clipPen.Dispose();
            subjectPen.Dispose();
            clippedPen.Dispose();
        }

        public void ClearData(PictureBox canvas)
        {
            subjectPolygon.Clear();
            clippedPolygon.Clear();
            clipWindow = Rectangle.Empty;
            canvas.Refresh();
        }
    }
}
