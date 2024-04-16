using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PRompecabezas
{
    public partial class ColorFondo : UserControl
    {	  private Color colorsSeleccionado = Color.Black;
        public ColorFondo()
        {
            get
            {
                return colorsSeleccionado;
            }
            set
            {
                colorsSeleccionado = value;
            }
        }
public SelectorDeColor()
        {
            InitializeComponent();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Actualizar();
        }

        private void Actualizar()
        {
            ColorSeleccionado = Color.FromArgb(hScrollBar1.Value, hScrollBar2.Value, hScrollBar3.Value);
            label1.BackColor = ColorSeleccionado;
            label2.Text = hScrollBar1.Value.ToString();
            label3.Text = hScrollBar1.Value.ToString();
            label4.Text = hScrollBar1.Value.ToString();
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            Actualizar();
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            Actualizar();
        }
    }
}
