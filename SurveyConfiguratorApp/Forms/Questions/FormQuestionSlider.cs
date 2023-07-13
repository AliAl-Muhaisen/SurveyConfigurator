using SurveyConfiguratorApp.Domain;
using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
using SurveyConfiguratorApp.Logic;
using System;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.Forms.Questions
{
    public partial class FormQuestionSlider : Form
    {
        private bool isUpdate = false;
        private QuestionSlider questionSlider;
        private int questionId = -1;
        private QuestionManager questionManager;
        private QuestionValidation questionValidation;
        // To Check inputs validation 
        private bool isValidMaxNum = false;
        private bool isValidMinNum = false;
        private bool isValidCaptionStart = false;
        private bool isValidCaptionEnd = false;
        public FormQuestionSlider()
        {

            try
            {
                InitializeComponent();
                questionSlider = new QuestionSlider();
                questionManager= new QuestionManager();
                questionValidation= new QuestionValidation();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// used in update operation 
        /// </summary>
        /// <param name="questionId"></param>
        public FormQuestionSlider(int questionId) : this()
        {
            try
            {
                if (questionId != -1)
                {
                    isUpdate = true;
                    this.questionId = questionId;
                    btnSave.Text = "Update";

                }

            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void FormQuestionSlider_Load(object sender, EventArgs e)
        {
            try
            {
                numericStartValue.Minimum = questionValidation.SliderMinValue;
                numericEndValue.Maximum = questionValidation.SliderMaxValue;
                numericEndValue.Minimum = numericStartValue.Minimum + 1;
                numericStartValue.Maximum = numericEndValue.Maximum - 1;
                numericEndValue.Value = numericEndValue.Maximum;

              
                if (questionId != -1)
                {
                    questionSlider.setId(questionId);
                     questionManager.GetQuestionSlider(ref questionSlider);
                    // Check if question still exists
                    HandleIsQuestionNotExists();

                    fillInputs(questionSlider);


                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }


        // From Buttons
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

        private bool HandleIsQuestionNotExists()
        {
            try
            {
                if (questionId != -1)
                {
                   int tStatusCode = questionManager.IsQuestionExists(questionId);
                    // Check if question still exists
                    if (tStatusCode != StatusCode.SUCCESS)
                    {
                        customMessageBoxControl1.StatusCodeMessage(tStatusCode);
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

        /// <summary>
        /// used for save and upate question 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

               // if (IsValidForm())
                {
                    questionSlider.Text = sharedBetweenQuestions.getQuestionText();
                    questionSlider.Order = Convert.ToInt32(sharedBetweenQuestions.getQuestionOrder());
                    int result;

                    questionSlider.StartValue = ((int)numericStartValue.Value);
                    questionSlider.EndValue = ((int)numericEndValue.Value);
                    questionSlider.StartCaption = textBoxStartCaption.Text;
                    questionSlider.EndCaption = textBoxEndCaption.Text;
                    if (!isUpdate)
                    {
                        result = questionManager.AddQuestionSlider(questionSlider);                       
                    }
                    else
                    {
                        bool isNotExits = HandleIsQuestionNotExists();
                        if (isNotExits) { return; }
                        result = questionManager.UpdateQuestionSlider(questionSlider);
                       

                    }
                    if (result != StatusCode.SUCCESS)
                    {
                        customMessageBoxControl1.StatusCodeMessageList(ref questionManager.ValidationErrorList);
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
        /// fill form inputs in update operation 
        /// </summary>
        /// <param name="questionSlider"></param>
        private void fillInputs(QuestionSlider questionSlider)
        {

            try
            {
                sharedBetweenQuestions.setQuestionText(questionSlider.Text);
                sharedBetweenQuestions.setQuestionOrderValue(questionSlider.Order);
                numericStartValue.Value = questionSlider.StartValue;
                numericEndValue.Value = questionSlider.EndValue;
                textBoxStartCaption.Text = questionSlider.StartCaption;
                textBoxEndCaption.Text = questionSlider.EndCaption;
                btnSave.Text = "Update";
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        //# Validation Functions
        /// <summary>
        /// Handle min value validation
        /// </summary>
       
        private void numericStartValue_ValueChanged(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

       
        
    }
}
