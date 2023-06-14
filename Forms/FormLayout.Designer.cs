namespace SurveyConfiguratorApp.Forms
{
    partial class FormLayout
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
            this.panelLog = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelColorBottom = new System.Windows.Forms.Panel();
            this.panelSideBar = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.labelMainBarTitle = new System.Windows.Forms.Label();
            this.panelHeadreBar = new System.Windows.Forms.Panel();
            this.panelLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelSideBar.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelHeadreBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLog
            // 
            this.panelLog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelLog.Controls.Add(this.pictureBox1);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLog.Location = new System.Drawing.Point(0, 0);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(161, 78);
            this.panelLog.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::SurveyConfiguratorApp.Properties.Resources.surveyor;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelColorBottom
            // 
            this.panelColorBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelColorBottom.BackColor = System.Drawing.Color.White;
            this.panelColorBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelColorBottom.Location = new System.Drawing.Point(0, 549);
            this.panelColorBottom.Name = "panelColorBottom";
            this.panelColorBottom.Size = new System.Drawing.Size(161, 100);
            this.panelColorBottom.TabIndex = 1;
            // 
            // panelSideBar
            // 
            this.panelSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.panelSideBar.Controls.Add(this.panelColorBottom);
            this.panelSideBar.Controls.Add(this.panelLog);
            this.panelSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideBar.Location = new System.Drawing.Point(0, 0);
            this.panelSideBar.Name = "panelSideBar";
            this.panelSideBar.Size = new System.Drawing.Size(161, 649);
            this.panelSideBar.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(290, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panelMain.Controls.Add(this.button1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.panelMain.Size = new System.Drawing.Size(1101, 649);
            this.panelMain.TabIndex = 5;
            // 
            // labelMainBarTitle
            // 
            this.labelMainBarTitle.AutoSize = true;
            this.labelMainBarTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMainBarTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.labelMainBarTitle.Location = new System.Drawing.Point(368, 20);
            this.labelMainBarTitle.Name = "labelMainBarTitle";
            this.labelMainBarTitle.Size = new System.Drawing.Size(86, 31);
            this.labelMainBarTitle.TabIndex = 0;
            this.labelMainBarTitle.Text = "Home";
            // 
            // panelHeadreBar
            // 
            this.panelHeadreBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panelHeadreBar.Controls.Add(this.labelMainBarTitle);
            this.panelHeadreBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeadreBar.Location = new System.Drawing.Point(161, 0);
            this.panelHeadreBar.Name = "panelHeadreBar";
            this.panelHeadreBar.Size = new System.Drawing.Size(940, 78);
            this.panelHeadreBar.TabIndex = 4;
            // 
            // FormLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 649);
            this.Controls.Add(this.panelHeadreBar);
            this.Controls.Add(this.panelSideBar);
            this.Controls.Add(this.panelMain);
            this.Name = "FormLayout";
            this.Text = "FormLayout";
            this.panelLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelSideBar.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelHeadreBar.ResumeLayout(false);
            this.panelHeadreBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelColorBottom;
        private System.Windows.Forms.Panel panelSideBar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label labelMainBarTitle;
        private System.Windows.Forms.Panel panelHeadreBar;
    }
}