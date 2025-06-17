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
    public partial class FrmEstrella : Form
    {
        CEstrella ObjEstrella = new CEstrella();

        private static FrmEstrella instance;

        public FrmEstrella()
        {
            InitializeComponent();
        }

        public static FrmEstrella GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmEstrella();
            }
            return instance;
        }

        private void FrmEstrella_Load(object sender, EventArgs e)
        {
            ObjEstrella.InitializeData(txtRadius, txtPerimeter, txtArea, picCanvas);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Leer los datos de entrada
            ObjEstrella.ReadData(txtRadius);

            // Calcular el perímetro y el área
            ObjEstrella.PerimeterEstrella();
            ObjEstrella.AreaEstrella();

            // Imprimir los resultados en los TextBox correspondientes
            ObjEstrella.PrintData(txtPerimeter, txtArea);

            // Graficar el rectángulo en el PictureBox
            ObjEstrella.PlotShape(picCanvas);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ObjEstrella.InitializeData(txtRadius, txtPerimeter, txtArea, picCanvas);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjEstrella.CloseForm(this);
        }
    }
}
