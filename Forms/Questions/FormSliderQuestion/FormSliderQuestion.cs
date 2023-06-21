using SurveyConfiguratorApp.Database.Questions;
using SurveyConfiguratorApp.Models;
using SurveyConfiguratorApp.Models.Questions;
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
using static SurveyConfiguratorApp.Models.Questions.Question;
using static SurveyConfiguratorApp.UserController.Questions.MinMaxNumControl;
using static SurveyConfiguratorApp.UserController.Questions.SharedBetweenQuestions;

namespace SurveyConfiguratorApp.Forms.Questions
{
    public partial class FormSliderQuestion : Form
    {
        private bool isUpdate = false;
        private QuestionValidation questionValidation;
        private bool isValidCaptionMinText = false;
        private bool isValidCaptionMaxText = false;
        public FormSliderQuestion()
        {
            InitializeComponent();
            questionValidation = QuestionValidation.Instance();

            minMaxNumControl1.setLabelTitleText("Slider Values");
            customLabelControlTitleCaption.setText("Captions");

            labelErrorCaptionMin.clearText();
            customLabelControlMin.setText("Min");
            customLabelControlMax.setText("Max");
            labelErrorCaptionMax.clearText();


            sharedBetweenQuestions.clearLabelsText();
            minMaxNumControl1.StartNumMin = questionValidation.SliderMinValue;
            minMaxNumControl1.StartNumMax = questionValidation.SliderMaxValue-1;
            minMaxNumControl1.EndNumMax = questionValidation.SliderMaxValue;
            minMaxNumControl1.EndNumMin = questionValidation.SliderMinValue+1;
            minMaxNumControl1.clearErrorLabelsText();
            //minMaxNumControl1.setIsNotEmptyCallBack(new CallBackIsNotEmpty(questionValidation.handelCaptionText));


            sharedBetweenQuestions.setIsNotEmptyCallBack(new CallBackIsNotEmpty(questionValidation.handelQuestionText));
         

        }
        private bool isValidForm()
        {
            handleCaptionMin();
            handleCaptionMax();
            return isValidCaptionMinText && isValidCaptionMaxText;
        }

        private void textBoxCaptionMin_TextChanged(object sender, EventArgs e)
        {
            handleCaptionMin();
        }

        private void handleCaptionMin()
        {
            string msg = 
            questionValidation.handelCaptionText(textBoxCaptionMin.Text);
          
            labelErrorCaptionMin.setText(msg);

                if (msg == null)
                {
                    isValidCaptionMinText = true;
                }
                else
                    isValidCaptionMinText = false;
            
        }

        private void handleCaptionMax()
        {
            string msg =
            questionValidation.handelCaptionText(textBoxCaptionMax.Text);

            labelErrorCaptionMax.setText(msg);

            if (msg == null)
            {
                isValidCaptionMaxText = true;
            }
            else
                isValidCaptionMaxText = false;

        }

        private void textBoxCaptionMax_TextChanged(object sender, EventArgs e)
        {
            handleCaptionMax();
        }

        private void clearInputsValue()
        {
            textBoxCaptionMax.Text = string.Empty;
            textBoxCaptionMin.Text = string.Empty;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            bool checkGeneralQuestions = sharedBetweenQuestions.isValidForm();
            bool checkCaption = isValidForm();
            bool checkMinMaxValues=minMaxNumControl1.isValidForm();
            if (checkGeneralQuestions && checkCaption && checkMinMaxValues)
            {
                QuestionSlider questionSlider = new QuestionSlider();
                questionSlider.Text = sharedBetweenQuestions.getQuestionText();
                questionSlider.Order = Convert.ToInt32(sharedBetweenQuestions.getQuestionOrder());

                questionSlider.StartValue= minMaxNumControl1.getStartValue();
                questionSlider.EndValue= minMaxNumControl1.getEndValue();

                questionSlider.StartCaption = textBoxCaptionMin.Text;
                questionSlider.EndCaption = textBoxCaptionMax.Text;
                questionSlider.add();

                sharedBetweenQuestions.clearInputValues();
                minMaxNumControl1.clearInputValues();
                clearInputsValue();

            }
        }
    }
}
