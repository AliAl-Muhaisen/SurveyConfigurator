using Microsoft.Extensions.DependencyInjection;
using SurveyConfiguratorApp.Data.Questions;
using SurveyConfiguratorApp.Logic.Questions;
using SurveyConfiguratorApp.Logic.Questions.Faces;
using SurveyConfiguratorApp.Logic.Questions.Stars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SurveyConfiguratorApp.Domain.Questions.Question;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SurveyConfiguratorApp.Forms.Questions
{
    public partial class FormQuestionAdd : Form
    {
        private Form activeForm;
        private readonly ServiceCollection services = new ServiceCollection();
        public FormQuestionAdd()
        {
            InitializeComponent();
            services = new ServiceCollection();
            foreach (QuestionTypes type in Enum.GetValues(typeof(QuestionTypes)))
                comboBox1.Items.Add(type);


        }

        private void FormQuestionAdd_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedText = "Faces";
            comboBox1.SelectedItem = "Faces";

            handleOpenChildForm(new FormQuestionFaces());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int typeNumber = (int)(QuestionTypes)Enum.Parse(typeof(QuestionTypes), comboBox1.SelectedItem.ToString(), true);
            if (typeNumber == (int)QuestionTypes.STARS)
            {
                services.AddScoped<IQuestionStarsRepository, DbQuestionStars>();
                services.AddScoped<IQuestionStarsService, QuestionStarsService>();
                using (ServiceProvider serviceProvider = services.BuildServiceProvider())
                {
                    var mainForm = new FormQuestionStars();

                    // Manually inject the dependencies
                    mainForm.questionStarsService = serviceProvider.GetRequiredService<IQuestionStarsService>();
                    handleOpenChildForm(mainForm);
                }

            }
            else if (typeNumber == (int)QuestionTypes.SLIDER)
            {
                handleOpenChildForm(new FormQuestionSlider());
            }
            else if (typeNumber == (int)QuestionTypes.FACES)
            {
                services.AddScoped<IQuestionFacesRepository, DbQuestionFaces>();
                services.AddScoped<IQuestionFacesService, QuestionFacesService>();
                using (ServiceProvider serviceProvider = services.BuildServiceProvider())
                {
                    var mainForm = new FormQuestionFaces();

                    // Manually inject the dependencies
                    mainForm.questionFacesService = serviceProvider.GetRequiredService<IQuestionFacesService>();
                    handleOpenChildForm(mainForm);
                }
            }
            else
            {
                MessageBox.Show("Please Select a valid Type");
            }
        }

        private void handleOpenChildForm(Form childForm)
        {
            //if (activeForm != null && childForm == activeForm) return;

            if (activeForm != null)
            {
                activeForm.Close();

            }
            // ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(childForm);

            panelContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public void CloseForm()
        {
            Close();
        }


    }
}
