namespace SurveyConfiguratorApp.UserController.Questions
{
    partial class SharedBetweenQuestions
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxQuestionText = new System.Windows.Forms.TextBox();
            this.numericUpDownQuestionOrder = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelErrorQuestionOrder = new SurveyConfiguratorApp.UserController.Questions.LabelErrorControl();
            this.labelErrorQuestionText = new SurveyConfiguratorApp.UserController.Questions.LabelErrorControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuestionOrder)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxQuestionText
            // 
            this.textBoxQuestionText.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBoxQuestionText.Location = new System.Drawing.Point(190, 22);
            this.textBoxQuestionText.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxQuestionText.Multiline = true;
            this.textBoxQuestionText.Name = "textBoxQuestionText";
            this.textBoxQuestionText.Size = new System.Drawing.Size(563, 83);
            this.textBoxQuestionText.TabIndex = 0;
            this.textBoxQuestionText.TextChanged += new System.EventHandler(this.textBoxQuestionText_TextChanged);
            // 
            // numericUpDownQuestionOrder
            // 
            this.numericUpDownQuestionOrder.Location = new System.Drawing.Point(190, 142);
            this.numericUpDownQuestionOrder.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownQuestionOrder.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQuestionOrder.Name = "numericUpDownQuestionOrder";
            this.numericUpDownQuestionOrder.Size = new System.Drawing.Size(563, 22);
            this.numericUpDownQuestionOrder.TabIndex = 6;
            this.numericUpDownQuestionOrder.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQuestionOrder.ValueChanged += new System.EventHandler(this.numericUpDownQuestionOrder_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Question Text";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Question Order";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // labelErrorQuestionOrder
            // 
            this.labelErrorQuestionOrder.AutoSize = true;
            this.labelErrorQuestionOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelErrorQuestionOrder.Location = new System.Drawing.Point(189, 168);
            this.labelErrorQuestionOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelErrorQuestionOrder.Name = "labelErrorQuestionOrder";
            this.labelErrorQuestionOrder.Size = new System.Drawing.Size(57, 23);
            this.labelErrorQuestionOrder.TabIndex = 8;
            this.labelErrorQuestionOrder.Load += new System.EventHandler(this.labelErrorQuestionOrder_Load);
            // 
            // labelErrorQuestionText
            // 
            this.labelErrorQuestionText.AutoSize = true;
            this.labelErrorQuestionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelErrorQuestionText.Location = new System.Drawing.Point(190, 111);
            this.labelErrorQuestionText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelErrorQuestionText.Name = "labelErrorQuestionText";
            this.labelErrorQuestionText.Size = new System.Drawing.Size(57, 23);
            this.labelErrorQuestionText.TabIndex = 7;
            this.labelErrorQuestionText.Load += new System.EventHandler(this.labelErrorQuestionText_Load);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxQuestionText);
            this.groupBox1.Controls.Add(this.numericUpDownQuestionOrder);
            this.groupBox1.Controls.Add(this.labelErrorQuestionOrder);
            this.groupBox1.Controls.Add(this.labelErrorQuestionText);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(812, 203);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // SharedBetweenQuestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SharedBetweenQuestions";
            this.Size = new System.Drawing.Size(812, 203);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuestionOrder)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxQuestionText;
        private System.Windows.Forms.NumericUpDown numericUpDownQuestionOrder;
        private LabelErrorControl labelErrorQuestionText;
        private LabelErrorControl labelErrorQuestionOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
