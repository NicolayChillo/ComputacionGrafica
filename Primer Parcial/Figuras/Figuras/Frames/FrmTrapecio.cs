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
    public partial class FrmTrapecio : Form
    {
        CTrapecio ObjTrapecio = new CTrapecio();

        private static FrmTrapecio instance;

        public FrmTrapecio()
        {
            InitializeComponent();
        }

        public static FrmTrapecio GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmTrapecio();
            }
            return instance;
        }

        private void FrmTrapecio_Load(object sender, EventArgs e)
        {
            ObjTrapecio.InitializeData(txtBaseHigher, txtBaseLess, txtHeight, txtSize,
                txtPerimeter, txtArea, picCanvas);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Leer los datos de entrada
            ObjTrapecio.ReadData(txtBaseHigher, txtBaseLess, txtHeight, txtSize);

            // Calcular el perímetro y el área
            ObjTrapecio.PerimeterTrapecio();
            ObjTrapecio.AreaTrapecio();

            // Imprimir los resultados en los TextBox correspondientes
            ObjTrapecio.PrintData(txtPerimeter, txtArea);

            // Graficar el rectángulo en el PictureBox
            ObjTrapecio.PlotShape(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjTrapecio.InitializeData(txtBaseHigher, txtBaseLess, txtHeight, txtSize,
                txtPerimeter, txtArea, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjTrapecio.CloseForm(this);
        }
    }
}
