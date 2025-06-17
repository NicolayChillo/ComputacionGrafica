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
    public partial class FrmRombo : Form
    {

        CRombo ObjRombo = new CRombo();

        private static FrmRombo instance;

        public FrmRombo()
        {
            InitializeComponent();
        }

        public static FrmRombo GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmRombo();
            }
            return instance;
        }

        private void FrmRombo_Load(object sender, EventArgs e)
        {
            ObjRombo.InitializeData(txtDiagHigher, txtDiagLess, txtSize,
                txtPerimeter, txtArea, picCanvas);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Leer los datos de entrada
            ObjRombo.ReadData(txtDiagHigher, txtDiagLess, txtSize);

            // Calcular el perímetro y el área
            ObjRombo.PerimeterRombo();
            ObjRombo.AreaRombo();

            // Imprimir los resultados en los TextBox correspondientes
            ObjRombo.PrintData(txtPerimeter, txtArea);

            // Graficar el rectángulo en el PictureBox
            ObjRombo.PlotShape(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjRombo.InitializeData(txtDiagHigher, txtDiagLess, txtSize,
                txtPerimeter, txtArea, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjRombo.CloseForm(this);
        }
    }
}
