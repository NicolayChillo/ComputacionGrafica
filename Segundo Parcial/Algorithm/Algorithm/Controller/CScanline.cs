using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm.Controller
{
    internal abstract class CScanline
    {
        private List<Point> filledPixels = new List<Point>();
        public IEnumerable<Point> GetPixels() => filledPixels;

        public Pen Borde { get; set; } = new Pen(Color.Black, 2);
        public Color ColorRelleno { get; set; } = Color.Transparent;

        public abstract void PlotShape(Graphics g, PictureBox picCanvas);

        public virtual void ScanlineFill(Point start, Bitmap bmp, Color targetColor,
                                 Color fillColor, Color borderColor, PictureBox canvas)
        {
            filledPixels.Clear();

            int width = bmp.Width;
            int height = bmp.Height;

            for (int y = 0; y < height; y++)
            {
                List<int> interseccionesX = new List<int>();

                for (int x = 0; x < width; x++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    if (pixel.ToArgb() == borderColor.ToArgb())
                    {
                        interseccionesX.Add(x);
                    }
                }

                for (int i = 0; i < interseccionesX.Count - 1; i += 2)
                {
                    int xStart = interseccionesX[i] + 1;
                    int xEnd = interseccionesX[i + 1] - 1;

                    for (int x = xStart; x <= xEnd; x++)
                    {
                        if (x >= 0 && x < width)
                        {
                            Color current = bmp.GetPixel(x, y);
                            if (current.ToArgb() != borderColor.ToArgb() &&
                                current.ToArgb() != fillColor.ToArgb())
                            {
                                bmp.SetPixel(x, y, fillColor);
                                filledPixels.Add(new Point(x, y));
                            }
                        }
                    }
                }
            }

            canvas.Image = bmp;
            canvas.Refresh();
        }
    }
}
