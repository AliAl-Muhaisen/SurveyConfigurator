using SurveyConfiguratorApp.Data.Questions;
using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
using SurveyConfiguratorApp.Logic.Questions.Faces;
using SurveyConfiguratorApp.Logic.Questions.Slider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                LogError.log(ex);
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
                LogError.log(ex);
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
                LogError.log(ex);
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
                LogError.log(ex);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {



            try
            {
                bool isValidGeneralQuestions = sharedBetweenQuestions.isValidForm();
                //  if (isValidGeneralQuestions)
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
                        MessageBox.Show("added");


                        if (result)
                        {
                            sharedBetweenQuestions.clearInputValues();
                            sharedBetweenQuestions.clearErrorLabelsText();

                        }
                        closeParentFrom();
                    }
                    else
                    {
                        result = questionSliderService.update(questionSlider);


                        //sharedBetweenQuestions.setOldOrder(questionSlider.Order);

                    }



                }

            }
            catch (Exception ex)
            {
                LogError.log(ex);
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
                LogError.log(ex);
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

                if (questionSliderService != null && questionId != -1)
                {
                    questionSlider = questionSliderService.Get(questionId);
                    if (questionSlider == null)
                    {
                        MessageBox.Show("This Question does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        closeParentFrom();
                    }
                    fillInputs(questionSlider);

                }
            }
            catch (Exception ex)
            {
                LogError.log(ex);
            }

        }

        private void handleMinValue()
        {
            try
            {
                if (numericStartValue.Value >= numericEndValue.Value)
                {
                    labelErrorStartValue.setText("Min should be less than max");
                    //isValidMinNum = false;

                }

                else if (numericStartValue.Value < numericStartValue.Minimum)
                {
                    labelErrorStartValue.setText("number must be greater than or equal " + numericStartValue.Minimum);

                }

                else
                {
                    labelErrorStartValue.clearText();
                    //  isValidMinNum = true;
                }
            }
            catch (Exception ex)
            {
                LogError.log(ex);
            }





        }

        private void handleMaxValue()
        {
            try
            {
                if (numericEndValue.Value <= numericStartValue.Value)
                {
                    labelErrorEndValue.setText("Max should be greater than min");
                    //  isValidMaxNum = false;

                }

                else if (numericEndValue.Value <= numericEndValue.Minimum)
                {
                    labelErrorEndValue.setText("number must be greater than or equal " + numericEndValue.Minimum);


                }

                else if (numericEndValue.Value > numericEndValue.Maximum)
                {
                    labelErrorEndValue.setText("number must be less than or equal " + numericEndValue.Maximum);
                    //  isValidMaxNum = false;

                }
                else
                {
                    labelErrorEndValue.clearText();
                    //  isValidMaxNum = true;
                }


            }
            catch (Exception ex)
            {
                LogError.log(ex);
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
                LogError.log(ex);
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
                LogError.log(ex);
            }

        }
    }
}
