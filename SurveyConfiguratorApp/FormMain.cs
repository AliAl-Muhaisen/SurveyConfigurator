
using SurveyConfiguratorApp.Data.Questions;
using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Forms;
using SurveyConfiguratorApp.Forms.Questions;
using SurveyConfiguratorApp.Helper;
using SurveyConfiguratorApp.Logic.Questions;
using SurveyConfiguratorApp.UserController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyConfiguratorApp
{
    public partial class FormMain : Form
    {



        // Active form and current button variables

        int questionId = -1;
        public IQuestionService questionService { get; set; }
        private int questionTypeNumber = -1;

        private static List<Question> questionList = new List<Question>();

        private int selectedRowIndex = -1;
        private string lastSortColumn = string.Empty;
        private SortOrder lastSortOrder = SortOrder.None;
        /// <summary>
        /// the FormMain constructor initializes the form's components, creates an instance of the DbQuestion class, 
        /// sets the initial value of the currentButton variable, and opens the FormHome as the initial child form within the main form.
        /// </summary>
        public FormMain()
        {
            try
            {
                InitializeComponent();
                InitializeTimer();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }



        }

        private void InitializeTimer()
        {
            timer1 = new Timer();
            timer1.Interval = 8000;

            timer1.Tick += Timer_Tick;

            timer1.Enabled = true; // Start the timer
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // This code will be executed every 8 second
            loadDataGridView();
        }
       
        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }



        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {


        }



        private void loadDataGridView()
        {
            try
            {
                DataTable table = new DataTable();
                questionList = questionService.GetQuestions();

                var bindingList = new BindingList<Question>(questionList);

                var source = new BindingSource(bindingList, null);

                dataGridViewQuestion.DataSource = source;
               
                // to re-sort the data after re-load
                if (lastSortColumn != null && lastSortOrder!=SortOrder.None)
                {
                   sortDataGridView(lastSortOrder.ToString(), lastSortColumn);

                }

                //to re-select the row after re-load
                if (selectedRowIndex >= 0 && selectedRowIndex < dataGridViewQuestion.Rows.Count)
                {
                    dataGridViewQuestion.Rows[selectedRowIndex].Selected = true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }


        private void FormMain_Load(object sender, EventArgs e)
        {

            try
            {
                loadDataGridView();
                dataGridViewQuestion.ClearSelection();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Form fromAdd = new FormQuestion();
                fromAdd.ShowDialog();
                loadDataGridView();
                dataGridViewQuestion.ClearSelection();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (questionId != -1)
                {
                    questionId = handleQuestionId(questionId);
                    Form fromAdd = new FormQuestion(false, questionId, questionTypeNumber, "Update Question");
                    fromAdd.ShowDialog();
                    loadDataGridView();
                    dataGridViewQuestion.ClearSelection();

                }
                else
                {
                    MessageBox.Show("No row selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                if (questionId != -1)
                {
                    questionId = handleQuestionId(questionId);
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        questionService.delete(questionId);
                        loadDataGridView();
                        questionId = -1;
                        dataGridViewQuestion.ClearSelection();
                    }


                }
                else
                {
                    MessageBox.Show("No row selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void dataGridViewQuestion_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                DataGridViewRow selectedRowData = null;
                bool isChecked = false;
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {

                    selectedRowData = dataGridViewQuestion.Rows[e.RowIndex];
                    selectedRowIndex = e.RowIndex;
                    isChecked = true;

                }
                //? Check if a row is selected
                else if (dataGridViewQuestion.SelectedRows.Count > 0)
                {
                    //# Get the selected row
                    selectedRowData = dataGridViewQuestion.SelectedRows[0];
                    isChecked = true;
                    selectedRowIndex= dataGridViewQuestion.SelectedRows[0].Index;
                    //# Get the ID value from the selected row

                }

                else
                {
                    questionId = -1;
                    questionTypeNumber = -1;
                    isChecked = false;



                }

                if (isChecked && selectedRowData != null)
                {
                    Question question = selectedRowData.DataBoundItem as Question;

                    questionTypeNumber = question.getTypeNumber();
                    questionId = question.getId();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);

            }


        }
        private int handleQuestionId(int id)
        {

            try
            {
                Question question = questionService.Get(id);

                if (question != null)
                {
                    return question.getId();
                }
                else
                {
                    loadDataGridView();
                    MessageBox.Show("This question does not exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception e)
            {
                Log.Error(e);

                MessageBox.Show(e.Message);
            }
            return -1;
        }

        private void dataGridViewQuestion_ColumnHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                string columnName = dataGridViewQuestion.Columns[e.ColumnIndex].Name;
                SortOrder sortOrder = dataGridViewQuestion.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Ascending
                      ? SortOrder.Descending
                      : SortOrder.Ascending;

                sortDataGridView(sortOrder.ToString(), columnName);
                this.lastSortColumn = columnName;
                lastSortOrder = sortOrder;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        private void sortDataGridView(string sortOrder, string columnName)
        {
            try
            {
                var comparer = new QuestionComparer(columnName, sortOrder);
                questionList.Sort(comparer);
                dataGridViewQuestion.DataSource = null;
                dataGridViewQuestion.DataSource = questionList;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }


    }
}


