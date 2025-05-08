using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            ObjCuadrado.InitializeData(txtSize, txtPerimeter, txtArea, picCanvas);
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
            ObjCuadrado.InitializeData(txtSize, txtPerimeter, txtArea, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjCuadrado.CloseForm(this);
        }
    }
}
