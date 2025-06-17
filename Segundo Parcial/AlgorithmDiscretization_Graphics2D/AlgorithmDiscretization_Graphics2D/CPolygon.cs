using System;
using System.Drawing;
using System.Windows.Forms;

namespace AlgorithmDiscretization_Graphics2D
{
    internal class CPolygon : CFigure
    {
        //Atributos
        private float mRadio;
        private int numLados;
        private const float SF = 1;
        private Pen mPen;

        public CPolygon()
        {
            mRadio = 0.0f;
        }

        public bool ReadData(TextBox txtRadio, TextBox txtNumLados)
        {
            try
            {
                mRadio = float.Parse(txtRadio.Text);
                numLados = int.Parse(txtNumLados.Text);

                if (mRadio <= 0)
                {
                    MessageBox.Show("El radio debe ser un número positivo.", "Error de validación");
                    mRadio = 0.0f;
                    return false;
                }

                if (numLados < 3 || numLados > 10)
                {
                    MessageBox.Show("El número de lados debe estar entre 3 y 10.", "Error de validación");
                    numLados = 3;

                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Ingreso no válido. Ingrese un número válido.", "Mensaje de error");
            }
            return true;
        }

        public void InitializeData(TextBox txtRadio, TextBox txtNumLados,
                                    PictureBox picCanvas)
        {
            mRadio = 0.0f;
            numLados = 0;

            txtRadio.Text = "";
            txtNumLados.Text = "";
            txtRadio.Focus();
            picCanvas.Refresh();
        }

        public override void PlotShape(Graphics g, PictureBox picCanvas)
        {
            mPen = new Pen(Color.Lime, 3);

            PointF[] points = new PointF[numLados];
            float centerX = picCanvas.Width / 2;
            float centerY = picCanvas.Height / 2;

            for (int i = 0; i < numLados; i++)
            {
                float angleDeg = (360.0f / numLados) * i;
                float angleRad = angleDeg * (float)Math.PI / 180.0f;

                float x = centerX + mRadio * SF * (float)Math.Cos(angleRad);
                float y = centerY + mRadio * SF * (float)Math.Sin(angleRad);
                points[i] = new PointF(x, y);
            }

            g.DrawPolygon(mPen, points);
        }
        public void CloseForm(Form objForm)
        {
            objForm.Close();
        }
    }
}