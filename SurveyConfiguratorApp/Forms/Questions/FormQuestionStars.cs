using SurveyConfiguratorApp.Domain;
using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
using SurveyConfiguratorApp.Logic;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.Forms.Questions
{
    public partial class FormQuestionStars : Form
    {
        private bool isUpdate = false;
        private int questionId = -1;
        private QuestionManager questionManager;
        private QuestionStars questionStars;
        private QuestionValidation questionValidation;
        public FormQuestionStars()
        {

            try
            {
                InitializeComponent();
                questionStars = new QuestionStars();
                questionManager = new QuestionManager();
                questionValidation =new QuestionValidation();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        public FormQuestionStars(int questionId) : this()
        {

            try
            {
                if (questionId != -1)
                {
                    this.questionId = questionId;
                    isUpdate = true;

                    btnSave.Text = "Update";
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

            this.questionId = questionId;
        }

        private void FormQuestionStars_Load(object sender, EventArgs e)
        {
            try
            {
                numericStarsNumber.Minimum = questionValidation.StarsMinValue;
                numericStarsNumber.Maximum = questionValidation.StarsMaxValue;

                if (questionId != -1)
                {
                    questionStars.setId(questionId);
                    // to check if the question still exists in the db
                     questionManager.GetQuestionStars(ref questionStars);
                    HandleIsQuestionNotExists();
                    fillInputs(questionStars);
                    sharedBetweenQuestions.setOldOrder(questionStars.Order);

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
                StatusCode tStatusCode= questionManager.IsQuestionExists(questionId);
                if (tStatusCode.Code != StatusCode.Success.Code)
                {
                    customMessageBoxControl1.StatusCodeMessage(tStatusCode);
                    CloseParentFrom();
                    return true;
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                    questionStars.Text = sharedBetweenQuestions.getQuestionText();
                    questionStars.Order = Convert.ToInt32(sharedBetweenQuestions.getQuestionOrder());
                    StatusCode result;

                    questionStars.StarsNumber = ((int)numericStarsNumber.Value);
                    if (!isUpdate)
                    {
                        result = questionManager.AddQuestionStars(questionStars);
                    }
                    else
                    {
                        bool isNotExits = HandleIsQuestionNotExists();
                        if (isNotExits) { return; }
                        result = questionManager.UpdateQuestionStars(questionStars);

                    }
                    if (result.Code != StatusCode.Success.Code)
                    {
                        customMessageBoxControl1.StatusCodeMessageList(ref questionManager.ValidationErrorList);
                    }

                    FormQuestion.CloseBasedOnStatus(ref result);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// Close The parent form
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

        /// <summary>
        /// fill form inputs in update operation 
        /// </summary>
        /// <param name="questionSlider"></param>
        private void fillInputs(QuestionStars questionStars)
        {
            try
            {
                sharedBetweenQuestions.setQuestionText(questionStars.Text);
                sharedBetweenQuestions.setQuestionOrderValue(questionStars.Order);
                numericStarsNumber.Value = questionStars.StarsNumber;
                sharedBetweenQuestions.setOldOrder(questionStars.Order);
                btnSave.Text = "Update";
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }
    }
}
