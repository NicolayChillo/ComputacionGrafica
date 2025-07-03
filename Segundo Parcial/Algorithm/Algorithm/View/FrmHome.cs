using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm.View
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void OpenForm(Form formulario)
        {
            panelContenido.Controls.Clear();
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(formulario);
            formulario.Show();
        }

        private void btnRasterizacion_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmRasterizacion());
            this.Text = "Algoritmo Rasterización";

        }

        private void btnRelleno_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmRelleno());
            this.Text = "Algoritmo Relleno";
        }
        private void btnRecorte_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmRecorte());
            this.Text = "Algoritmo Recortes";
        }
        private void btnCurvas_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmCurvas());
            this.Text = "Algoritmo Curvas";
        }

        
    }
}
