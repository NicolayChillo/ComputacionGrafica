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
    public partial class FrmDeltoide : Form
    {
        CDeltoide ObjDeltoide = new CDeltoide();

        private static FrmDeltoide instance;

        public FrmDeltoide()
        {
            InitializeComponent();
        }

        public static FrmDeltoide GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmDeltoide();
            }
            return instance;
        }

        private void FrmDeltoide_Load(object sender, EventArgs e)
        {
            ObjDeltoide.InitializeData(txtBaseSup, txtBaseLower, txtHeight,
                txtPerimeter, txtArea, picCanvas);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Leer los datos de entrada
            ObjDeltoide.ReadData(txtBaseSup, txtBaseLower, txtHeight);

            // Calcular el perímetro y el área
            ObjDeltoide.PerimeterDeltoide();
            ObjDeltoide.AreaDeltoide();

            // Imprimir los resultados en los TextBox correspondientes
            ObjDeltoide.PrintData(txtPerimeter, txtArea);

            // Graficar el rectángulo en el PictureBox
            ObjDeltoide.PlotShape(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjDeltoide.InitializeData(txtBaseSup, txtBaseLower, txtHeight,
                txtPerimeter, txtArea, picCanvas);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjDeltoide.CloseForm(this);
        }
    }
}
