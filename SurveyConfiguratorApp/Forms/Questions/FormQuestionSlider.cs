using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
using SurveyConfiguratorApp.Logic;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.Forms.Questions
{
    public partial class FormQuestionSlider : Form
    {
        private bool isUpdate = false;
        private QuestionSlider questionSlider;
        private int questionId = -1;
        private QuestionValidation questionValidation;
        private QuestionManager questionManager;

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
                questionValidation = QuestionValidation.Instance();
                questionManager= new QuestionManager();
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

                labelErrorStartValue.clearText();
                labelErrorEndValue.clearText();
                labelErrorCaptionStart.clearText();
                labelErrorCaptionEnd.clearText();

                if (questionId != -1)
                {
                    questionSlider = questionManager.GetQuestionSlider(questionId);
                    // Check if question still exists
                    if (questionSlider == null)
                    {
                        MessageBox.Show("This Question does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        closeParentFrom();
                    }
                    sharedBetweenQuestions.setOldOrder(questionSlider.Order);
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
                closeParentFrom();
            }
            catch (Exception ex)
            {
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
        /// used for save and upate question 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (isValidForm())
                {
                    questionSlider.Text = sharedBetweenQuestions.getQuestionText();
                    questionSlider.Order = Convert.ToInt32(sharedBetweenQuestions.getQuestionOrder());
                    bool result = false;

                    questionSlider.StartValue = ((int)numericStartValue.Value);
                    questionSlider.EndValue = ((int)numericEndValue.Value);
                    questionSlider.StartCaption = textBoxStartCaption.Text;
                    questionSlider.EndCaption = textBoxEndCaption.Text;
                    if (!isUpdate)
                    {

                        result = questionManager.AddQuestionSlider(questionSlider);
                        if (!result)
                            customMessageBoxControl1.sqlInsert(result);
                    }
                    else
                    {
                        result = questionManager.UpdateQuestionSlider(questionSlider);
                        //sharedBetweenQuestions.setOldOrder(questionSlider.Order);
                        if (!result)
                            customMessageBoxControl1.sqlUpdate(result);

                    }
                    if (result)
                    {
                        closeParentFrom();
                    }



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
                sharedBetweenQuestions.setOldOrder(questionSlider.Order);
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
        private void handleMinValue()
        {
            try
            {
                if (numericStartValue.Value >= numericEndValue.Value)
                {
                    labelErrorStartValue.setText("Should be less than max");
                    isValidMinNum = false;

                }

                else if (numericStartValue.Value < numericStartValue.Minimum)
                {
                    labelErrorStartValue.setText("number must be greater than or equal " + numericStartValue.Minimum);

                }

                else
                {
                    labelErrorStartValue.clearText();
                    isValidMinNum = true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }





        }

        /// <summary>
        /// Handle max value validation
        /// </summary>
        private void handleMaxValue()
        {
            try
            {
                if (numericEndValue.Value <= numericStartValue.Value)
                {
                    labelErrorEndValue.setText("Should be greater than min");
                    isValidMaxNum = false;

                }

                else if (numericEndValue.Value <= numericEndValue.Minimum)
                {
                    labelErrorEndValue.setText("number must be greater than or equal " + numericEndValue.Minimum);


                }

                else if (numericEndValue.Value > numericEndValue.Maximum)
                {
                    labelErrorEndValue.setText("number must be less than or equal " + numericEndValue.Maximum);
                    isValidMaxNum = false;

                }
                else
                {
                    labelErrorEndValue.clearText();
                    isValidMaxNum = true;
                }


            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        /// <summary>
        /// Handle End Caption Validation
        /// </summary>
        private void handleCaptionEnd()
        {
            try
            {
                string msg =
                           questionValidation.handelCaptionText(textBoxEndCaption.Text);
                if (msg == null)
                {
                    isValidCaptionEnd = true;
                }
                else
                    isValidCaptionEnd = false;
                labelErrorCaptionEnd.setText(msg);

            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        private void numericStartValue_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                handleMinValue();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        private void numericEndValue_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                handleMaxValue();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        private void textBoxEndCaption_TextChanged(object sender, EventArgs e)
        {
            handleCaptionEnd();
        }

        /// <summary>
        /// Handle Start Caption Validation
        /// </summary>
        private void handleCaptionStart()
        {
            try
            {
                string msg =
                           questionValidation.handelCaptionText(textBoxStartCaption.Text);
                if (msg == null)
                {
                    isValidCaptionStart = true;
                }
                else
                    isValidCaptionStart = false;
                labelErrorCaptionStart.setText(msg);

            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }
        private void textBoxStartCaption_TextChanged(object sender, EventArgs e)
        {
            try
            {
                handleCaptionStart();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }
      
        /// <summary>
        /// To Check form inputs validation
        /// </summary>
        /// <returns></returns>
        private bool isValidForm()
        {
            try
            {
                handleCaptionEnd();
                handleMaxValue();
                handleMinValue();
                handleCaptionStart();
                return sharedBetweenQuestions.isValidForm() && isValidMaxNum && isValidMinNum && isValidCaptionStart && isValidCaptionEnd;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
            return false;

        }

        
    }
}
