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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.dividerPanelControl2 = new SurveyConfiguratorApp.UserController.Controllers.DividerPanelControl();
            this.upDownWithLabelControl = new SurveyConfiguratorApp.UserController.Questions.UpDownWithLabelControl();
            this.dividerPanelVerticalControl1 = new SurveyConfiguratorApp.UserController.Controllers.DividerPanelVerticalControl();
            this.dividerPanelControl1 = new SurveyConfiguratorApp.UserController.Controllers.DividerPanelControl();
            this.sharedBetweenQuestions = new SurveyConfiguratorApp.UserController.Questions.SharedBetweenQuestions();


            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dividerPanelControl2);
            this.panel1.Controls.Add(this.upDownWithLabelControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 224);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 226);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            this.buttonSave.Location = new System.Drawing.Point(44, 23);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.buttonSave.Size = new System.Drawing.Size(113, 53);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Save";
            this.buttonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.button2_Click);
            // 
            // dividerPanelControl2
            // 
            this.dividerPanelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanelControl2.Location = new System.Drawing.Point(0, 105);
            this.dividerPanelControl2.Name = "dividerPanelControl2";
            this.dividerPanelControl2.Size = new System.Drawing.Size(800, 11);
            this.dividerPanelControl2.TabIndex = 8;
            // 
            // upDownWithLabelControl
            // 
            this.upDownWithLabelControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.upDownWithLabelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.upDownWithLabelControl.Location = new System.Drawing.Point(0, 0);
            this.upDownWithLabelControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.upDownWithLabelControl.Name = "upDownWithLabelControl";
            this.upDownWithLabelControl.Padding = new System.Windows.Forms.Padding(8, 8, 22, 8);
            this.upDownWithLabelControl.Size = new System.Drawing.Size(800, 105);
            this.upDownWithLabelControl.TabIndex = 7;
            // 
            // dividerPanelVerticalControl1
            // 
            this.dividerPanelVerticalControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dividerPanelVerticalControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dividerPanelVerticalControl1.Location = new System.Drawing.Point(774, 224);
            this.dividerPanelVerticalControl1.Margin = new System.Windows.Forms.Padding(4);
            this.dividerPanelVerticalControl1.Name = "dividerPanelVerticalControl1";
            this.dividerPanelVerticalControl1.Size = new System.Drawing.Size(26, 226);
            this.dividerPanelVerticalControl1.TabIndex = 2;
            // 
            // dividerPanelControl1
            // 
            this.dividerPanelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dividerPanelControl1.Location = new System.Drawing.Point(0, 192);
            this.dividerPanelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.dividerPanelControl1.Name = "dividerPanelControl1";
            this.dividerPanelControl1.Size = new System.Drawing.Size(800, 32);
            this.dividerPanelControl1.TabIndex = 2;
            // 
            // sharedBetweenQuestions
            // 
            this.sharedBetweenQuestions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.sharedBetweenQuestions.Dock = System.Windows.Forms.DockStyle.Top;
            this.sharedBetweenQuestions.Location = new System.Drawing.Point(0, 0);
            this.sharedBetweenQuestions.Margin = new System.Windows.Forms.Padding(4);
            this.sharedBetweenQuestions.Name = "sharedBetweenQuestions";
            this.sharedBetweenQuestions.Size = new System.Drawing.Size(800, 192);
            this.sharedBetweenQuestions.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonSave);
            this.panel2.Location = new System.Drawing.Point(567, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 10;
            // 
            // FormFacesQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dividerPanelVerticalControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dividerPanelControl1);
            this.Controls.Add(this.sharedBetweenQuestions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFacesQuestion";
            this.Text = "FormFaces";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UserController.Questions.SharedBetweenQuestions sharedBetweenQuestions;
        private UserController.Controllers.DividerPanelControl dividerPanelControl1;
        private System.Windows.Forms.Panel panel1;
        private UserController.Controllers.DividerPanelVerticalControl dividerPanelVerticalControl1;
        private UserController.Questions.UpDownWithLabelControl upDownWithLabelControl;
        private UserController.Controllers.DividerPanelControl dividerPanelControl2;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Panel panel2;
    }
}