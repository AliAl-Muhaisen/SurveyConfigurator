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
        public FormQuestionSlider()
        {
            InitializeComponent();
            questionSlider=new QuestionSlider();
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
                        //  result = questionStars.update();


                        sharedBetweenQuestions.setOldOrder(questionSlider.Order);

                    }



                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
