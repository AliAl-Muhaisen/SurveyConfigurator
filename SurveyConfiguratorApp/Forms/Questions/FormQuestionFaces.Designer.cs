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
            this.sharedBetweenQuestions = new SurveyConfiguratorApp.UserController.Questions.CommonQuestionForm();
            ((System.ComponentModel.ISupportInitialize)(this.numericFaceNumber)).BeginInit();
            this.groupBoxFaces.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Faces Number";
            // 
            // numericFaceNumber
            // 
            this.numericFaceNumber.Location = new System.Drawing.Point(108, 22);
            this.numericFaceNumber.Name = "numericFaceNumber";
            this.numericFaceNumber.Size = new System.Drawing.Size(422, 20);
            this.numericFaceNumber.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(350, 293);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(97, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(453, 293);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBoxFaces
            // 
            this.groupBoxFaces.Controls.Add(this.numericFaceNumber);
            this.groupBoxFaces.Controls.Add(this.label1);
            this.groupBoxFaces.Location = new System.Drawing.Point(10, 141);
            this.groupBoxFaces.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxFaces.Name = "groupBoxFaces";
            this.groupBoxFaces.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBoxFaces.Size = new System.Drawing.Size(540, 57);
            this.groupBoxFaces.TabIndex = 6;
            this.groupBoxFaces.TabStop = false;
            this.groupBoxFaces.Text = "Faces";
            // 
            // customMessageBoxControl1
            // 
            this.customMessageBoxControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.customMessageBoxControl1.Location = new System.Drawing.Point(745, 200);
            this.customMessageBoxControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customMessageBoxControl1.Name = "customMessageBoxControl1";
            this.customMessageBoxControl1.Size = new System.Drawing.Size(8, 19);
            this.customMessageBoxControl1.TabIndex = 5;
            // 
            // sharedBetweenQuestions
            // 
            this.sharedBetweenQuestions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.sharedBetweenQuestions.Location = new System.Drawing.Point(10, 12);
            this.sharedBetweenQuestions.Margin = new System.Windows.Forms.Padding(4);
            this.sharedBetweenQuestions.Name = "sharedBetweenQuestions";
            this.sharedBetweenQuestions.Size = new System.Drawing.Size(540, 123);
            this.sharedBetweenQuestions.TabIndex = 0;
            // 
            // FormQuestionFaces
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(581, 327);
            this.Controls.Add(this.groupBoxFaces);
            this.Controls.Add(this.customMessageBoxControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.sharedBetweenQuestions);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(597, 366);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(597, 366);
            this.Name = "FormQuestionFaces";
            this.Text = "Faces Question";
            this.Load += new System.EventHandler(this.FormQuestionFaces_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericFaceNumber)).EndInit();
            this.groupBoxFaces.ResumeLayout(false);
            this.groupBoxFaces.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UserController.Questions.CommonQuestionForm sharedBetweenQuestions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericFaceNumber;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private UserController.Controllers.CustomMessageBoxControl customMessageBoxControl1;
        private System.Windows.Forms.GroupBox groupBoxFaces;
    }
}