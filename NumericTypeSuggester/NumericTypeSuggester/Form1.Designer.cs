namespace NumericTypeSuggester
{
    partial class Form1
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
            MinValueTextBox = new TextBox();
            MaxValueTextBox = new TextBox();
            MinValueLabel = new Label();
            MaxValueLabel = new Label();
            IntegralLabel = new Label();
            PreciseLabel = new Label();
            ResultLabel = new Label();
            IntegralCheckBox = new CheckBox();
            PreciseCheckBox = new CheckBox();
            SuspendLayout();
            // 
            // MinValueTextBox
            // 
            MinValueTextBox.Location = new Point(125, 16);
            MinValueTextBox.Name = "MinValueTextBox";
            MinValueTextBox.Size = new Size(100, 23);
            MinValueTextBox.TabIndex = 0;
            MinValueTextBox.TextChanged += NumericTextBox_TextChanged;
            MinValueTextBox.KeyPress += NumericTextBox_KeyPress;
            // 
            // MaxValueTextBox
            // 
            MaxValueTextBox.Location = new Point(125, 51);
            MaxValueTextBox.Name = "MaxValueTextBox";
            MaxValueTextBox.Size = new Size(100, 23);
            MaxValueTextBox.TabIndex = 1;
            MaxValueTextBox.TextChanged += NumericTextBox_TextChanged;
            MaxValueTextBox.KeyPress += NumericTextBox_KeyPress;
            // 
            // MinValueLabel
            // 
            MinValueLabel.AutoSize = true;
            MinValueLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MinValueLabel.Location = new Point(37, 18);
            MinValueLabel.Name = "MinValueLabel";
            MinValueLabel.Size = new Size(82, 21);
            MinValueLabel.TabIndex = 2;
            MinValueLabel.Text = "Min Value:";
            // 
            // MaxValueLabel
            // 
            MaxValueLabel.AutoSize = true;
            MaxValueLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            MaxValueLabel.Location = new Point(35, 53);
            MaxValueLabel.Name = "MaxValueLabel";
            MaxValueLabel.Size = new Size(84, 21);
            MaxValueLabel.TabIndex = 3;
            MaxValueLabel.Text = "Max Value:";
            // 
            // IntegralLabel
            // 
            IntegralLabel.AutoSize = true;
            IntegralLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            IntegralLabel.Location = new Point(49, 85);
            IntegralLabel.Name = "IntegralLabel";
            IntegralLabel.Size = new Size(70, 21);
            IntegralLabel.TabIndex = 4;
            IntegralLabel.Text = "Integral?";
            // 
            // PreciseLabel
            // 
            PreciseLabel.AutoSize = true;
            PreciseLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            PreciseLabel.Location = new Point(53, 116);
            PreciseLabel.Name = "PreciseLabel";
            PreciseLabel.Size = new Size(66, 21);
            PreciseLabel.TabIndex = 5;
            PreciseLabel.Text = "Precise?";
            PreciseLabel.Visible = false;
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            ResultLabel.Location = new Point(35, 150);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(312, 25);
            ResultLabel.TabIndex = 6;
            ResultLabel.Text = "Suggested Type: not enough data";
            // 
            // IntegralCheckBox
            // 
            IntegralCheckBox.AutoSize = true;
            IntegralCheckBox.Checked = true;
            IntegralCheckBox.CheckState = CheckState.Checked;
            IntegralCheckBox.Location = new Point(125, 91);
            IntegralCheckBox.Name = "IntegralCheckBox";
            IntegralCheckBox.Size = new Size(15, 14);
            IntegralCheckBox.TabIndex = 8;
            IntegralCheckBox.UseVisualStyleBackColor = true;
            IntegralCheckBox.CheckedChanged += IntegralCheckBox_CheckedChanged;
            // 
            // PreciseCheckBox
            // 
            PreciseCheckBox.AutoSize = true;
            PreciseCheckBox.Location = new Point(125, 120);
            PreciseCheckBox.Name = "PreciseCheckBox";
            PreciseCheckBox.Size = new Size(15, 14);
            PreciseCheckBox.TabIndex = 9;
            PreciseCheckBox.UseVisualStyleBackColor = true;
            PreciseCheckBox.Visible = false;
            PreciseCheckBox.CheckedChanged += PreciseCheckBox_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 213);
            Controls.Add(PreciseCheckBox);
            Controls.Add(IntegralCheckBox);
            Controls.Add(ResultLabel);
            Controls.Add(PreciseLabel);
            Controls.Add(IntegralLabel);
            Controls.Add(MaxValueLabel);
            Controls.Add(MinValueLabel);
            Controls.Add(MaxValueTextBox);
            Controls.Add(MinValueTextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox MinValueTextBox;
        private TextBox MaxValueTextBox;
        private Label MinValueLabel;
        private Label MaxValueLabel;
        private Label IntegralLabel;
        private Label PreciseLabel;
        private Label ResultLabel;
        private CheckBox IntegralCheckBox;
        private CheckBox PreciseCheckBox;
    }
}