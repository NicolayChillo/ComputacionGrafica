using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
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
        private float mScale = 20;      // Escala del cuadrado
        private Pen mPen;               // Objeto Pen -> Lapiz
        private float mPosX;        //Posición X
        private float mPosY;        //Posición Y
        private float mAngle = 0;
        private PointF[] mPoints; 

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
        public void InitializeData(TextBox txtSize, TextBox txtPerimeter,
                                    TextBox txtArea, PictureBox picCanvas, TrackBar trBarScale)
        {
            mSize = 0.0f;
            mPerimeter = 0.0f; mArea = 0.0f;

            txtSize.Text = "";
            txtPerimeter.Text = ""; txtArea.Text = "";

            float maxScale = 1.0f;

            if(float.TryParse(txtSize.Text, out float size) && size > 0)
            {
                float scaleX = (float)picCanvas.Width / size;
                float scaleY = (float)picCanvas.Height / size;
                maxScale = (float)Math.Min(scaleX, scaleY);

            }

            int maxValue = (int)(maxScale * 10);

            trBarScale.Minimum = 1;     // Valor mínimo de la escala
            trBarScale.Maximum = Math.Max(1, maxValue);   // Valor maximo de la escala
            trBarScale.Value = 20;      // Valor inicial de la escala
            ChangeScale(trBarScale.Value / 10.0f);

            // Mantiene el cursor titilando en una caja de texto
            txtSize.Focus();
            picCanvas.Refresh();
        }

        // Función que dibuja el cuadrado en el canvas
        public void PlotShape(PictureBox picCanvas)
        {
            picCanvas.Refresh();

            mGraphs = picCanvas.CreateGraphics();   // Inicializa el objeto Graphics

            float size = mSize * mScale;

            //Validación para no dibujar fuera del canvas
            if (size > picCanvas.Width || size > picCanvas.Height)
            {
                MessageBox.Show("El cuadrado es demasiado grande para ser dibujado", "Error");
                return;
            }

            mPosX = (picCanvas.Width / 2) - ((mSize * mScale) / 2);
            mPosY = (picCanvas.Height / 2) - ((mSize * mScale) / 2);

            // Inicializa el objeto Pen
            mPen = new Pen(Color.Yellow, 3);
            // Dibuja el rectángulo
            mGraphs.DrawRectangle(mPen, mPosX, mPosY, mSize * mScale, mSize * mScale);
        }

        // Función para Traslación
        public void Traslate(float dx, float dy)
        { 
            mPosX += dx;
            mPosY += dy;
        }

        public void ChangeScale(float scale)
        {
            mScale = scale;
        }

        public void CalculateVertex()
        { 
            float lado = mSize * mScale;

            mPoints = new PointF[]
            {
                new Point((int)mPosX, (int)mPosY),
                new PointF((int)mPosX + lado, mPosY),
                new PointF(mPosX + lado, mPosY + lado),           // Inferior derecha
                new PointF(mPosX, mPosY + lado) 
            };
        }
        public void RotateAnti(float grades)
        {
            if (mPoints == null || mPoints.Length != 4)
                CalculateVertex();

            float anguleRad = grades * (float)Math.PI / 180;

            float cx = 0, cy = 0;
            for (int i = 0; i < mPoints.Length; i++)
            {
                cx += mPoints[i].X;
                cy += mPoints[i].Y;
            }
            cx /= mPoints.Length;
            cy /= mPoints.Length;

            // Aplicar rotación a cada punto
            for (int i = 0; i < mPoints.Length; i++)
            {
                float x = mPoints[i].X - cx;
                float y = mPoints[i].Y - cy;

                float xRot = x * (float)Math.Cos(anguleRad) - y * (float)Math.Sin(anguleRad);
                float yRot = x * (float)Math.Sin(anguleRad) + y * (float)Math.Cos(anguleRad);

                mPoints[i] = new PointF(xRot + cx, yRot + cy);
            }
        }

        //Función que cierra un formulario
        public void CloseForm(Form ObjForm)
        {
            ObjForm.Close();
        }
    }
}
