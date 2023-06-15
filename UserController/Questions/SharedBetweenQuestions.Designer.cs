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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuestionOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxQuestionText
            // 
            this.textBoxQuestionText.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxQuestionText.ImeMode = System.Windows.Forms.ImeMode.On;
            this.textBoxQuestionText.Location = new System.Drawing.Point(161, 39);
            this.textBoxQuestionText.Multiline = true;
            this.textBoxQuestionText.Name = "textBoxQuestionText";
            this.textBoxQuestionText.Size = new System.Drawing.Size(423, 68);
            this.textBoxQuestionText.TabIndex = 0;
            // 
            // labelQuestionOrder
            // 
            this.labelQuestionOrder.AutoSize = true;
            this.labelQuestionOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelQuestionOrder.Location = new System.Drawing.Point(33, 138);
            this.labelQuestionOrder.Margin = new System.Windows.Forms.Padding(0);
            this.labelQuestionOrder.Name = "labelQuestionOrder";
            this.labelQuestionOrder.Size = new System.Drawing.Size(48, 20);
            this.labelQuestionOrder.TabIndex = 5;
            // 
            // labelQuestionText
            // 
            this.labelQuestionText.AutoSize = true;
            this.labelQuestionText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelQuestionText.Location = new System.Drawing.Point(33, 63);
            this.labelQuestionText.Margin = new System.Windows.Forms.Padding(0);
            this.labelQuestionText.Name = "labelQuestionText";
            this.labelQuestionText.Size = new System.Drawing.Size(48, 20);
            this.labelQuestionText.TabIndex = 4;
            this.labelQuestionText.Load += new System.EventHandler(this.customLabelControl1_Load);
            // 
            // numericUpDownQuestionOrder
            // 
            this.numericUpDownQuestionOrder.Location = new System.Drawing.Point(161, 138);
            this.numericUpDownQuestionOrder.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQuestionOrder.Name = "numericUpDownQuestionOrder";
            this.numericUpDownQuestionOrder.Size = new System.Drawing.Size(423, 20);
            this.numericUpDownQuestionOrder.TabIndex = 6;
            this.numericUpDownQuestionOrder.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SharedBetweenQuestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.numericUpDownQuestionOrder);
            this.Controls.Add(this.labelQuestionOrder);
            this.Controls.Add(this.labelQuestionText);
            this.Controls.Add(this.textBoxQuestionText);
            this.Name = "SharedBetweenQuestions";
            this.Size = new System.Drawing.Size(647, 227);
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
    }
}
