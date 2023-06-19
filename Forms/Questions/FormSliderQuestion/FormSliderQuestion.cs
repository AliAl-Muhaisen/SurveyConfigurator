using SurveyConfiguratorApp.Database.Questions;
using SurveyConfiguratorApp.Models;
using SurveyConfiguratorApp.Models.Questions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SurveyConfiguratorApp.Models.Questions.Question;
using static SurveyConfiguratorApp.UserController.Questions.SharedBetweenQuestions;

namespace SurveyConfiguratorApp.Forms.Questions
{
    public partial class FormSliderQuestion : Form
    {
        private QuestionValidation questionValidation;

        public FormSliderQuestion()
        {
            InitializeComponent();
            questionValidation = QuestionValidation.Instance();

            minMaxNumControl1.setLabelTitleText("Slider Values");
            customLabelControlTitleCaption.setText("Captions");
            customLabelControlMin.setText("Min");
            customLabelControlMax.setText("Max");
            sharedBetweenQuestions.clearLabelsText();

            sharedBetweenQuestions.setIsNotEmptyCallBack(new CallBackIsNotEmpty(questionValidation.handelQuestionText));
         

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool checkGeneralQuestions = sharedBetweenQuestions.isValidForm();

            if (checkGeneralQuestions)
            {

                QuestionSlider questionSlider = new QuestionSlider();
                questionSlider.Text = sharedBetweenQuestions.getQuestionText();
                questionSlider.Order = Convert.ToInt32(sharedBetweenQuestions.getQuestionOrder());
                questionSlider.TypeNumber = (int)QuestionTypes.SLIDER;
                Question question = new QuestionSlider();
                question = questionSlider;

                // initialize questionSlider before adding
                questionSlider = new QuestionSlider();
                questionSlider.add();



                //QuestionSlider questionSlider = new QuestionSlider();
                //questionSlider.Text= sharedBetweenQuestions.getQuestionText();
                //questionSlider.Order= Convert.ToInt32(sharedBetweenQuestions.getQuestionOrder());
                //questionSlider.TypeNumber = (int)QuestionTypes.SLIDER;
                //Question question = new QuestionSlider();
                //question= questionSlider;
                //questionSlider.add(question);
                //DbQuestion dbQuestion = new DbQuestion();





                //Question question = new Question();
                //question.Text = sharedBetweenQuestions.getQuestionText();
                //question.Order = Convert.ToInt32(sharedBetweenQuestions.getQuestionOrder());
                //question.TypeNumber = (int)QuestionTypes.SLIDER;
                //dbQuestion.create(question);
            }

        }
    }
}
