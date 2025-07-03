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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Algorithm.View
{
    public partial class FrmBSplines : Form
    {
        private CAlgorithmBSpline spline = new CAlgorithmBSpline();
        private bool isDragging = false;
        private int draggedPointIndex = -1;
        public FrmBSplines()
        {
            InitializeComponent();
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (spline.GetControlPoints().Count < 100)
            {
                spline.AddControlPoint(e.Location);
                picCanvas.Invalidate();
            }
        }

        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < spline.GetControlPoints().Count; i++)
            {
                var pt = spline.GetControlPoints()[i];
                Rectangle r = new Rectangle(pt.X - 6, pt.Y - 6, 12, 12);
                if (r.Contains(e.Location))
                {
                    isDragging = true;
                    draggedPointIndex = i;
                    return;
                }
            }

            if (!isDragging && e.Button == MouseButtons.Left)
            {
                spline.AddControlPoint(e.Location);
                picCanvas.Invalidate();
            }

        }

        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                isDragging = false;
                draggedPointIndex = -1;
            }

        }

        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && draggedPointIndex != -1)
            {
                // Mover el punto bajo el mouse
                var points = spline.GetControlPoints();
                points[draggedPointIndex] = e.Location;
                picCanvas.Invalidate();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            spline.ClearData(picCanvas);

        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            spline.PlotShape(e.Graphics);

        }
    }
}
