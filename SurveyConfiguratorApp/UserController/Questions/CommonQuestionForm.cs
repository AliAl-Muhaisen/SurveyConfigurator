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
        private int oldOrder = -1;
        public CommonQuestionForm()
        {

            try
            {
                InitializeComponent();
                questionValidation =new QuestionValidation();

                clearErrorLabelsText();
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
                handelQuestionText();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        public void handelQuestionText()
        {


            try
            {
                //string msg = null;
                //{
                //    string inputText = textBoxQuestionText.Text;
                //    msg = questionValidation.HandelQuestionText(inputText);
                //    labelErrorQuestionText.setText(msg);


                //    if (msg == null)
                //    {
                //        isValidQuestionText = true;
                //    }
                //    else
                //        isValidQuestionText = false;

                //}
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        public bool isValidForm()
        {
            try
            {
                handelQuestionText();
                handleOrderValue();

                return isValidOrderValue && isValidQuestionText;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
            return false;

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



        public void clearErrorLabelsText()
        {
            try
            {
                labelErrorQuestionOrder.clearText();
                labelErrorQuestionText.clearText();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }


        /// <summary>
        /// Check if the order is taken 
        /// </summary>
        private void handleOrderValue()
        {
            try
            {
                bool isExists = false;

                int newOderValue = (int)numericUpDownQuestionOrder.Value;

                //isExists = questionValidation.IsOrderAlreadyExists(newOderValue, oldOrder);


                //if (isExists)
                //{
                //    labelErrorQuestionOrder.setText("This Order Alread Exists");
                //    isValidOrderValue = false;
                //}
                //else
                //{
                    isValidOrderValue = true;
                    labelErrorQuestionOrder.clearText();
               //}

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

        /// <summary>
        /// set order in update operation 
        /// </summary>
        /// <param name="value"></param>
        public void setOldOrder(int value)
        {

            try
            {
                oldOrder = value;
                handleOrderValue();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void labelErrorQuestionText_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelErrorQuestionOrder_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }
    }
}
