using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms.VisualStyles;

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
        int instructionPointer = 0;
        int waitingTicks = 0;
        bool render = true;
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
            if (renderSlowly)
            {
                textBoxError.Text = "";
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
                instructionPointer = 0;
                string[] code = richTextBoxCode.Text.Split('\n');
                // renders set of horizontal scan lines
                if (slowY > 0)
                {
                    for (int y = 0; y < slowY; y++)
                    {
                        for (int x = 0; x < 640 / 4.0; x++)
                        {
                            Tick(x, y, code, e);
                        }
                    }
                }
                // renders final scan line
                for (int x = 0; x < slowX / 4; x++)
                {
                    Tick(x, slowY, code, e);
                }
                slowX += 4;
            }
            else
            {
                textBoxError.Text = "";
                // paints the form quickly
                e.Graphics.Clear(Color.White);
                instructionPointer = 0;
                string[] code = richTextBoxCode.Text.Split('\n');
                for (int y = 0; y < 480 / 4; y++)
                {
                    for (int x = 0; x < 640 / 4; x++)
                    {
                        Tick(x, y, code, e);
                    }
                }
            }
        }
        private void Tick(int x, int y, string[] code, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            if (waitingTicks > 0)
            {
                waitingTicks--;
            }
            else
            {
                ProcessInstruction(instructionPointer, code);
                instructionPointer++;
            }
            if (!render)
            {
                e.Graphics.FillRectangle(brush, x * 4, y * 4, 4, 4);
                return;
            }
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
            brush.Dispose();
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
        private void CatchError(int call, int line, string[] code)
        {
            if (textBoxError.Text == "")
            {
                if (call == -1)
                {
                    // for now, it's okay. This error calls when there isn't an instruction read
                }
                else if (call == -2)
                {
                    textBoxError.Text = $"Unreadable instruction at line {line + 1} \"{code[line]}\"";
                }
                else if (call == -3)
                {
                    textBoxError.Text = $"Unexpected parameter value at line {line + 1} \"{code[line]}\"";
                }
                else if (call == -3)
                {
                    textBoxError.Text = $"Unexpected parameter value at line {line + 1} \"{code[line]}\"";
                }
                else
                {
                    textBoxError.Text = $"Unexpected error of value \"{call}\", {line + 1}. \"{code[line]}\"";
                }
            }
        }
        private int ProcessInstruction(int instructionIdx, string[] code)
        {
            if (instructionIdx >= code.Length)
            {
                CatchError(-1, instructionIdx, code);
                return -1;
            }
            else
            {
                if (code[instructionIdx] == "turnoff")
                {
                    render = false;
                    return 1;
                }
                else if (code[instructionIdx] == "turnon")
                {
                    render = true;
                    return 2;
                }
                else if (code[instructionIdx].StartsWith("wait"))
                {
                    string[] parts = code[instructionIdx].Split(' ');
                    if (parts[0] == "wait")
                    {
                        try
                        {
                            int t = int.Parse(parts[1]);
                            waitingTicks = t;
                            return 0;
                        }
                        catch
                        {
                            CatchError(-3, instructionIdx, code);
                            return -3;
                        }
                    }
                    else
                    {
                        CatchError(-2, instructionIdx, code);
                        return -2;
                    }
                }
                else if (code[instructionIdx].StartsWith("m7register"))
                {
                    if (code[instructionIdx].Length < 13)
                    {
                        CatchError(-4, instructionIdx, code);
                        return -4;
                    }
                    char tmp = code[instructionIdx][10];
                    string part = code[instructionIdx].Split(' ')[1];
                    int value;
                    try
                    {
                        value = int.Parse(part);
                    }
                    catch
                    {
                        CatchError(-3, instructionIdx, code);
                        return -3;
                    }
                    switch (tmp)
                    {
                        case '0':
                            {
                                a = value;
                                textBoxXStretch.Text = a.ToString();
                                return 0;
                            }
                        case '1':
                            {
                                b = value;
                                textBoxYStretch.Text = b.ToString();
                                return 0;
                            }
                        case '2':
                            {
                                c = value;
                                textBoxXAxis.Text = c.ToString();
                                return 0;
                            }
                        case '3':
                            {
                                d = value;
                                textBoxYAxis.Text = d.ToString();
                                return 0;
                            }
                        case '4':
                            {
                                xt = value;
                                textBoxShiftX.Text = xt.ToString();
                                return 0;
                            }
                        case '5':
                            {
                                yt = value;
                                textBoxShiftX.Text = yt.ToString();
                                return 0;
                            }
                        case '6':
                            {
                                h = value;
                                textBoxXShift.Text = h.ToString();
                                return 0;
                            }
                        case '7':
                            {
                                v = value;
                                textBoxYShift.Text = v.ToString();
                                return 0;
                            }
                        default:
                            {
                                CatchError(-2, instructionIdx, code);
                                return -2;
                            }
                    }
                }
                else if (code[instructionIdx] != "")
                {
                    CatchError(-2, instructionIdx, code);
                    return -2;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
