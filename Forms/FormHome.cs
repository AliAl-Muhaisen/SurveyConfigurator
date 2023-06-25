using SurveyConfiguratorApp.Database.Questions;
using SurveyConfiguratorApp.Forms.Questions;
using SurveyConfiguratorApp.Models;
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

namespace SurveyConfiguratorApp.Forms
{
    public partial class FormHome : Form
    {
        private DbQuestion dbQuestion;

        int questionId = -1;
        int questionType = -1;
        public FormHome()
        {
            InitializeComponent();
            dbQuestion = new DbQuestion();
            loadDataGridView();

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form form = new FormQuestion();
            form.ShowDialog();
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
                        displayRefreshMessageBox();
                    }

                }
                else if (questionType == (int)QuestionTypes.STARS)
                {
                    DbQuestionStars dbQuestionStars = new DbQuestionStars();
                    QuestionStars questionStars = new QuestionStars();
                    questionStars = dbQuestionStars.read(questionId);
                    if (questionStars != null)
                    {
                        Form formStars = new FormStarsQuestion(questionStars);
                        formStars.ShowDialog();
                    }
                    else
                    {
                        displayRefreshMessageBox();

                    }



                }
                else if (questionType == (int)QuestionTypes.SLIDER)
                {
                    DbQuestionSlider dbQuestionSlider = new DbQuestionSlider();
                    QuestionSlider questionSlider = new QuestionSlider();
                    questionSlider = dbQuestionSlider.read(questionId);
                    if (questionSlider != null)
                    {
                        Form formSlider = new FormSliderQuestion(questionSlider);
                        formSlider.ShowDialog();
                    }
                    else
                    {
                        displayRefreshMessageBox();
                    }
                }
                loadDataGridView();

            }
            else
            {
                questionId = -1;
                MessageBox.Show("No row selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (questionId != -1)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        dbQuestion.delete(questionId);
                        loadDataGridView();
                        questionId = -1;
                    }


                }
                else
                {
                    MessageBox.Show("No row selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }


        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        private void loadDataGridView()
        {
            try
            {
                DataTable table = new DataTable();

                using (SqlDataReader reader = dbQuestion.readAll())
                {
                    if (reader != null)
                    {
                        table.Load(reader);
                    }
                }

                dataGridView.DataSource = table;
            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }


        }
        private void displayRefreshMessageBox()
        {
            MessageBox.Show("Please Refresh the data and try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void FormHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                dbQuestion.CloseConnection();
            }
            catch (Exception ex)
            {

                handleExceptionLog(ex);
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                handleExceptionLog(ex);
            }

        }

        protected void handleExceptionLog(Exception ex)
        {
            try
            {
                ErrorLoggerFile errorLoggerFile = new ErrorLoggerFile();
                errorLoggerFile.HandleException(ex);
            }
            catch { }
        }
    }
}
