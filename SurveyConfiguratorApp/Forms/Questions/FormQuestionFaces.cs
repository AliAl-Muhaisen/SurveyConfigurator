using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
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
using static SurveyConfiguratorApp.UserController.Questions.SharedBetweenQuestions;

namespace SurveyConfiguratorApp.Forms.Questions
{
    public partial class FormQuestionFaces : Form
    {
        QuestionValidation questionValidation;
        public IQuestionFacesService questionFacesService { get; set; }
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
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
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
                Log.Error(ex);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            try
            {
                bool isValidGeneralQuestions = sharedBetweenQuestions.isValidForm();
                if(isValidGeneralQuestions)
                {
                    questionFaces.Text = sharedBetweenQuestions.getQuestionText();
                    questionFaces.Order = Convert.ToInt32(sharedBetweenQuestions.getQuestionOrder());
                    bool result = false;

                    questionFaces.FacesNumber = ((int)numericFaceNumber.Value);
                    
                    if (!isUpdate)
                    {

                        result = questionFacesService.add(questionFaces);
                        customMessageBoxControl1.sqlInsert(result);

                    }
                    else
                    {
                        result = questionFacesService.update(questionFaces);
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

        private void FormQuestionFaces_Load(object sender, EventArgs e)
        {
            try
            {
                numericFaceNumber.Maximum = questionValidation.FacesMaxValue;
                numericFaceNumber.Minimum = questionValidation.FacesMinValue;
                if (questionFacesService != null && questionId != -1)
                {
                    questionFaces = questionFacesService.Get(questionId);
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

        private void save()
        {

        }
    }
}
