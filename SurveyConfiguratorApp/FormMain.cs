using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Forms.DbConnection;
using SurveyConfiguratorApp.Forms.Questions;
using SurveyConfiguratorApp.Helper;
using SurveyConfiguratorApp.Logic;
using SurveyConfiguratorApp.Logic.Questions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

using ListView = System.Windows.Forms.ListView;
using SortOrder = System.Windows.Forms.SortOrder;

namespace SurveyConfiguratorApp
{
    public partial class FormMain : Form
    {



        // Active form and current button variables

        int questionId = -1;
        private QuestionManager questionManager;
        private int questionTypeNumber = -1;

        private static List<Question> questionList = new List<Question>();

        private int lastSelectedQuestionOrder = -1;
        private Question currentQuestion = null;

        private int lastSortColumn = -1;




        /// <summary>
        /// the FormMain constructor initializes the form's components, creates an instance of the DbQuestion class, 
        /// sets the initial value of the currentButton variable, and opens the FormHome as the initial child form within the main form.
        /// </summary>
        public FormMain()
        {
            try
            {
                InitializeComponent();
                questionManager = new QuestionManager();
                listViewQuestions.Items.Clear();
                FillListView();
                questionManager.DataChangedUI += OnRefreshData;
                listViewQuestions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }



        }
        // Form Load

        private void FormMain_Load(object sender, EventArgs e)
        {

            try
            {
                loadDataGridView();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        //Timer Methods



        // Data Grid View Methods
        private void loadDataGridView()
        {
            try
            {
                DataTable table = new DataTable();
                questionList = QuestionManager.questions;

                var bindingList = new BindingList<Question>(questionList);

                var source = new BindingSource(bindingList, null);

            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }



        private void OnRefreshData(object sender, EventArgs e)
        {
            try
            {
                RefreshData();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
        private void RefreshData()
        {
            try
            {
                FillListView();
                handleSelectTheLastOrder();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }


        }


        /// <summary>
        /// Sort Data Grid View based on sorting type and selected column
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="columnName"></param>
        private void sortDataGridView(string sortOrder, string columnName)
        {
            try
            {
                // var comparer = new QuestionListComparer(columnName, sortOrder);

                // questionList.Sort(comparer);
                // dataGridViewQuestion.DataSource = null;
                // dataGridViewQuestion.DataSource = questionList;
                handleSelectTheLastOrder();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }


        // Data Grid View Buttons
        //Add Button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Form fromAdd = new FormQuestion();
                fromAdd.ShowDialog();
                RefreshData();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }


        }

        // Update Button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (questionId != -1)
                {
                    // questionId = handleQuestionId(questionId);
                    Form fromAdd = new FormQuestion(false, questionId, questionTypeNumber, "Update Question");
                    fromAdd.ShowDialog();
                    loadDataGridView();

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

        // Delete Button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                if (questionId != -1)
                {
                    //  questionId = handleQuestionId(questionId);
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        questionManager.Delete(questionId);
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
                Log.Error(ex);
            }
        }

        // General Function

        /// <summary>
        /// This function is a helper to check if the object with a specific ID is still available in the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private int handleQuestionId(int id)
        {

            try
            {
                Question question = questionManager.GetQuestion(id);

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

        /// <summary>
        /// This function is a helper to re-select the last row based on the [Order] value
        /// It should be called after any changes in the data view
        /// </summary>
        private void handleSelectTheLastOrder()
        {
            try
            {
                // to re-select the row after re-load
                if (lastSelectedQuestionOrder != -1)
                {

                    foreach (ListViewItem item in listViewQuestions.Items)
                    {
                        if (item.SubItems[0].Text == lastSelectedQuestionOrder.ToString())
                        {
                            item.Selected = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

        }

        private void FillListView()
        {
            try
            {
                List<Question> list = new List<Question>();
                list = QuestionManager.questions;
                listViewQuestions.Items.Clear();
                foreach (Question question in list)
                {
                    // Create a new ListViewItem and set its Text property to the Order value
                    ListViewItem item = new ListViewItem(question.Order.ToString());

                    // Add sub-items to the ListViewItem
                    item.SubItems.Add(question.TypeName);
                    item.SubItems.Add(question.Text);
                    item.Tag = question;

                    listViewQuestions.Items.Add(item);


                }

            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
              //  string lastSortedType;
                if (e.Column != lastSortColumn)
                {
                    lastSortColumn = e.Column;
                    listViewQuestions.Sorting = SortOrder.Ascending;
                }
                else
                {
                    listViewQuestions.Sorting = listViewQuestions.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
                }
               // lastSortedType = listViewQuestions.Sorting.ToString();
                QuestionListComparer comparer = new QuestionListComparer(e.Column, listViewQuestions.Sorting.ToString());

                // Set the ListViewItemSorter property
                listViewQuestions.ListViewItemSorter = comparer;

                // Call the Sort method to apply sorting
                listViewQuestions.Sort();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void UpdateSelectedQuestion(Question question)
        {
            questionTypeNumber = question.getTypeNumber();
            questionId = question.getId();
            lastSelectedQuestionOrder = question.Order;
        }

        private void ClearSelectedQuestion()
        {
            questionId = -1;
            questionTypeNumber = -1;
            lastSelectedQuestionOrder = -1;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListView listView = (ListView)sender;
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem selectedRowData = listView.SelectedItems[0];

                if (selectedRowData.Tag is Question question)
                {
                    UpdateSelectedQuestion(question);
                }
            }
            else
            {
                ClearSelectedQuestion();
            }


        }

        private void dataBaseConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form DbConnection = new FormDbConnection();
                DbConnection.ShowDialog();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
    }
}


