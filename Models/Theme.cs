using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.Models
{
    public static class Theme
    {
        public static Button FlatButton()
        {
            Button button = new Button();
            button.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button.ForeColor = System.Drawing.SystemColors.Control;
            button.Image = global::SurveyConfiguratorApp.Properties.Resources.home;
            button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button.Location = new System.Drawing.Point(0, 77);
            button.Name = "button";
            button.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            button.Size = new System.Drawing.Size(161, 54);
            button.TabIndex = 2;
            button.Text = "Home";
            button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            button.UseVisualStyleBackColor = true;
            return button;

        }

        public static System.Drawing.Font FontTitle()
        {
            return new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
        public static Label LabelTitle()
        {
            Label labelMainBarTitle = new Label();
            labelMainBarTitle.AutoSize = true;
            labelMainBarTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labelMainBarTitle.ForeColor = System.Drawing.SystemColors.Control;
            labelMainBarTitle.Location = new System.Drawing.Point(368, 20);
            labelMainBarTitle.Name = "labelMainBarTitle";
            labelMainBarTitle.Size = new System.Drawing.Size(86, 31);
            labelMainBarTitle.TabIndex = 0;
            labelMainBarTitle.Text = "Home";
            return labelMainBarTitle;

        }



    }


  }
