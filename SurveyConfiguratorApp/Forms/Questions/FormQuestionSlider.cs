using SurveyConfiguratorApp.Data.Questions;
using SurveyConfiguratorApp.Domain.Questions;
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
        public FormQuestionSlider()
        {
            InitializeComponent();
            questionSlider=new QuestionSlider();
        }
        public FormQuestionSlider(int questionId):this() 
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
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            closeParentFrom();
        }
        private void closeParentFrom()
        {
            if (Application.OpenForms.OfType<FormQuestion>().Any())
            {
                // Close the form
                FormQuestion form = (FormQuestion)Application.OpenForms["FormQuestion"];
                form.Close();
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

            }
        }

        private void fillInputs(QuestionSlider questionSlider)
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

        private void FormQuestionSlider_Load(object sender, EventArgs e)
        {
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
    }
}
