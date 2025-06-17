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
    public partial class FrmRectangulo : Form
    {
        CRectangulo ObjRectangulo = new CRectangulo();

        private static FrmRectangulo instance;
        public FrmRectangulo()
        {
            InitializeComponent();
        }

        // Constructor privado para el patrón Singleton
        public static FrmRectangulo GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmRectangulo();
            }
            return instance;
        }
        private void FrmRectangulo_Load(object sender, EventArgs e)
        {
            ObjRectangulo.InitializeData(txtWidth,txtHeight, txtPerimeter, txtArea, picCanvas);

        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Leer los datos de entrada
            ObjRectangulo.ReadData(txtWidth,txtHeight);

            // Calcular el perímetro y el área
            ObjRectangulo.PerimeterRectangulo();
            ObjRectangulo.AreaRectangulo();

            // Imprimir los resultados en los TextBox correspondientes
            ObjRectangulo.PrintData(txtPerimeter, txtArea);

            // Graficar el rectángulo en el PictureBox
            ObjRectangulo.PlotShape(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Inicializar los datos y controles
            ObjRectangulo.InitializeData(txtWidth,txtHeight,txtPerimeter,txtArea,picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjRectangulo.CloseForm(this);
        }
    }
}
