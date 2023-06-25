
using SurveyConfiguratorApp.Database.Questions;
using SurveyConfiguratorApp.Models;
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

namespace SurveyConfiguratorApp.Forms
{
    public partial class FormFacesQuestion : Form
    {
        private QuestionValidation questionValidation;
        private bool isUpdate = false;

        private QuestionFaces questionFaces;
        public FormFacesQuestion()
        {


            try
            {
                InitializeComponent();
                questionFaces = new QuestionFaces();

                questionValidation = QuestionValidation.Instance();

                upDownWithLabelControl.setLabelTitle("Number Of Faces");

                upDownWithLabelControl.setInputMinValue(questionValidation.FacesMinValue);
                upDownWithLabelControl.setInputMaxValue(questionValidation.FacesMaxValue);

                upDownWithLabelControl.clearErrorText();

                upDownWithLabelControl.setCallBackFunction(new CallBackHandleErrorMsg(questionValidation.facesHandleMsg));


                sharedBetweenQuestions.clearErrorLabelsText();
                sharedBetweenQuestions.setIsNotEmptyCallBack(new CallBackIsNotEmpty(questionValidation.handelQuestionText));
                sharedBetweenQuestions.setCallBackIsOrderAlreadyExists(new CallBackIsOrderAlreadyExists(questionValidation.isOrderAlreadyExists));
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }

        }
        public FormFacesQuestion(QuestionFaces questionFaces) : this()
        {

            try
            {
                isUpdate = true;
                this.questionFaces = questionFaces;
                sharedBetweenQuestions.setQuestionText(questionFaces.Text);
                sharedBetweenQuestions.setQuestionOrderValue(questionFaces.Order);
                upDownWithLabelControl.setNumericValue(questionFaces.FacesNumber);
                sharedBetweenQuestions.setOldOrder(questionFaces.Order);
                buttonSave.Text = "Update";
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dividerPanelControl2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                bool isValidGeneralQuestions = sharedBetweenQuestions.isValidForm();
                bool isValidFacesNumber = upDownWithLabelControl.isValidForm();
                if (isValidGeneralQuestions && isValidFacesNumber)
                {
                    questionFaces.Text = sharedBetweenQuestions.getQuestionText();
                    questionFaces.Order = Convert.ToInt32(sharedBetweenQuestions.getQuestionOrder());
                    bool result = false;

                    questionFaces.FacesNumber = upDownWithLabelControl.getFacesNumber();
                    if (!isUpdate)
                    {

                        result = questionFaces.add();
                        customMessageBoxControl1.sqlInsert(result);
                        if (result)
                        {
                            sharedBetweenQuestions.clearInputValues();
                            sharedBetweenQuestions.clearErrorLabelsText();
                            upDownWithLabelControl.clearInputValues();
                            upDownWithLabelControl.clearErrorText();
                        }
                    }
                    else
                    {
                        result = questionFaces.update();

                        customMessageBoxControl1.sqlUpdate(result);
                        sharedBetweenQuestions.setOldOrder(questionFaces.Order);

                    }



                }

            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void handleExceptionLog(Exception ex)
        {

            ErrorLoggerFile errorLoggerFile = new ErrorLoggerFile();
            errorLoggerFile.HandleException(ex);

        }
    }
}
