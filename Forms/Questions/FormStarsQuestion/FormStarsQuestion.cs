﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.Forms.Questions
{
    public partial class FormStarsQuestion : Form
    {
        public FormStarsQuestion()
        {
            InitializeComponent();
            minMaxNumControl1.setLabelTitleText("Number Of Stars");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
