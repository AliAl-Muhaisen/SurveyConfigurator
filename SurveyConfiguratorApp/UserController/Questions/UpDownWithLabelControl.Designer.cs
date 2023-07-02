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
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.labelErrorControl = new SurveyConfiguratorApp.UserController.Questions.LabelErrorControl();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(166, 58);
            this.numericUpDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(426, 20);
            this.numericUpDown.TabIndex = 8;
            this.numericUpDown.ValueChanged += new System.EventHandler(this.numericUpDown_ValueChanged);
            // 
            // labelErrorControl
            // 
            this.labelErrorControl.AutoSize = true;
            this.labelErrorControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelErrorControl.Location = new System.Drawing.Point(166, 81);
            this.labelErrorControl.Margin = new System.Windows.Forms.Padding(2);
            this.labelErrorControl.Name = "labelErrorControl";
            this.labelErrorControl.Size = new System.Drawing.Size(40, 20);
            this.labelErrorControl.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "label1";
            // 
            // UpDownWithLabelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelErrorControl);
            this.Controls.Add(this.numericUpDown);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UpDownWithLabelControl";
            this.Padding = new System.Windows.Forms.Padding(8, 8, 22, 8);
            this.Size = new System.Drawing.Size(635, 129);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private LabelErrorControl labelErrorControl;
        private System.Windows.Forms.Label label1;
    }
}
