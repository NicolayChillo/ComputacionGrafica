﻿using System;
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
    public partial class FrmAlgorithmBresenham : Form
    {
        private CAlgorithmBresenham algorithmBresenham = new CAlgorithmBresenham();
        private int clickCount = 0;
        public FrmAlgorithmBresenham()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            algorithmBresenham.ReadData(txtX1, txtY1, txtX2, txtY2);
            algorithmBresenham.PlotShape(picCanvas.CreateGraphics());
            lstPoints.Items.Clear();
            foreach (Point pt in algorithmBresenham.GetLinePoints())
            {
                lstPoints.Items.Add($"({pt.X}, {pt.Y})");
            }
            lblInfoPoints.Enabled = true;
            lblTotalPoints.Visible = true;
            lblTotalPoints.Text = "Total: " + lstPoints.Items.Count.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            algorithmBresenham.InitializeData(txtX1, txtY1, txtX2, txtY2, picCanvas);
            clickCount = 0;
            lstPoints.Items.Clear();
            lblInfoPoints.Enabled = false;
            lblTotalPoints.Visible = false;
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (clickCount == 0)
            {
                txtX1.Text = e.X.ToString();
                txtY1.Text = e.Y.ToString();
                txtX2.Text = "";
                txtY2.Text = "";

                picCanvas.Refresh(); // Limpia el PictureBox

                // Dibuja el primer punto
                using (Graphics g = picCanvas.CreateGraphics())
                {
                    g.FillRectangle(Brushes.Lime, e.X, e.Y, 1, 1);
                }
                clickCount = 1;
            }
            else if (clickCount == 1)
            {
                txtX2.Text = e.X.ToString();
                txtY2.Text = e.Y.ToString();

                // Dibuja segundo punto
                using (Graphics g = picCanvas.CreateGraphics())
                {
                    g.FillRectangle(Brushes.Lime, e.X, e.Y, 1, 1);
                }
                clickCount = 0;
            }
        }
    }
}
