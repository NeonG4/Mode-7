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
            timerTick = new System.Windows.Forms.Timer(components);
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
            SuspendLayout();
            // 
            // timerTick
            // 
            timerTick.Enabled = true;
            timerTick.Interval = 13;
            timerTick.Tick += timerTick_Tick;
            // 
            // textBoxXStretch
            // 
            textBoxXStretch.Location = new Point(350, 28);
            textBoxXStretch.Name = "textBoxXStretch";
            textBoxXStretch.Size = new Size(100, 23);
            textBoxXStretch.TabIndex = 0;
            textBoxXStretch.Text = "8";
            textBoxXStretch.TextChanged += XStrechChanged;
            // 
            // textBoxXAxis
            // 
            textBoxXAxis.Location = new Point(350, 101);
            textBoxXAxis.Name = "textBoxXAxis";
            textBoxXAxis.Size = new Size(100, 23);
            textBoxXAxis.TabIndex = 1;
            textBoxXAxis.Text = "0";
            textBoxXAxis.TextChanged += XPos;
            // 
            // textBoxYAxis
            // 
            textBoxYAxis.Location = new Point(350, 130);
            textBoxYAxis.Name = "textBoxYAxis";
            textBoxYAxis.Size = new Size(100, 23);
            textBoxYAxis.TabIndex = 3;
            textBoxYAxis.Text = "0";
            textBoxYAxis.TextChanged += YPos;
            // 
            // textBoxYStretch
            // 
            textBoxYStretch.Location = new Point(350, 57);
            textBoxYStretch.Name = "textBoxYStretch";
            textBoxYStretch.Size = new Size(100, 23);
            textBoxYStretch.TabIndex = 2;
            textBoxYStretch.Text = "8";
            textBoxYStretch.TextChanged += YStrechChanged;
            // 
            // textBoxYShift
            // 
            textBoxYShift.Location = new Point(484, 57);
            textBoxYShift.Name = "textBoxYShift";
            textBoxYShift.Size = new Size(100, 23);
            textBoxYShift.TabIndex = 5;
            textBoxYShift.Text = "0";
            textBoxYShift.TextChanged += YShift;
            // 
            // textBoxXShift
            // 
            textBoxXShift.Location = new Point(484, 28);
            textBoxXShift.Name = "textBoxXShift";
            textBoxXShift.Size = new Size(100, 23);
            textBoxXShift.TabIndex = 4;
            textBoxXShift.Text = "0";
            textBoxXShift.TextChanged += XShift;
            // 
            // labelSkewing
            // 
            labelSkewing.AutoSize = true;
            labelSkewing.Location = new Point(350, 83);
            labelSkewing.Name = "labelSkewing";
            labelSkewing.Size = new Size(51, 15);
            labelSkewing.TabIndex = 6;
            labelSkewing.Text = "Skewing";
            // 
            // labelScaling
            // 
            labelScaling.AutoSize = true;
            labelScaling.Location = new Point(350, 10);
            labelScaling.Name = "labelScaling";
            labelScaling.Size = new Size(45, 15);
            labelScaling.TabIndex = 7;
            labelScaling.Text = "Scaling";
            // 
            // labelShift
            // 
            labelShift.AutoSize = true;
            labelShift.Location = new Point(484, 10);
            labelShift.Name = "labelShift";
            labelShift.Size = new Size(68, 15);
            labelShift.TabIndex = 8;
            labelShift.Text = "Shift Before";
            // 
            // labelShiftAfter
            // 
            labelShiftAfter.AutoSize = true;
            labelShiftAfter.Location = new Point(484, 83);
            labelShiftAfter.Name = "labelShiftAfter";
            labelShiftAfter.Size = new Size(60, 15);
            labelShiftAfter.TabIndex = 11;
            labelShiftAfter.Text = "Shift After";
            // 
            // textBoxShiftY
            // 
            textBoxShiftY.Location = new Point(484, 130);
            textBoxShiftY.Name = "textBoxShiftY";
            textBoxShiftY.Size = new Size(100, 23);
            textBoxShiftY.TabIndex = 10;
            textBoxShiftY.Text = "0";
            textBoxShiftY.TextChanged += textBoxShiftY_TextChanged;
            // 
            // textBoxShiftX
            // 
            textBoxShiftX.Location = new Point(484, 101);
            textBoxShiftX.Name = "textBoxShiftX";
            textBoxShiftX.Size = new Size(100, 23);
            textBoxShiftX.TabIndex = 9;
            textBoxShiftX.Text = "0";
            textBoxShiftX.TextChanged += textBoxShiftX_TextChanged;
            // 
            // FormMode7
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 463);
            Controls.Add(labelShiftAfter);
            Controls.Add(textBoxShiftY);
            Controls.Add(textBoxShiftX);
            Controls.Add(labelShift);
            Controls.Add(labelScaling);
            Controls.Add(labelSkewing);
            Controls.Add(textBoxYShift);
            Controls.Add(textBoxXShift);
            Controls.Add(textBoxYAxis);
            Controls.Add(textBoxYStretch);
            Controls.Add(textBoxXAxis);
            Controls.Add(textBoxXStretch);
            DoubleBuffered = true;
            Name = "FormMode7";
            Text = "Mode 7";
            Paint += FormMode7_Paint;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timerTick;
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
    }
}
