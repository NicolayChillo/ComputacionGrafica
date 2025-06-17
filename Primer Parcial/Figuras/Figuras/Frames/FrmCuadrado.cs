using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figuras
{
    public partial class FrmCuadrado : Form
    {
        CCuadrado ObjCuadrado = new CCuadrado();

        private static FrmCuadrado instance;
        public FrmCuadrado()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += FrmCuadrado_KeyDown ;
        }

        // Constructor privado para el patrón Singleton
        public static FrmCuadrado GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmCuadrado();
            }
            return instance;
        }
        private void FrmCuadrado_Load(object sender, EventArgs e)
        {
            ObjCuadrado.InitializeData(txtSize, txtPerimeter, txtArea, picCanvas, trBarScale);
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Leer los datos de entrada
            ObjCuadrado.ReadData(txtSize);

            // Calcular el perímetro y el área
            ObjCuadrado.PerimeterCuadrado();
            ObjCuadrado.AreaCuadrado();

            // Imprimir los resultados en los TextBox correspondientes
            ObjCuadrado.PrintData(txtPerimeter, txtArea);

            // Graficar el rectángulo en el PictureBox
            ObjCuadrado.PlotShape(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Inicializar los datos y controles
            ObjCuadrado.InitializeData(txtSize, txtPerimeter, txtArea, picCanvas, trBarScale);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjCuadrado.CloseForm(this);
        }

        // Funcion que permite mover el cuadrado con las teclas de flecha
        private void FrmCuadrado_KeyDown(object sender, KeyEventArgs e)
        {
            float step = 10f;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    ObjCuadrado.Traslate(0,-step);
                    break;
                case Keys.Down:
                    ObjCuadrado.Traslate(0,step);
                    break;
                case Keys.Left:
                    ObjCuadrado.Traslate(-step,0);
                    break;
                case Keys.Right:
                    ObjCuadrado.Traslate(step,0);
                    break;
            }
            ObjCuadrado.PlotShape(picCanvas);
        }

        private void trBarScale_Scroll(object sender, EventArgs e)
        {
            float newScale = trBarScale.Value / 10.0f;  // por ejemplo, si Value=25 => escala 2.5
            ObjCuadrado.ChangeScale(newScale);
            if (!string.IsNullOrWhiteSpace(txtSize.Text) && float.TryParse(txtSize.Text, out float size))
            {
                ObjCuadrado.PlotShape(picCanvas);
            }
        }

        private void btnRotateAnti_Click(object sender, EventArgs e)
        {
            float grades = 50.0f;
            ObjCuadrado.RotateAnti(grades);
            ObjCuadrado.PlotShape(picCanvas);
        }
    }
}
