using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms.VisualStyles;

namespace _mode_7
{
    public partial class FormMode7 : Form
    {
        readonly static Token[] tokens = [
            new Token([new SingleToken(TokenType.LiteralString, "turnoff")]),
            new Token([new SingleToken(TokenType.LiteralString, "turnon")]),
            new Token([new SingleToken(TokenType.LiteralString, "wait "), new SingleToken(TokenType.Number)]),
            new Token([new SingleToken(TokenType.LiteralString, "m7register"), new SingleToken(TokenType.Number), new SingleToken(TokenType.LiteralCharacter, " "), new SingleToken(TokenType.Number)]),
            ];

        public Color[,] colors = new Color[1024, 1024];
        int width = 1024, height = 1024;

        // m7 variables
        int a = 8, b = 8, c = 0, d = 0;
        int h = 0, v = 0;
        int xt = 0, yt = 0;

        // rendering variables
        bool renderSlowly = true;
        int slowX = 0;
        int slowY = 0;

        // compiling variables
        byte[] compiledCode = new byte[65536];

        // operating variables
        int instructionPointer = 0;
        int waitingTicks = 0;
        bool render = true;
        public FormMode7()
        {
            InitializeComponent();
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
                e.Graphics.Clear(Color.White);
                instructionPointer = 0;
                string[] code = richTextBoxCode.Text.Split('\n');
                // renders set of horizontal scan lines
                if (slowY > 0)
                {
                    for (int y = 0; y < slowY; y++)
                    {
                        for (int x = 0; x < 640 / 4.0; x++)
                        {
                            Tick(x, y, e);
                        }
                    }
                }
                // renders final scan line
                for (int x = 0; x < slowX / 4; x++)
                {
                    Tick(x, slowY, e);
                }
                slowX += 4;
            }
            else
            {

                // paints the form quickly
                e.Graphics.Clear(Color.White);
                instructionPointer = 0;
                string[] code = richTextBoxCode.Text.Split('\n');
                for (int y = 0; y < 480 / 4; y++)
                {
                    for (int x = 0; x < 640 / 4; x++)
                    {
                        Tick(x, y, e);
                    }
                }
            }
        }
        private void Tick(int x, int y, PaintEventArgs e)
        {
            SolidBrush brush = new SolidBrush(Color.Black);
            if (waitingTicks > 0)
            {
                waitingTicks--;
            }
            else
            {
                ProcessInstruction(instructionPointer);
            }
            if (!render)
            {
                e.Graphics.FillRectangle(brush, x * 4, y * 4, 4, 4);
                return;
            }

            // m7 transforms
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
        private int ProcessInstruction(int instructionIdx)
        {
            switch (compiledCode[instructionIdx])
            {
                case 255:
                    {
                        instructionPointer++;
                        return 0;
                    }
                case 0:
                    {
                        render = false;
                        instructionPointer++;
                        return 0;
                    }
                case 1:
                    {
                        render = true;
                        instructionPointer++;
                        return 0;
                    }
                case 2:
                    {
                        waitingTicks = compiledCode[instructionIdx + 1];
                        instructionPointer++;
                        instructionPointer++;
                        return 0;
                    }
                case 3:
                    {
                        byte register = compiledCode[instructionIdx + 1];
                        int value = compiledCode[instructionIdx + 2] - 128;
                        instructionPointer++;
                        instructionPointer++;
                        instructionPointer++;
                        switch (register)
                        {
                            case 0:
                                {
                                    a = value;
                                    return 0;
                                }
                            case 1:
                                {
                                    b = value;
                                    return 0;
                                }
                            case 2:
                                {
                                    c = value;
                                    return 0;
                                }
                            case 3:
                                {
                                    d = value;
                                    return 0;
                                }
                            case 4:
                                {
                                    xt = value;
                                    return 0;
                                }
                            case 5:
                                {
                                    yt = value;
                                    return 0;
                                }
                            case 6:
                                {
                                    h = value;
                                    return 0;
                                }
                            case 7:
                                {
                                    v = value;
                                    return 0;
                                }
                            default:
                                {
                                    return -1;
                                }
                        }
                    }
                default:
                    {
                        instructionPointer++;
                        return -1;
                    }
            }
        }

        private void richTextBoxCode_TextChanged(object sender, EventArgs e)
        {
            textBoxError.Text = string.Empty;
            richTextBoxCompiledCode.Text = string.Empty;
            // we want to compile the code
            // compiled instructions: 
            // 000 - turn off the screen
            // 001 - turn on the screen
            // 002 - wait for a time
            // 003 - set a m7 register

            string[] code = richTextBoxCode.Text.Split('\n');
            int buffed = 0;
            for (int i = 0; i < code.Length; i++)
            {
                for (int j = 0; j < tokens.Length; j++)
                {
                    try
                    {

                        string[] parsed = tokens[j].Parse(code[i]);
                        if (parsed.Length == 0)
                        {
                            if (textBoxError.Text == string.Empty)
                            {
                                if (j == tokens.Length - 1)
                                {
                                    textBoxError.Text = $"Unparsable Function \"{code[i]}\"";
                                }
                            }
                            continue;
                        }
                        else if (parsed.Length == 1)
                        {
                            if (parsed[0] == "turnoff") // adding twice, make sure parser checks if literals are the same as provided
                            {
                                compiledCode[buffed] = 0;
                                richTextBoxCompiledCode.Text += "000 ";
                                buffed++;
                                j = tokens.Length;
                            }
                            else if (parsed[0] == "turnon")
                            {
                                compiledCode[buffed] = 1;
                                richTextBoxCompiledCode.Text += "001 ";
                                buffed++;
                                j = tokens.Length;
                            }

                        }
                        else if (parsed.Length == 2)
                        {
                            if (parsed[0] == "wait ")
                            {
                                string tmp = parsed[1];
                                if (int.Parse(tmp) > 255)
                                {
                                    textBoxError.Text = $"Compile Error: Unexpected Argument \"{tmp}\"";
                                    continue;
                                }
                                compiledCode[buffed] = 2;
                                richTextBoxCompiledCode.Text += "002 ";
                                if (tmp.Length == 1)
                                {
                                    tmp = "00" + tmp;
                                }
                                else if (tmp.Length == 2)
                                {
                                    tmp = "0" + tmp;
                                }
                                richTextBoxCompiledCode.Text += tmp + " ";
                                buffed++;
                                compiledCode[buffed] = byte.Parse(tmp);
                                buffed++;
                                j = tokens.Length;
                            }
                        }
                        else if (parsed.Length == 4)
                        {
                            if (parsed[0] == "m7register")
                            {
                                string tmp = parsed[1];
                                if (byte.Parse(tmp) > 7)
                                {
                                    textBoxError.Text = $"Compile Error: Unexpected Argument \"{tmp}\", expected value between 0 and 7";
                                    continue;
                                }
                                string tmp2 = parsed[3];
                                if (int.Parse(tmp2) > 127 || int.Parse(tmp2) < -128)
                                {
                                    textBoxError.Text = $"Compile Error: Unexpected Argument \"{tmp2}\", expected value between -128 and 127";
                                    continue;
                                }
                                compiledCode[buffed] = 3;
                                richTextBoxCompiledCode.Text += "003 ";
                                tmp = "00" + tmp;
                                if (tmp2.Length == 1)
                                {
                                    tmp2 = "00" + tmp2;
                                }
                                else if (tmp2.Length == 2)
                                {
                                    tmp2 = "0" + tmp2;
                                }
                                richTextBoxCompiledCode.Text += tmp + " ";
                                richTextBoxCompiledCode.Text += (int.Parse(tmp2) + 128) + " ";
                                buffed++;
                                compiledCode[buffed] = byte.Parse(tmp);
                                buffed++;
                                compiledCode[buffed] = byte.Parse((SByte.Parse(tmp2) + 128).ToString()); // super messy conversion
                                buffed++;
                                j = tokens.Length;
                            }
                        }
                        else
                        {
                            textBoxError.Text = $"Compile Error: Unexpected Instruction \"{parsed[0]}\"";

                        }
                    }
                    catch
                    {
                        textBoxError.Text = $"Unexpected Error, line {i}";
                    }
                }
            }
            while (buffed < 65536)
            {
                compiledCode[buffed] = 255;
                buffed++;
            }
        }
    }
}
