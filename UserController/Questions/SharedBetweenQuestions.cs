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
    public partial class SharedBetweenQuestions : UserControl
    {

        public delegate string CallBackIsNotEmpty(string text);
        public delegate bool CallBackIsOrderAlreadyExists(int order,int oldOrder);
        private CallBackIsNotEmpty callBackIsNotEmptyMsg;
        private CallBackIsOrderAlreadyExists callBackIsOrderAlreadyExists;

        private bool isValidQuestionText = false;
        private bool isValidOrderValue = false;
        private int oldOrder = -1;
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

        private void textBoxQuestionText_TextChanged(object sender, EventArgs e)
        {
            handelQuestionText();

        }

        public void handelQuestionText()
        {
            string msg = null;
            if (callBackIsNotEmptyMsg != null)
            {
                string inputText = textBoxQuestionText.Text;
                msg = callBackIsNotEmptyMsg(inputText);
                labelErrorQuestionText.setText(msg);


                if (msg == null)
                {
                    isValidQuestionText = true;
                }
                else
                    isValidQuestionText = false;

            }
        }

        public bool isValidForm()
        {
            handelQuestionText();
            handleOrderValue();

            return isValidOrderValue && isValidQuestionText;
        }
        public string getQuestionText()
        {
            return textBoxQuestionText.Text;
        }
        public void setQuestionText(string questionText)
        {
            textBoxQuestionText.Text = questionText;
        }



        public string getQuestionOrder()
        {
            return numericUpDownQuestionOrder.Text;
        }
        public void setQuestionOrderValue(int num)
        {
            numericUpDownQuestionOrder.Value = (decimal)num;
        }

        //# Question Text Error Label


        public void clearErrorLabelQuestionText()
        {
            labelErrorQuestionText.clearText();
        }
        //!End Question Text Error Label

        //# Question Order Error Label
        private void setErrorLabelQuestionOrder(string errorText)
        {
            labelErrorQuestionOrder.setText(errorText);
        }
        public void clearErrorLabelQuestionOrder()
        {
            labelErrorQuestionOrder.clearText();
        }

        //! End Question Order Error Label

        public void clearLabelsText()
        {
            labelErrorQuestionOrder.clearText();
            labelErrorQuestionText.clearText();


        }
        public void setIsNotEmptyCallBack(CallBackIsNotEmpty callBack)
        {

            try
            {
                callBackIsNotEmptyMsg = callBack;
            }
            catch (Exception ex)
            {
                MessageBox.Show("callBackIsNotEmptyMsg Failed ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TODO:use log here

            }
        }

        public void setCallBackIsOrderAlreadyExists(CallBackIsOrderAlreadyExists callBack)
        {

            try
            {
                callBackIsOrderAlreadyExists = callBack;
            }
            catch (Exception ex)
            {
                MessageBox.Show("callBackIsNotEmptyMsg Failed ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TODO:use log here

            }
        }

        private void handleOrderValue()
        {
            bool isExists = false;
            if (callBackIsOrderAlreadyExists != null)
            {
                int newOderValue = (int)numericUpDownQuestionOrder.Value;
                
                isExists = callBackIsOrderAlreadyExists(newOderValue, oldOrder);



                if (isExists)
                {
                    labelErrorQuestionOrder.setText("This Order Alread Exists");
                    isValidOrderValue = false;
                }
                else
                {
                    isValidOrderValue = true;
                    labelErrorQuestionOrder.clearText();
                }


            }
        }
        public void clearInputValues()
        {
            textBoxQuestionText.Text = null;
            numericUpDownQuestionOrder.Value = 1;
        }

        private void numericUpDownQuestionOrder_ValueChanged(object sender, EventArgs e)
        {
            handleOrderValue();
        }
        public void setOldOrder(int value)
        {
            oldOrder = value;
        }
    }
}
