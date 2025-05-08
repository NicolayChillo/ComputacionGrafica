using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figuras
{
    internal class CDeltoide
    {
        // Datos Miembro (Atributos)
        private float mBaseSup;  // Base superior del deltoide
        private float mBaseLower;  // Base inferior del deltoide
        private float mHeight;        // Altura del deltoide
        private float mArea;          // Área del deltoide
        private float mPerimeter;     // Perímetro del deltoide
        private const float SF = 20;  // Factor de escala
        private Graphics mGraphs;    // Objeto Graphics
        private Pen mPen;             // Objeto Pen -> Lapiz

        // Funciones Miembro (Métodos)

        // Constructor
        public CDeltoide()
        {
            mBaseSup = 0.0f;
            mBaseLower = 0.0f;
            mHeight = 0.0f;
            mArea = 0.0f;
            mPerimeter = 0.0f;
        }

        // Función que lee los datos de entrada del deltoide
        public void ReadData(TextBox txtBaseSup, TextBox txtBaseLower, TextBox txtHeight)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBaseSup.Text) || string.IsNullOrWhiteSpace(txtBaseLower.Text) || string.IsNullOrWhiteSpace(txtHeight.Text))
                {
                    MessageBox.Show("Los campos no pueden estar vacíos.", "Error de entrada");
                    return;
                }

                if (!float.TryParse(txtBaseSup.Text, out float baseSuperior) || !float.TryParse(txtBaseLower.Text, out float baseInferior) || !float.TryParse(txtHeight.Text, out float altura))
                {
                    MessageBox.Show("Ingrese solo números válidos.", "Error de entrada");
                    return;
                }

                if (baseSuperior <= 0 || baseInferior <= 0 || altura <= 0)
                {
                    MessageBox.Show("Los valores deben ser números positivos.", "Error de entrada");
                    return;
                }

                mBaseSup = baseSuperior;
                mBaseLower = baseInferior;
                mHeight = altura;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Mensaje de Error");
            }
        }

        // Función que calcula el perímetro del deltoide (suponiendo que los lados son iguales)
        public void PerimeterDeltoide()
        {
            // El perímetro de un deltoide se calcula como la suma de los 4 lados.
            // Para simplificar, calculamos la longitud de los dos lados iguales usando Pitágoras
            float lado = (float)Math.Sqrt((mHeight * mHeight) + ((mBaseSup - mBaseLower) / 2) * ((mBaseSup - mBaseLower) / 2));
            mPerimeter = 2 * (lado + mBaseLower);  // Perímetro = 2*(lado + base inferior)
        }

        // Función que calcula el área del deltoide
        public void AreaDeltoide()
        {
            mArea = (mBaseSup + mBaseLower) * mHeight / 2;
        }

        // Función que imprime el perímetro y el área del deltoide
        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = mPerimeter.ToString();
            txtArea.Text = mArea.ToString();
        }

        // Función que inicializa los datos y controles del deltoide
        public void InitializeData(TextBox txtBaseSup, TextBox txtBaseLower, TextBox txtHeight,
                                   TextBox txtPerimeter, TextBox txtArea, PictureBox picCanvas)
        {
            mBaseSup = 0.0f;
            mBaseLower = 0.0f;
            mHeight = 0.0f;
            mPerimeter = 0.0f;
            mArea = 0.0f;

            txtBaseSup.Text = "";
            txtBaseLower.Text = "";
            txtHeight.Text = "";
            txtPerimeter.Text = "";
            txtArea.Text = "";

            picCanvas.Refresh();
        }

        // Función que dibuja el deltoide en el canvas
        public void PlotShape(PictureBox picCanvas)
        {
            mGraphs = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Cyan, 3);

            // Calculando los puntos del deltoide (cometa)
            float offsetSuperior = mBaseSup / 2 * SF;
            float offsetInferior = mBaseLower / 2 * SF;
            float scaleHeight = mHeight* SF;

            // Puntos de la figura
            PointF[] puntos = new PointF[4];

            // Superior izquierda, superior derecha, inferior derecha, inferior izquierda
            puntos[0] = new PointF(picCanvas.Width / 2 - offsetSuperior, picCanvas.Height / 2 - scaleHeight); // Superior izquierda
            puntos[1] = new PointF(picCanvas.Width / 2 + offsetSuperior, picCanvas.Height / 2 - scaleHeight); // Superior derecha
            puntos[2] = new PointF(picCanvas.Width / 2 + offsetInferior, picCanvas.Height / 2); // Inferior derecha
            puntos[3] = new PointF(picCanvas.Width / 2 - offsetInferior, picCanvas.Height / 2); // Inferior izquierda

            mGraphs.DrawPolygon(mPen, puntos);
        }

        // Función que cierra un formulario
        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }
}
