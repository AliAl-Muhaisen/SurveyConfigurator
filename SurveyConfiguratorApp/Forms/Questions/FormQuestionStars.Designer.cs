namespace SurveyConfiguratorApp.Forms.Questions
{
    partial class FormQuestionStars
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
            this.label1 = new System.Windows.Forms.Label();
            this.numericStarsNumber = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.sharedBetweenQuestions = new SurveyConfiguratorApp.UserController.Questions.SharedBetweenQuestions();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericStarsNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(397, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // numericStarsNumber
            // 
            this.numericStarsNumber.Location = new System.Drawing.Point(150, 192);
            this.numericStarsNumber.Name = "numericStarsNumber";
            this.numericStarsNumber.Size = new System.Drawing.Size(417, 20);
            this.numericStarsNumber.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Stars Number";
            // 
            // sharedBetweenQuestions
            // 
            this.sharedBetweenQuestions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.sharedBetweenQuestions.Location = new System.Drawing.Point(12, 12);
            this.sharedBetweenQuestions.Name = "sharedBetweenQuestions";
            this.sharedBetweenQuestions.Size = new System.Drawing.Size(647, 159);
            this.sharedBetweenQuestions.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(491, 329);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormQuestionStars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numericStarsNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sharedBetweenQuestions);
            this.Controls.Add(this.label1);
            this.Name = "FormQuestionStars";
            this.Text = "FormQuestionStars";
            ((System.ComponentModel.ISupportInitialize)(this.numericStarsNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericStarsNumber;
        private System.Windows.Forms.Label label2;
        private UserController.Questions.SharedBetweenQuestions sharedBetweenQuestions;
        private System.Windows.Forms.Button btnSave;
    }
}