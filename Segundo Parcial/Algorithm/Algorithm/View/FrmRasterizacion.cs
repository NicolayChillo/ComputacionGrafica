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
    public partial class FrmRasterizacion : Form
    {
        public FrmRasterizacion()
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
            OpenForm(new FrmDDA());
        }

        private void lINEASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmBresLines());
        }

        private void cIRCUNFERENCIAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmBresCircle());
        }

        private void eLIPSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmBresElipse());
        }
    }
}
