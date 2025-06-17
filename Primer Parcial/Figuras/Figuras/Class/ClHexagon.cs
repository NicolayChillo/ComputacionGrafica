using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figuras.Class
{
    internal class ClHexagon
    {
        //Datos Miembro (Atributos9

        //Lado del hexágono
        private float side;
        //Apotema del hexágono
        private float apothem;
        //Segmento 'b' del hexágono;
        private float b;
        //ángulo agudo del triángulo rectángilar APC
        private float angle;
        //Perímetro del hexágono
        private float perimeter;
        //Área del hexágono
        private float area;
        // Objeto que activa el modo gráfico
        private Graphics mGraphs;
        // Objeto que maneja un pincel para el relleno
        private SolidBrush mBrush;
        //Constante scale factor (Zoom In/Zoom Out)
        private const float SF = 20;
        //Objeto Punto que representa a los vértices del hexágono
        private PointF A, B, C, D, E, F, O;

        //Funciones miembro = Métodos

        //Constructor sin parámetros    
        public ClHexagon()
        {
            side = 0.0f;
            perimeter = 0.0f;
            area = 0.0f;
        }

        //Funcion que lee el lado del hexágono
        public void ReadData(TextBox txtSide)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSide.Text))
                {
                    MessageBox.Show("Ningún campo puede estar vacío.", "Error de entrada");
                    return;
                }
                if (!float.TryParse(txtSide.Text, out float side))
                {
                    MessageBox.Show("Ingrese solo números válidos.", "Error de entrada");
                    return;
                }
                if (side <= 0)
                {
                    MessageBox.Show("Los valores deben ser positivos.", "Error de entrada");
                    return;
                }
                this.side = side;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Mensaje de Error");
            }
        }
        //Función que calcula el perimetro del hexágono
        public void PerimeterHexagon()
        {
            perimeter = 6 * side;
        }

        //Función que calcula el área del hexágono
        public void AreaHexagon()
        {
            angle = 60.0F * (float)Math.PI / 180.0F;
            apothem = side * (float)Math.Sin(angle);
            
            area = perimeter * apothem / 2.0f;
        }

        //Función que imprime el perimetro y area del hexágono
        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        { 

            txtPerimeter.Text = perimeter.ToString();
            txtArea.Text = area.ToString();
        }

        //Funcion que calcula los valores de los seis vvértices del hexágono
        public void CalculateVertex()
        {
            angle = 60.0f * (float)Math.PI / 180.0f;
            b = side * (float)Math.Cos(angle);
            apothem = side * (float)Math.Sin(angle);

            A.X = b; A.Y = 0;
            B.X = side + b; B.Y = 0;
            C.X = 0; C.Y = apothem;
            D.X = side + 2.0f * b; D.Y = apothem;
            E.X = b; E.Y = 2.0f * apothem;
            F.X = side + b; F.Y = 2.0f * apothem;
            O.X = b + side / 2; O.Y = apothem;
        }

        //Función que grafica un hexágono con 6 triángulos de diferentes colores
        public void PlotShape(PictureBox picCanvas)
        { 
            mGraphs = picCanvas.CreateGraphics();

            CalculateVertex();


        }
    }
}

