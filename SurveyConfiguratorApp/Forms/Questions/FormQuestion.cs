﻿using Microsoft.Extensions.DependencyInjection;
using SurveyConfiguratorApp.Data.Questions;
using SurveyConfiguratorApp.Helper;
using SurveyConfiguratorApp.Logic.Questions.Faces;
using SurveyConfiguratorApp.Logic.Questions.Slider;
using SurveyConfiguratorApp.Logic.Questions.Stars;
using System;
using System.Linq;
using System.Windows.Forms;
using static SurveyConfiguratorApp.Domain.Questions.Question;

namespace SurveyConfiguratorApp.Forms.Questions
{
    public partial class FormQuestion : Form
    {

        private Form activeForm;

        /// <summary>
        /// This variable, 'services', is a helper variable used to create a collection of services and add scopes for dependency injection.
        /// </summary>
        private readonly ServiceCollection services = new ServiceCollection();

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
                services = new ServiceCollection();

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
                //This line registers the QuestionFacesService class as the implementation for the IQuestionFacesService interface.
                //It means that whenever an instance of IQuestionFacesService is requested, the QuestionFacesService implementation will be provided.
                //
                services.AddScoped<IQuestionFacesRepository, DbQuestionFaces>();
                services.AddScoped<IQuestionFacesService, QuestionFacesService>();
                using (ServiceProvider serviceProvider = services.BuildServiceProvider())
                {

                    var mainForm = new FormQuestionFaces(questionId);


                    // Manually inject the dependencies
                    mainForm.questionFacesService = serviceProvider.GetRequiredService<IQuestionFacesService>();
                    handleOpenChildForm(mainForm);
                }
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
                services.AddScoped<IQuestionStarsRepository, DbQuestionStars>();
                services.AddScoped<IQuestionStarsService, QuestionStarsService>();
                using (ServiceProvider serviceProvider = services.BuildServiceProvider())
                {
                    var mainForm = new FormQuestionStars(questionId);

                    // Manually inject the dependencies
                    mainForm.questionStarsService = serviceProvider.GetRequiredService<IQuestionStarsService>();
                    handleOpenChildForm(mainForm);
                }
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
                //This line registers the QuestionSliderService class as the implementation for the IQuestionSliderService interface.
                //It means that whenever an instance of IQuestionSliderService is requested, the QuestionSliderService implementation will be provided.
                //
                services.AddScoped<IQuestionSliderRepository, DbQuestionSlider>();
                services.AddScoped<IQuestionSliderService, QuestionSliderService>();
                using (ServiceProvider serviceProvider = services.BuildServiceProvider())
                {
                    var mainForm = new FormQuestionSlider(questionId);

                    // Manually inject the dependencies
                    mainForm.questionSliderService = serviceProvider.GetRequiredService<IQuestionSliderService>();
                    handleOpenChildForm(mainForm);
                }
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


    }
}
