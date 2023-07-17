using SurveyConfiguratorApp.Domain;
using SurveyConfiguratorApp.Helper;
using SurveyConfiguratorApp.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Forms;
using static SurveyConfiguratorApp.Domain.Questions.Question;

namespace SurveyConfiguratorApp.Forms.Questions
{
    public partial class FormQuestion : CustomForm
    {

        private Form activeForm;

        /// <summary>
        /// This variable, 'pQuestionId', is used to get the object info from the db in the updated operation
        /// </summary>
        private readonly int questionId = -1;

        /// <summary>
        /// The variable 'pQuestionTypeNumber' is used as a helper variable in the updated operation to set a default value for a comboBox 
        /// </summary>
        private readonly int questionTypeNumber = -1;

        private int lastQuestionType = 0;//to check if user changed question type 
        public FormQuestion()
        {

            try
            {
                InitializeComponent();
                // add question types to drop down list
                foreach (QuestionTypes type in Enum.GetValues(typeof(QuestionTypes)))
                {
                    //comboBox1.Items.Add(type);
                    switch (type)
                    {
                        case QuestionTypes.FACES:
                            comboBox1.Items.Add(Resource.FACES);
                            break;
                        case QuestionTypes.SLIDER:
                            comboBox1.Items.Add(Resource.SLIDER);
                            break;
                        case QuestionTypes.STARS:
                            comboBox1.Items.Add(Resource.STARS);
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public FormQuestion(bool pIsEnableSelectType, int pQuestionId, int pQuestionTypeNumber, string pFormTitle = null) : this()
        {

            try
            {
                comboBox1.Enabled = pIsEnableSelectType;
                this.questionId = pQuestionId;
                this.questionTypeNumber = pQuestionTypeNumber - 1;
                //change form title in update operation
                this.Text = pFormTitle ?? Text;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        private void FormQuestionAdd_Load(object sender, EventArgs e)
        {
            try
            {
                // select the first value in the list as a default
                comboBox1.SelectedIndex = questionTypeNumber != -1 ? questionTypeNumber : 0;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                HandleChildForms();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        /// <summary>
        /// The function responsible for displaying a child form within a panel container
        /// </summary>
        /// <param name="pChildForm"></param>
        private void HandleOpenChildForm(Form pChildForm)
        {
            try
            {
                if (activeForm != null)
                {
                    activeForm.Close();
                }
                activeForm = pChildForm;
                pChildForm.TopLevel = false;
                pChildForm.FormBorderStyle = FormBorderStyle.None;
                pChildForm.Dock = DockStyle.Fill;
                panelContainer.Controls.Add(pChildForm);

                panelContainer.Tag = pChildForm;
                //z-order
                pChildForm.BringToFront();
                pChildForm.Show();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        /// <summary>
        /// The HandleChildForms function handles the Appropriate question from based on the selected item in a combo box 
        /// </summary>
        private void HandleChildForms()
        {
            try
            {
                int tTypeNumber = HandelSelectedTypeLanguage();

                if (tTypeNumber != lastQuestionType)
                {
                    if (tTypeNumber == (int)QuestionTypes.STARS)
                    {
                        HandleQuestionStars(questionId);
                    }
                    else if (tTypeNumber == (int)QuestionTypes.SLIDER)
                    {
                        HandleQuestionSlider(questionId);
                    }
                    else if (tTypeNumber == (int)QuestionTypes.FACES)
                    {
                        HandleQuestionFaces(questionId);
                    }
                    else
                    {
                        MessageBox.Show("Please Select a valid Type");
                    }
                }


                lastQuestionType = tTypeNumber;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Log.Error(e);
            }

        }

        private void HandleQuestionFaces(int questionId = -1)
        {
            try
            {
                var mainForm = new FormQuestionFaces(questionId);
                HandleOpenChildForm(mainForm);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        private void HandleQuestionStars(int pQuestionId = -1)
        {
            try
            {
                //This line registers the QuestionStarsService class as the implementation for the IQuestionStarsService interface.
                //It means that whenever an instance of IQuestionStarsService is requested, the QuestionStarsService implementation will be provided.
                //
                var tMainForm = new FormQuestionStars(pQuestionId);
                HandleOpenChildForm(tMainForm);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        private void HandleQuestionSlider(int pQuestionId = -1)
        {
            try
            {
                var tMainForm = new FormQuestionSlider(pQuestionId);

                HandleOpenChildForm(tMainForm);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        /// <summary>
        /// Close the FormQuestion if it's open
        /// </summary>
        public static void CloseForm()
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

        public static void CloseBasedOnResult(ref int pResult)
        {
            try
            {
                if (pResult == ResultCode.SUCCESS || pResult == ResultCode.DB_CONNECTION_FAILED || pResult == ResultCode.DB_FAILED_NETWORK_CONNECTION)
                {
                    CloseForm();
                }

            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        private int HandelSelectedTypeLanguage()
        {
            int tTypeNumber = 0;
            try
            {
                string tSelectedItem = comboBox1.SelectedItem.ToString();

                if (tSelectedItem == Resource.FACES)
                {
                    tTypeNumber = (int)QuestionTypes.FACES;
                }
                else if (tSelectedItem == Resource.SLIDER)
                {
                    tTypeNumber = (int)QuestionTypes.SLIDER;
                }
                else if (tSelectedItem == Resource.STARS)
                {
                    tTypeNumber = (int)QuestionTypes.STARS;
                }

            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return tTypeNumber;
        }

    }
}
