namespace lab_try
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.inputType = new System.Windows.Forms.ComboBox();
            this.inputFile = new System.Windows.Forms.TextBox();
            this.inputFileLabel = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Scale = new System.Windows.Forms.NumericUpDown();
            this.labelRandomly = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownRepeiteCount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Scale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeiteCount)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(445, 664);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 47);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create Yard";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(940, 664);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 47);
            this.button3.TabIndex = 2;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(648, 664);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(180, 47);
            this.button4.TabIndex = 3;
            this.button4.Text = "Find guards";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // inputType
            // 
            this.inputType.FormattingEnabled = true;
            this.inputType.Items.AddRange(new object[] {
            "Read from file",
            "Generate"});
            this.inputType.Location = new System.Drawing.Point(708, 571);
            this.inputType.Name = "inputType";
            this.inputType.Size = new System.Drawing.Size(242, 29);
            this.inputType.TabIndex = 10;
            this.inputType.SelectedIndexChanged += new System.EventHandler(this.inputType_SelectedIndexChanged);
            // 
            // inputFile
            // 
            this.inputFile.Location = new System.Drawing.Point(445, 573);
            this.inputFile.Name = "inputFile";
            this.inputFile.Size = new System.Drawing.Size(242, 27);
            this.inputFile.TabIndex = 11;
            // 
            // inputFileLabel
            // 
            this.inputFileLabel.AutoSize = true;
            this.inputFileLabel.Location = new System.Drawing.Point(441, 622);
            this.inputFileLabel.Name = "inputFileLabel";
            this.inputFileLabel.Size = new System.Drawing.Size(72, 21);
            this.inputFileLabel.TabIndex = 12;
            this.inputFileLabel.Text = "Input File";
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.result.Location = new System.Drawing.Point(258, 610);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(0, 20);
            this.result.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 667);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 21);
            this.label1.TabIndex = 18;
            this.label1.Text = "Scale:";
            // 
            // Scale
            // 
            this.Scale.Location = new System.Drawing.Point(161, 664);
            this.Scale.Name = "Scale";
            this.Scale.Size = new System.Drawing.Size(184, 27);
            this.Scale.TabIndex = 19;
            this.Scale.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.Scale.ValueChanged += new System.EventHandler(this.scale_ValueChanged);
            // 
            // labelRandomly
            // 
            this.labelRandomly.AutoSize = true;
            this.labelRandomly.Location = new System.Drawing.Point(545, 622);
            this.labelRandomly.Name = "labelRandomly";
            this.labelRandomly.Size = new System.Drawing.Size(166, 21);
            this.labelRandomly.TabIndex = 20;
            this.labelRandomly.Text = "Generate yard randomly";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(838, 622);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 21);
            this.label2.TabIndex = 21;
            this.label2.Text = "Repeite Count";
            // 
            // numericUpDownRepeiteCount
            // 
            this.numericUpDownRepeiteCount.Location = new System.Drawing.Point(956, 619);
            this.numericUpDownRepeiteCount.Name = "numericUpDownRepeiteCount";
            this.numericUpDownRepeiteCount.Size = new System.Drawing.Size(122, 27);
            this.numericUpDownRepeiteCount.TabIndex = 22;
            this.numericUpDownRepeiteCount.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1132, 723);
            this.Controls.Add(this.numericUpDownRepeiteCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelRandomly);
            this.Controls.Add(this.Scale);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.result);
            this.Controls.Add(this.inputFileLabel);
            this.Controls.Add(this.inputFile);
            this.Controls.Add(this.inputType);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Goudy Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form";
            this.Text = "Computer Geometry. Finding Yard";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Scale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepeiteCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox inputType;
        private System.Windows.Forms.TextBox inputFile;
        private System.Windows.Forms.Label inputFileLabel;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Scale;
        private System.Windows.Forms.Label labelRandomly;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownRepeiteCount;
    }
}