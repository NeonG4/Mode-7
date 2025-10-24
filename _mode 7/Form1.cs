using Microsoft.Win32;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms.VisualStyles;

// TODO: UPDATE REGISTER SET LOGIC, ADD [register] = n!!!
namespace _mode_7
{
    public partial class FormMode7 : Form
    {
        readonly static Token[] tokens = [
            new Token([new SingleToken(TokenType.LiteralString, "turnoff")]),
            new Token([new SingleToken(TokenType.LiteralString, "turnon")]),
            // "wait n" where n is a number
            new Token([
                new SingleToken(TokenType.LiteralString, "wait "),
                new SingleToken(TokenType.Number),]),
            
            // "wait [30]", or "wait [n]" where [n] is a register
            new Token([
                new SingleToken(TokenType.LiteralString, "wait ["),
                new SingleToken(TokenType.String, "]"),
                new SingleToken(TokenType.LiteralCharacter, "]")]),
            // "[register] = [n]" set register to another register
            new Token([
                new SingleToken(TokenType.LiteralCharacter, "["),
                new SingleToken(TokenType.String, "]"),
                new SingleToken(TokenType.LiteralCharacter, "]"),
                new SingleToken(TokenType.LiteralString, " = "),
                new SingleToken(TokenType.LiteralCharacter, "["),
                new SingleToken(TokenType.String, "]"),
                new SingleToken(TokenType.LiteralCharacter, "]")
                ]),
            // "[register] = n" set register to a number
            new Token([
                new SingleToken(TokenType.LiteralCharacter, "["),
                new SingleToken(TokenType.String, "]"),
                new SingleToken(TokenType.LiteralCharacter, "]"),
                new SingleToken(TokenType.LiteralString, " = "),
                new SingleToken(TokenType.Number),
                ]),
            ];

        public Color[,] colors = new Color[1024, 1024];
        int width = 1024, height = 1024;


        // registers
        string[] registerNames = ["m7register0", "m7register1", "m7register2", "m7register3", "m7register4", "m7register5", "m7register6", "m7register7"];
        int[] registerValues = [8, 8, 0, 0, 0, 0, 0, 0];

        // rendering variables
        bool renderSlowly = true;
        bool renderBounds = true;
        int slowX = 0;
        int slowY = 0;

