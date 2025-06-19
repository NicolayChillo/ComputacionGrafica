using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorithmDiscretization_Graphics2D
{
    public partial class FrmPolygon : Form
    {
        private Bitmap canvasBitmap;
        private CPolygon polygon = new CPolygon();
        public FrmPolygon()
        {
            InitializeComponent();
        }
        private void FrmPolygon_Load(object sender, EventArgs e)
        {
            polygon.InitializeData(txtRadio, txtNumLados, picCanvas);
            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            picCanvas.Image = canvasBitmap;
            picCanvas.Invalidate();
        }
        private void btnDibujar_Click(object sender, EventArgs e)
        {
            if (!polygon.ReadData(txtRadio, txtNumLados))
            {
                return;
            }
            using (Graphics g = Graphics.FromImage(canvasBitmap))
            {
                polygon.PlotShape(g, picCanvas);
            }
            picCanvas.Invalidate();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            polygon.InitializeData(txtRadio, txtNumLados, picCanvas);
            // Limpiar el bitmap 
            using (Graphics g = Graphics.FromImage(canvasBitmap))
            {
                g.Clear(Color.DarkOrchid);
            }

            picCanvas.Invalidate();
            lblInfoPoints.Enabled = false;
            lblTotalPoints.Visible = false;
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            Color target = canvasBitmap.GetPixel(e.X, e.Y);
            polygon.FloodFill(new Point(e.X, e.Y), canvasBitmap, target, Color.Lime, picCanvas);
            picCanvas.Invalidate();
            lstPoints.Items.Clear();
            List<Point> points = new List<Point>(polygon.GetPixels()); // convertir de Stack a List
            foreach (Point pt in points)
            {
                lstPoints.Items.Add($"({pt.X}, {pt.Y})");
            }
            lblInfoPoints.Enabled = true;
            lblTotalPoints.Visible = true;
            lblTotalPoints.Text = "Total: " + lstPoints.Items.Count.ToString();
        }

        
    }
}
