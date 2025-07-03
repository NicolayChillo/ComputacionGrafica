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
    public partial class FrmRecorte : Form
    {
        public FrmRecorte()
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
        private void cohenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmCohenShuterland());
        }

        private void hodgmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmShuterlandHodgman());
        }
    }
}
