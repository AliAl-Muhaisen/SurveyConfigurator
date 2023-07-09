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
            this.labelErrorCaptionEnd = new SurveyConfiguratorApp.UserController.Questions.LabelErrorControl();
            this.labelErrorCaptionStart = new SurveyConfiguratorApp.UserController.Questions.LabelErrorControl();
            this.customMessageBoxControl1 = new SurveyConfiguratorApp.UserController.Controllers.CustomMessageBoxControl();
            this.labelErrorStartValue = new SurveyConfiguratorApp.UserController.Questions.LabelErrorControl();
            this.labelErrorEndValue = new SurveyConfiguratorApp.UserController.Questions.LabelErrorControl();
            this.sharedBetweenQuestions = new SurveyConfiguratorApp.UserController.Questions.SharedBetweenQuestions();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericStartValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEndValue)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(471, 286);
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
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Start Value";
            // 
            // numericStartValue
            // 
            this.numericStartValue.Location = new System.Drawing.Point(141, 24);
            this.numericStartValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericStartValue.Name = "numericStartValue";
            this.numericStartValue.Size = new System.Drawing.Size(112, 20);
            this.numericStartValue.TabIndex = 9;
            this.numericStartValue.ValueChanged += new System.EventHandler(this.numericStartValue_ValueChanged);
            // 
            // numericEndValue
            // 
            this.numericEndValue.Location = new System.Drawing.Point(458, 22);
            this.numericEndValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericEndValue.Name = "numericEndValue";
            this.numericEndValue.Size = new System.Drawing.Size(112, 20);
            this.numericEndValue.TabIndex = 11;
            this.numericEndValue.ValueChanged += new System.EventHandler(this.numericEndValue_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "End Value";
            // 
            // textBoxStartCaption
            // 
            this.textBoxStartCaption.Location = new System.Drawing.Point(141, 75);
            this.textBoxStartCaption.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxStartCaption.Name = "textBoxStartCaption";
            this.textBoxStartCaption.Size = new System.Drawing.Size(114, 20);
            this.textBoxStartCaption.TabIndex = 12;
            this.textBoxStartCaption.TextChanged += new System.EventHandler(this.textBoxStartCaption_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Start Caption";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(327, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "End Caption";
            // 
            // textBoxEndCaption
            // 
            this.textBoxEndCaption.Location = new System.Drawing.Point(457, 75);
            this.textBoxEndCaption.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxEndCaption.Name = "textBoxEndCaption";
            this.textBoxEndCaption.Size = new System.Drawing.Size(114, 20);
            this.textBoxEndCaption.TabIndex = 14;
            this.textBoxEndCaption.TextChanged += new System.EventHandler(this.textBoxEndCaption_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(322, 286);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelErrorCaptionEnd
            // 
            this.labelErrorCaptionEnd.AutoSize = true;
            this.labelErrorCaptionEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelErrorCaptionEnd.Location = new System.Drawing.Point(461, 96);
            this.labelErrorCaptionEnd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.labelErrorCaptionEnd.Name = "labelErrorCaptionEnd";
            this.labelErrorCaptionEnd.Size = new System.Drawing.Size(30, 14);
            this.labelErrorCaptionEnd.TabIndex = 21;
            // 
            // labelErrorCaptionStart
            // 
            this.labelErrorCaptionStart.AutoSize = true;
            this.labelErrorCaptionStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelErrorCaptionStart.Location = new System.Drawing.Point(141, 96);
            this.labelErrorCaptionStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.labelErrorCaptionStart.Name = "labelErrorCaptionStart";
            this.labelErrorCaptionStart.Size = new System.Drawing.Size(30, 14);
            this.labelErrorCaptionStart.TabIndex = 20;
            // 
            // customMessageBoxControl1
            // 
            this.customMessageBoxControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.customMessageBoxControl1.Location = new System.Drawing.Point(749, 151);
            this.customMessageBoxControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customMessageBoxControl1.Name = "customMessageBoxControl1";
            this.customMessageBoxControl1.Size = new System.Drawing.Size(8, 19);
            this.customMessageBoxControl1.TabIndex = 19;
            // 
            // labelErrorStartValue
            // 
            this.labelErrorStartValue.AutoSize = true;
            this.labelErrorStartValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelErrorStartValue.Location = new System.Drawing.Point(141, 50);
            this.labelErrorStartValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.labelErrorStartValue.Name = "labelErrorStartValue";
            this.labelErrorStartValue.Size = new System.Drawing.Size(30, 14);
            this.labelErrorStartValue.TabIndex = 18;
            // 
            // labelErrorEndValue
            // 
            this.labelErrorEndValue.AutoSize = true;
            this.labelErrorEndValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelErrorEndValue.Location = new System.Drawing.Point(458, 43);
            this.labelErrorEndValue.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.labelErrorEndValue.Name = "labelErrorEndValue";
            this.labelErrorEndValue.Size = new System.Drawing.Size(30, 14);
            this.labelErrorEndValue.TabIndex = 17;
            // 
            // sharedBetweenQuestions
            // 
            this.sharedBetweenQuestions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.sharedBetweenQuestions.Location = new System.Drawing.Point(10, 11);
            this.sharedBetweenQuestions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sharedBetweenQuestions.Name = "sharedBetweenQuestions";
            this.sharedBetweenQuestions.Size = new System.Drawing.Size(573, 154);
            this.sharedBetweenQuestions.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericStartValue);
            this.groupBox1.Controls.Add(this.labelErrorCaptionEnd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labelErrorCaptionStart);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericEndValue);
            this.groupBox1.Controls.Add(this.labelErrorStartValue);
            this.groupBox1.Controls.Add(this.textBoxStartCaption);
            this.groupBox1.Controls.Add(this.labelErrorEndValue);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxEndCaption);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(9, 171);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(574, 110);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Slider Values";
            // 
            // FormQuestionSlider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(616, 436);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.customMessageBoxControl1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.sharedBetweenQuestions);
            this.MaximumSize = new System.Drawing.Size(632, 475);
            this.MinimumSize = new System.Drawing.Size(632, 475);
            this.Name = "FormQuestionSlider";
            this.Text = "FormQuestionSlider";
            this.Load += new System.EventHandler(this.FormQuestionSlider_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericStartValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEndValue)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

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
        private UserController.Questions.LabelErrorControl labelErrorEndValue;
        private UserController.Questions.LabelErrorControl labelErrorStartValue;
        private UserController.Controllers.CustomMessageBoxControl customMessageBoxControl1;
        private UserController.Questions.LabelErrorControl labelErrorCaptionStart;
        private UserController.Questions.LabelErrorControl labelErrorCaptionEnd;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}