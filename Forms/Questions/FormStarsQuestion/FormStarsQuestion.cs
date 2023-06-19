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
using static SurveyConfiguratorApp.UserController.Questions.SharedBetweenQuestions;
using static SurveyConfiguratorApp.UserController.Questions.UpDownWithLabelControl;

namespace SurveyConfiguratorApp.Forms.Questions
{
    public partial class FormStarsQuestion : Form
    {
        private QuestionValidation questionValidation;

        public FormStarsQuestion()
        {
            InitializeComponent();
            questionValidation = QuestionValidation.Instance();


            upDownWithLabelControl1.setLabelTitle("Number Of Stars");

            upDownWithLabelControl1.setInputMinValue(questionValidation.StarsMinValue);
            upDownWithLabelControl1.setInputMaxValue(questionValidation.StarsMaxValue);
            upDownWithLabelControl1.clearErrorText();

            //upDownWithLabelControl.setCallBackFunction(questionValidation.starsHandleMsg);
            upDownWithLabelControl1.setCallBackFunction(new CallBackHandleErrorMsg(questionValidation.facesHandleMsg));

            sharedBetweenQuestions1.clearLabelsText();
            sharedBetweenQuestions1.setIsNotEmptyCallBack(new CallBackIsNotEmpty(questionValidation.handelQuestionText));

        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void upDownWithLabelControl_Load(object sender, EventArgs e)
        {
          //  upDownWithLabelControl.setCallBackFunction(questionValidation.starsHandleMsg);

        }

        private void FormStarsQuestion_Load(object sender, EventArgs e)
        {
           // upDownWithLabelControl.setCallBackFunction(questionValidation.starsHandleMsg);

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool checkGeneralQuestions = sharedBetweenQuestions1.isValidForm();


        }
    }
}
