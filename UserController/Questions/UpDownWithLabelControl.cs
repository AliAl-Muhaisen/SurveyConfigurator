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
            labelInputValue.setText (leableValueText);
        }

        public void setInputMinValue(int value)
        {
            numericUpDown.Minimum = value;
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
           

        }
        public void handleNumericError(CallBackHandleErrorMsg handleError)
        {
            try
            {
            int value= (int)numericUpDown.Value;
            string msg=handleError(value);
                setErrorText (msg);
            }
            catch (Exception e)
            {

            }
           
        }
    }
}
