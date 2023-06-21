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
using static SurveyConfiguratorApp.UserController.Questions.SharedBetweenQuestions;
using static SurveyConfiguratorApp.UserController.Questions.UpDownWithLabelControl;

namespace SurveyConfiguratorApp.Forms.Questions
{
    public partial class FormStarsQuestion : Form
    {
        private QuestionValidation questionValidation;
        private bool isUpdate = false;
        private QuestionStars questionStars;

        public FormStarsQuestion()
        {
            InitializeComponent();

            this.questionStars = new QuestionStars();

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
        public FormStarsQuestion(QuestionStars questionStars):this()
        {
            this.isUpdate = true;
           
               
                this.questionStars=questionStars;
                sharedBetweenQuestions1.setQuestionText(questionStars.Text);
                sharedBetweenQuestions1.setQuestionOrderValue(questionStars.Order);
                upDownWithLabelControl1.setNumericValue(questionStars.StarsNumber);
                buttonSave.Text = "Update";
            
            
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
            bool isValidGeneralQuestions = sharedBetweenQuestions1.isValidForm();
            bool isValidFacesNumber = upDownWithLabelControl1.isValidForm();
            if (isValidGeneralQuestions && isValidFacesNumber)
            {

                
                    questionStars.Text = sharedBetweenQuestions1.getQuestionText();
                    questionStars.Order = Convert.ToInt32(sharedBetweenQuestions1.getQuestionOrder());
                
                    questionStars.StarsNumber = upDownWithLabelControl1.getFacesNumber();
                if (!isUpdate)
                {
                   
                    questionStars.add();

                    upDownWithLabelControl1.clearInputValues();
                    sharedBetweenQuestions1.clearInputValues();
                    upDownWithLabelControl1.clearErrorText();
                    sharedBetweenQuestions1.clearLabelsText();
                }
                else
                {
                    questionStars.update();
                }

            }



        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void sharedBetweenQuestions1_Load(object sender, EventArgs e)
        {

        }
    }
}
