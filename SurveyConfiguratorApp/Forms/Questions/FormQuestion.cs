using SurveyConfiguratorApp.Domain;
using SurveyConfiguratorApp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static SurveyConfiguratorApp.Domain.Questions.Question;

namespace SurveyConfiguratorApp.Forms.Questions
{
    public partial class FormQuestion : CustomForm
    {

        private Form activeForm;

        /// <summary>
        /// This variable, 'questionId', is used to get the object info from the db in the updated operation
        /// </summary>
        private int questionId = -1;

        /// <summary>
        /// The variable 'questionTypeNumber' is used as a helper variable in the updated operation to set a default value for a comboBox 
        /// </summary>
        private int questionTypeNumber = -1;

        private int lastQuestionType = 0;//to check if user changed question type 
        public FormQuestion()
        {

            try
            {
                InitializeComponent();
                // add question types to drop down list
                foreach (QuestionTypes type in Enum.GetValues(typeof(QuestionTypes)))
                    comboBox1.Items.Add(type);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public FormQuestion(bool isEnableSelectType, int questionId, int questionTypeNumber, string FormTitle = null) : this()
        {

            try
            {
                comboBox1.Enabled = isEnableSelectType;
                this.questionId = questionId;
                this.questionTypeNumber = questionTypeNumber - 1;
                //change form title in update operation
                this.Text = FormTitle != null ? FormTitle : Text;
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
                handleChildForms();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        /// <summary>
        /// The function responsible for displaying a child form within a panel container
        /// </summary>
        /// <param name="childForm"></param>
        private void handleOpenChildForm(Form childForm)
        {
            try
            {
                if (activeForm != null)
                {
                    activeForm.Close();
                }
                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                panelContainer.Controls.Add(childForm);

                panelContainer.Tag = childForm;
                //z-order
                childForm.BringToFront();
                childForm.Show();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        /// <summary>
        /// The handleChildForms function handles the Appropriate question from based on the selected item in a combo box 
        /// </summary>
        private void handleChildForms()
        {
            try
            {
                int typeNumber = (int)(QuestionTypes)Enum.Parse(typeof(QuestionTypes), comboBox1.SelectedItem.ToString(), true);
                if (typeNumber != lastQuestionType)
                {

                    if (typeNumber == (int)QuestionTypes.STARS)
                    {
                        handleQuestionStars(questionId);
                    }
                    else if (typeNumber == (int)QuestionTypes.SLIDER)
                    {
                        handleQuestionSlider(questionId);
                    }
                    else if (typeNumber == (int)QuestionTypes.FACES)
                    {
                        handleQuestionFaces(questionId);
                    }
                    else
                    {
                        MessageBox.Show("Please Select a valid Type");
                    }
                }


                lastQuestionType = typeNumber;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Log.Error(e);
            }

        }

        private void handleQuestionFaces(int questionId = -1)
        {
            try
            {
                var mainForm = new FormQuestionFaces(questionId);
                handleOpenChildForm(mainForm);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        private void handleQuestionStars(int questionId = -1)
        {
            try
            {
                //This line registers the QuestionStarsService class as the implementation for the IQuestionStarsService interface.
                //It means that whenever an instance of IQuestionStarsService is requested, the QuestionStarsService implementation will be provided.
                //
                var mainForm = new FormQuestionStars(questionId);
                handleOpenChildForm(mainForm);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        private void handleQuestionSlider(int questionId = -1)
        {
            try
            {
                var mainForm = new FormQuestionSlider(questionId);

                handleOpenChildForm(mainForm);
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

        public static void CloseBasedOnStatus(ref StatusCode pStatusCode)
        {
            try
            {
                if (pStatusCode.Code == StatusCode.Success.Code || pStatusCode.Code == StatusCode.DbFailedNetWorkConnection.Code || pStatusCode.Code == StatusCode.DbFailedConnection.Code)
                {
                    CloseForm();
                }

            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }


    }
}
