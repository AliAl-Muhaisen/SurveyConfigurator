using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
using System;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.UserController.Questions
{
    public partial class CommonQuestionForm : UserControl
    {

        QuestionValidation questionValidation;

        private bool isValidQuestionText = false;
        private bool isValidOrderValue = false;
        public CommonQuestionForm()
        {

            try
            {
                InitializeComponent();
                questionValidation =new QuestionValidation();

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
        public void setQuestionText(string questionText)
        {

            try
            {
                textBoxQuestionText.Text = questionText;
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
        public void setQuestionOrderValue(int num)
        {

            try
            {
                numericUpDownQuestionOrder.Value = (decimal)num;
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
        private void handleOrderValue()
        {
            try
            {
                int newOderValue = (int)numericUpDownQuestionOrder.Value;
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
                handleOrderValue();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

     
       
    }
}
