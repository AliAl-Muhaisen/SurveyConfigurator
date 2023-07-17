using SurveyConfiguratorApp.Domain;
using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
using SurveyConfiguratorApp.Logic;
using SurveyConfiguratorApp.Properties;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.Forms.Questions
{
    public partial class FormQuestionStars : Form
    {
        private readonly bool isUpdate = false;
        private readonly int questionId = -1;
        private readonly QuestionManager questionManager;
        private QuestionStars questionStars;
        private readonly QuestionValidation questionValidation;
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

        public FormQuestionStars(int tQuestionId) : this()
        {

            try
            {
                if (tQuestionId != -1)
                {
                    this.questionId = tQuestionId;
                    isUpdate = true;

                    btnSave.Text = Resource.UPDATE;
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

            this.questionId = tQuestionId;
        }

        private void FormQuestionStars_Load(object sender, EventArgs e)
        {
            try
            {
                numericStarsNumber.Minimum = questionValidation.StarsMinValue;
                numericStarsNumber.Maximum = questionValidation.StarsMaxValue;

                if (questionId != -1)
                {
                    questionStars.SetId(questionId);
                    // to check if the question still exists in the db
                     questionManager.GetQuestionStars(ref questionStars);
                    HandleIsQuestionNotExists();
                    FillInputs(questionStars);

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
                int tStatusCode= questionManager.IsQuestionExists(questionId);
                if (tStatusCode != ResultCode.SUCCESS)
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
                    int result;

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
                    if (result != ResultCode.SUCCESS)
                    {
                        customMessageBoxControl1.ResultCodeMessageList(ref questionManager.ValidationErrorList);
                    }

                    FormQuestion.CloseBasedOnResult(ref result);
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
        private void FillInputs(QuestionStars questionStars)
        {
            try
            {
                sharedBetweenQuestions.setQuestionText(questionStars.Text);
                sharedBetweenQuestions.setQuestionOrderValue(questionStars.Order);
                numericStarsNumber.Value = questionStars.StarsNumber;
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
