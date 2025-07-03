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
    public partial class FrmBezier : Form
    {
        private CAlgorithmBezier bezier = new CAlgorithmBezier();
        private bool isDragging = false;

        public FrmBezier()
        {
            InitializeComponent();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            bezier.ClearData(picCanvas);
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (bezier.GetControlPoints().Count < 100)
            {
                bezier.AddControlPoint(e.Location);
                picCanvas.Invalidate();
            }
        }

        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;

        }

        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = true;
        }

        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                bezier.MovePoint(e.Location);
                picCanvas.Invalidate();
            }
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            bezier.PlotShape(e.Graphics);
        }
    }
}
