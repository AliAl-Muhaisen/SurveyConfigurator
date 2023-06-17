namespace SurveyConfiguratorApp.UserController.Questions
{
    partial class UpDownWithLabelControl
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
            this.labelTitle = new SurveyConfiguratorApp.UserController.Controllers.CustomLabelControl();
            this.labelInputValue = new SurveyConfiguratorApp.UserController.Controllers.CustomLabelControl();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelTitle.Location = new System.Drawing.Point(481, 10);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(59, 23);
            this.labelTitle.TabIndex = 9;
            // 
            // labelInputValue
            // 
            this.labelInputValue.AutoSize = true;
            this.labelInputValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelInputValue.Location = new System.Drawing.Point(39, 72);
            this.labelInputValue.Margin = new System.Windows.Forms.Padding(0);
            this.labelInputValue.Name = "labelInputValue";
            this.labelInputValue.Size = new System.Drawing.Size(59, 23);
            this.labelInputValue.TabIndex = 7;
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(221, 72);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(568, 22);
            this.numericUpDown.TabIndex = 8;
            // 
            // UpDownWithLabelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelInputValue);
            this.Controls.Add(this.numericUpDown);
            this.Name = "UpDownWithLabelControl";
            this.Padding = new System.Windows.Forms.Padding(10, 10, 30, 10);
            this.Size = new System.Drawing.Size(847, 115);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controllers.CustomLabelControl labelTitle;
        private Controllers.CustomLabelControl labelInputValue;
        private System.Windows.Forms.NumericUpDown numericUpDown;
    }
}
