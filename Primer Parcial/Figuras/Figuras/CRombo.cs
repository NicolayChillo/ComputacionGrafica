using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figuras
{
    internal class CRombo
    {
        // Datos Miembro (Atributos)
        private float mDiagonalHigher;
        private float mDiagonalLess;
        private float mSide;
        private float mArea;
        private float mPerimeter;
        private Graphics mGraphs;
        private const float SF = 10;
        private Pen mPen;

        // Constructor
        public CRombo()
        {
            mDiagonalHigher = 0.0f;
            mDiagonalLess = 0.0f;
            mSide = 0.0f;
            mArea = 0.0f;
            mPerimeter = 0.0f;
        }

        // Leer datos
        public void ReadData(TextBox txtDiagHigher, TextBox txtDiagLess, TextBox txtSide)
        {
            try
            {
                if (!float.TryParse(txtDiagHigher.Text, out mDiagonalHigher) || mDiagonalHigher <= 0 ||
                    !float.TryParse(txtDiagLess.Text, out mDiagonalLess) || mDiagonalLess <= 0 ||
                    !float.TryParse(txtSide.Text, out mSide) || mSide <= 0)
                {
                    MessageBox.Show("Todos los valores deben ser numéricos y positivos.", "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error");
            }
        }

        // Calcular área
        public void AreaRombo()
        {
            mArea = (mDiagonalHigher * mDiagonalLess) / 2;
        }

        // Calcular perímetro
        public void PerimeterRombo()
        {
            mPerimeter = 4 * mSide;
        }

        // Imprimir resultados
        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = mPerimeter.ToString();
            txtArea.Text = mArea.ToString();
        }

        // Inicializar
        public void InitializeData(TextBox txtDiagHigher, TextBox txtDiagLess, TextBox txtSide,
                                   TextBox txtPerimeter, TextBox txtArea, PictureBox picCanvas)
        {
            mDiagonalHigher = mDiagonalLess = mSide = mArea = mPerimeter = 0;

            txtDiagHigher.Text = "";
            txtDiagLess.Text = "";
            txtSide.Text = "";
            txtPerimeter.Text = "";
            txtArea.Text = "";

            txtDiagHigher.Focus();
            picCanvas.Refresh();
        }

        // Dibujar figura
        public void PlotShape(PictureBox picCanvas)
        {
            mGraphs = picCanvas.CreateGraphics();
            mPen = new Pen(Color.OrangeRed, 3);

            float centerX = picCanvas.Width / 2;
            float centerY = picCanvas.Height / 2;

            PointF[] puntos = new PointF[4];
            puntos[0] = new PointF(centerX, centerY - mDiagonalHigher / 2 * SF); // arriba
            puntos[1] = new PointF(centerX + mDiagonalLess / 2 * SF, centerY); // derecha
            puntos[2] = new PointF(centerX, centerY + mDiagonalHigher / 2 * SF); // abajo
            puntos[3] = new PointF(centerX - mDiagonalLess / 2 * SF, centerY); // izquierda

            mGraphs.DrawPolygon(mPen, puntos);
        }

        // Cerrar formulario
        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }
}
