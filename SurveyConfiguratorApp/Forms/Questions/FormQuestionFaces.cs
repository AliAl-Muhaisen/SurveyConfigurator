using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
using SurveyConfiguratorApp.Logic;
using System;
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
                questionValidation = QuestionValidation.Instance();
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
                    btnSave.Text = "Update";
                    // questionFaces=questoinManager.GetQuestionFaces(this.questionId);
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
                    questionFaces = questoinManager.GetQuestionFaces(questionId);
                    HandleIsQuestionNotExists();
                    fillInputs(questionFaces);
                    sharedBetweenQuestions.setOldOrder(questionFaces.Order);

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }



        }

        private void HandleIsQuestionNotExists()
        {
            try
            {
                if (questionId != -1)
                {
                    QuestionFaces questionFaces = questoinManager.GetQuestionFaces(questionId);

                    if (questionFaces == null)
                    {
                        customMessageBoxControl1.NotExists();
                        CloseParentFrom();
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
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
                bool isValidGeneralQuestions = sharedBetweenQuestions.isValidForm();
                if (isValidGeneralQuestions)
                {
                    questionFaces.Text = sharedBetweenQuestions.getQuestionText();
                    questionFaces.Order = Convert.ToInt32(sharedBetweenQuestions.getQuestionOrder());
                    StatusCode result=StatusCode.Success;

                    questionFaces.FacesNumber = ((int)numericFaceNumber.Value);

                    if (!isUpdate)
                    {
                        result = questoinManager.AddQuestionFaces(questionFaces);                       
                    }
                    else
                    {
                        HandleIsQuestionNotExists();
                        result =
                            questoinManager.UpdateQuestionFaces(questionFaces);
                        sharedBetweenQuestions.setOldOrder(questionFaces.Order);

                    }
                    if (result == StatusCode.Success)
                        CloseParentFrom();
                    else
                        customMessageBoxControl1.StatusCodeMessage(result);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                sharedBetweenQuestions.setOldOrder(questionFaces.Order);
                btnSave.Text = "Update";
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }


    }
}
