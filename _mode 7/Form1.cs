using System.Runtime.CompilerServices;

namespace _mode_7
{
    public partial class FormMode7 : Form
    {
        public Color[,] colors = new Color[1024, 1024];
        int width = 1024, height = 1024;
        int a = 8, b = 8, c = 0, d = 0; // params for x scale and y scale
        int h = 0, v = 0;
        int xt = 0, yt = 0;
        bool renderSlowly = true;
        int slowX = 0;
        int slowY = 0;
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
            this.Invalidate();
        }

        private void FormMode7_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            if (renderSlowly)
            {
                if (slowY >= 480)
                {
                    slowY = 0;
                    slowX = 0;
                }
                if (slowX >= 640)
                {
                    slowX = 0;
                    slowY += 1;
                }
                // renders set of horizontal scan lines
                if (slowY > 0)
                {
                    for (int y = 0; y < slowY; y++)
                    {
                        for (int x = 0; x < 640 / 4.0; x++)
                        {
                            int x0 = xt + ((x - h) * a + (y - v) * c) + x;
                            int y0 = yt + ((y - v) * b + (x - h) * d) + y;
                            if (x0 < 0 || x0 > width - 1)
                            {
                                brush.Color = Color.FromArgb(200, 200, 200);
                                e.Graphics.FillRectangle(brush, x * 4, y * 4, 4, 4);
                            }
                            else if (y0 < 0 || y0 > height - 1)
                            {
                                brush.Color = Color.FromArgb(200, 200, 200);
                                e.Graphics.FillRectangle(brush, x * 4, y * 4, 4, 4);
                            }
                            else
                            {
                                brush.Color = colors[x0, y0];
                                e.Graphics.FillRectangle(brush, x * 4, y * 4, 4, 4);
                            }
                            if (x > 512 / 4 || y > 424 / 4) // displays blackened border
                            {
                                brush.Color = Color.FromArgb(127, 0, 0, 0);
                                e.Graphics.FillRectangle(brush, x * 4, y * 4, 4, 4);
                            }
                        }
                    }
                }
                // renders final scan line
                for (int x = 0; x < slowX / 4; x++)
                {
                    int x0 = xt + ((x - h) * a + (slowY - v) * c) + x;
                    int y0 = yt + ((slowY - v) * b + (x - h) * d) + slowY;
                    if (x0 < 0 || x0 > width - 1)
                    {
                        brush.Color = Color.FromArgb(200, 200, 200);
                        e.Graphics.FillRectangle(brush, x * 4, slowY * 4, 4, 4);
                    }
                    else if (y0 < 0 || y0 > height - 1)
                    {
                        brush.Color = Color.FromArgb(200, 200, 200);
                        e.Graphics.FillRectangle(brush, x * 4, slowY * 4, 4, 4);
                    }
                    else
                    {
                        brush.Color = colors[x0, y0];
                        e.Graphics.FillRectangle(brush, x * 4, slowY * 4, 4, 4);
                    }
                    if (x > 512 / 4 || slowY > 424 / 4) // displays blackened border
                    {
                        brush.Color = Color.FromArgb(127, 0, 0, 0);
                        e.Graphics.FillRectangle(brush, x * 4, slowY * 4, 4, 4);
                    }
                }
                slowX += 4;
            }
            else
            {
                // paints the form quickly
                e.Graphics.Clear(Color.White);
                for (int y = 0; y < 480 / 4; y++)
                {
                    for (int x = 0; x < 640 / 4; x++)
                    {
                        int x0 = xt + ((x - h) * a + (y - v) * c) + x;
                        int y0 = yt + ((y - v) * b + (x - h) * d) + y;
                        if (x0 < 0 || x0 > width - 1)
                        {
                            brush.Color = Color.FromArgb(200, 200, 200);
                            e.Graphics.FillRectangle(brush, x * 4, y * 4, 4, 4);
                        }
                        else if (y0 < 0 || y0 > height - 1)
                        {
                            brush.Color = Color.FromArgb(200, 200, 200);
                            e.Graphics.FillRectangle(brush, x * 4, y * 4, 4, 4);
                        }
                        else
                        {
                            brush.Color = colors[x0, y0];
                            e.Graphics.FillRectangle(brush, x * 4, y * 4, 4, 4);
                        }
                        if (x > 512 / 4 || y > 424 / 4) // displays blackened border
                        {
                            brush.Color = Color.FromArgb(127, 0, 0, 0);
                            e.Graphics.FillRectangle(brush, x * 4, y * 4, 4, 4);
                        }
                    }
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

        private void checkBoxRenderSlowly_CheckedChanged(object sender, EventArgs e)
        {
            slowX = 0;
            slowY = 0;
            renderSlowly = checkBoxRenderSlowly.Checked;
        }
    }
}
