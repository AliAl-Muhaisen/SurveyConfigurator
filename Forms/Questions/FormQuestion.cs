using SurveyConfiguratorApp.Forms.Questions;
using SurveyConfiguratorApp.Models;
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
    public partial class FormQuestion : Form
    {
        private Button currentButton;

        public FormQuestion()
        {
            try
            {
                InitializeComponent();
                layoutControl1.changeTitle("Questions");
                layoutControl1.addToPanelSideBar(panelSideBarChild);
                panelSideBarChild.BackColor = layoutControl1.PanelSideBarColor;
                panelSideBarChild.Padding = new Padding(5, 0, 0, 0);
                currentButton = buttonStarsQuestion;
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }



        }


        private void FormQuestion_Load(object sender, EventArgs e)
        {

        }


        private void layoutControl1_Load(object sender, EventArgs e)
        {
            try
            {
                layoutControl1.OpenChildForm(new FormStarsQuestion());
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }

        }

        private void buttonSmileyQuestion_Click(object sender, EventArgs e)
        {

            try
            {
                if (sender != null && (Button)sender != currentButton)
                    layoutControl1.OpenChildForm(new FormFacesQuestion());

                currentButton = (Button)sender;
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }

        }

        private void buttonStarsQuestion_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender != null && (Button)sender != currentButton)
                    layoutControl1.OpenChildForm(new FormStarsQuestion());

                currentButton = (Button)sender;
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }

        }

        private void buttonSliderQuestion_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender != null && (Button)sender != currentButton)
                    layoutControl1.OpenChildForm(new FormSliderQuestion());

                currentButton = (Button)sender;
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }

        }

        private void handleExceptionLog(Exception ex)
        {

            ErrorLoggerFile errorLoggerFile = new ErrorLoggerFile();
            errorLoggerFile.HandleException(ex);

        }
    }
}
