using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figuras
{
    internal class CEstrella
    {
        // Datos Miembro (Atributos)
        private float mRadius;           // Radio exterior
        private float mPerimeter;       // Perímetro aproximado
        private float mArea;            // Área aproximada
        private Graphics mGraphs;       // Objeto Graphics
        private const float SF = 10;    // Factor de escala
        private Pen mPen;               // Objeto Pen -> Lápiz

        // Constructor sin parámetros
        public CEstrella()
        {
            mRadius = 0.0f;
            mPerimeter = 0.0f;
            mArea = 0.0f;
        }

        // Leer datos de entrada
        public void ReadData(TextBox txtRadio)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtRadio.Text))
                {
                    MessageBox.Show("El campo no puede estar vacío.", "Error de entrada");
                    return;
                }

                if (!float.TryParse(txtRadio.Text, out float radio))
                {
                    MessageBox.Show("Ingrese solo números válidos.", "Error de entrada");
                    return;
                }

                if (radio <= 0)
                {
                    MessageBox.Show("El valor debe ser un número positivo.", "Error de entrada");
                    return;
                }

                mRadius = radio;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Mensaje de Error");
            }
        }

        // Calcular perímetro (aproximación)
        public void PerimeterEstrella()
        {
            // Aproximación usando 10 lados iguales
            float lado = 2 * mRadius * (float)Math.Sin(Math.PI / 5);
            mPerimeter = 10 * lado;
        }

        // Calcular área (aproximación)
        public void AreaEstrella()
        {
            // Aproximación del área de una estrella de 5 puntas
            mArea = (float)(2.5 * mRadius * mRadius * Math.Sin(2 * Math.PI / 5));
        }

        // Imprimir resultados
        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = mPerimeter.ToString("F2");
            txtArea.Text = mArea.ToString("F2");
        }

        // Inicializar controles
        public void InitializeData(TextBox txtRadius, TextBox txtPerimeter,
                                   TextBox txtArea, PictureBox picCanvas)
        {
            mRadius = 0.0f;
            mPerimeter = 0.0f;
            mArea = 0.0f;

            txtRadius.Text = "";
            txtPerimeter.Text = "";
            txtArea.Text = "";

            txtRadius.Focus();
            picCanvas.Refresh();
        }

        // Dibujar estrella
        public void PlotShape(PictureBox picCanvas)
        {
            mGraphs = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Red, 3);

            PointF[] puntos = new PointF[10];
            float angulo = -(float)(Math.PI / 2);
            float anguloPaso = (float)(Math.PI / 5);

            float radioInterior = mRadius * 0.5f;  // Escala para vértices internos

            for (int i = 0; i < 10; i++)
            {
                float r = (i % 2 == 0) ? mRadius * SF : radioInterior * SF;
                puntos[i] = new PointF(
                    picCanvas.Width / 2 + r * (float)Math.Cos(angulo),
                    picCanvas.Height / 2 + r * (float)Math.Sin(angulo)
                );
                angulo += anguloPaso;
            }

            mGraphs.DrawPolygon(mPen, puntos);
        }

        // Cerrar formulario
        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }

}
