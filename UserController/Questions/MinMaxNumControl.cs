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

namespace SurveyConfiguratorApp.UserController.Questions
{
    public partial class MinMaxNumControl : UserControl
    {
        private bool isValidMinNum = false;
        private bool isValidMaxNum = false;


        public decimal StartNumMin
        {
            get
            {
                return numericUpDownStart.Minimum;
            }
            set
            {
                numericUpDownStart.Minimum = value;
                numericUpDownStart.Value = value;
            }

        }

        public decimal StartNumMax
        {
            get
            {
                return numericUpDownEnd.Maximum;
            }
            set
            {
                numericUpDownStart.Maximum = value;
            }

        }

        public decimal EndNumMin
        {
            get
            {
                return numericUpDownEnd.Minimum;
            }
            set { numericUpDownEnd.Minimum = value; }

        }

        public decimal EndNumMax
        {
            get
            {
                return numericUpDownEnd.Maximum;
            }
            set
            {
                numericUpDownEnd.Maximum = value;
                numericUpDownEnd.Value = value;
            }

        }

        public MinMaxNumControl()
        {
            try
            {
                InitializeComponent();
                customLabelControlMax.setText("Max");
                customLabelControlMin.setText("Min");
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }


        }


        public void setLabelTitleText(string title)
        {
            customLabelControlTitle.setText(title);
        }


        private void numericUpDownStart_ValueChanged(object sender, EventArgs e)
        {
            handleMinValue();
        }

        private void numericUpDownStart_MouseDown(object sender, MouseEventArgs e)
        {
            handleMinValue();
        }

        private void handleMinValue()
        {
            try
            {
                if (numericUpDownStart.Value >= numericUpDownEnd.Value)
                {
                    setLabelErrorMin("Min should be less than max");
                    isValidMinNum = false;

                }

                else if (numericUpDownStart.Value < numericUpDownStart.Minimum)
                {
                    setLabelErrorMin("number must be greater than or equal " + numericUpDownStart.Minimum);

                }

                else
                {
                    setLabelErrorMin(null);
                    isValidMinNum = true;
                }
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }





        }

        private void handleMaxValue()
        {
            try
            {
                if (numericUpDownEnd.Value <= numericUpDownStart.Value)
                {
                    setLabelErrorMax("Max should be greater than min");
                    isValidMaxNum = false;

                }

                else if (numericUpDownEnd.Value <= numericUpDownEnd.Minimum)
                {
                    setLabelErrorMax("number must be greater than or equal " + numericUpDownEnd.Minimum);


                }

                else if (numericUpDownEnd.Value > numericUpDownEnd.Maximum)
                {
                    setLabelErrorMax("number must be less than or equal " + numericUpDownEnd.Maximum);
                    isValidMaxNum = false;

                }
                else
                {
                    setLabelErrorMax(null);
                    isValidMaxNum = true;
                }


            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }
        }
        private void numericUpDownStart_KeyDown(object sender, KeyEventArgs e)
        {

            handleMinValue();

        }


        public void clearErrorLabelsText()
        {
            labelErrorMax.clearText();
            labelErrorMin.clearText();
        }
        public void setLabelErrorMax(string errorMax)
        {
            labelErrorMax.setText(errorMax);
        }
        public void setLabelErrorMin(string errorMin)
        {
            labelErrorMin.setText(errorMin);
        }

        private void numericUpDownEnd_ValueChanged(object sender, EventArgs e)
        {
            handleMaxValue();
        }

        private void numericUpDownEnd_KeyDown(object sender, KeyEventArgs e)
        {
            handleMaxValue();
        }

        private void numericUpDownEnd_MouseDown(object sender, MouseEventArgs e)
        {
            handleMaxValue();
        }

        private void numericUpDownEnd_KeyUp(object sender, KeyEventArgs e)
        {
            handleMaxValue();
        }

        public bool isValidForm()
        {
            try
            {
                handleMaxValue();
                handleMinValue();
                return isValidMaxNum && isValidMinNum;
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }
            return false;

        }

        public int getStartValue()
        {
            try
            {
                return (int)numericUpDownStart.Value;
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }
            return 0;

        }

        public int getEndValue()
        {
            try
            {
                return (int)numericUpDownEnd.Value;
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }
            return 0;

        }
        public void setStartValue(int value)
        {
            try
            {
                if (value > numericUpDownStart.Maximum || value < numericUpDownStart.Minimum)
                    numericUpDownStart.Value = numericUpDownStart.Minimum;


                else numericUpDownStart.Value = value;
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }

        }

        public void setEndValue(int value)
        {
            try
            {
                if (value > numericUpDownEnd.Maximum || value < numericUpDownEnd.Minimum)
                    numericUpDownEnd.Value = numericUpDownEnd.Minimum;


                else numericUpDownEnd.Value = value;
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }


        }


        public void clearInputValues()
        {

            try
            {
                numericUpDownEnd.Value = numericUpDownEnd.Maximum;
                numericUpDownStart.Value = numericUpDownStart.Minimum;
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }

        }

        private void handleExceptionLog(Exception ex)
        {

            ErrorLoggerFile errorLoggerFile = new ErrorLoggerFile();
            errorLoggerFile.HandleException(ex);

        }
    }
}
