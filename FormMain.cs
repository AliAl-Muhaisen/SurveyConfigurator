using SurveyConfiguratorApp.Database;
using SurveyConfiguratorApp.Database.Questions;
using SurveyConfiguratorApp.Forms;
using SurveyConfiguratorApp.Forms.Questions;
using SurveyConfiguratorApp.Models.Questions;
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
        int questionId = -1;
        int questionType = -1;

        public FormMain()
        {
            InitializeComponent();
            dbQuestion = new DbQuestion();
            loadDataGridView();

        }


        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form form = new FormQuestion();
            form.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            if (questionId != -1)
            {
                dbQuestion.delete(questionId);
                loadDataGridView();

            }
            else
            {
                questionId = -1;
                MessageBox.Show("No row selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }



        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                DataGridViewRow selectedRow = dataGridView.Rows[e.RowIndex];

                questionId = Convert.ToInt32(selectedRow.Cells["id"].Value);
                questionType = Convert.ToInt32(selectedRow.Cells["typeNumber"].Value);


            }
            //? Check if a row is selected
            else if (dataGridView.SelectedRows.Count > 0)
            {
                //# Get the selected row
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                //# Get the ID value from the selected row
                questionId = Convert.ToInt32(selectedRow.Cells["id"].Value);
                questionType = Convert.ToInt32(selectedRow.Cells["typeNumber"].Value);


            }
            else
            {
                questionId = -1;
                questionType = -1;

            }
        }

        private void loadDataGridView()
        {
            DataTable table = new DataTable();
            SqlDataReader reader = dbQuestion.readAll();
            table.Load(reader);


            dataGridView.DataSource = table;
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (questionType != -1 && questionId != -1)
            {

                if (questionType == (int)QuestionTypes.FACES)
                {
                    DbQuestionFaces dbQuestionFaces = new DbQuestionFaces();
                    QuestionFaces questionFaces = new QuestionFaces();

                    questionFaces = dbQuestionFaces.read(questionId);
                    if (questionFaces != null)
                    {
                        Form formFaces = new FormFacesQuestion(dbQuestionFaces.read(questionId));
                        formFaces.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Please Refresh the data and try again");
                    }

                }
                else if (questionType == (int)QuestionTypes.STARS)
                {
                    DbQuestionStars questionStars = new DbQuestionStars();

                    Form formStars = new FormStarsQuestion(questionStars.read(questionId));
                    formStars.ShowDialog();


                }
                else if (questionType == (int)QuestionTypes.SLIDER)
                {

                }
                loadDataGridView();

            }
            else
            {
                questionId = -1;
                MessageBox.Show("No row selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}


