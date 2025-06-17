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
    public partial class FrmRomboide : Form
    {
        CRomboide ObjRomboide = new CRomboide();

        private static FrmRomboide instance;

        public FrmRomboide()
        {
            InitializeComponent();
        }

        public static FrmRomboide GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmRomboide();
            }
            return instance;
        }

        private void FrmRomboide_Load(object sender, EventArgs e)
        {
            ObjRomboide.InitializeData(txtBase, txtHeight, txtSize,
                txtPerimeter, txtArea, picCanvas);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Leer los datos de entrada
            ObjRomboide.ReadData(txtBase, txtHeight, txtSize);

            // Calcular el perímetro y el área
            ObjRomboide.PerimeterRomboide();
            ObjRomboide.AreaRomboide();

            // Imprimir los resultados en los TextBox correspondientes
            ObjRomboide.PrintData(txtPerimeter, txtArea);

            // Graficar el rectángulo en el PictureBox
            ObjRomboide.PlotShape(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjRomboide.InitializeData(txtBase, txtHeight, txtSize,
                txtPerimeter, txtArea, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjRomboide.CloseForm(this);
        }
    }
}
