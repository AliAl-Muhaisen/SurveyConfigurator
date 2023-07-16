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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQuestionFaces));
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
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // numericFaceNumber
            // 
            resources.ApplyResources(this.numericFaceNumber, "numericFaceNumber");
            this.numericFaceNumber.Name = "numericFaceNumber";
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBoxFaces
            // 
            resources.ApplyResources(this.groupBoxFaces, "groupBoxFaces");
            this.groupBoxFaces.Controls.Add(this.numericFaceNumber);
            this.groupBoxFaces.Controls.Add(this.label1);
            this.groupBoxFaces.Name = "groupBoxFaces";
            this.groupBoxFaces.TabStop = false;
            // 
            // customMessageBoxControl1
            // 
            resources.ApplyResources(this.customMessageBoxControl1, "customMessageBoxControl1");
            this.customMessageBoxControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.customMessageBoxControl1.Name = "customMessageBoxControl1";
            // 
            // sharedBetweenQuestions
            // 
            resources.ApplyResources(this.sharedBetweenQuestions, "sharedBetweenQuestions");
            this.sharedBetweenQuestions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.sharedBetweenQuestions.Name = "sharedBetweenQuestions";
            // 
            // FormQuestionFaces
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBoxFaces);
            this.Controls.Add(this.customMessageBoxControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.sharedBetweenQuestions);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormQuestionFaces";
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