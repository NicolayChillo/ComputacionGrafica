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
    public partial class FrmTrapezoide : Form
    {
        CTrapezoide ObjTrapezoide = new CTrapezoide();

        private static FrmTrapezoide instance;

        public FrmTrapezoide()
        {
            InitializeComponent();
        }

        public static FrmTrapezoide GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmTrapezoide();
            }
            return instance;
        }

        private void FrmTrapecio_Load(object sender, EventArgs e)
        {
            ObjTrapezoide.InitializeData(txtBaseHigher, txtBaseLess, txtHeight, txtSizeLeft,
                txtSizeRight, txtPerimeter, txtArea, picCanvas);
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Leer los datos de entrada
            ObjTrapezoide.ReadData(txtBaseHigher, txtBaseLess, txtHeight, txtSizeLeft, txtSizeRight);

            // Calcular el perímetro y el área
            ObjTrapezoide.PerimeterTrapezoide();
            ObjTrapezoide.AreaTrapezoide();

            // Imprimir los resultados en los TextBox correspondientes
            ObjTrapezoide.PrintData(txtPerimeter, txtArea);

            // Graficar el rectángulo en el PictureBox
            ObjTrapezoide.PlotShape(picCanvas);
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjTrapezoide.InitializeData(txtBaseHigher, txtBaseLess, txtHeight, txtSizeLeft,
                txtSizeRight, txtPerimeter, txtArea, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjTrapezoide.CloseForm(this);
        }
    }
}
