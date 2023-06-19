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
    public partial class SharedBetweenQuestions : UserControl
    {
        public delegate string CallBackIsNotEmpty(string text);
        private CallBackIsNotEmpty callBackIsNotEmptyMsg;
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
            string msg = null;
            if (callBackIsNotEmptyMsg != null)
            {
                string inputText = textBoxQuestionText.Text;
                msg = callBackIsNotEmptyMsg(inputText);
                labelErrorQuestionText.setText(msg);

            }

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
    }
}
