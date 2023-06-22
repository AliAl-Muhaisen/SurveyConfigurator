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
            this.labelQuestionOrder = new SurveyConfiguratorApp.UserController.Controllers.CustomLabelControl();
            this.labelQuestionText = new SurveyConfiguratorApp.UserController.Controllers.CustomLabelControl();
            this.numericUpDownQuestionOrder = new System.Windows.Forms.NumericUpDown();
            this.labelErrorQuestionText = new SurveyConfiguratorApp.UserController.Questions.LabelErrorControl();
            this.labelErrorQuestionOrder = new SurveyConfiguratorApp.UserController.Questions.LabelErrorControl();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuestionOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxQuestionText
            // 
            this.textBoxQuestionText.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBoxQuestionText.Location = new System.Drawing.Point(215, 48);
            this.textBoxQuestionText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxQuestionText.Multiline = true;
            this.textBoxQuestionText.Name = "textBoxQuestionText";
            this.textBoxQuestionText.Size = new System.Drawing.Size(563, 83);
            this.textBoxQuestionText.TabIndex = 0;
            this.textBoxQuestionText.TextChanged += new System.EventHandler(this.textBoxQuestionText_TextChanged);
            // 
            // labelQuestionOrder
            // 
            this.labelQuestionOrder.AutoSize = true;
            this.labelQuestionOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelQuestionOrder.Location = new System.Drawing.Point(44, 170);
            this.labelQuestionOrder.Margin = new System.Windows.Forms.Padding(0);
            this.labelQuestionOrder.Name = "labelQuestionOrder";
            this.labelQuestionOrder.Size = new System.Drawing.Size(64, 25);
            this.labelQuestionOrder.TabIndex = 5;
            // 
            // labelQuestionText
            // 
            this.labelQuestionText.AutoSize = true;
            this.labelQuestionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelQuestionText.Location = new System.Drawing.Point(44, 78);
            this.labelQuestionText.Margin = new System.Windows.Forms.Padding(0);
            this.labelQuestionText.Name = "labelQuestionText";
            this.labelQuestionText.Size = new System.Drawing.Size(64, 25);
            this.labelQuestionText.TabIndex = 4;
            this.labelQuestionText.Load += new System.EventHandler(this.customLabelControl1_Load);
            // 
            // numericUpDownQuestionOrder
            // 
            this.numericUpDownQuestionOrder.Location = new System.Drawing.Point(215, 170);
            this.numericUpDownQuestionOrder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownQuestionOrder.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQuestionOrder.Name = "numericUpDownQuestionOrder";
            this.numericUpDownQuestionOrder.Size = new System.Drawing.Size(564, 22);
            this.numericUpDownQuestionOrder.TabIndex = 6;
            this.numericUpDownQuestionOrder.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQuestionOrder.ValueChanged += new System.EventHandler(this.numericUpDownQuestionOrder_ValueChanged);
            // 
            // labelErrorQuestionText
            // 
            this.labelErrorQuestionText.AutoSize = true;
            this.labelErrorQuestionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelErrorQuestionText.Location = new System.Drawing.Point(215, 140);
            this.labelErrorQuestionText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelErrorQuestionText.Name = "labelErrorQuestionText";
            this.labelErrorQuestionText.Size = new System.Drawing.Size(57, 23);
            this.labelErrorQuestionText.TabIndex = 7;
            // 
            // labelErrorQuestionOrder
            // 
            this.labelErrorQuestionOrder.AutoSize = true;
            this.labelErrorQuestionOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelErrorQuestionOrder.Location = new System.Drawing.Point(215, 203);
            this.labelErrorQuestionOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelErrorQuestionOrder.Name = "labelErrorQuestionOrder";
            this.labelErrorQuestionOrder.Size = new System.Drawing.Size(57, 23);
            this.labelErrorQuestionOrder.TabIndex = 8;
            // 
            // SharedBetweenQuestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.labelErrorQuestionOrder);
            this.Controls.Add(this.labelErrorQuestionText);
            this.Controls.Add(this.numericUpDownQuestionOrder);
            this.Controls.Add(this.labelQuestionOrder);
            this.Controls.Add(this.labelQuestionText);
            this.Controls.Add(this.textBoxQuestionText);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SharedBetweenQuestions";
            this.Size = new System.Drawing.Size(863, 279);
            this.Load += new System.EventHandler(this.SharedBetweenQuestions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuestionOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxQuestionText;
        private Controllers.CustomLabelControl labelQuestionText;
        private Controllers.CustomLabelControl labelQuestionOrder;
        private System.Windows.Forms.NumericUpDown numericUpDownQuestionOrder;
        private LabelErrorControl labelErrorQuestionText;
        private LabelErrorControl labelErrorQuestionOrder;
    }
}
