using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithm.Controller;

namespace Algorithm.View
{
    public partial class FrmShuterlandHodgman : Form
    {
        private CHodgman shClipper = new CHodgman();
        private List<Point> polygonPoints = new List<Point>();
        private bool clippingWindowSet = false;
        private int selectedPointIndex = -1;
        private bool isDragging = false;

        public FrmShuterlandHodgman()
        {
            InitializeComponent();
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            polygonPoints.Add(e.Location);
            picCanvas.Invalidate();
            if (!clippingWindowSet)
            {
                MessageBox.Show("Primero debes establecer la ventana de recorte (clic en 'Rectángulo')");
                return;
            }
        }

        private void btnSetWindow_Click(object sender, EventArgs e)
        {
            try
            {
                int xmin = int.Parse(txtXmin.Text);
                int ymin = int.Parse(txtYmin.Text);
                int xmax = int.Parse(txtXmax.Text);
                int ymax = int.Parse(txtYmax.Text);

                shClipper.SetClippingWindow(xmin, ymin, xmax, ymax);
                clippingWindowSet = true;
                picCanvas.Refresh();

                // Dibuja solo la ventana
                using (Graphics g = picCanvas.CreateGraphics())
                {
                    g.DrawRectangle(Pens.Blue, xmin, ymin, xmax - xmin, ymax - ymin);
                }
            }
            catch
            {
                MessageBox.Show("Verifica que los valores de la ventana de recorte sean válidos.");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            polygonPoints.Clear();
            clippingWindowSet = false;
            shClipper.ClearData(picCanvas);
            picCanvas.Invalidate();
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Dibuja puntos ingresados
            foreach (var pt in polygonPoints)
            {
                g.FillEllipse(Brushes.Blue, pt.X - 4, pt.Y - 4, 8, 8);
            }

            // Dibuja líneas del polígono original si hay más de 1 punto
            if (polygonPoints.Count > 1)
            {
                g.DrawPolygon(Pens.Red, polygonPoints.ToArray());
            }

            // Dibuja ventana y polígonos con el recorte si está definido
            shClipper.PlotShape(g);
        }

        private void btnClip_Click(object sender, EventArgs e)
        {
            if (!clippingWindowSet)
            {
                MessageBox.Show("Debes establecer primero la ventana de recorte");
                return;
            }

            if (polygonPoints.Count < 3)
            {
                MessageBox.Show("Debes agregar al menos 3 puntos para formar un polígono");
                return;
            }

            shClipper.SetSubjectPolygon(polygonPoints);
            shClipper.ClipPolygon();
            picCanvas.Invalidate();
        }

        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < polygonPoints.Count; i++)
            {
                Rectangle area = new Rectangle(polygonPoints[i].X - 6, polygonPoints[i].Y - 6, 12, 12);
                if (area.Contains(e.Location))
                {
                    selectedPointIndex = i;
                    isDragging = true;
                    break;
                }
            }
        }

        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && selectedPointIndex != -1)
            {
                // Actualizar la posición del punto seleccionado
                polygonPoints[selectedPointIndex] = e.Location;
                picCanvas.Invalidate();
            }
        }

        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            selectedPointIndex = -1;
        }
    }
}
