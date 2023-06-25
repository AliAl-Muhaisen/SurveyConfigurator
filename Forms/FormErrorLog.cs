using SurveyConfiguratorApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.Forms.Log
{
    public partial class FormErrorLog : Form
    {
        private ErrorLoggerFile errorLoggerFile;
        private List<Exception> errors;
        public FormErrorLog()
        {
            try
            {
                InitializeComponent();
                errors = new List<Exception>();
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }


        }

        private void FormErrorLog_Load(object sender, EventArgs e)
        {
            try
            {
                errorLoggerFile = new ErrorLoggerFile();
                errors = errorLoggerFile.DeserializeLogFile();
                dataGridView1.DataSource = errors;
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }

        }

        private void FormErrorLog_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void handleExceptionLog(Exception ex)
        {

            ErrorLoggerFile errorLoggerFile = new ErrorLoggerFile();
            errorLoggerFile.HandleException(ex);

        }
    }
}
