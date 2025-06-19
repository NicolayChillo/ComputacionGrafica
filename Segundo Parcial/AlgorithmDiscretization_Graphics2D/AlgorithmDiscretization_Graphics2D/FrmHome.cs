using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorithmDiscretization_Graphics2D
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void OpenForm(Form formulario)
        {
            panelContainer.Controls.Clear();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(formulario);
            formulario.Show();
        }

        private void dDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmAlgorithmDDA());
            this.Text = "Algoritmo DDA";
        }

        private void bressenhanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmAlgorithmBresenham());
            this.Text = "Algoritmo de Bresenham";
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmAlgorithmCircle());
            this.Text = "Algoritmo del Circulo";
        }

        private void rellenoDeFigurasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmPolygon());
            this.Text = "Algoritmo de Relleno de Figuras";
        }

        
    }
}
