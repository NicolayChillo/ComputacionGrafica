using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figuras
{
    internal class CRomboide
    {
        // Datos Miembro (Atributos)
        private float mBase;
        private float mHeight;
        private float mSide;
        private float mArea;
        private float mPerimeter;
        private Graphics mGraphs;
        private const float SF = 10;
        private Pen mPen;

        // Constructor
        public CRomboide()
        {
            mBase = 0.0f;
            mHeight = 0.0f;
            mSide = 0.0f;
            mArea = 0.0f;
            mPerimeter = 0.0f;
        }

        // Leer datos
        public void ReadData(TextBox txtBase, TextBox txtHeight, TextBox txtSide)
        {
            try
            {
                if (!float.TryParse(txtBase.Text, out mBase) || mBase <= 0 ||
                    !float.TryParse(txtHeight.Text, out mHeight) || mHeight <= 0 ||
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
        public void AreaRomboide()
        {
            mArea = mBase * mHeight;
        }

        // Calcular perímetro
        public void PerimeterRomboide()
        {
            mPerimeter = 2 * (mBase + mSide);
        }

        // Imprimir resultados
        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = mPerimeter.ToString();
            txtArea.Text = mArea.ToString();
        }

        // Inicializar
        public void InitializeData(TextBox txtBase, TextBox txtHeight, TextBox txtSide,
                                   TextBox txtPerimeter, TextBox txtArea, PictureBox picCanvas)
        {
            mBase = mHeight = mSide = mArea = mPerimeter = 0;

            txtBase.Text = "";
            txtHeight.Text = "";
            txtSide.Text = "";
            txtPerimeter.Text = "";
            txtArea.Text = "";

            txtBase.Focus();
            picCanvas.Refresh();
        }

        // Dibujar figura
        public void PlotShape(PictureBox picCanvas)
        {
            mGraphs = picCanvas.CreateGraphics();
            mPen = new Pen(Color.ForestGreen, 3);

            // Centrado de la figura en el canvas
            float centerX = picCanvas.Width / 2;
            float centerY = picCanvas.Height / 2;

            // Ajustar el ángulo de inclinación (por ejemplo, 30 grados)
            float angulo = (float)(Math.PI / 6);  // 30 grados de inclinación

            // Desplazamiento en la base por la inclinación
            float offsetX = (float)(Math.Tan(angulo) * mHeight / 2);  // Cantidad de desplazamiento

            // Coordenadas de los puntos (sin rotar)
            PointF[] puntos = new PointF[4];

            // Los puntos son calculados de manera inclinada
            puntos[0] = new PointF(centerX - mBase / 2 * SF, centerY - mHeight / 2 * SF); // Arriba izquierda
            puntos[1] = new PointF(centerX + mBase / 2 * SF, centerY - mHeight / 2 * SF); // Arriba derecha
            puntos[2] = new PointF(centerX + mBase / 2 * SF + offsetX, centerY + mHeight / 2 * SF); // Abajo derecha
            puntos[3] = new PointF(centerX - mBase / 2 * SF - offsetX, centerY + mHeight / 2 * SF); // Abajo izquierda

            // Dibuja el romboide con la inclinación deseada
            mGraphs.DrawPolygon(mPen, puntos);
        }



        // Cerrar formulario
        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }
}
