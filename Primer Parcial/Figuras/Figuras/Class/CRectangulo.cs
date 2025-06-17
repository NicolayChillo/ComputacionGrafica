using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figuras
{
    internal class CRectangulo
    {
        // Datos Miembro (Atributos)
        private float mWidth;           // Ancho del rectángulo
        private float mHeight;          // Alto del rectángulo
        private float mPerimeter;       // Perímetro del rectángulo
        private float mArea;            // Área del rectángulo
        private Graphics mGraphs;       // Objeto Graphics
        private const float SF = 20;    // Factor de escala
        private Pen mPen;               // Objeto Pen -> Lápiz

        
        
        // Constructor sin parámetros
        public CRectangulo()
        {
            mWidth = 0.0f;
            mHeight = 0.0f;
            mPerimeter = 0.0f;
            mArea = 0.0f;
        }

        // Función que lee los datos de entrada del rectángulo
        public void ReadData(TextBox txtWidth, TextBox txtHeight)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtWidth.Text) || string.IsNullOrWhiteSpace(txtHeight.Text))
                {
                    MessageBox.Show("Ningún campo puede estar vacío.", "Error de entrada");
                    return;
                }

                if (!float.TryParse(txtWidth.Text, out float width) || !float.TryParse(txtHeight.Text, out float height))
                {
                    MessageBox.Show("Ingrese solo números válidos.", "Error de entrada");
                    return;
                }

                if (width <= 0 || height <= 0)
                {
                    MessageBox.Show("Los valores deben ser positivos.", "Error de entrada");
                    return;
                }

                mWidth = width;
                mHeight = height;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Mensaje de Error");
            }
        }

        // Función que calcula el perímetro del rectángulo
        public void PerimeterRectangulo()
        {
            mPerimeter = 2 * (mWidth + mHeight);
        }

        // Función que calcula el área del rectángulo
        public void AreaRectangulo()
        {
            mArea = mWidth * mHeight;
        }

        // Función que imprime el perímetro y el área del rectángulo
        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = mPerimeter.ToString();
            txtArea.Text = mArea.ToString();
        }

        // Función que inicializa los datos y controles del rectángulo
        public void InitializeData(TextBox txtWidth, TextBox txtHeight,
                                   TextBox txtPerimeter, TextBox txtArea,
                                   PictureBox picCanvas)
        {
            mWidth = 0.0f;
            mHeight = 0.0f;
            mPerimeter = 0.0f;
            mArea = 0.0f;

            txtWidth.Text = "";
            txtHeight.Text = "";
            txtPerimeter.Text = "";
            txtArea.Text = "";

            txtWidth.Focus();
            picCanvas.Refresh();
        }

        // Función que dibuja el rectángulo en el canvas
        public void PlotShape(PictureBox picCanvas)
        {
            mGraphs = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Green, 3);
            mGraphs.DrawRectangle(mPen, 0, 0, mWidth * SF, mHeight * SF);

        }

        // Función que cierra un formulario
        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }
}
