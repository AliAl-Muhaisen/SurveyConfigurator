namespace SurveyConfiguratorApp.Forms
{
    partial class FormQuestion
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
            this.buttonSliderQuestion = new System.Windows.Forms.Button();
            this.buttonStarsQuestion = new System.Windows.Forms.Button();
            this.buttonSmileyQuestion = new System.Windows.Forms.Button();
            this.layoutControl1 = new SurveyConfiguratorApp.UserController.LayoutControl();
            this.SuspendLayout();
            // 
            // buttonSliderQuestion
            // 
            this.buttonSliderQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.buttonSliderQuestion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonSliderQuestion.FlatAppearance.BorderSize = 0;
            this.buttonSliderQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSliderQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSliderQuestion.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonSliderQuestion.Image = global::SurveyConfiguratorApp.Properties.Resources.left_and_right_arrows;
            this.buttonSliderQuestion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSliderQuestion.Location = new System.Drawing.Point(0, 224);
            this.buttonSliderQuestion.Name = "buttonSliderQuestion";
            this.buttonSliderQuestion.Size = new System.Drawing.Size(159, 68);
            this.buttonSliderQuestion.TabIndex = 3;
            this.buttonSliderQuestion.Text = "Slider Question";
            this.buttonSliderQuestion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSliderQuestion.UseVisualStyleBackColor = false;
            this.buttonSliderQuestion.Click += new System.EventHandler(this.buttonSliderQuestion_Click);
            // 
            // buttonStarsQuestion
            // 
            this.buttonStarsQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.buttonStarsQuestion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonStarsQuestion.FlatAppearance.BorderSize = 0;
            this.buttonStarsQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStarsQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStarsQuestion.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonStarsQuestion.Image = global::SurveyConfiguratorApp.Properties.Resources.star;
            this.buttonStarsQuestion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonStarsQuestion.Location = new System.Drawing.Point(0, 150);
            this.buttonStarsQuestion.Name = "buttonStarsQuestion";
            this.buttonStarsQuestion.Size = new System.Drawing.Size(159, 68);
            this.buttonStarsQuestion.TabIndex = 2;
            this.buttonStarsQuestion.Text = "Stars Question";
            this.buttonStarsQuestion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonStarsQuestion.UseVisualStyleBackColor = false;
            this.buttonStarsQuestion.Click += new System.EventHandler(this.buttonStarsQuestion_Click);
            // 
            // buttonSmileyQuestion
            // 
            this.buttonSmileyQuestion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.buttonSmileyQuestion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonSmileyQuestion.FlatAppearance.BorderSize = 0;
            this.buttonSmileyQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSmileyQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSmileyQuestion.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonSmileyQuestion.Image = global::SurveyConfiguratorApp.Properties.Resources.happiness__1_;
            this.buttonSmileyQuestion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSmileyQuestion.Location = new System.Drawing.Point(0, 76);
            this.buttonSmileyQuestion.Name = "buttonSmileyQuestion";
            this.buttonSmileyQuestion.Size = new System.Drawing.Size(159, 68);
            this.buttonSmileyQuestion.TabIndex = 1;
            this.buttonSmileyQuestion.Text = "Smiley Question";
            this.buttonSmileyQuestion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSmileyQuestion.UseVisualStyleBackColor = false;
            this.buttonSmileyQuestion.Click += new System.EventHandler(this.buttonSmileyQuestion_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Size = new System.Drawing.Size(1125, 619);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Load += new System.EventHandler(this.layoutControl1_Load);
            // 
            // FormQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 619);
            this.Controls.Add(this.buttonSliderQuestion);
            this.Controls.Add(this.buttonStarsQuestion);
            this.Controls.Add(this.buttonSmileyQuestion);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FormQuestion";
            this.Text = "FormQuestion";
            this.Load += new System.EventHandler(this.FormQuestion_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonSmileyQuestion;
        private System.Windows.Forms.Button buttonStarsQuestion;
        private System.Windows.Forms.Button buttonSliderQuestion;
        public UserController.LayoutControl layoutControl1;
    }
}