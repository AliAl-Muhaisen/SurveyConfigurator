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
                questoinManager=new QuestionManager();
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
                    questionFaces=questoinManager.GetQuestionFaces(this.questionId);
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
               if ( questionId != -1)
                {
                   questionFaces = questoinManager.GetQuestionFaces(questionId);
                    
                    if (questionFaces == null)
                    {
                        MessageBox.Show("This Question does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        closeParentFrom();
                    }
                    fillInputs(questionFaces);
                    sharedBetweenQuestions.setOldOrder(questionFaces.Order);

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
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
                    bool result = false;

                    questionFaces.FacesNumber = ((int)numericFaceNumber.Value);

                    if (!isUpdate)
                    {

                        result = questoinManager.AddQuestionFaces(questionFaces);
                        if(!result)
                            customMessageBoxControl1.sqlInsert(result);

                    }
                    else
                    {
                        result = questoinManager.UpdateQuestionFaces(questionFaces);
                        if (!result)
                            customMessageBoxControl1.sqlUpdate(result);
                        sharedBetweenQuestions.setOldOrder(questionFaces.Order);

                    }
                    if (result)
                        closeParentFrom();
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
