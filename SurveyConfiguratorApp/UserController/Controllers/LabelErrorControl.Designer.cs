namespace SurveyConfiguratorApp.UserController.Questions
{
    partial class LabelErrorControl
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
            this.labelError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(0, 0);
            this.labelError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(29, 13);
            this.labelError.TabIndex = 0;
            this.labelError.Text = "Error";
            // 
            // LabelErrorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.labelError);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LabelErrorControl";
            this.Size = new System.Drawing.Size(53, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelError;
    }
}
