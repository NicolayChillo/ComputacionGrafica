﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Algorithm.Controller;
using AlgorithmDiscretization_Graphics2D;

namespace Algorithm.View
{
    public partial class FrmFloodFill : Form
    {
        private Bitmap canvasBitmap;
        private CPolygon polygon = new CPolygon();
        public FrmFloodFill()
        {
            InitializeComponent();
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
                g.Clear(Color.White);
            }

            picCanvas.Invalidate();
        }

        private void FrmFloodFill_Load(object sender, EventArgs e)
        {
            polygon.InitializeData(txtRadio, txtNumLados, picCanvas);
            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            picCanvas.Image = canvasBitmap;
            picCanvas.Invalidate();
        }

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            Color target = canvasBitmap.GetPixel(e.X, e.Y);
            polygon.FloodFill(new Point(e.X, e.Y), canvasBitmap, target, Color.Blue, picCanvas);
            picCanvas.Invalidate();
        }
    }
}
