using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figuras
{
    internal class CTrapezoide
    {
        // Datos Miembro (Atributos)
        private float mBaseHigher, mBaseLess, mHeight;
        private float mSizeLeft, mSizeRight;
        private float mPerimeter, mArea;
        private Graphics mGraphs;
        private const float SF = 10;
        private Pen mPen;

        // Constructor sin parámetros
        public CTrapezoide()
        {
            mBaseHigher = mBaseLess = mHeight = mSizeLeft = mSizeRight = 0.0f;
            mPerimeter = mArea = 0.0f;
        }

        // Leer los datos del trapezoide
        public void ReadData(TextBox txtBaseHigher, TextBox txtBaseLess, TextBox txtHeight,
                             TextBox txtSizeLeft, TextBox txtSizeRight)
        {
            try
            {
                mBaseHigher = float.Parse(txtBaseHigher.Text);
                mBaseLess = float.Parse(txtBaseLess.Text);
                mHeight = float.Parse(txtHeight.Text);
                mSizeLeft = float.Parse(txtSizeLeft.Text);
                mSizeRight = float.Parse(txtSizeRight.Text);

                if (mBaseHigher <= 0 || mBaseLess <= 0 || mHeight <= 0 || mSizeLeft <= 0 || mSizeRight <= 0)
                {
                    throw new Exception("Todos los valores deben ser mayores a cero.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en los datos: " + ex.Message, "Entrada no válida");
            }
        }

        // Calcular el perímetro
        public void PerimeterTrapezoide()
        {
            mPerimeter = mBaseHigher + mBaseLess + mSizeLeft + mSizeRight;
        }

        // Calcular el área
        public void AreaTrapezoide()
        {
            mArea = ((mBaseHigher + mBaseLess) * mHeight) / 2;
        }

        // Imprimir los resultados
        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = mPerimeter.ToString("F2");
            txtArea.Text = mArea.ToString("F2");
        }

        // Inicializar los datos
        public void InitializeData(TextBox txtBaseHigher, TextBox txtBaseLess, TextBox txtHeight,
                                   TextBox txtSizeLeft, TextBox txtSizeRight,
                                   TextBox txtPerimeter, TextBox txtArea, PictureBox picCanvas)
        {
            mBaseHigher = mBaseLess = mHeight = mSizeLeft = mSizeRight = 0.0f;
            mPerimeter = mArea = 0.0f;

            txtBaseHigher.Text = txtBaseLess.Text = txtHeight.Text = "";
            txtSizeLeft.Text = txtSizeRight.Text = "";
            txtPerimeter.Text = txtArea.Text = "";

            txtBaseHigher.Focus();
            picCanvas.Refresh();
        }

        // Dibujar el trapezoide
        public void PlotShape(PictureBox picCanvas)
        {
            mGraphs = picCanvas.CreateGraphics();
            mPen = new Pen(Color.DarkCyan, 3);

            PointF[] puntos = new PointF[4];

            float offset = (mBaseHigher - mBaseLess) / 2 * SF;
            float yBase = 50; // margen superior

            puntos[0] = new PointF(0, yBase);                         // Esquina inferior izquierda
            puntos[1] = new PointF(mBaseHigher * SF, yBase);          // Inferior derecha
            puntos[2] = new PointF((mBaseHigher * SF) - offset, yBase + mHeight * SF); // Superior derecha
            puntos[3] = new PointF(offset, yBase + mHeight * SF);     // Superior izquierda

            mGraphs.DrawPolygon(mPen, puntos);
        }


        // Cerrar formulario
        public void CloseForm(Form objForm)
        {
            objForm.Close();
        }
    }
}
