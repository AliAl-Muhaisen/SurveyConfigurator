using SurveyConfiguratorApp.Database;
using SurveyConfiguratorApp.Database.Questions;
using SurveyConfiguratorApp.Forms;
using SurveyConfiguratorApp.Forms.Log;
using SurveyConfiguratorApp.Forms.Questions;
using SurveyConfiguratorApp.Models;
using SurveyConfiguratorApp.Models.Questions;
using SurveyConfiguratorApp.UserController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SurveyConfiguratorApp.Models.Questions.Question;

namespace SurveyConfiguratorApp
{
    public partial class FormMain : Form
    {

        private DbQuestion dbQuestion;
    

        // Active form and current button variables
        private Form activeForm;
        private Button currentButton;

        /// <summary>
        /// the FormMain constructor initializes the form's components, creates an instance of the DbQuestion class, 
        /// sets the initial value of the currentButton variable, and opens the FormHome as the initial child form within the main form.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            dbQuestion = new DbQuestion();
            currentButton = buttonHome;
            OpenChildForm(new FormHome());

        }


        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }


        /// <summary>
        ///  closing the database connection managed by the dbQuestion object when the main form is being closed.
        ///  This ensures that the database connection is properly closed before the application exits.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbQuestion.CloseConnection();        

        }

        /// <summary>
        /// this event handler is responsible for opening the FormHome form as a child form when the
        /// "HOME" button is clicked, and it keeps track of the currently selected button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHome_Click(object sender, EventArgs e)
        {
            if (sender != null && (Button)sender != currentButton)
                OpenChildForm(new FormHome());

            currentButton = (Button)sender;
        }



        /// <summary>
        /// this event handler is responsible for opening the FormErrorLog form as a child form when the
        /// "Log" button is clicked, and it keeps track of the currently selected button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLog_Click(object sender, EventArgs e)
        {
            if (sender != null && (Button)sender != currentButton)
            {
               
                OpenChildForm(new FormErrorLog());
            }

            currentButton = (Button)sender;

        }



        /// <summary>
        /// Opens a child form within the main form as a controller.
        /// </summary>
        /// <param name="childForm" type="Form"></param>
        private void OpenChildForm(Form childForm)
        {

            // Close any previously active form
            if (activeForm != null)
            {
                activeForm.Close();

            }

            // If the child form is already active, return
            if (childForm == activeForm)
                return;

            // Set the child form as the active form
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            // Add the child form to the Controls collection of the panelContainer, making it a child control of the panel
            panelContainer.Controls.Add(childForm);
            // Set the Tag of the panelContainer to the child form, allowing easy access to the child form later
            panelContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void buttonError_Click(object sender, EventArgs e)
        {
            //Just for test
            DbQuestion question = null;
            ErrorLoggerFile log = new ErrorLoggerFile();
            try
            {
                question.OpenConnection();
            }
            catch (Exception ex)
            {

                log.HandleException(ex);
            }
        }
    }
}


