using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlgorithmDiscretization_Graphics2D
{
    public abstract class CFigure
    {
        private int animateInterval = 1;
        private List<Point> filledPixels = new List<Point>();
        public IEnumerable<Point> GetPixels() => filledPixels;

        public Pen Borde { get; set; } = new Pen(Color.Black, 2);
        public Color ColorRelleno { get; set; } = Color.Transparent;

        public abstract void PlotShape(Graphics g, PictureBox picCanvas);

        public virtual void FloodFill(Point p, Bitmap bmp, Color targetColor, 
                                      Color fillColor, PictureBox canvas)
        {
            if (targetColor.ToArgb() == fillColor.ToArgb()) return;

            filledPixels.Clear();

            Stack<Point> workStack = new Stack<Point>();
            workStack.Push(p);

            while (workStack.Count > 0)
            {
                Point pt = workStack.Pop();
                if (pt.X < 0 || pt.Y < 0 || pt.X >= bmp.Width || pt.Y >= bmp.Height)
                    continue;

                if (bmp.GetPixel(pt.X, pt.Y).ToArgb() == targetColor.ToArgb())
                {
                    bmp.SetPixel(pt.X, pt.Y, fillColor);
                    filledPixels.Add(pt);

                    workStack.Push(new Point(pt.X + 1, pt.Y));
                    workStack.Push(new Point(pt.X - 1, pt.Y));
                    workStack.Push(new Point(pt.X, pt.Y + 1));
                    workStack.Push(new Point(pt.X, pt.Y - 1));
                }
                canvas.Refresh();
                Application.DoEvents();
                System.Threading.Thread.Sleep(animateInterval);
            }
        }
    }
}