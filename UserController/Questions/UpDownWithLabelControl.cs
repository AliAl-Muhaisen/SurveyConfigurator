using SurveyConfiguratorApp.Models;
using SurveyConfiguratorApp.Models.Questions;
using System;
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
    public partial class UpDownWithLabelControl : UserControl
    {


        public delegate string CallBackHandleErrorMsg(int num);

        private bool isValidNumber = false;

        private CallBackHandleErrorMsg callBackHandleErrorMsg;
        public UpDownWithLabelControl()
        {

            try
            {
                InitializeComponent();
                labelInputValue.setText("Value");
            }
            catch (Exception e)
            {
                handleExceptionLog(e);
            }


        }


        public void setLabelTitle(string title)
        {
            labelTitle.setText(title);
        }

        public void setLeableValueText(string leableValueText)
        {
            labelInputValue.setText(leableValueText);
        }

        public void setInputMinValue(int value)
        {
            numericUpDown.Minimum = value;
            numericUpDown.Value = value;
        }

        public void setInputMaxValue(int value)
        {
            numericUpDown.Maximum = value;
        }
        public void setErrorText(string errorText)
        {
            labelErrorControl.setText(errorText);
        }
        public void setNumericValue(int value)
        {

            try
            {
                if (value > numericUpDown.Maximum || value < numericUpDown.Minimum)
                    numericUpDown.Value = numericUpDown.Minimum;


                else numericUpDown.Value = value;
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }
        }


        public void clearErrorText()
        {
            labelErrorControl.clearText();
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            string msg = null;
            try
            {
                int value = (int)numericUpDown.Value;
                if (callBackHandleErrorMsg != null)
                    msg = callBackHandleErrorMsg(value);
                setErrorText(msg);
                if (msg == null)
                {
                    isValidNumber = true;
                }
                else
                    isValidNumber = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Something went wrong please try again" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                handleExceptionLog(ex);

            }

        }
        public void setCallBackFunction(CallBackHandleErrorMsg callBackFun)
        {
            try
            {
                callBackHandleErrorMsg = callBackFun;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong please try again" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                handleExceptionLog(ex);
            }

        }

        public int getFacesNumber()
        {
            return (int)numericUpDown.Value;
        }

        public bool isValidForm()
        {
            return isValidNumber;
        }

        public void clearInputValues()
        {
            numericUpDown.Value = numericUpDown.Minimum;

        }
        private void handleExceptionLog(Exception ex)
        {

            ErrorLoggerFile errorLoggerFile = new ErrorLoggerFile();
            errorLoggerFile.HandleException(ex);

        }

    }
}
