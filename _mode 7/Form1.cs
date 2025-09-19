using System.Runtime.CompilerServices;

namespace _mode_7
{
    public partial class FormMode7 : Form
    {
        public Color[,] colors = new Color[512, 512];
        int width = 512, height = 512;
        int a = 8, b = 8, c = 0, d = 0; // params for x scale and y scale
        int h = 0, v = 0; // params for start transform
        int xt = 0, yt = 0;
        public FormMode7()
        {
            InitializeComponent();
            Random rand = new Random();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    colors[i, j] = Color.FromArgb((int)((i / (double)width) * 256), (int)((j / (double)height) * 256), 0);
                }
            }
        }

        private void timerTick_Tick(object sender, EventArgs e)
        {
            // tick event
            this.Refresh();
        }

        private void FormMode7_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.FromArgb(0, 0, 0));
            // paints the form
            for (int y = 0; y < 256 / 4; y++)
            {
                for (int x = 0; x < 248 / 4; x++)
                {

                    int x0 = xt + ((x - h) * a + (y - v) * c) + x;
                    int y0 = yt + ((y - v) * b + (x - h) * d) + y;
                    if (x0 < 0 || x0 > width - 1)
                    {
                        brush.Color = Color.FromArgb(200, 200, 200);
                        e.Graphics.FillRectangle(brush, x * 4, y * 4, 4, 4);
                        continue;
                    }
                    if (y0 < 0 || y0 > height - 1)
                    {
                        brush.Color = Color.FromArgb(200, 200, 200);
                        e.Graphics.FillRectangle(brush, x * 4, y * 4, 4, 4);
                        continue;
                    }
                    brush.Color = colors[x0, y0];
                    e.Graphics.FillRectangle(brush, x * 4, y * 4, 4, 4);
                }
            }
        }

        private void XStrechChanged(object sender, EventArgs e)
        {
            string text = textBoxXStretch.Text;
            if (string.IsNullOrEmpty(text))
            {
                a = 0;
                return;
            }
            a = int.Parse(text);
        }
        private void YStrechChanged(object sender, EventArgs e)
        {
            string text = textBoxYStretch.Text;
            if (string.IsNullOrEmpty(text))
            {
                b = 0;
                return;
            }
            b = int.Parse(text);
        }
        private void XPos(object sender, EventArgs e)
        {
            string text = textBoxXAxis.Text;
            if (string.IsNullOrEmpty(text))
            {
                c = 0;
                return;
            }
            c = int.Parse(text);
        }
        private void YPos(object sender, EventArgs e)
        {
            string text = textBoxYAxis.Text;
            if (string.IsNullOrEmpty(text))
            {
                d = 0;
                return;
            }
            d = int.Parse(text);
        }
        private void XShift(object sender, EventArgs e)
        {
            string text = textBoxXShift.Text;
            if (string.IsNullOrEmpty(text))
            {
                h = 0;
                return;
            }
            h = int.Parse(text);
        }
        private void YShift(object sender, EventArgs e)
        {
            string text = textBoxYShift.Text;
            if (string.IsNullOrEmpty(text))
            {
                v = 0;
                return;
            }
            v = int.Parse(text);
        }

        private void textBoxShiftX_TextChanged(object sender, EventArgs e)
        {
            string text = textBoxShiftX.Text;
            if (string.IsNullOrEmpty(text))
            {
                xt = 0;
                return;
            }
            xt = int.Parse(text);
        }

        private void textBoxShiftY_TextChanged(object sender, EventArgs e)
        {
            string text = textBoxShiftY.Text;
            if (string.IsNullOrEmpty(text))
            {
                yt = 0;
                return;
            }
            yt = int.Parse(text);
        }
    }
}
