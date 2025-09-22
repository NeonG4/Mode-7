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
            textBoxXStretch.TextChanged += XStrechChanged;
            // 
            // textBoxXAxis
            // 
            textBoxXAxis.Location = new Point(6, 110);
            textBoxXAxis.Name = "textBoxXAxis";
            textBoxXAxis.Size = new Size(100, 23);
            textBoxXAxis.TabIndex = 1;
            textBoxXAxis.Text = "0";
            textBoxXAxis.TextChanged += XPos;
            // 
            // textBoxYAxis
            // 
            textBoxYAxis.Location = new Point(6, 139);
            textBoxYAxis.Name = "textBoxYAxis";
            textBoxYAxis.Size = new Size(100, 23);
            textBoxYAxis.TabIndex = 3;
            textBoxYAxis.Text = "0";
            textBoxYAxis.TextChanged += YPos;
            // 
            // textBoxYStretch
            // 
            textBoxYStretch.Location = new Point(6, 66);
            textBoxYStretch.Name = "textBoxYStretch";
            textBoxYStretch.Size = new Size(100, 23);
            textBoxYStretch.TabIndex = 2;
            textBoxYStretch.Text = "8";
            textBoxYStretch.TextChanged += YStrechChanged;
            // 
            // textBoxYShift
            // 
            textBoxYShift.Location = new Point(140, 66);
            textBoxYShift.Name = "textBoxYShift";
            textBoxYShift.Size = new Size(100, 23);
            textBoxYShift.TabIndex = 5;
            textBoxYShift.Text = "0";
            textBoxYShift.TextChanged += YShift;
            // 
            // textBoxXShift
            // 
            textBoxXShift.Location = new Point(140, 37);
            textBoxXShift.Name = "textBoxXShift";
            textBoxXShift.Size = new Size(100, 23);
            textBoxXShift.TabIndex = 4;
            textBoxXShift.Text = "0";
            textBoxXShift.TextChanged += XShift;
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
            textBoxShiftY.TextChanged += textBoxShiftY_TextChanged;
            // 
            // textBoxShiftX
            // 
            textBoxShiftX.Location = new Point(140, 110);
            textBoxShiftX.Name = "textBoxShiftX";
            textBoxShiftX.Size = new Size(100, 23);
            textBoxShiftX.TabIndex = 9;
            textBoxShiftX.Text = "0";
            textBoxShiftX.TextChanged += textBoxShiftX_TextChanged;
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
            groupBoxMode7Controls.Location = new Point(691, 12);
            groupBoxMode7Controls.Name = "groupBoxMode7Controls";
            groupBoxMode7Controls.Size = new Size(253, 181);
            groupBoxMode7Controls.TabIndex = 12;
            groupBoxMode7Controls.TabStop = false;
            groupBoxMode7Controls.Text = "Mode 7 Controls";
            // 
            // richTextBoxStats
            // 
            richTextBoxStats.BackColor = SystemColors.Window;
            richTextBoxStats.Location = new Point(691, 215);
            richTextBoxStats.Name = "richTextBoxStats";
            richTextBoxStats.ReadOnly = true;
            richTextBoxStats.Size = new Size(253, 108);
            richTextBoxStats.TabIndex = 13;
            richTextBoxStats.Text = "512x424 screen\n(Only Renders at a 16th of that for performance)";
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
            // FormMode7
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Menu;
            ClientSize = new Size(1009, 609);
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
    }
}
