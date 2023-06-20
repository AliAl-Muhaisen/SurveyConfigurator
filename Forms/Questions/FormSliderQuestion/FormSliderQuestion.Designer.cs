namespace SurveyConfiguratorApp.Forms.Questions
{
    partial class FormSliderQuestion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelErrorCaptionMax = new SurveyConfiguratorApp.UserController.Questions.LabelErrorControl();
            this.labelErrorCaptionMin = new SurveyConfiguratorApp.UserController.Questions.LabelErrorControl();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxCaptionMax = new System.Windows.Forms.TextBox();
            this.textBoxCaptionMin = new System.Windows.Forms.TextBox();
            this.customLabelControlTitleCaption = new SurveyConfiguratorApp.UserController.Controllers.CustomLabelControl();
            this.customLabelControlMax = new SurveyConfiguratorApp.UserController.Controllers.CustomLabelControl();
            this.customLabelControlMin = new SurveyConfiguratorApp.UserController.Controllers.CustomLabelControl();
            this.dividerPanelControl2 = new SurveyConfiguratorApp.UserController.Controllers.DividerPanelControl();
            this.minMaxNumControl1 = new SurveyConfiguratorApp.UserController.Questions.MinMaxNumControl();
            this.dividerPanelVerticalControl1 = new SurveyConfiguratorApp.UserController.Controllers.DividerPanelVerticalControl();
            this.dividerPanelControl1 = new SurveyConfiguratorApp.UserController.Controllers.DividerPanelControl();
            this.sharedBetweenQuestions = new SurveyConfiguratorApp.UserController.Questions.SharedBetweenQuestions();
            this.panelContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.panelContainer.Controls.Add(this.panel1);
            this.panelContainer.Controls.Add(this.dividerPanelControl2);
            this.panelContainer.Controls.Add(this.minMaxNumControl1);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 224);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(800, 294);
            this.panelContainer.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelErrorCaptionMax);
            this.panel1.Controls.Add(this.labelErrorCaptionMin);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Controls.Add(this.textBoxCaptionMax);
            this.panel1.Controls.Add(this.textBoxCaptionMin);
            this.panel1.Controls.Add(this.customLabelControlTitleCaption);
            this.panel1.Controls.Add(this.customLabelControlMax);
            this.panel1.Controls.Add(this.customLabelControlMin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 163);
            this.panel1.TabIndex = 3;
            // 
            // labelErrorCaptionMax
            // 
            this.labelErrorCaptionMax.AutoSize = true;
            this.labelErrorCaptionMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelErrorCaptionMax.Location = new System.Drawing.Point(444, 88);
            this.labelErrorCaptionMax.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.labelErrorCaptionMax.Name = "labelErrorCaptionMax";
            this.labelErrorCaptionMax.Size = new System.Drawing.Size(43, 19);
            this.labelErrorCaptionMax.TabIndex = 27;
            // 
            // labelErrorCaptionMin
            // 
            this.labelErrorCaptionMin.AutoSize = true;
            this.labelErrorCaptionMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelErrorCaptionMin.Location = new System.Drawing.Point(157, 88);
            this.labelErrorCaptionMin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.labelErrorCaptionMin.Name = "labelErrorCaptionMin";
            this.labelErrorCaptionMin.Size = new System.Drawing.Size(43, 19);
            this.labelErrorCaptionMin.TabIndex = 26;
            // 
            // buttonSave
            // 
            this.buttonSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.buttonSave.Image = global::SurveyConfiguratorApp.Properties.Resources.save_instagram;
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.Location = new System.Drawing.Point(657, 96);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.buttonSave.Size = new System.Drawing.Size(113, 65);
            this.buttonSave.TabIndex = 25;
            this.buttonSave.Text = "Save";
            this.buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxCaptionMax
            // 
            this.textBoxCaptionMax.Location = new System.Drawing.Point(444, 61);
            this.textBoxCaptionMax.Name = "textBoxCaptionMax";
            this.textBoxCaptionMax.Size = new System.Drawing.Size(146, 20);
            this.textBoxCaptionMax.TabIndex = 24;
            // 
            // textBoxCaptionMin
            // 
            this.textBoxCaptionMin.Location = new System.Drawing.Point(157, 61);
            this.textBoxCaptionMin.Name = "textBoxCaptionMin";
            this.textBoxCaptionMin.Size = new System.Drawing.Size(153, 20);
            this.textBoxCaptionMin.TabIndex = 23;
            // 
            // customLabelControlTitleCaption
            // 
            this.customLabelControlTitleCaption.AutoSize = true;
            this.customLabelControlTitleCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.customLabelControlTitleCaption.Location = new System.Drawing.Point(290, 6);
            this.customLabelControlTitleCaption.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelControlTitleCaption.Name = "customLabelControlTitleCaption";
            this.customLabelControlTitleCaption.Size = new System.Drawing.Size(59, 23);
            this.customLabelControlTitleCaption.TabIndex = 22;
            // 
            // customLabelControlMax
            // 
            this.customLabelControlMax.AutoSize = true;
            this.customLabelControlMax.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.customLabelControlMax.Location = new System.Drawing.Point(363, 61);
            this.customLabelControlMax.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelControlMax.Name = "customLabelControlMax";
            this.customLabelControlMax.Size = new System.Drawing.Size(59, 23);
            this.customLabelControlMax.TabIndex = 21;
            // 
            // customLabelControlMin
            // 
            this.customLabelControlMin.AutoSize = true;
            this.customLabelControlMin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.customLabelControlMin.Location = new System.Drawing.Point(30, 61);
            this.customLabelControlMin.Margin = new System.Windows.Forms.Padding(0);
            this.customLabelControlMin.Name = "customLabelControlMin";
            this.customLabelControlMin.Size = new System.Drawing.Size(59, 23);
            this.customLabelControlMin.TabIndex = 20;
            // 
            // dividerPanelControl2
            // 
            this.dividerPanelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanelControl2.Location = new System.Drawing.Point(0, 120);
            this.dividerPanelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.dividerPanelControl2.Name = "dividerPanelControl2";
            this.dividerPanelControl2.Size = new System.Drawing.Size(800, 11);
            this.dividerPanelControl2.TabIndex = 2;
            // 
            // minMaxNumControl1
            // 
            this.minMaxNumControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.minMaxNumControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.minMaxNumControl1.EndNumMax = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.minMaxNumControl1.EndNumMin = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.minMaxNumControl1.Location = new System.Drawing.Point(0, 0);
            this.minMaxNumControl1.Margin = new System.Windows.Forms.Padding(4);
            this.minMaxNumControl1.Name = "minMaxNumControl1";
            this.minMaxNumControl1.Size = new System.Drawing.Size(800, 120);
            this.minMaxNumControl1.StartNumMax = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.minMaxNumControl1.StartNumMin = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.minMaxNumControl1.TabIndex = 0;
            // 
            // dividerPanelVerticalControl1
            // 
            this.dividerPanelVerticalControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dividerPanelVerticalControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dividerPanelVerticalControl1.Location = new System.Drawing.Point(774, 224);
            this.dividerPanelVerticalControl1.Margin = new System.Windows.Forms.Padding(4);
            this.dividerPanelVerticalControl1.Name = "dividerPanelVerticalControl1";
            this.dividerPanelVerticalControl1.Size = new System.Drawing.Size(26, 294);
            this.dividerPanelVerticalControl1.TabIndex = 3;
            // 
            // dividerPanelControl1
            // 
            this.dividerPanelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanelControl1.Location = new System.Drawing.Point(0, 192);
            this.dividerPanelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.dividerPanelControl1.Name = "dividerPanelControl1";
            this.dividerPanelControl1.Size = new System.Drawing.Size(800, 32);
            this.dividerPanelControl1.TabIndex = 1;
            // 
            // sharedBetweenQuestions
            // 
            this.sharedBetweenQuestions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.sharedBetweenQuestions.Dock = System.Windows.Forms.DockStyle.Top;
            this.sharedBetweenQuestions.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.sharedBetweenQuestions.Location = new System.Drawing.Point(0, 0);
            this.sharedBetweenQuestions.Margin = new System.Windows.Forms.Padding(4);
            this.sharedBetweenQuestions.Name = "sharedBetweenQuestions";
            this.sharedBetweenQuestions.Size = new System.Drawing.Size(800, 192);
            this.sharedBetweenQuestions.TabIndex = 0;
            // 
            // FormSliderQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 518);
            this.Controls.Add(this.dividerPanelVerticalControl1);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.dividerPanelControl1);
            this.Controls.Add(this.sharedBetweenQuestions);
            this.Name = "FormSliderQuestion";
            this.Text = "FormSliderQuestion";
            this.panelContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UserController.Questions.SharedBetweenQuestions sharedBetweenQuestions;
        private UserController.Controllers.DividerPanelControl dividerPanelControl1;
        private System.Windows.Forms.Panel panelContainer;
        private UserController.Questions.MinMaxNumControl minMaxNumControl1;
        private UserController.Controllers.DividerPanelControl dividerPanelControl2;
        private UserController.Controllers.DividerPanelVerticalControl dividerPanelVerticalControl1;
        private System.Windows.Forms.Panel panel1;
        private UserController.Questions.LabelErrorControl labelErrorCaptionMax;
        private UserController.Questions.LabelErrorControl labelErrorCaptionMin;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxCaptionMax;
        private System.Windows.Forms.TextBox textBoxCaptionMin;
        private UserController.Controllers.CustomLabelControl customLabelControlTitleCaption;
        private UserController.Controllers.CustomLabelControl customLabelControlMax;
        private UserController.Controllers.CustomLabelControl customLabelControlMin;
    }
}