using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Logic.Questions.Faces;
using SurveyConfiguratorApp.UserController.Controllers;
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
    public partial class FormQuestionFaces : Form
    {
        public IQuestionFacesService questionFacesService { get; set; }
        private bool isUpdate = false;

        private QuestionFaces questionFaces;
        public FormQuestionFaces()
        {
            InitializeComponent();
        }
        public FormQuestionFaces(QuestionFaces questionFaces) : this()
        {

            try
            {
                isUpdate = true;
                this.questionFaces = questionFaces;
                sharedBetweenQuestions.setQuestionText(questionFaces.Text);
                sharedBetweenQuestions.setQuestionOrderValue(questionFaces.Order);
                numericFaceNumber.Value = questionFaces.FacesNumber;
                sharedBetweenQuestions.setOldOrder(questionFaces.Order);
                btnSave.Text = "Update";
            }
            catch (Exception ex)
            {
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            QuestionFaces questionFaces = new QuestionFaces();


            try
            {
                bool isValidGeneralQuestions = sharedBetweenQuestions.isValidForm();
                //  if (isValidGeneralQuestions)
                {
                    questionFaces.Text = sharedBetweenQuestions.getQuestionText();
                    questionFaces.Order = Convert.ToInt32(sharedBetweenQuestions.getQuestionOrder());
                    bool result = false;

                    questionFaces.FacesNumber = ((int)numericFaceNumber.Value);
                    if (!isUpdate)
                    {

                        result = questionFacesService.add(questionFaces);
                        MessageBox.Show("added");
                        this.Close();

                        if (result)
                        {
                            sharedBetweenQuestions.clearInputValues();
                            sharedBetweenQuestions.clearErrorLabelsText();

                        }
                    }
                    else
                    {
                        //  result = questionFaces.update();


                        sharedBetweenQuestions.setOldOrder(questionFaces.Order);

                    }



                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
