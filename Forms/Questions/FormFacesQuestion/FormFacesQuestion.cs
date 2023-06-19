
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

namespace SurveyConfiguratorApp.Forms
{
    public partial class FormFacesQuestion : Form
    {
        private QuestionValidation questionValidation;
       
        public FormFacesQuestion()
        {
            InitializeComponent();
            questionValidation = QuestionValidation.Instance();

            upDownWithLabelControl.setLabelTitle("Number Of Faces");

            upDownWithLabelControl.setInputMinValue(questionValidation.FacesMinValue);
            upDownWithLabelControl.setInputMaxValue(questionValidation.FacesMaxValue);
           
            upDownWithLabelControl.clearErrorText();

            upDownWithLabelControl.setCallBackFunction(new CallBackHandleErrorMsg(questionValidation.facesHandleMsg));
            // upDownWithLabelControl.setCallBackFunction(questionValidation.facesHandleMsg);
            

            sharedBetweenQuestions.clearLabelsText();
            sharedBetweenQuestions.setIsNotEmptyCallBack(new CallBackIsNotEmpty(questionValidation.handelQuestionText));

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dividerPanelControl2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isValidGeneralQuestions=sharedBetweenQuestions.isValidForm();
            bool isValidFacesNumber= upDownWithLabelControl.isValidForm();
            if (isValidGeneralQuestions && isValidFacesNumber)
            {
                QuestionFaces questionFaces = new QuestionFaces();
                questionFaces.Text = sharedBetweenQuestions.getQuestionText();
                questionFaces.Order = Convert.ToInt32(sharedBetweenQuestions.getQuestionOrder());
                questionFaces.TypeNumber = (int)QuestionTypes.FACES;
                questionFaces.FacesNumber= upDownWithLabelControl.getFacesNumber();
                questionFaces.add();



            }
        }
    }
}
