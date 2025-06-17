using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Figuras.Class
{
    internal class CPentagonFlower
    {
        private float side;
        private float sideBig;
        private float angleIntern;
        private float angle;
        private Graphics mGraph;
        private Brush mBrush;
        private Pen mPen;

        private const float SF = 20;

        public CPentagonFlower()
        {
            side = 0.0f;
            sideBig = 0.0f;
            angleIntern = 0.0f;
            angle = 0.0f;
        }

        public void ReadData(TextBox txtSide)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSide.Text) )
                {
                    MessageBox.Show("Ningún campo puede estar vacío.", "Error de entrada");
                    return;
                }
                if (!float.TryParse(txtSide.Text, out float side) )
                {
                    MessageBox.Show("Ingrese solo números válidos.", "Error de entrada");
                    return;
                }
                if (side <= 0 )
                {
                    MessageBox.Show("Los valores deben ser positivos.", "Error de entrada");
                    return;
                }
                this.side = side;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void InitializeData(TextBox txtSide, PictureBox picCanvas)
        {
            side = 0.0f;

            txtSide.Text = "";

            txtSide.Focus();
            picCanvas.Refresh();

        }

        public void CalucalteVertex()
        {
            float baseT = (float)Math.Sqrt(2 * (side * side) - 2 * (side *side) * (float)Math.Cos(1 / 5 * (float)Math.PI));
            sideBig = 2 * side + baseT;

        }
    }
}
