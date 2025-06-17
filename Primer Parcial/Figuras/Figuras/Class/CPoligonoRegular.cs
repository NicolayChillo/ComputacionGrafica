using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figuras
{
    internal class CPoligonoRegular
    {
        private float mRadius;
        private float mSizes;
        private Graphics mGraphs;
        private const float SF = 20;
        private Pen mPen;
        public float radio;
        public CPoligonoRegular()
        {
            mRadius = 0.0f;
        }

        private void ReadData(TextBox txtRadius, TextBox txtSizes)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtRadius.Text) || string.IsNullOrWhiteSpace(txtSizes.Text))
                {
                    MessageBox.Show("El campo no puede estar vacío.", "Error de entrada");
                    return;
                }

                if (!float.TryParse(txtRadius.Text, out float radius) || !int.TryParse(txtSizes.Text, out int sizes) )
                {
                    MessageBox.Show("Ingrese solo números válidos.", "Error de entrada");
                    return;
                }

                if (radius <= 0 )
                {
                    MessageBox.Show("El valor debe ser un número positivo.", "Error de entrada");
                    return;
                }
                if (sizes <= 5)
                {
                    MessageBox.Show("El valor de los lados debe ser mayor que 4");
                    return;
                }

                mRadius = radius;
                mSizes = sizes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Mensaje de Error");
            }
        }

        public void InitializeData(TextBox txtRadius,TextBox txtSizes, PictureBox picCanvas)
        {
            mRadius = 0.0f;
            txtRadius.Text = "";
            txtSizes.Text = "";

            txtRadius.Focus();
            picCanvas.Refresh();
        }

        public void PlotShape(PictureBox picCanvas, TextBox txtSizes)
        { 
            mGraphs = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Black, 3);
            int numPoints = int.Parse(txtSizes.Text);


            PointF[] puntos = new PointF[numPoints];
            float angulo = -(float)(Math.PI / 2); // 

            float radioInterior = mRadius * 0.5f;  // Escala para vértices internos
        }

    }
}
