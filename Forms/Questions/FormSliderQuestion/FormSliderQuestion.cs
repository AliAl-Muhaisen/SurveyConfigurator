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
    }
}
