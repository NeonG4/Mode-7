namespace _mode_7
{
    partial class FormMode7
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMode7));
            timerTickScreen = new System.Windows.Forms.Timer(components);
            textBoxXStretch = new TextBox();
            textBoxXAxis = new TextBox();
            textBoxYAxis = new TextBox();
            textBoxYStretch = new TextBox();
            textBoxYShift = new TextBox();
            textBoxXShift = new TextBox();
            labelSkewing = new Label();
            labelScaling = new Label();
            labelShift = new Label();
            labelShiftAfter = new Label();
            textBoxShiftY = new TextBox();
            textBoxShiftX = new TextBox();
            groupBoxMode7Controls = new GroupBox();
            richTextBoxStats = new RichTextBox();
            labelStats = new Label();
            checkBoxRenderSlowly = new CheckBox();
            richTextBoxCode = new RichTextBox();
            labelInstructions = new Label();
            labelInstructionDocumentation = new Label();
            richTextBoxInstructionDocumentation = new RichTextBox();
            textBoxError = new TextBox();
            richTextBoxCompiledCode = new RichTextBox();
            labelCompiledInstructions = new Label();
            buttonCompileCode = new Button();
            checkBoxRenderBounds = new CheckBox();
            groupBoxMode7Controls.SuspendLayout();
            SuspendLayout();
            // 
            // timerTickScreen
            // 
            timerTickScreen.Enabled = true;
            timerTickScreen.Interval = 13;
            timerTickScreen.Tick += timerTick_Tick;
            // 
            // textBoxXStretch
            // 
            textBoxXStretch.Location = new Point(6, 37);
            textBoxXStretch.Name = "textBoxXStretch";
            textBoxXStretch.Size = new Size(100, 23);
            textBoxXStretch.TabIndex = 0;
            textBoxXStretch.Text = "8";
            // 
            // textBoxXAxis
            // 
            textBoxXAxis.Location = new Point(6, 110);
            textBoxXAxis.Name = "textBoxXAxis";
            textBoxXAxis.Size = new Size(100, 23);
            textBoxXAxis.TabIndex = 1;
            textBoxXAxis.Text = "0";
            // 
            // textBoxYAxis
            // 
            textBoxYAxis.Location = new Point(6, 139);
            textBoxYAxis.Name = "textBoxYAxis";
            textBoxYAxis.Size = new Size(100, 23);
            textBoxYAxis.TabIndex = 3;
            textBoxYAxis.Text = "0";
            // 
            // textBoxYStretch
            // 
            textBoxYStretch.Location = new Point(6, 66);
            textBoxYStretch.Name = "textBoxYStretch";
            textBoxYStretch.Size = new Size(100, 23);
            textBoxYStretch.TabIndex = 2;
            textBoxYStretch.Text = "8";
            // 
            // textBoxYShift
            // 
            textBoxYShift.Location = new Point(140, 66);
            textBoxYShift.Name = "textBoxYShift";
            textBoxYShift.Size = new Size(100, 23);
            textBoxYShift.TabIndex = 5;
            textBoxYShift.Text = "0";
            // 
            // textBoxXShift
            // 
            textBoxXShift.Location = new Point(140, 37);
            textBoxXShift.Name = "textBoxXShift";
            textBoxXShift.Size = new Size(100, 23);
            textBoxXShift.TabIndex = 4;
            textBoxXShift.Text = "0";
            // 
            // labelSkewing
            // 
            labelSkewing.AutoSize = true;
            labelSkewing.Location = new Point(6, 92);
            labelSkewing.Name = "labelSkewing";
            labelSkewing.Size = new Size(51, 15);
            labelSkewing.TabIndex = 6;
            labelSkewing.Text = "Skewing";
            // 
            // labelScaling
            // 
            labelScaling.AutoSize = true;
            labelScaling.Location = new Point(6, 19);
            labelScaling.Name = "labelScaling";
            labelScaling.Size = new Size(45, 15);
            labelScaling.TabIndex = 7;
            labelScaling.Text = "Scaling";
            // 
            // labelShift
            // 
            labelShift.AutoSize = true;
            labelShift.Location = new Point(140, 19);
            labelShift.Name = "labelShift";
            labelShift.Size = new Size(68, 15);
            labelShift.TabIndex = 8;
            labelShift.Text = "Shift Before";
            // 
            // labelShiftAfter
            // 
            labelShiftAfter.AutoSize = true;
            labelShiftAfter.Location = new Point(140, 92);
            labelShiftAfter.Name = "labelShiftAfter";
            labelShiftAfter.Size = new Size(60, 15);
            labelShiftAfter.TabIndex = 11;
            labelShiftAfter.Text = "Shift After";
            // 
            // textBoxShiftY
            // 
            textBoxShiftY.Location = new Point(140, 139);
            textBoxShiftY.Name = "textBoxShiftY";
            textBoxShiftY.Size = new Size(100, 23);
            textBoxShiftY.TabIndex = 10;
            textBoxShiftY.Text = "0";
            // 
            // textBoxShiftX
            // 
            textBoxShiftX.Location = new Point(140, 110);
            textBoxShiftX.Name = "textBoxShiftX";
            textBoxShiftX.Size = new Size(100, 23);
            textBoxShiftX.TabIndex = 9;
            textBoxShiftX.Text = "0";
            // 
            // groupBoxMode7Controls
            // 
            groupBoxMode7Controls.Controls.Add(labelScaling);
            groupBoxMode7Controls.Controls.Add(labelShiftAfter);
            groupBoxMode7Controls.Controls.Add(textBoxXStretch);
            groupBoxMode7Controls.Controls.Add(textBoxShiftY);
            groupBoxMode7Controls.Controls.Add(textBoxXAxis);
            groupBoxMode7Controls.Controls.Add(textBoxShiftX);
            groupBoxMode7Controls.Controls.Add(textBoxYStretch);
            groupBoxMode7Controls.Controls.Add(labelShift);
            groupBoxMode7Controls.Controls.Add(textBoxYAxis);
            groupBoxMode7Controls.Controls.Add(textBoxXShift);
            groupBoxMode7Controls.Controls.Add(labelSkewing);
            groupBoxMode7Controls.Controls.Add(textBoxYShift);
            groupBoxMode7Controls.Enabled = false;
            groupBoxMode7Controls.Location = new Point(691, 12);
            groupBoxMode7Controls.Name = "groupBoxMode7Controls";
            groupBoxMode7Controls.Size = new Size(253, 181);
            groupBoxMode7Controls.TabIndex = 12;
            groupBoxMode7Controls.TabStop = false;
            groupBoxMode7Controls.Text = "Mode 7 Controls (disabled)";
            // 
            // richTextBoxStats
            // 
            richTextBoxStats.BackColor = SystemColors.Window;
            richTextBoxStats.Location = new Point(691, 215);
            richTextBoxStats.Name = "richTextBoxStats";
            richTextBoxStats.ReadOnly = true;
            richTextBoxStats.Size = new Size(253, 108);
            richTextBoxStats.TabIndex = 13;
            richTextBoxStats.Text = "512x424 screen\n(Only Renders at a 16th of that for performance)\n\nThe instructions are run every frame";
            // 
            // labelStats
            // 
            labelStats.AutoSize = true;
            labelStats.Location = new Point(691, 197);
            labelStats.Name = "labelStats";
            labelStats.Size = new Size(32, 15);
            labelStats.TabIndex = 14;
            labelStats.Text = "Stats";
            // 
            // checkBoxRenderSlowly
            // 
            checkBoxRenderSlowly.AutoSize = true;
            checkBoxRenderSlowly.Checked = true;
            checkBoxRenderSlowly.CheckState = CheckState.Checked;
            checkBoxRenderSlowly.Location = new Point(691, 329);
            checkBoxRenderSlowly.Name = "checkBoxRenderSlowly";
            checkBoxRenderSlowly.Size = new Size(100, 19);
            checkBoxRenderSlowly.TabIndex = 15;
            checkBoxRenderSlowly.Text = "Render Slowly";
            checkBoxRenderSlowly.UseVisualStyleBackColor = true;
            checkBoxRenderSlowly.CheckedChanged += checkBoxRenderSlowly_CheckedChanged;
            // 
            // richTextBoxCode
            // 
            richTextBoxCode.Location = new Point(950, 31);
            richTextBoxCode.Name = "richTextBoxCode";
            richTextBoxCode.Size = new Size(133, 437);
            richTextBoxCode.TabIndex = 16;
            richTextBoxCode.Text = "turnoff\nwait 120\n[m7register0] = 0\n[m7register1] = 0\n[m7register2] = 16\n[m7register3] = 8\n[m7register4] = 32\n[m7register5] = 8\n[m7register6] = 8\n[m7register7] = 16\nturnon";
            richTextBoxCode.TextChanged += richTextBoxCode_TextChanged;
            // 
            // labelInstructions
            // 
            labelInstructions.AutoSize = true;
            labelInstructions.Location = new Point(950, 9);
            labelInstructions.Name = "labelInstructions";
            labelInstructions.Size = new Size(69, 15);
            labelInstructions.TabIndex = 17;
            labelInstructions.Text = "Instructions";
            // 
            // labelInstructionDocumentation
            // 
            labelInstructionDocumentation.AutoSize = true;
            labelInstructionDocumentation.Location = new Point(1232, 9);
            labelInstructionDocumentation.Name = "labelInstructionDocumentation";
            labelInstructionDocumentation.Size = new Size(150, 15);
            labelInstructionDocumentation.TabIndex = 19;
            labelInstructionDocumentation.Text = "Instruction Documentation";
            // 
            // richTextBoxInstructionDocumentation
            // 
            richTextBoxInstructionDocumentation.Location = new Point(1232, 31);
            richTextBoxInstructionDocumentation.Name = "richTextBoxInstructionDocumentation";
            richTextBoxInstructionDocumentation.ReadOnly = true;
            richTextBoxInstructionDocumentation.Size = new Size(427, 437);
            richTextBoxInstructionDocumentation.TabIndex = 18;
            richTextBoxInstructionDocumentation.Text = resources.GetString("richTextBoxInstructionDocumentation.Text");
            // 
            // textBoxError
            // 
            textBoxError.Location = new Point(950, 474);
            textBoxError.Name = "textBoxError";
            textBoxError.ReadOnly = true;
            textBoxError.Size = new Size(276, 23);
            textBoxError.TabIndex = 20;
            // 
            // richTextBoxCompiledCode
            // 
            richTextBoxCompiledCode.Location = new Point(1093, 31);
            richTextBoxCompiledCode.Name = "richTextBoxCompiledCode";
            richTextBoxCompiledCode.ReadOnly = true;
            richTextBoxCompiledCode.Size = new Size(133, 437);
            richTextBoxCompiledCode.TabIndex = 21;
            richTextBoxCompiledCode.Text = "";
            // 
            // labelCompiledInstructions
            // 
            labelCompiledInstructions.AutoSize = true;
            labelCompiledInstructions.Location = new Point(1093, 9);
            labelCompiledInstructions.Name = "labelCompiledInstructions";
            labelCompiledInstructions.Size = new Size(124, 15);
            labelCompiledInstructions.TabIndex = 22;
            labelCompiledInstructions.Text = "Compiled Instructions";
            // 
            // buttonCompileCode
            // 
            buttonCompileCode.Location = new Point(950, 503);
            buttonCompileCode.Name = "buttonCompileCode";
            buttonCompileCode.Size = new Size(75, 23);
            buttonCompileCode.TabIndex = 23;
            buttonCompileCode.Text = "Compile Code";
            buttonCompileCode.UseVisualStyleBackColor = true;
            buttonCompileCode.Click += buttonCompileCode_Click;
            // 
            // checkBoxRenderBounds
            // 
            checkBoxRenderBounds.AutoSize = true;
            checkBoxRenderBounds.Checked = true;
            checkBoxRenderBounds.CheckState = CheckState.Checked;
            checkBoxRenderBounds.Location = new Point(691, 354);
            checkBoxRenderBounds.Name = "checkBoxRenderBounds";
            checkBoxRenderBounds.Size = new Size(106, 19);
            checkBoxRenderBounds.TabIndex = 24;
            checkBoxRenderBounds.Text = "Render Bounds";
            checkBoxRenderBounds.UseVisualStyleBackColor = true;
            checkBoxRenderBounds.CheckedChanged += checkBoxRenderBounds_CheckedChanged;
            // 
            // FormMode7
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(1711, 613);
            Controls.Add(checkBoxRenderBounds);
            Controls.Add(buttonCompileCode);
            Controls.Add(labelCompiledInstructions);
            Controls.Add(richTextBoxCompiledCode);
            Controls.Add(textBoxError);
            Controls.Add(labelInstructionDocumentation);
            Controls.Add(richTextBoxInstructionDocumentation);
            Controls.Add(labelInstructions);
            Controls.Add(richTextBoxCode);
            Controls.Add(checkBoxRenderSlowly);
            Controls.Add(labelStats);
            Controls.Add(richTextBoxStats);
            Controls.Add(groupBoxMode7Controls);
            DoubleBuffered = true;
            Name = "FormMode7";
            Text = "Mode 7";
            Paint += FormMode7_Paint;
            groupBoxMode7Controls.ResumeLayout(false);
            groupBoxMode7Controls.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timerTickScreen;
        private TextBox textBoxXStretch;
        private TextBox textBoxXAxis;
        private TextBox textBoxYAxis;
        private TextBox textBoxYStretch;
        private TextBox textBoxYShift;
        private TextBox textBoxXShift;
        private Label labelSkewing;
        private Label labelScaling;
        private Label labelShift;
        private Label labelShiftAfter;
        private TextBox textBoxShiftY;
        private TextBox textBoxShiftX;
        private GroupBox groupBoxMode7Controls;
        private RichTextBox richTextBoxStats;
        private Label labelStats;
        private CheckBox checkBoxRenderSlowly;
        private RichTextBox richTextBoxCode;
        private Label labelInstructions;
        private Label labelInstructionDocumentation;
        private RichTextBox richTextBoxInstructionDocumentation;
        private TextBox textBoxError;
        private RichTextBox richTextBoxCompiledCode;
        private Label labelCompiledInstructions;
        private Button buttonCompileCode;
        private CheckBox checkBoxRenderBounds;
    }
}
