namespace SurveyConfiguratorApp.UserController.Controllers
{
    partial class DividerPanelControl
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
            this.panelDivider = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelDivider
            // 
            this.panelDivider.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panelDivider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDivider.Location = new System.Drawing.Point(0, 0);
            this.panelDivider.Name = "panelDivider";
            this.panelDivider.Size = new System.Drawing.Size(450, 32);
            this.panelDivider.TabIndex = 0;
            // 
            // DividerPanelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelDivider);
            this.Name = "DividerPanelControl";
            this.Size = new System.Drawing.Size(450, 32);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDivider;
    }
}
