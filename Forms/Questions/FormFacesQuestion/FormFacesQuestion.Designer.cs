namespace SurveyConfiguratorApp.Forms
{
    partial class FormFacesQuestion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFacesQuestion));
            this.sharedBetweenQuestions1 = new SurveyConfiguratorApp.UserController.Questions.SharedBetweenQuestions();
            this.dividerPanelControl1 = new SurveyConfiguratorApp.UserController.Controllers.DividerPanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.minMaxNumControl = new SurveyConfiguratorApp.UserController.Questions.MinMaxNumControl();
            this.dividerPanelControl2 = new SurveyConfiguratorApp.UserController.Controllers.DividerPanelControl();
            this.dividerPanelVerticalControl1 = new SurveyConfiguratorApp.UserController.Controllers.DividerPanelVerticalControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sharedBetweenQuestions1
            // 
            this.sharedBetweenQuestions1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.sharedBetweenQuestions1.Dock = System.Windows.Forms.DockStyle.Top;
            this.sharedBetweenQuestions1.Location = new System.Drawing.Point(0, 0);
            this.sharedBetweenQuestions1.Name = "sharedBetweenQuestions1";
            this.sharedBetweenQuestions1.Size = new System.Drawing.Size(800, 192);
            this.sharedBetweenQuestions1.TabIndex = 1;
            // 
            // dividerPanelControl1
            // 
            this.dividerPanelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanelControl1.Location = new System.Drawing.Point(0, 192);
            this.dividerPanelControl1.Name = "dividerPanelControl1";
            this.dividerPanelControl1.Size = new System.Drawing.Size(800, 32);
            this.dividerPanelControl1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.panel1.Controls.Add(this.dividerPanelControl2);
            this.panel1.Controls.Add(this.minMaxNumControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 224);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 226);
            this.panel1.TabIndex = 3;
            // 
            // minMaxNumControl
            // 
            this.minMaxNumControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.minMaxNumControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.minMaxNumControl.Location = new System.Drawing.Point(0, 0);
            this.minMaxNumControl.Name = "minMaxNumControl";
            this.minMaxNumControl.Size = new System.Drawing.Size(800, 102);
            this.minMaxNumControl.TabIndex = 0;
            // 
            // dividerPanelControl2
            // 
            this.dividerPanelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanelControl2.Location = new System.Drawing.Point(0, 102);
            this.dividerPanelControl2.Name = "dividerPanelControl2";
            this.dividerPanelControl2.Size = new System.Drawing.Size(800, 11);
            this.dividerPanelControl2.TabIndex = 1;
            // 
            // dividerPanelVerticalControl1
            // 
            this.dividerPanelVerticalControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dividerPanelVerticalControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dividerPanelVerticalControl1.Location = new System.Drawing.Point(774, 224);
            this.dividerPanelVerticalControl1.Name = "dividerPanelVerticalControl1";
            this.dividerPanelVerticalControl1.Size = new System.Drawing.Size(26, 226);
            this.dividerPanelVerticalControl1.TabIndex = 2;
            // 
            // FormFacesQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dividerPanelVerticalControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dividerPanelControl1);
            this.Controls.Add(this.sharedBetweenQuestions1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFacesQuestion";
            this.Text = "FormFaces";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserController.Questions.SharedBetweenQuestions sharedBetweenQuestions1;
        private UserController.Controllers.DividerPanelControl dividerPanelControl1;
        private System.Windows.Forms.Panel panel1;
        private UserController.Questions.MinMaxNumControl minMaxNumControl;
        private UserController.Controllers.DividerPanelControl dividerPanelControl2;
        private UserController.Controllers.DividerPanelVerticalControl dividerPanelVerticalControl1;
    }
}