using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figuras
{
    internal class CTrianguloEquilatero
    {
        // Atributos
        private float mSize;           // Lado del triángulo equilátero
        private float mPerimeter;      // Perímetro
        private float mArea;           // Área
        private Graphics mGraphs;      // Objeto Graphics
        private const float SF = 10;   // Factor de escala
        private Pen mPen;              // Lápiz

        // Constructor
        public CTrianguloEquilatero()
        {
            mSize = 0.0f;
            mPerimeter = 0.0f;
            mArea = 0.0f;
        }

        // Leer datos
        public void ReadData(TextBox txtLado)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtLado.Text))
                {
                    MessageBox.Show("El campo no puede estar vacío.", "Error de entrada");
                    return;
                }

                if (!float.TryParse(txtLado.Text, out float lado))
                {
                    MessageBox.Show("Ingrese solo números válidos.", "Error de entrada");
                    return;
                }

                if (lado <= 0)
                {
                    MessageBox.Show("El valor debe ser positivo.", "Error de entrada");
                    return;
                }

                mSize = lado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Mensaje de Error");
            }
        }

        // Calcular perímetro
        public void PerimeterTriangulo()
        {
            mPerimeter = 3 * mSize;
        }

        // Calcular área
        public void AreaTriangulo()
        {
            mArea = (float)((Math.Sqrt(3) / 4) * mSize * mSize);
        }

        // Mostrar resultados
        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = mPerimeter.ToString("F2");
            txtArea.Text = mArea.ToString("F2");
        }

        // Inicializar datos
        public void InitializeData(TextBox txtSize, TextBox txtPerimeter,
                                   TextBox txtArea, PictureBox picCanvas)
        {
            mSize = 0.0f;
            mPerimeter = 0.0f;
            mArea = 0.0f;

            txtSize.Text = "";
            txtPerimeter.Text = "";
            txtArea.Text = "";

            txtSize.Focus();
            picCanvas.Refresh();
        }

        // Dibujar triángulo equilátero
        public void PlotShape(PictureBox picCanvas)
        {
            mGraphs = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Green, 3);

            float altura = (float)(Math.Sqrt(3) / 2 * mSize * SF);

            PointF p1 = new PointF(picCanvas.Width / 2, picCanvas.Height / 2 - altura / 2);
            PointF p2 = new PointF(picCanvas.Width / 2 - (mSize * SF) / 2, picCanvas.Height / 2 + altura / 2);
            PointF p3 = new PointF(picCanvas.Width / 2 + (mSize * SF) / 2, picCanvas.Height / 2 + altura / 2);

            PointF[] puntos = { p1, p2, p3 };
            mGraphs.DrawPolygon(mPen, puntos);
        }

        // Cerrar formulario
        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }
}
