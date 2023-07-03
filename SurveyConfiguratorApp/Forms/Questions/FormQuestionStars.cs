using SurveyConfiguratorApp.Data.Questions;
using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Logic.Questions.Faces;
using SurveyConfiguratorApp.Logic.Questions.Stars;
using SurveyConfiguratorApp.UserController.Questions;
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
    public partial class FormQuestionStars : Form
    {
        public IQuestionStarsService questionStarsService { get; set; }
        private bool isUpdate = false;

        private QuestionStars questionStars;
        public FormQuestionStars()
        {
            InitializeComponent();
        }

        public FormQuestionStars(int id) : this()
        {

            try
            {
                questionStars = new QuestionStars();
                isUpdate = true;
              
                sharedBetweenQuestions.setQuestionText(questionStars.Text);
                sharedBetweenQuestions.setQuestionOrderValue(questionStars.Order);
                numericStarsNumber.Value = questionStars.StarsNumber;
                sharedBetweenQuestions.setOldOrder(questionStars.Order);
                btnSave.Text = "Update";
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            questionStars = new QuestionStars();


            try
            {
                bool isValidGeneralQuestions = sharedBetweenQuestions.isValidForm();
                //  if (isValidGeneralQuestions)
                {
                    questionStars.Text = sharedBetweenQuestions.getQuestionText();
                    questionStars.Order = Convert.ToInt32(sharedBetweenQuestions.getQuestionOrder());
                    bool result = false;

                    questionStars.StarsNumber = ((int)numericStarsNumber.Value);
                    if (!isUpdate)
                    {

                        result = questionStarsService.add(questionStars);
                        MessageBox.Show("added");
                        closeParentFrom();

                        if (result)
                        {
                            sharedBetweenQuestions.clearInputValues();
                            sharedBetweenQuestions.clearErrorLabelsText();

                        }
                    }
                    else
                    {
                        //  result = questionStars.update();


                     //   sharedBetweenQuestions.setOldOrder(questionStars.Order);

                    }



                }

            }
            catch (Exception ex)
            {

            }
        }
        private void closeParentFrom()
        {
            if (Application.OpenForms.OfType<FormQuestion>().Any())
            {
                // Close the form
                FormQuestion form = (FormQuestion)Application.OpenForms["FormQuestionAdd"];
                form.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            closeParentFrom();
        }
    }
}
