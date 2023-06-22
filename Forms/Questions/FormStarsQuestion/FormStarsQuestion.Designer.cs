﻿namespace SurveyConfiguratorApp.Forms.Questions
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.sharedBetweenQuestions1 = new SurveyConfiguratorApp.UserController.Questions.SharedBetweenQuestions();
            this.dividerPanelControl3 = new SurveyConfiguratorApp.UserController.Controllers.DividerPanelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.dividerPanelControl4 = new SurveyConfiguratorApp.UserController.Controllers.DividerPanelControl();
            this.upDownWithLabelControl1 = new SurveyConfiguratorApp.UserController.Questions.UpDownWithLabelControl();
            this.dividerPanelVerticalControl1 = new SurveyConfiguratorApp.UserController.Controllers.DividerPanelVerticalControl();
            this.customMessageBoxControl1 = new SurveyConfiguratorApp.UserController.Controllers.CustomMessageBoxControl();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
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
            // button2
            // 
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.button2.Image = global::SurveyConfiguratorApp.Properties.Resources.save_instagram;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(656, 162);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(113, 54);
            this.button2.TabIndex = 11;
            this.button2.Text = "Save";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 224);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(800, 226);
            this.panelContainer.TabIndex = 4;
            // 
            // sharedBetweenQuestions1
            // 
            this.sharedBetweenQuestions1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.sharedBetweenQuestions1.Dock = System.Windows.Forms.DockStyle.Top;
            this.sharedBetweenQuestions1.Location = new System.Drawing.Point(0, 0);
            this.sharedBetweenQuestions1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.sharedBetweenQuestions1.Name = "sharedBetweenQuestions1";
            this.sharedBetweenQuestions1.Size = new System.Drawing.Size(1067, 236);
            this.sharedBetweenQuestions1.TabIndex = 0;
            this.sharedBetweenQuestions1.Load += new System.EventHandler(this.sharedBetweenQuestions1_Load);
            // 
            // dividerPanelControl3
            // 
            this.dividerPanelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanelControl3.Location = new System.Drawing.Point(0, 236);
            this.dividerPanelControl3.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dividerPanelControl3.Name = "dividerPanelControl3";
            this.dividerPanelControl3.Size = new System.Drawing.Size(1067, 39);
            this.dividerPanelControl3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.panel2.Controls.Add(this.customMessageBoxControl1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dividerPanelControl4);
            this.panel2.Controls.Add(this.upDownWithLabelControl1);
            this.panel2.Controls.Add(this.dividerPanelVerticalControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 275);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1067, 279);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint_1);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonSave);
            this.panel3.Location = new System.Drawing.Point(757, 150);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(267, 123);
            this.panel3.TabIndex = 11;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.AutoSize = true;
            this.buttonSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.buttonSave.Image = global::SurveyConfiguratorApp.Properties.Resources.save_instagram;
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.Location = new System.Drawing.Point(60, 32);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 4, 40, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.buttonSave.Size = new System.Drawing.Size(172, 65);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save";
            this.buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // dividerPanelControl4
            // 
            this.dividerPanelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanelControl4.Location = new System.Drawing.Point(0, 129);
            this.dividerPanelControl4.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dividerPanelControl4.Name = "dividerPanelControl4";
            this.dividerPanelControl4.Size = new System.Drawing.Size(1032, 14);
            this.dividerPanelControl4.TabIndex = 3;
            // 
            // upDownWithLabelControl1
            // 
            this.upDownWithLabelControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.upDownWithLabelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.upDownWithLabelControl1.Location = new System.Drawing.Point(0, 0);
            this.upDownWithLabelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.upDownWithLabelControl1.Name = "upDownWithLabelControl1";
            this.upDownWithLabelControl1.Padding = new System.Windows.Forms.Padding(11, 10, 29, 10);
            this.upDownWithLabelControl1.Size = new System.Drawing.Size(1032, 129);
            this.upDownWithLabelControl1.TabIndex = 2;
            // 
            // dividerPanelVerticalControl1
            // 
            this.dividerPanelVerticalControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dividerPanelVerticalControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dividerPanelVerticalControl1.Location = new System.Drawing.Point(1032, 0);
            this.dividerPanelVerticalControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dividerPanelVerticalControl1.Name = "dividerPanelVerticalControl1";
            this.dividerPanelVerticalControl1.Size = new System.Drawing.Size(35, 279);
            this.dividerPanelVerticalControl1.TabIndex = 1;
            // 
            // customMessageBoxControl1
            // 
            this.customMessageBoxControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.customMessageBoxControl1.Location = new System.Drawing.Point(1054, 150);
            this.customMessageBoxControl1.Name = "customMessageBoxControl1";
            this.customMessageBoxControl1.Size = new System.Drawing.Size(10, 23);
            this.customMessageBoxControl1.TabIndex = 12;
            // 
            // FormStarsQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dividerPanelControl3);
            this.Controls.Add(this.sharedBetweenQuestions1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormStarsQuestion";
            this.Text = "FormSmileyQuestion";
            this.Load += new System.EventHandler(this.FormStarsQuestion_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UserController.Questions.SharedBetweenQuestions sharedBetweenQuestions;
        private UserController.Controllers.DividerPanelControl dividerPanelControl1;
        private UserController.Controllers.DividerPanelControl dividerPanelControl2;
        private UserController.Questions.UpDownWithLabelControl upDownWithLabelControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelContainer;
        private UserController.Questions.SharedBetweenQuestions sharedBetweenQuestions1;
        private UserController.Controllers.DividerPanelControl dividerPanelControl3;
        private System.Windows.Forms.Panel panel2;
        private UserController.Controllers.DividerPanelControl dividerPanelControl4;
        private UserController.Questions.UpDownWithLabelControl upDownWithLabelControl1;
        private UserController.Controllers.DividerPanelVerticalControl dividerPanelVerticalControl1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Panel panel3;
        private UserController.Controllers.CustomMessageBoxControl customMessageBoxControl1;
    }
}