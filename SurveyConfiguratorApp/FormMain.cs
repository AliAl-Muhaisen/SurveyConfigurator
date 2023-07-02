
using SurveyConfiguratorApp.Data.Questions;
using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Forms;
using SurveyConfiguratorApp.Logic.Questions;
using SurveyConfiguratorApp.UserController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyConfiguratorApp
{
    public partial class FormMain : Form
    {



        // Active form and current button variables
        private Form activeForm;
        private Button currentButton;
        public IQuestionService questionService { get; set; }


        /// <summary>
        /// the FormMain constructor initializes the form's components, creates an instance of the DbQuestion class, 
        /// sets the initial value of the currentButton variable, and opens the FormHome as the initial child form within the main form.
        /// </summary>
        public FormMain()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
            }



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
          

        }



        private void loadDataGridView()
        {

            try
            {
               

                DataTable table = new DataTable();
                    List<Question> list;
                 list = questionService.GetQuestions();

                var bindingList = new BindingList<Question>(list);

                var source = new BindingSource(bindingList, null);
                dataGridViewQuestion.DataSource = source;
                
               
           
            }
            catch (Exception ex)
            {
            }


        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}


