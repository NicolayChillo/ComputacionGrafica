using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figuras
{
    internal class CCuadrado
    {
        // Datos Miembro (Atributos)

        // Lado del cuadrado
        private float mSize;            //Lado del Cuadrado
        private float mPerimeter;       // Perímetro del cuadrado
        private float mArea;            // Área del cuadrado
        private Graphics mGraphs;       // Objeto Graphics
        private const float SF = 20;    // Factor de escala
        private Pen mPen;               // Objeto Pen -> Lapiz

        // Funciones Miembro (Métodos)

        // Constructor sin parámetros
        public CCuadrado()
        {
            mSize = 0.0f;
            mPerimeter = 0.0f; mArea = 0.0f;
        }

        // Función que lee los datos de entrada del cuadrado
        public void ReadData(TextBox txtWidth)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtWidth.Text))
                {
                    MessageBox.Show("El campo no puede estar vacío.", "Error de entrada");
                    return;
                }

                if (!float.TryParse(txtWidth.Text, out float size))
                {
                    MessageBox.Show("Ingrese solo números válidos.", "Error de entrada");
                    return;
                }

                if (size <= 0)
                {
                    MessageBox.Show("El valor debe ser un número positivo.", "Error de entrada");
                    return;
                }

                mSize = size;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Mensaje de Error");
            }
        }


        // Función que calcula el perimetro del cuadrado
        public void PerimeterCuadrado()
        {
            mPerimeter = 4 * mSize;
        }

        // Función que calcula el área del cuadrado
        public void AreaCuadrado()
        {
            mArea = mSize * mSize;
        }

        // Función que imprime el perimetro y el área del cuadrado
        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = mPerimeter.ToString();
            txtArea.Text = mArea.ToString();
        }

        // Función que inicializa los datos y controles del cuadrado
        public void InitializeData(TextBox txtWidth, TextBox txtPerimeter,
                                    TextBox txtArea, PictureBox picCanvas)
        {
            mSize = 0.0f;
            mPerimeter = 0.0f; mArea = 0.0f;

            txtWidth.Text = "";
            txtPerimeter.Text = ""; txtArea.Text = "";

            // Mantiene el cursor titilando en una caja de texto
            txtWidth.Focus();
            picCanvas.Refresh();
        }

        // Función que dibuja el cuadrado en el canvas
        public void PlotShape(PictureBox picCanvas)
        {
            // Inicializa el objeto Graphics
            mGraphs = picCanvas.CreateGraphics();
            // Inicializa el objeto Pen
            mPen = new Pen(Color.Yellow, 3);
            // Dibuja el rectángulo
            mGraphs.DrawRectangle(mPen, 0, 0, mSize * SF, mSize * SF);
        }

        //Función que cierra un formulario
        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }
}
