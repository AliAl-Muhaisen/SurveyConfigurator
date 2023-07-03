namespace SurveyConfiguratorApp.Forms.Questions
{
    partial class FormQuestionSlider
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericStartValue = new System.Windows.Forms.NumericUpDown();
            this.numericEndValue = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxStartCaption = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxEndCaption = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.sharedBetweenQuestions = new SurveyConfiguratorApp.UserController.Questions.SharedBetweenQuestions();
            ((System.ComponentModel.ISupportInitialize)(this.numericStartValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEndValue)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(464, 338);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 205);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Start Value";
            // 
            // numericStartValue
            // 
            this.numericStartValue.Location = new System.Drawing.Point(144, 205);
            this.numericStartValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericStartValue.Name = "numericStartValue";
            this.numericStartValue.Size = new System.Drawing.Size(112, 20);
            this.numericStartValue.TabIndex = 9;
            // 
            // numericEndValue
            // 
            this.numericEndValue.Location = new System.Drawing.Point(464, 205);
            this.numericEndValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericEndValue.Name = "numericEndValue";
            this.numericEndValue.Size = new System.Drawing.Size(112, 20);
            this.numericEndValue.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 205);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "End Value";
            // 
            // textBoxStartCaption
            // 
            this.textBoxStartCaption.Location = new System.Drawing.Point(144, 269);
            this.textBoxStartCaption.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxStartCaption.Name = "textBoxStartCaption";
            this.textBoxStartCaption.Size = new System.Drawing.Size(114, 20);
            this.textBoxStartCaption.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 274);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Start Caption";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(330, 274);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "End Caption";
            // 
            // textBoxEndCaption
            // 
            this.textBoxEndCaption.Location = new System.Drawing.Point(464, 269);
            this.textBoxEndCaption.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxEndCaption.Name = "textBoxEndCaption";
            this.textBoxEndCaption.Size = new System.Drawing.Size(114, 20);
            this.textBoxEndCaption.TabIndex = 14;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(311, 338);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // sharedBetweenQuestions
            // 
            this.sharedBetweenQuestions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.sharedBetweenQuestions.Location = new System.Drawing.Point(10, 11);
            this.sharedBetweenQuestions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sharedBetweenQuestions.Name = "sharedBetweenQuestions";
            this.sharedBetweenQuestions.Size = new System.Drawing.Size(647, 159);
            this.sharedBetweenQuestions.TabIndex = 4;
            // 
            // FormQuestionSlider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxEndCaption);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxStartCaption);
            this.Controls.Add(this.numericEndValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericStartValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.sharedBetweenQuestions);
            this.Name = "FormQuestionSlider";
            this.Text = "FormQuestionSlider";
            this.Load += new System.EventHandler(this.FormQuestionSlider_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericStartValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEndValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private UserController.Questions.SharedBetweenQuestions sharedBetweenQuestions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericStartValue;
        private System.Windows.Forms.NumericUpDown numericEndValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxStartCaption;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxEndCaption;
        private System.Windows.Forms.Button btnSave;
    }
}