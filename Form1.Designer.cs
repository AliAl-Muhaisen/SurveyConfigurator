﻿namespace SurveyConfiguratorApp
{
    partial class Form1
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
            this.panelSideBar = new System.Windows.Forms.Panel();
            this.panelColorBottom = new System.Windows.Forms.Panel();
            this.panelLog = new System.Windows.Forms.Panel();
            this.panelHeadreBar = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.buttonHome = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelMainBarTitle = new System.Windows.Forms.Label();
            this.panelSideBar.SuspendLayout();
            this.panelLog.SuspendLayout();
            this.panelHeadreBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSideBar
            // 
            this.panelSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.panelSideBar.Controls.Add(this.buttonHome);
            this.panelSideBar.Controls.Add(this.panelColorBottom);
            this.panelSideBar.Controls.Add(this.panelLog);
            this.panelSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideBar.Location = new System.Drawing.Point(0, 0);
            this.panelSideBar.Name = "panelSideBar";
            this.panelSideBar.Size = new System.Drawing.Size(161, 612);
            this.panelSideBar.TabIndex = 0;
            // 
            // panelColorBottom
            // 
            this.panelColorBottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelColorBottom.BackColor = System.Drawing.Color.White;
            this.panelColorBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelColorBottom.Location = new System.Drawing.Point(0, 512);
            this.panelColorBottom.Name = "panelColorBottom";
            this.panelColorBottom.Size = new System.Drawing.Size(161, 100);
            this.panelColorBottom.TabIndex = 1;
            // 
            // panelLog
            // 
            this.panelLog.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelLog.Controls.Add(this.pictureBox1);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLog.Location = new System.Drawing.Point(0, 0);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(161, 77);
            this.panelLog.TabIndex = 0;
            // 
            // panelHeadreBar
            // 
            this.panelHeadreBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panelHeadreBar.Controls.Add(this.labelMainBarTitle);
            this.panelHeadreBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeadreBar.Location = new System.Drawing.Point(161, 0);
            this.panelHeadreBar.Name = "panelHeadreBar";
            this.panelHeadreBar.Size = new System.Drawing.Size(928, 77);
            this.panelHeadreBar.TabIndex = 1;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(161, 77);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.panelMain.Size = new System.Drawing.Size(928, 535);
            this.panelMain.TabIndex = 2;
            // 
            // buttonHome
            // 
            this.buttonHome.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonHome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonHome.FlatAppearance.BorderSize = 0;
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHome.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHome.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonHome.Image = global::SurveyConfiguratorApp.Properties.Resources.home;
            this.buttonHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHome.Location = new System.Drawing.Point(0, 77);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.buttonHome.Size = new System.Drawing.Size(161, 54);
            this.buttonHome.TabIndex = 2;
            this.buttonHome.Text = "Home";
            this.buttonHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonHome.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::SurveyConfiguratorApp.Properties.Resources.surveyor;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 612);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeadreBar);
            this.Controls.Add(this.panelSideBar);
            this.HelpButton = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelSideBar.ResumeLayout(false);
            this.panelLog.ResumeLayout(false);
            this.panelHeadreBar.ResumeLayout(false);
            this.panelHeadreBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSideBar;
        private System.Windows.Forms.Panel panelHeadreBar;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelColorBottom;
        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Label labelMainBarTitle;
    }
}

