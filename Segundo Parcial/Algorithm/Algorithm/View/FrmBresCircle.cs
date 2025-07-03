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
    public partial class FrmBresCircle : Form
    {
        private CAlgorithmBresCircle algorithmCircle = new CAlgorithmBresCircle();
        public FrmBresCircle()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            algorithmCircle.ReadData(txtRadius, picCanvas);
            algorithmCircle.PlotShape(picCanvas.CreateGraphics());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            algorithmCircle.InitializeData(txtRadius, picCanvas);
        }

        private void FrmBresCircle_Load(object sender, EventArgs e)
        {

        }
    }
}
