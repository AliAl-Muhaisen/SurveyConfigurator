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
        private int questionId = -1;

        private QuestionFaces questionFaces;
        public FormQuestionFaces()
        {
            InitializeComponent();
            questionFaces=new QuestionFaces();

        }
        public FormQuestionFaces(int questionId) : this()
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

        private void btnSave_Click(object sender, EventArgs e)
        {


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


                        if (result)
                        {
                            sharedBetweenQuestions.clearInputValues();
                            sharedBetweenQuestions.clearErrorLabelsText();

                        }
                        else
                        {
                            MessageBox.Show("not added");
                        }
                        closeParentFrom();

                    }
                    else
                    {
                        result = questionFacesService.update(questionFaces);

                        if (result)
                        {
                            sharedBetweenQuestions.clearInputValues();
                            sharedBetweenQuestions.clearErrorLabelsText();

                        }
                        else
                        {
                            MessageBox.Show("not added");
                        }
                        closeParentFrom();

                        sharedBetweenQuestions.setOldOrder(questionFaces.Order);

                    }



                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void FormQuestionFaces_Load(object sender, EventArgs e)
        {

            if (questionFacesService != null && questionId != -1)
            {
                questionFaces = questionFacesService.Get(questionId);
                if (questionFaces == null)
                {
                    MessageBox.Show("This Question does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    closeParentFrom();
                }
                fillInputs(questionFaces);

            }
        }

        private void fillInputs(QuestionFaces questionFaces)
        {
            sharedBetweenQuestions.setQuestionText(questionFaces.Text);
            sharedBetweenQuestions.setQuestionOrderValue(questionFaces.Order);
            numericFaceNumber.Value = questionFaces.FacesNumber;
            sharedBetweenQuestions.setOldOrder(questionFaces.Order);
            btnSave.Text = "Update";
        }

        private void save()
        {

        }
    }
}
