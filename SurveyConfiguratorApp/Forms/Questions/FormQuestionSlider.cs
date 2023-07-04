using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
using SurveyConfiguratorApp.Logic.Questions.Slider;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.Forms.Questions
{
    public partial class FormQuestionSlider : Form
    {
        public IQuestionSliderService questionSliderService { get; set; }
        private bool isUpdate = false;
        private QuestionSlider questionSlider;
        private int questionId = -1;
        private QuestionValidation questionValidation;

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
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
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
        private void closeParentFrom()
        {
            try
            {
                if (Application.OpenForms.OfType<FormQuestion>().Any())
                {
                    // Close the form
                    FormQuestion form = (FormQuestion)Application.OpenForms["FormQuestion"];
                    form.Close();
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

                        result = questionSliderService.add(questionSlider);
                        customMessageBoxControl1.sqlInsert(result);
                    }
                    else
                    {
                        result = questionSliderService.update(questionSlider);
                        //sharedBetweenQuestions.setOldOrder(questionSlider.Order);
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

                if (questionSliderService != null && questionId != -1)
                {
                    questionSlider = questionSliderService.Get(questionId);
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

        private void handleMinValue()
        {
            try
            {
                if (numericStartValue.Value >= numericEndValue.Value)
                {
                    labelErrorStartValue.setText("Min should be less than max");
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

        private void handleMaxValue()
        {
            try
            {
                if (numericEndValue.Value <= numericStartValue.Value)
                {
                    labelErrorEndValue.setText("Max should be greater than min");
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
            handleCaptionStart();
        }
        private bool isValidForm()
        {
            handleCaptionEnd();
            handleMaxValue();
            handleMinValue();
            handleCaptionStart();
            return sharedBetweenQuestions.isValidForm() && isValidMaxNum && isValidMinNum && isValidCaptionStart && isValidCaptionEnd;
        }
    }
}
