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
        private int questionId = -1;
        private QuestionStars questionStars;
        public FormQuestionStars()
        {
            InitializeComponent();
            questionStars = new QuestionStars();
        }

        public FormQuestionStars( int questionId) : this()
        {

            try
            {
                if (questionId != -1)
                {
                    this.questionId= questionId;
                    isUpdate = true;
                    
                    btnSave.Text = "Update";
                }

            }
            catch (Exception ex)
            {
            }

            this.questionId = questionId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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
                          result = questionStarsService.update(questionStars);


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
                FormQuestion form = (FormQuestion)Application.OpenForms["FormQuestion"];
                form.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            closeParentFrom();
        }

        private void FormQuestionStars_Load(object sender, EventArgs e)
        {
            if (questionStarsService != null && questionId != -1)
            {
                questionStars = questionStarsService.Get(questionId);
                if (questionStars == null)
                {
                    MessageBox.Show("This Question does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    closeParentFrom();
                }
                fillInputs(questionStars);

            }
        }

        private void fillInputs(QuestionStars questionStars)
        {
            sharedBetweenQuestions.setQuestionText(questionStars.Text);
            sharedBetweenQuestions.setQuestionOrderValue(questionStars.Order);
            numericStarsNumber.Value = questionStars.StarsNumber;
            sharedBetweenQuestions.setOldOrder(questionStars.Order);
            btnSave.Text = "Update";
        }
    }
}
