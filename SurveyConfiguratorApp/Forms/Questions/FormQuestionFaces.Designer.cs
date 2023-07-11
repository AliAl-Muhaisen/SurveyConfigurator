namespace SurveyConfiguratorApp.Forms.Questions
{
    partial class FormQuestionFaces
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
            this.numericFaceNumber = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBoxFaces = new System.Windows.Forms.GroupBox();
            this.customMessageBoxControl1 = new SurveyConfiguratorApp.UserController.Controllers.CustomMessageBoxControl();
            this.sharedBetweenQuestions = new SurveyConfiguratorApp.UserController.Questions.SharedBetweenQuestions();
            ((System.ComponentModel.ISupportInitialize)(this.numericFaceNumber)).BeginInit();
            this.groupBoxFaces.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Faces Number";
            // 
            // numericFaceNumber
            // 
            this.numericFaceNumber.Location = new System.Drawing.Point(144, 27);
            this.numericFaceNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericFaceNumber.Name = "numericFaceNumber";
            this.numericFaceNumber.Size = new System.Drawing.Size(563, 22);
            this.numericFaceNumber.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(467, 361);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 28);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(604, 361);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(129, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBoxFaces
            // 
            this.groupBoxFaces.Controls.Add(this.numericFaceNumber);
            this.groupBoxFaces.Controls.Add(this.label1);
            this.groupBoxFaces.Location = new System.Drawing.Point(13, 209);
            this.groupBoxFaces.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxFaces.Name = "groupBoxFaces";
            this.groupBoxFaces.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxFaces.Size = new System.Drawing.Size(720, 70);
            this.groupBoxFaces.TabIndex = 6;
            this.groupBoxFaces.TabStop = false;
            this.groupBoxFaces.Text = "Faces";
            // 
            // customMessageBoxControl1
            // 
            this.customMessageBoxControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.customMessageBoxControl1.Location = new System.Drawing.Point(993, 246);
            this.customMessageBoxControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customMessageBoxControl1.Name = "customMessageBoxControl1";
            this.customMessageBoxControl1.Size = new System.Drawing.Size(11, 23);
            this.customMessageBoxControl1.TabIndex = 5;
            // 
            // sharedBetweenQuestions
            // 
            this.sharedBetweenQuestions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.sharedBetweenQuestions.Location = new System.Drawing.Point(13, 15);
            this.sharedBetweenQuestions.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.sharedBetweenQuestions.Name = "sharedBetweenQuestions";
            this.sharedBetweenQuestions.Size = new System.Drawing.Size(720, 187);
            this.sharedBetweenQuestions.TabIndex = 0;
            // 
            // FormQuestionFaces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(773, 394);
            this.Controls.Add(this.groupBoxFaces);
            this.Controls.Add(this.customMessageBoxControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.sharedBetweenQuestions);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(791, 441);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(791, 441);
            this.Name = "FormQuestionFaces";
            this.Text = "Faces Question";
            this.Load += new System.EventHandler(this.FormQuestionFaces_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericFaceNumber)).EndInit();
            this.groupBoxFaces.ResumeLayout(false);
            this.groupBoxFaces.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UserController.Questions.SharedBetweenQuestions sharedBetweenQuestions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericFaceNumber;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private UserController.Controllers.CustomMessageBoxControl customMessageBoxControl1;
        private System.Windows.Forms.GroupBox groupBoxFaces;
    }
}