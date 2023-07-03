using Microsoft.Extensions.DependencyInjection;
using SurveyConfiguratorApp.Data.Questions;
using SurveyConfiguratorApp.Logic.Questions;
using SurveyConfiguratorApp.Logic.Questions.Faces;
using SurveyConfiguratorApp.Logic.Questions.Slider;
using SurveyConfiguratorApp.Logic.Questions.Stars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SurveyConfiguratorApp.Domain.Questions.Question;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SurveyConfiguratorApp.Forms.Questions
{
    public partial class FormQuestion : Form
    {
        private Form activeForm;
        private readonly ServiceCollection services = new ServiceCollection();
        private int questionId = -1;
        private int questionTypeNumber = -1;
        private int lastQuestionType = 0;//to check if user changed question type 
        public FormQuestion()
        {
            InitializeComponent();
            services = new ServiceCollection();
            foreach (QuestionTypes type in Enum.GetValues(typeof(QuestionTypes)))
                comboBox1.Items.Add(type);

        }
        public FormQuestion(bool isEnableSelectType, int questionId,int questionTypeNumber) : this()
        {
            comboBox1.Enabled = isEnableSelectType;
            this.questionId = questionId;
            this.questionTypeNumber = questionTypeNumber-1;
        }
        private void FormQuestionAdd_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = questionTypeNumber != -1 ? questionTypeNumber : 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            handleChildForms();
        }

        private void handleOpenChildForm(Form childForm)
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
            }

        }

        private void handleQuestionFaces(int questionId=-1)
        {
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

        private void handleQuestionStars(int questionId = -1)
        {
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

        private void handleQuestionSlider(int questionId = -1)
        {
            services.AddScoped<IQuestionSliderRepository, DbQuestionSlider>();
            services.AddScoped<IQuestionSliderService, QuestionSliderService>();
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var mainForm = new FormQuestionSlider();

                // Manually inject the dependencies
                mainForm.questionSliderService = serviceProvider.GetRequiredService<IQuestionSliderService>();
                handleOpenChildForm(mainForm);
            }
        }




    }
}
