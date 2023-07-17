using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
using System;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.UserController.Questions
{
    public partial class CommonQuestionForm : UserControl
    {

 
        public CommonQuestionForm()
        {

            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void textBoxQuestionText_TextChanged(object sender, EventArgs e)
        {

            try
            {
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

      
        public string getQuestionText()
        {

            try
            {
                return textBoxQuestionText.Text;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
            return null;
        }
        public void setQuestionText(string pQuestionText)
        {

            try
            {
                textBoxQuestionText.Text = pQuestionText;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }



        public string getQuestionOrder()
        {
            try
            {
                return numericUpDownQuestionOrder.Text;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
            return null;

        }
        public void setQuestionOrderValue(int pNum)
        {

            try
            {
                numericUpDownQuestionOrder.Value = (decimal)pNum;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        //# Question Text Error Label


        //!End Question Text Error Label


        /// <summary>
        /// Check if the order is taken 
        /// </summary>
        private void HandleOrderValue()
        {
            try
            {
                int tNewOderValue = (int)numericUpDownQuestionOrder.Value;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void numericUpDownQuestionOrder_ValueChanged(object sender, EventArgs e)
        {

            try
            {
                HandleOrderValue();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
