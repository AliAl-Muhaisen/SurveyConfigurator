﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.UserController.Questions
{
    public partial class SharedBetweenQuestions : UserControl
    {
        public SharedBetweenQuestions()
        {
            InitializeComponent();
            labelQuestionText.setText("Text");
            labelQuestionOrder.setText("Order");
        }

        private void customLabelControl1_Load(object sender, EventArgs e)
        {

        }

        private void SharedBetweenQuestions_Load(object sender, EventArgs e)
        {

        }
    }
}