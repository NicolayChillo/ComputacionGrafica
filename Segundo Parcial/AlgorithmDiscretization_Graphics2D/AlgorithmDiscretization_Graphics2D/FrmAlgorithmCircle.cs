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
    public partial class FrmAlgorithmCircle : Form
    {
        private CAlgorithmCircle algorithmCircle = new CAlgorithmCircle();
        public FrmAlgorithmCircle()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            algorithmCircle.ReadData(txtRadius, picCanvas);
            algorithmCircle.PlotShape(picCanvas.CreateGraphics());
            lstPoints.Items.Clear();
            foreach (Point pt in algorithmCircle.GetCirclePoints())
            {
                lstPoints.Items.Add($"({pt.X}, {pt.Y})");
            }
            lblInfoPoints.Enabled = true;
            lblTotalPoints.Visible = true;
            lblTotalPoints.Text = "Total: " + lstPoints.Items.Count.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            algorithmCircle.InitializeData(txtRadius, picCanvas);
            lstPoints.Items.Clear();
            lblInfoPoints.Enabled = false;
            lblTotalPoints.Visible = false;
        }
    }
}
