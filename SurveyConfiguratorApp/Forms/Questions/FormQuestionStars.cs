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
        private QuestionManager questionFacade;
        private QuestionStars questionStars;
        private QuestionValidation questionValidation;
        public FormQuestionStars()
        {

            try
            {
                InitializeComponent();
                questionStars = new QuestionStars();
                questionFacade= new QuestionManager();
                questionValidation = QuestionValidation.Instance();
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
                if ( questionId != -1)
                {
                    // to check if the question still exists in the db
                    questionStars = questionFacade.GetQuestionStars(questionId);
                    if (questionStars == null)
                    {
                        MessageBox.Show("This Question does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        closeParentFrom();
                    }
                    fillInputs(questionStars);
                    sharedBetweenQuestions.setOldOrder(questionStars.Order);

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool isValidGeneralQuestions = sharedBetweenQuestions.isValidForm();
                if (isValidGeneralQuestions)
                {
                    questionStars.Text = sharedBetweenQuestions.getQuestionText();
                    questionStars.Order = Convert.ToInt32(sharedBetweenQuestions.getQuestionOrder());
                    bool result = false;

                    questionStars.StarsNumber = ((int)numericStarsNumber.Value);
                    if (!isUpdate)
                    {

                        result = questionFacade.AddQuestionStars(questionStars);
                        if (!result) 
                             customMessageBoxControl1.sqlInsert(result);
                    }
                    else
                    {
                        result = questionFacade.UpdateQuestionStars(questionStars);
                        if (!result)
                            customMessageBoxControl1.sqlUpdate(result);
                    }
                    if (result)
                        closeParentFrom();


                }

            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// Close The parent form
        /// </summary>
        private void closeParentFrom()
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
                closeParentFrom();

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
