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
    public partial class LabelErrorControl : UserControl
    {

        public LabelErrorControl()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                HandleExceptionLog(ex);
            }


        }

        public void SetText(string text)
        {
            labelError.Text = text;
        }
        public void ClearText()
        {
            labelError.Text = null;
        }

        private void HandleExceptionLog(Exception ex)
        {

            //ErrorLoggerFile errorLoggerFile = new ErrorLoggerFile();
            //errorLoggerFile.HandleException(ex);

        }

    }
}
