﻿using SurveyConfiguratorApp.Models;
using SurveyConfiguratorApp.Models.Questions;
using SurveyConfiguratorApp.UserController.Questions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SurveyConfiguratorApp.Models.Questions.Question;
using static SurveyConfiguratorApp.UserController.Questions.SharedBetweenQuestions;
using static SurveyConfiguratorApp.UserController.Questions.UpDownWithLabelControl;

namespace SurveyConfiguratorApp.Forms.Questions
{
    public partial class FormStarsQuestion : Form
    {
        private QuestionValidation questionValidation;
        private bool isUpdate = false;
        private QuestionStars questionStars;

        public FormStarsQuestion()
        {
            try
            {
                InitializeComponent();

                this.questionStars = new QuestionStars();

                questionValidation = QuestionValidation.Instance();


                upDownWithLabelControl1.setLabelTitle("Number Of Stars");

                upDownWithLabelControl1.setInputMinValue(questionValidation.StarsMinValue);
                upDownWithLabelControl1.setInputMaxValue(questionValidation.StarsMaxValue);
                upDownWithLabelControl1.clearErrorText();

                upDownWithLabelControl1.setCallBackFunction(new CallBackHandleErrorMsg(questionValidation.facesHandleMsg));

                sharedBetweenQuestions1.clearErrorLabelsText();
                sharedBetweenQuestions1.setIsNotEmptyCallBack(new CallBackIsNotEmpty(questionValidation.handelQuestionText));
                sharedBetweenQuestions1.setCallBackIsOrderAlreadyExists(new CallBackIsOrderAlreadyExists(questionValidation.isOrderAlreadyExists));
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }



        }
        public FormStarsQuestion(QuestionStars questionStars) : this()
        {

            try
            {
                this.isUpdate = true;


                this.questionStars = questionStars;
                sharedBetweenQuestions1.setQuestionText(questionStars.Text);
                sharedBetweenQuestions1.setQuestionOrderValue(questionStars.Order);
                upDownWithLabelControl1.setNumericValue(questionStars.StarsNumber);
                sharedBetweenQuestions1.setOldOrder(questionStars.Order);
                buttonSave.Text = "Update";
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }



        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void upDownWithLabelControl_Load(object sender, EventArgs e)
        {

        }

        private void FormStarsQuestion_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool isValidGeneralQuestions = sharedBetweenQuestions1.isValidForm();
                bool isValidFacesNumber = upDownWithLabelControl1.isValidForm();
                if (isValidGeneralQuestions && isValidFacesNumber)
                {


                    questionStars.Text = sharedBetweenQuestions1.getQuestionText();
                    questionStars.Order = Convert.ToInt32(sharedBetweenQuestions1.getQuestionOrder());

                    questionStars.StarsNumber = upDownWithLabelControl1.getFacesNumber();

                    bool result = false;
                    if (!isUpdate)
                    {
                        result = questionStars.add();
                        customMessageBoxControl1.sqlInsert(result);
                        if (result)
                        {
                            upDownWithLabelControl1.clearInputValues();
                            sharedBetweenQuestions1.clearInputValues();
                            upDownWithLabelControl1.clearErrorText();
                            sharedBetweenQuestions1.clearErrorLabelsText();
                        }
                    }
                    else
                    {
                        result = questionStars.update();
                        customMessageBoxControl1.sqlUpdate(result);
                        sharedBetweenQuestions1.setOldOrder(questionStars.Order);
                    }



                }

            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }



        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void sharedBetweenQuestions1_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void handleExceptionLog(Exception ex)
        {

            ErrorLoggerFile errorLoggerFile = new ErrorLoggerFile();
            errorLoggerFile.HandleException(ex);

        }
    }
}
