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
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        private void cuadradoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCuadrado frmCuadrado = FrmCuadrado.GetInstance();
            frmCuadrado.MdiParent = this;
            frmCuadrado.Show();
        }

        private void rectánguloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRectangulo frmRectangulo = FrmRectangulo.GetInstance();
            frmRectangulo.MdiParent = this;
            frmRectangulo.Show();
        }

        private void estrellaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEstrella frmEstrella = FrmEstrella.GetInstance();
            frmEstrella.MdiParent = this;
            frmEstrella.Show();
        }

        private void trianguloEquilateroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTrianguloEquilatero frmTrianguloEquilatero = FrmTrianguloEquilatero.GetInstance();
            frmTrianguloEquilatero.MdiParent = this;
            frmTrianguloEquilatero.Show();
        }

        private void trapecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTrapecio frmTrapecio = FrmTrapecio.GetInstance();
            frmTrapecio.MdiParent = this;
            frmTrapecio.Show();
        }

        private void trapezoideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTrapezoide frmTrapezoide = FrmTrapezoide.GetInstance();
            frmTrapezoide.MdiParent = this;
            frmTrapezoide.Show();
        }

        private void romboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRombo frmRombo = FrmRombo.GetInstance();
            frmRombo.MdiParent = this;
            frmRombo.Show();
        }

        private void romboideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRomboide frmRomboide = FrmRomboide.GetInstance();
            frmRomboide.MdiParent = this;
            frmRomboide.Show();
        }

        private void deltoideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDeltoide frmDeltoide = FrmDeltoide.GetInstance();
            frmDeltoide.MdiParent = this;
            frmDeltoide.Show();
        }
    }
}
