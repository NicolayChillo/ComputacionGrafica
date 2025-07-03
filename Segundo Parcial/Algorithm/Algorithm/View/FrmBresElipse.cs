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
    public partial class FrmBresElipse : Form
    {
        private CAlgorithmBresElipse algorithmBresElipse = new CAlgorithmBresElipse();
        public FrmBresElipse()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            algorithmBresElipse.ReadData(txtRx, txtRy, picCanvas);
            algorithmBresElipse.PlotShape(picCanvas.CreateGraphics());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            algorithmBresElipse.InitializeData(txtRx, txtRy, picCanvas);
        }
    }
}
