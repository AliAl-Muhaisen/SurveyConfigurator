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


            upDownWithLabelControl.setLabelTitle("Number Of Stars");

            upDownWithLabelControl.setInputMinValue(questionValidation.StarsMinValue);
            upDownWithLabelControl.setInputMaxValue(questionValidation.StarsMaxValue);
            upDownWithLabelControl.clearErrorText();

            //upDownWithLabelControl.setCallBackFunction(questionValidation.starsHandleMsg);
            upDownWithLabelControl.setCallBackFunction(new CallBackHandleErrorMsg(questionValidation.facesHandleMsg));
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
    }
}
