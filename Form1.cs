using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proba
{
    public partial class Form1 : Form
    {
        List<int> a = new List<int> { 23, 11, 88, 45, 3 };
        List<int> r = new List<int> { 52, 31, 89, 41, 14 };
        int k = 5;
        const int meret = 100;
        Bitmap enkep = new Bitmap(meret, meret);
        Bitmap cskep = new Bitmap(meret, meret);
        int ido = 0;
        bool stopper_on = false;
        Random rnd = new Random();


        int V()
        {
            int vsz = 0;
            for (int i = 0; i < k; i++)
                vsz += a[i] * r[i];
            vsz %= 100;
            for (int i = 1; i < k; i++)
                r[i - 1] = r[i];
            r[k - 1] = vsz;
            return vsz;
        }

        private void Kapcsol(int x, int y, PictureBox p, Bitmap b)
        {
            //MessageBox.Show(b.GetPixel(x, y).ToString());
            b.SetPixel(x, y, b.GetPixel(x, y) == Color.White ? Color.Black : Color.White);
            p.Refresh();
        }

        private void Feherites(PictureBox p, Bitmap b)
        {
            for (int i = 0; i < meret; i++)
                for (int j = 0; j < meret; j++)
                    b.SetPixel(i, j, Color.White);
            p.Image=b;
        }

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = enkep;
            pictureBox2.Image = cskep;
            timer1.Interval = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                pictureBox1.Refresh();
                pictureBox2.Refresh();
            }

            else
                timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // label3.Text=ido++.ToString();
            //            Kapcsol(20+ido, 20, pictureBox1, enkep);
            enkep.SetPixel(V(), V(), Color.Black);
            pictureBox1.Refresh();
            cskep.SetPixel(rnd.Next(0,100), rnd.Next(0, 100), Color.Black);
            pictureBox2.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Feherites(pictureBox1, enkep);
            Feherites(pictureBox2, cskep);
        }
    }
}