        // compiling variables
        byte[] compiledCode = new byte[307200]; // 640 * 480

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
                // renders set of horizontal scan lines
                instructionPointer = 0;

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
            UpdateM7Reigsters();

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
            // a-d 0, 1, 2, 3. h & v are 4 5, xt yt are 6 7
            int x0 = registerValues[6] + ((x - registerValues[4]) * registerValues[0] + (y - registerValues[5]) * registerValues[2]) + x;
            int y0 = registerValues[7] + ((y - registerValues[5]) * registerValues[1] + (x - registerValues[4]) * registerValues[3]) + y;
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
                if (renderBounds)
                {
                    brush.Color = Color.FromArgb(127, 0, 0, 0);
                }
                else
                {
                    brush.Color = Color.FromArgb(0, 0, 0);
                }
                e.Graphics.FillRectangle(brush, x * 4, y * 4, 4, 4);
            }
            brush.Dispose();
        }
        private void UpdateM7Reigsters()
        {
            textBoxXStretch.Text = registerValues[0].ToString();
            textBoxYStretch.Text = registerValues[1].ToString();
            textBoxXAxis.Text = registerValues[2].ToString();
            textBoxYAxis.Text = registerValues[3].ToString();

            textBoxShiftX.Text = registerValues[4].ToString();
            textBoxShiftY.Text = registerValues[5].ToString();

            textBoxXShift.Text = registerValues[6].ToString();
            textBoxYShift.Text = registerValues[7].ToString();
        }
        // these events have been desynced from textbox updates
        private void XStrechChanged(object sender, EventArgs e)
        {
            string text = textBoxXStretch.Text;
            if (string.IsNullOrEmpty(text))
            {
                registerValues[registerNames.ToList<string>().IndexOf($"m7register0")] = 0;
                return;
            }
            registerValues[registerNames.ToList<string>().IndexOf($"m7register0")] = int.Parse(text);
        }
        private void YStrechChanged(object sender, EventArgs e)
        {
            string text = textBoxYStretch.Text;
            if (string.IsNullOrEmpty(text))
            {
                registerValues[registerNames.ToList<string>().IndexOf($"m7register1")] = 0;
                return;
            }
            registerValues[registerNames.ToList<string>().IndexOf($"m7register1")] = int.Parse(text);
        }
        private void XPos(object sender, EventArgs e)
        {
            string text = textBoxXAxis.Text;
            if (string.IsNullOrEmpty(text))
            {
                registerValues[registerNames.ToList<string>().IndexOf($"m7register2")] = 0;
                return;
            }
            registerValues[registerNames.ToList<string>().IndexOf($"m7register2")] = int.Parse(text);
        }
        private void YPos(object sender, EventArgs e)
        {
            string text = textBoxYAxis.Text;
            if (string.IsNullOrEmpty(text))
            {
                registerValues[registerNames.ToList<string>().IndexOf($"m7register3")] = 0;
                return;
            }
            registerValues[registerNames.ToList<string>().IndexOf($"m7register3")] = int.Parse(text);
        }
        private void XShift(object sender, EventArgs e)
        {
            string text = textBoxXShift.Text;
            if (string.IsNullOrEmpty(text))
            {
                registerValues[registerNames.ToList<string>().IndexOf($"m7register4")] = 0;
                return;
            }
            registerValues[registerNames.ToList<string>().IndexOf($"m7register4")] = int.Parse(text);
        }
        private void YShift(object sender, EventArgs e)
        {
            string text = textBoxYShift.Text;
            if (string.IsNullOrEmpty(text))
            {
                registerValues[registerNames.ToList<string>().IndexOf($"m7register5")] = 0;
                return;
            }
            registerValues[registerNames.ToList<string>().IndexOf($"m7register5")] = int.Parse(text);
        }

        private void textBoxShiftX_TextChanged(object sender, EventArgs e)
        {
            string text = textBoxShiftX.Text;
            if (string.IsNullOrEmpty(text))
            {
                registerValues[registerNames.ToList<string>().IndexOf($"m7register6")] = 0;
                return;
            }
            registerValues[registerNames.ToList<string>().IndexOf($"m7register6")] = int.Parse(text);
        }

        private void textBoxShiftY_TextChanged(object sender, EventArgs e)
        {
            string text = textBoxShiftY.Text;
            if (string.IsNullOrEmpty(text))
            {
                registerValues[registerNames.ToList<string>().IndexOf($"m7register7")] = 0;
                return;
            }
            registerValues[registerNames.ToList<string>().IndexOf($"m7register7")] = int.Parse(text);
        }

        private void checkBoxRenderSlowly_CheckedChanged(object sender, EventArgs e)
        {
            slowX = 0;
            slowY = 0;
            renderSlowly = checkBoxRenderSlowly.Checked;
            instructionPointer = 0;
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
                        waitingTicks = registerValues[compiledCode[instructionIdx + 1]];
                        instructionPointer++;
                        instructionPointer++;
                        return 0;
                    }
                case 4:
                    {
                        int register = compiledCode[instructionIdx + 1];
                        byte value = compiledCode[instructionIdx + 2];
                        value -= 128;
                        registerValues[register] = value;
                        instructionPointer++;
                        instructionPointer++;
                        instructionPointer++;
                        return 0;
                    }
                case 5:
                    {
                        int register = compiledCode[instructionIdx + 1];
                        int register2 = compiledCode[instructionIdx + 2];
                        registerValues[register] = registerValues[register2];
                        instructionPointer++;
                        instructionPointer++;
                        instructionPointer++;
                        return 0;
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
            buttonCompileCode.Enabled = true;
        }
        private void buttonCompileCode_Click(object sender, EventArgs e)
        {
            buttonCompileCode.Enabled = false;
            textBoxError.Text = string.Empty;
            richTextBoxCompiledCode.Text = string.Empty;
            // we want to compile the code
            // compiled instructions: 
            // 000 - turn off the screen
            // 001 - turn on the screen
            // 002 - wait for a time (number)
            // 003 - wait for a time (register)
            // 004 - set a register to a number
            // 005 - set a register to a register

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
                                    return;
                                }
                            }
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
                                string tmp = parsed[1]; // could be a number, could be a register
                                if (int.Parse(tmp) > 255)
                                {
                                    textBoxError.Text = $"Compile Error: Unexpected Argument \"{tmp}\"";
                                    return;
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
                        else if (parsed.Length == 3)
                        {
                            if (parsed[0] == "wait [" && parsed[2] == "]")
                            {
                                string tmp = parsed[1]; // the number of the register
                                compiledCode[buffed] = 3;
                                richTextBoxCompiledCode.Text = "003 ";
                                buffed++;
                                if (tmp.Length == 1)
                                {
                                    tmp = "00" + tmp;
                                }
                                else if (tmp.Length == 2)
                                {
                                    tmp = "0" + tmp;
                                }
                                richTextBoxCompiledCode.Text += tmp;
                                int registerIndex = registerNames.ToList<string>().IndexOf(tmp);
                                if (registerIndex == -1)
                                {
                                    textBoxError.Text = $"Compile Error: Unexpected Register \"{tmp}\"";
                                    return;
                                }
                                compiledCode[buffed] = (byte)registerIndex;
                                buffed++;
                                j = tokens.Length;
                            }
                        }
                        else if (parsed.Length == 5)
                        {
                            // write for assigning a register to a number
                            if (parsed[0] == "[" && parsed[2] == "]" && parsed[3] == " = ")
                            {
                                // asignment of a register to a number
                                int value = int.Parse(parsed[4]);
                                int registerIndex = registerNames.ToList<string>().IndexOf(parsed[1]);
                                if (registerIndex == -1)
                                {
                                    textBoxError.Text = $"Compile Error: Unexpected Register \"{parsed[1]}\"";
                                    return;
                                }
                                if (value < -128 || value > 127)
                                {
                                    textBoxError.Text = $"Compile Error: Invalid Argument \"{value}\" out of range";
                                    return;
                                }
                                richTextBoxCompiledCode.Text += "004 ";
                                if (registerIndex.ToString().Length == 1)
                                {
                                    richTextBoxCompiledCode.Text += $"00{registerIndex} ";
                                }
                                else if (registerIndex.ToString().Length == 2)
                                {
                                    richTextBoxCompiledCode.Text += $"0{registerIndex} ";
                                }
                                if (value.ToString().Length == 1)
                                {
                                    richTextBoxCompiledCode.Text += $"00{value} ";
                                }
                                else if (value.ToString().Length == 2)
                                {
                                    richTextBoxCompiledCode.Text += $"0{value} ";
                                }
                                compiledCode[buffed] = 4;
                                buffed++;
                                compiledCode[buffed] = (byte)registerIndex;
                                buffed++;
                                compiledCode[buffed] = (byte)(value + 128);
                                buffed++;
                                j = tokens.Length;
                            }
                        }
                        else if (parsed.Length == 7)
                        {
                            // write for assigning a register to another register
                            if (parsed[0] == "[" && parsed[2] == "]" && parsed[3] == " = " && parsed[4] == "[" && parsed[6] == "]")
                            {
                                int a = registerNames.ToList().IndexOf(parsed[2]);
                                int b = registerNames.ToList().IndexOf(parsed[5]);
                                if (a == -1)
                                {
                                    textBoxError.Text = $"Compile Error: invalid register \"{parsed[2]}\"";
                                    return;
                                }
                                if (b == -1)
                                {
                                    textBoxError.Text = $"Compile Error: invalid register \"{parsed[5]}\"";
                                    return;
                                }
                                compiledCode[buffed] = 5;
                                buffed++;
                                richTextBoxCompiledCode.Text += "005 ";

                                compiledCode[buffed] = (byte)a;
                                buffed++;
                                compiledCode[buffed] = (byte)b;
                                buffed++;
                                richTextBoxCompiledCode.Text += a.ToString("D3");
                                richTextBoxCompiledCode.Text += b.ToString("D3");
                                j = tokens.Length;
                            }
                        }
                        else
                        {
                            textBoxError.Text = $"Compile Error: Unexpected Instruction \"{parsed[0]}\"";
                            return;

                        }
                    }
                    catch
                    {
                        textBoxError.Text = $"Unexpected Error, line {i}";
                    }
                }
            }
            while (buffed < compiledCode.Length)
            {
                compiledCode[buffed] = 255;
                buffed++;
            }
        }

        private void checkBoxRenderBounds_CheckedChanged(object sender, EventArgs e)
        {
            renderBounds = checkBoxRenderBounds.Checked;
        }
    }
}
