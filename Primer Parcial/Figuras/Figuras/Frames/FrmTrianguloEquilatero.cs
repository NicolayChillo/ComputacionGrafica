using System;
using System.Windows.Forms;

namespace Figuras
{
    public partial class FrmTrianguloEquilatero : Form
    {
        CTrianguloEquilatero ObjTriEquilatero = new CTrianguloEquilatero();

        private static FrmTrianguloEquilatero instance;

        public FrmTrianguloEquilatero()
        {
            InitializeComponent();
        }

        public static FrmTrianguloEquilatero GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmTrianguloEquilatero();
            }
            return instance;
        }

        private void FrmTrianguloEquilatero_Load(object sender, EventArgs e)
        {
            ObjTriEquilatero.InitializeData(txtSize, txtPerimeter, txtArea, picCanvas);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Leer los datos de entrada
            ObjTriEquilatero.ReadData(txtSize);

            // Calcular el perímetro y el área
            ObjTriEquilatero.PerimeterTriangulo();
            ObjTriEquilatero.AreaTriangulo();

            // Imprimir los resultados en los TextBox correspondientes
            ObjTriEquilatero.PrintData(txtPerimeter, txtArea);

            // Graficar el rectángulo en el PictureBox
            ObjTriEquilatero.PlotShape(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjTriEquilatero.InitializeData(txtSize, txtPerimeter, txtArea, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjTriEquilatero.CloseForm(this);
        }
    }
}
