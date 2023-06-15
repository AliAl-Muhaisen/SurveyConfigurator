namespace SurveyConfiguratorApp.Forms.Questions
{
    partial class FormStarsQuestion
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
            this.panelContainer = new System.Windows.Forms.Panel();
            this.minMaxNumControl1 = new SurveyConfiguratorApp.UserController.Questions.MinMaxNumControl();
            this.dividerPanelControl1 = new SurveyConfiguratorApp.UserController.Controllers.DividerPanelControl();
            this.sharedBetweenQuestions1 = new SurveyConfiguratorApp.UserController.Questions.SharedBetweenQuestions();
            this.dividerPanelControl2 = new SurveyConfiguratorApp.UserController.Controllers.DividerPanelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.panelContainer.Controls.Add(this.dividerPanelControl2);
            this.panelContainer.Controls.Add(this.minMaxNumControl1);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 224);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(800, 226);
            this.panelContainer.TabIndex = 4;
            // 
            // minMaxNumControl1
            // 
            this.minMaxNumControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.minMaxNumControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.minMaxNumControl1.Location = new System.Drawing.Point(0, 0);
            this.minMaxNumControl1.Name = "minMaxNumControl1";
            this.minMaxNumControl1.Size = new System.Drawing.Size(800, 102);
            this.minMaxNumControl1.TabIndex = 0;
            // 
            // dividerPanelControl1
            // 
            this.dividerPanelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanelControl1.Location = new System.Drawing.Point(0, 192);
            this.dividerPanelControl1.Name = "dividerPanelControl1";
            this.dividerPanelControl1.Size = new System.Drawing.Size(800, 32);
            this.dividerPanelControl1.TabIndex = 3;
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
            // dividerPanelControl2
            // 
            this.dividerPanelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanelControl2.Location = new System.Drawing.Point(0, 102);
            this.dividerPanelControl2.Name = "dividerPanelControl2";
            this.dividerPanelControl2.Size = new System.Drawing.Size(800, 11);
            this.dividerPanelControl2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(775, 224);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(25, 226);
            this.panel1.TabIndex = 5;
            // 
            // FormStarsQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.dividerPanelControl1);
            this.Controls.Add(this.sharedBetweenQuestions1);
            this.Name = "FormStarsQuestion";
            this.Text = "FormSmileyQuestion";
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserController.Questions.SharedBetweenQuestions sharedBetweenQuestions1;
        private System.Windows.Forms.Panel panelContainer;
        private UserController.Questions.MinMaxNumControl minMaxNumControl1;
        private UserController.Controllers.DividerPanelControl dividerPanelControl1;
        private UserController.Controllers.DividerPanelControl dividerPanelControl2;
        private System.Windows.Forms.Panel panel1;
    }
}