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

            upDownWithLabelControl.handleNumericError(questionValidation.facesHandleMsg);


        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dividerPanelControl2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
