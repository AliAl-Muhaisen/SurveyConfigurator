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
        readonly QuestionValidation questionValidation;
        private readonly QuestionManager questoinManager;
        private readonly bool isUpdate = false;
        private readonly int questionId = -1;

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
        /// <param name="pQuestionId"></param>
        public FormQuestionFaces(int pQuestionId) : this()
        {

            try
            {
                if (pQuestionId != -1)
                {
                    isUpdate = true;
                    this.questionId = pQuestionId;
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

                if (questionId < 0) return;
               
                    questionFaces.SetId(questionId);
                    questoinManager.GetQuestionFaces(ref questionFaces);
                    HandleIsQuestionNotExists();
                    FillInputs(questionFaces);

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
                if (questionId >0)
                {
                    QuestionFaces tQuestionFaces = new QuestionFaces();
                    tQuestionFaces.SetId(questionId);
                    int tResultCode = questoinManager.IsQuestionExists(questionId);

                    if (tResultCode != ResultCode.SUCCESS)
                    {
                        customMessageBoxControl1.StatusCodeMessage(tResultCode);
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
                    int tResult;

                    questionFaces.FacesNumber = ((int)numericFaceNumber.Value);

                    if (!isUpdate)
                    {
                        tResult = questoinManager.AddQuestionFaces(questionFaces);
                    }
                    else
                    {
                        bool tIsNotExits = HandleIsQuestionNotExists();
                        if (tIsNotExits) { return; }
                        tResult =
                            questoinManager.UpdateQuestionFaces(questionFaces);

                    }
                    if (tResult !=ResultCode.SUCCESS)
                    {
                         customMessageBoxControl1.ResultCodeMessageList(ref questoinManager.ValidationErrorList);
                    }
                   
                    FormQuestion.CloseBasedOnResult(ref tResult);

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


        private void FillInputs(QuestionFaces pQuestionFaces)
        {

            try
            {
                sharedBetweenQuestions.setQuestionText(pQuestionFaces.Text);
                sharedBetweenQuestions.setQuestionOrderValue(pQuestionFaces.Order);

                numericFaceNumber.Value = pQuestionFaces.FacesNumber;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }


    }
}
