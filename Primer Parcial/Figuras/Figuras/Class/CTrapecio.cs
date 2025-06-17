using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figuras
{
    internal class CTrapecio
    {
        // Atributos
        private float mBaseHigher;      // Base mayor
        private float mBaseLess;        // Base menor
        private float mHeight;           // Altura
        private float mSize;            // Lado
        private float mPerimeter;       // Perímetro
        private float mArea;            // Área
        private Graphics mGraphs;       // Objeto Graphics
        private Pen mPen;               // Objeto Pen -> Lápiz
        private const float SF = 10;    // Factor de escala

        // Constructor
        public CTrapecio()
        {
            mBaseHigher = mBaseLess = mHeight = mSize = 0.0f;
            mPerimeter = mArea = 0.0f;
        }

        // Leer datos
        public void ReadData(TextBox txtBaseHigher, TextBox txtBaseLess, 
                            TextBox txtHeight, TextBox txtSize)
        {
            try
            {
                if (!float.TryParse(txtBaseHigher.Text, out mBaseHigher) || mBaseHigher <= 0 ||
                    !float.TryParse(txtBaseLess.Text, out mBaseLess) || mBaseLess <= 0 ||
                    !float.TryParse(txtHeight.Text, out mHeight) || mHeight <= 0 ||
                    !float.TryParse(txtSize.Text, out mSize) || mSize <= 0)
                {
                    MessageBox.Show("Ingrese solo números válidos y positivos en todos los campos.", "Error de entrada");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Mensaje de Error");
            }
        }

        // Calcular perímetro
        public void PerimeterTrapecio()
        {
            mPerimeter = mBaseHigher + mBaseLess + 2 * mSize;
        }

        // Calcular área
        public void AreaTrapecio()
        {
            mArea = ((mBaseHigher + mBaseLess) * mHeight) / 2;
        }

        // Mostrar resultados
        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = mPerimeter.ToString("F2");
            txtArea.Text = mArea.ToString("F2");
        }

        // Inicializar datos
        public void InitializeData(TextBox txtBaseHigher, TextBox txtBaseLess,
                                   TextBox txtHeight, TextBox txtSize,
                                   TextBox txtPerimeter, TextBox txtArea,
                                   PictureBox picCanvas)
        {
            mBaseHigher = mBaseLess = mHeight = mSize = 0.0f;
            mPerimeter = mArea = 0.0f;

            txtBaseHigher.Text = "";
            txtBaseLess.Text = "";
            txtHeight.Text = "";
            txtSize.Text = "";
            txtPerimeter.Text = "";
            txtArea.Text = "";

            txtBaseHigher.Focus();
            picCanvas.Refresh();
        }

        // Dibujar trapecio isósceles
        public void PlotShape(PictureBox picCanvas)
        {
            mGraphs = picCanvas.CreateGraphics();
            mPen = new Pen(Color.Orange, 3);

            float xCentro = picCanvas.Width / 2;
            float yCentro = picCanvas.Height / 2;

            float bM = mBaseHigher * SF;
            float bm = mBaseLess * SF;
            float h = mHeight * SF;

            float x1 = xCentro - bM / 2;
            float x2 = xCentro + bM / 2;
            float x3 = xCentro + bm / 2;
            float x4 = xCentro - bm / 2;

            float y1 = yCentro - h / 2;
            float y2 = yCentro + h / 2;

            PointF[] puntos = new PointF[]
            {
            new PointF(x1, y1),  // esquina inferior izquierda (base mayor)
            new PointF(x2, y1),  // esquina inferior derecha
            new PointF(x3, y2),  // esquina superior derecha (base menor)
            new PointF(x4, y2)   // esquina superior izquierda
            };

            mGraphs.DrawPolygon(mPen, puntos);
        }

        // Cerrar formulario
        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }
}
