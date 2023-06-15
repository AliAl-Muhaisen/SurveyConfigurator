namespace SurveyConfiguratorApp.UserController.Questions
{
    partial class MinMaxNumControl
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
            this.customLabelControlTitle = new SurveyConfiguratorApp.UserController.Controllers.CustomLabelControl();
            this.customLabelControlMax = new SurveyConfiguratorApp.UserController.Controllers.CustomLabelControl();
            this.customLabelControlMin = new SurveyConfiguratorApp.UserController.Controllers.CustomLabelControl();
            this.numericUpDownEnd = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownStart = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStart)).BeginInit();
            this.SuspendLayout();
            // 
            // customLabelControlTitle
            // 
            this.customLabelControlTitle.AutoSize = true;
            this.customLabelControlTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.customLabelControlTitle.Location = new System.Drawing.Point(284, 11);
            this.customLabelControlTitle.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelControlTitle.Name = "customLabelControlTitle";
            this.customLabelControlTitle.Size = new System.Drawing.Size(48, 20);
            this.customLabelControlTitle.TabIndex = 9;
            // 
            // customLabelControlMax
            // 
            this.customLabelControlMax.AutoSize = true;
            this.customLabelControlMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.customLabelControlMax.Location = new System.Drawing.Point(358, 66);
            this.customLabelControlMax.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelControlMax.Name = "customLabelControlMax";
            this.customLabelControlMax.Size = new System.Drawing.Size(48, 20);
            this.customLabelControlMax.TabIndex = 8;
            // 
            // customLabelControlMin
            // 
            this.customLabelControlMin.AutoSize = true;
            this.customLabelControlMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.customLabelControlMin.Location = new System.Drawing.Point(35, 66);
            this.customLabelControlMin.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelControlMin.Name = "customLabelControlMin";
            this.customLabelControlMin.Size = new System.Drawing.Size(48, 20);
            this.customLabelControlMin.TabIndex = 7;
            // 
            // numericUpDownEnd
            // 
            this.numericUpDownEnd.Location = new System.Drawing.Point(441, 67);
            this.numericUpDownEnd.Name = "numericUpDownEnd";
            this.numericUpDownEnd.Size = new System.Drawing.Size(141, 20);
            this.numericUpDownEnd.TabIndex = 6;
            // 
            // numericUpDownStart
            // 
            this.numericUpDownStart.Location = new System.Drawing.Point(158, 67);
            this.numericUpDownStart.Name = "numericUpDownStart";
            this.numericUpDownStart.Size = new System.Drawing.Size(145, 20);
            this.numericUpDownStart.TabIndex = 5;
            // 
            // MinMaxNumControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.customLabelControlTitle);
            this.Controls.Add(this.customLabelControlMax);
            this.Controls.Add(this.customLabelControlMin);
            this.Controls.Add(this.numericUpDownEnd);
            this.Controls.Add(this.numericUpDownStart);
            this.Name = "MinMaxNumControl";
            this.Size = new System.Drawing.Size(649, 102);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controllers.CustomLabelControl customLabelControlTitle;
        private Controllers.CustomLabelControl customLabelControlMax;
        private Controllers.CustomLabelControl customLabelControlMin;
        private System.Windows.Forms.NumericUpDown numericUpDownEnd;
        private System.Windows.Forms.NumericUpDown numericUpDownStart;
    }
}
