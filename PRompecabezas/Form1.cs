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
    public partial class FRompecabezas : Form
    {
        String foto;
        Panel[] pan = new Panel[25];
        PictureBox[] pic = new PictureBox[25];
        int np;
        public FRompecabezas()// Constructor
        {
            InitializeComponent();
            pan[0] = panel1;
            pan[1] = panel2;
            pan[2] = panel3;
            pan[3] = panel4;
            pan[4] = panel5;
            pan[5] = panel6;
            pan[6] = panel7;
            pan[7] = panel8;
            pan[8] = panel9;
            pan[9] = panel10;
            pan[10] = panel11;
            pan[11] = panel12;
            pan[12] = panel13;
            pan[13] = panel14;
            pan[14] = panel15;
            pan[15] = panel16;
            pan[16] = panel17;
            pan[17] = panel18;
            pan[18] = panel19;
            pan[19] = panel20;
            pan[20] = panel21;
            pan[21] = panel22;
            pan[22] = panel23;
            pan[23] = panel24;
            pan[24] = panel25;
            pic[0] = pictureBox1;
            pic[1] = pictureBox2;
            pic[2] = pictureBox3;
            pic[3] = pictureBox4;
            pic[4] = pictureBox5;
            pic[5] = pictureBox6;
            pic[6] = pictureBox7;
            pic[7] = pictureBox8;
            pic[8] = pictureBox9;
            pic[9] = pictureBox10;
            pic[10] = pictureBox11;
            pic[11] = pictureBox12;
            pic[12] = pictureBox13;
            pic[13] = pictureBox14;
            pic[14] = pictureBox15;
            pic[15] = pictureBox16;
            pic[16] = pictureBox17;
            pic[17] = pictureBox18;
            pic[18] = pictureBox19;
            pic[19] = pictureBox20;
            pic[20] = pictureBox21;
            pic[21] = pictureBox22;
            pic[22] = pictureBox23;
            pic[23] = pictureBox24;
            pic[24] = pictureBox25;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            Panel p = sender as Panel;
            if(e.Data.GetDataPresent(typeof(PictureBox)))
            {
                pic[np].Parent = p;
                pic[np].BringToFront();
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent(typeof(PictureBox)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox p = sender as PictureBox;
            np = Convert.ToInt16(p.Tag.ToString());
            if(e.Button== MouseButtons.Left)
            {
                DoDragDrop(pic[np], DragDropEffects.Move);
            }
            else
            {
                if (e.Button == MouseButtons.Right)
                {
                    pic[np].Image = gira(pic[np].Image);
                }
            }
        }

        private void BSal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BSel_Click(object sender, EventArgs e)
        {
            foto = "";
            while(foto == "")
            {
                OFD1.ShowDialog();
                foto = OFD1.FileName;
            }
            PbOri.Load(foto);
            romper();
        }
        public void romper()
        {
            Bitmap BitO, bit;
            int anc, lar, x, y, i;
            Rectangle area;
            BitO = new Bitmap(foto);
            anc = BitO.Width / 5;
            lar = BitO.Height / 5;
            i = 0;
            x = 0;
            y = 0;
            do
            {
                area = new Rectangle(x, y, anc, lar);
                bit = new Bitmap(anc, lar);
                bit = BitO.Clone(area, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                pic[i].Image = bit;
                if ((i + 1) % 5 == 0)
                {
                    y = y + lar;
                    x = 0;
                }
                else
                {
                    x = x + anc;
                }
                i++;
            } while (i < 25);
            revolver();
        }
        public Image gira (Image ima)
        {
            Bitmap bit;
            bit = new Bitmap(ima);
            bit.RotateFlip(RotateFlipType.Rotate90FlipNone);
            return bit;
        }
        public void revolver()
        {
            Random r = new Random();
            int i, a, v, j;
            int[] n = new int[25];
            n[0] = 0; n[1] = 1; n[2] = 2; n[3] = 3; n[4] = 4; n[5] = 5; n[6] = 6; n[7] = 7; n[8] = 8; n[9] = 9; n[10] = 10; n[11] = 11; n[12] = 12; n[12] = 12; n[13] = 13; n[14] = 14; n[15] = 15; n[16] = 16; n[17] = 17; n[18] = 18; n[19] = 19; n[20] = 20; n[21] = 21; n[22] = 22; n[23] = 23; n[24] = 24;
            for(i=0; i<24; i++)
            {
                a = r.Next(i + 1, 24);
                v = n[i];
                n[i] = n[a];
                n[a] = v;
            }
            for(i=0; i<=24; i++)
            {
                pic[i].Parent = pan[n[i]];
                a = r.Next(1, 25);
                for (j=1; j<=a; j++)
                {
                    pic[i].Image = gira(pic[i].Image);
                }
            }
        }

        private void FRompecabezas_Load(object sender, EventArgs e)
        {

        }
    }
}
