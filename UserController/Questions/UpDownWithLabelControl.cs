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
         
        private bool isValidNumber=false;

        private CallBackHandleErrorMsg callBackHandleErrorMsg;
        public UpDownWithLabelControl()
        {
            InitializeComponent();
            labelInputValue.setText("Value");


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

                MessageBox.Show("Call Back Failed 2" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Call Back Failed ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

    }
}
