using SurveyConfiguratorApp.Domain;
using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
using SurveyConfiguratorApp.Logic;
using SurveyConfiguratorApp.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.Forms.Questions
{
    public partial class FormQuestionFaces : Form
    {
        QuestionValidation questionValidation;
        private QuestionManager questoinManager;
        private bool isUpdate = false;
        private int questionId = -1;

        private QuestionFaces questionFaces;
        public FormQuestionFaces()
        {

            try
            {
                InitializeComponent();
                questionFaces = new QuestionFaces();
                questionValidation =new QuestionValidation();
                questoinManager = new QuestionManager();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="questionId"></param>
        public FormQuestionFaces(int questionId) : this()
        {

            try
            {
                if (questionId != -1)
                {
                    isUpdate = true;
                    this.questionId = questionId;
                    btnSave.Text = Resource.UPDATE;
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }
        /// <summary>
        /// Used in update operation 
        /// </summary>
        /// <param name="questionId"></param>
        private void FormQuestionFaces_Load(object sender, EventArgs e)
        {
            try
            {
                numericFaceNumber.Maximum = questionValidation.FacesMaxValue;
                numericFaceNumber.Minimum = questionValidation.FacesMinValue;

                if (questionId != -1)
                {
                    questionFaces.setId(questionId);
                    questoinManager.GetQuestionFaces(ref questionFaces);
                    HandleIsQuestionNotExists();
                    fillInputs(questionFaces);

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }



        }

        private bool HandleIsQuestionNotExists()
        {
            try
            {
                if (questionId != -1)
                {
                    QuestionFaces questionFaces = new QuestionFaces();
                    questionFaces.setId(questionId);
                    int statusCode = questoinManager.IsQuestionExists(questionId);

                    if (statusCode != StatusCode.SUCCESS)
                    {
                        customMessageBoxControl1.StatusCodeMessage(statusCode);
                        CloseParentFrom();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return false;
        }

        // From Buttons
        /// <summary>
        /// used for save and upate question 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {


            try
            {
               // bool isValidGeneralQuestions = sharedBetweenQuestions.isValidForm();
              //  if (isValidGeneralQuestions)
                {
                    questionFaces.Text = sharedBetweenQuestions.getQuestionText();
                    questionFaces.Order = Convert.ToInt32(sharedBetweenQuestions.getQuestionOrder());
                    int result ;

                    questionFaces.FacesNumber = ((int)numericFaceNumber.Value);

                    if (!isUpdate)
                    {
                        result = questoinManager.AddQuestionFaces(questionFaces);
                    }
                    else
                    {
                        bool isNotExits = HandleIsQuestionNotExists();
                        if (isNotExits) { return; }
                        result =
                            questoinManager.UpdateQuestionFaces(questionFaces);

                    }
                    if (result !=StatusCode.SUCCESS)
                    {
                         customMessageBoxControl1.StatusCodeMessageList(ref questoinManager.ValidationErrorList);
                    }
                   
                    FormQuestion.CloseBasedOnStatus(ref result);

                }

            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// Close The parent form that running the child form
        /// </summary>
        private void CloseParentFrom()
        {
            try
            {
                FormQuestion.CloseForm();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        /// <summary>
        /// Close the Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {

            try
            {
                CloseParentFrom();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }


        private void fillInputs(QuestionFaces questionFaces)
        {

            try
            {
                sharedBetweenQuestions.setQuestionText(questionFaces.Text);
                sharedBetweenQuestions.setQuestionOrderValue(questionFaces.Order);

                numericFaceNumber.Value = questionFaces.FacesNumber;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }


    }
}
