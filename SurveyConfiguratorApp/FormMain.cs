using SurveyConfiguratorApp.Domain;
using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Forms.DbConnection;
using SurveyConfiguratorApp.Forms.Questions;
using SurveyConfiguratorApp.Forms.Settings;
using SurveyConfiguratorApp.Helper;
using SurveyConfiguratorApp.Logic;
using SurveyConfiguratorApp.Logic.Questions;
using SurveyConfiguratorApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using ListView = System.Windows.Forms.ListView;
using SortOrder = System.Windows.Forms.SortOrder;

namespace SurveyConfiguratorApp
{
    public partial class FormMain : CustomForm
    {



        // Active form and current button variables

        int questionId = -1;
        private QuestionManager questionManager;
        private DbManager dbManager;
        private int questionTypeNumber = -1;


        private int lastSelectedQuestionOrder = -1;

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
                dbManager = new DbManager();
                dbManager.ConnectionRefreshed += OnConnectionRefreshed;
                listViewQuestions.Items.Clear();
                FillListView();
                questionManager.DataChangedUI += OnRefreshData;

                questionManager.FollowDbChanges();
                listViewQuestions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);




            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        private void FormMain_Load(object sender, EventArgs e)
        {

            try
            {
                ButtonsEnable(false);
                TryConnectToServer();
                ButtonsUpdateAndDeleteEnable(false);
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
                //The InvokeRequired property in Windows Forms is used to check if the current code is executing on the UI thread or a different thread.
                //If InvokeRequired is true, it means the code is running on a non-UI thread.
                Log.Info("---OnRefreshData called");

                if (listViewQuestions.InvokeRequired)
                    //the MethodInvoker delegate enables you to execute code on the UI thread from a different thread, ensuring thread-safety when interacting with UI controls.
                    listViewQuestions.Invoke((MethodInvoker)(() =>
                    {
                        RefreshData();
                    }));

                else
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
                Log.Info("RefreshData called");
                if (listViewQuestions.InvokeRequired)

                    listViewQuestions.Invoke((MethodInvoker)(() =>
                    {
                        FillListView();
                    }));
                else
                    FillListView();

                //  CheckConnection();
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
                    Form fromAdd = new FormQuestion(false, questionId, questionTypeNumber, Resource.UPDATE);
                    fromAdd.ShowDialog();
                    RefreshData();

                }

                ClearSelectedQuestion();

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
                    DialogResult dialogResult = MessageBox.Show(Resource.DELETE_MESSAGE, Resource.CONFIRM, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        questionManager.Delete(questionId);
                        RefreshData();
                    }
                }

                ClearSelectedQuestion();

            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        // General Function


        /// <summary>
        /// This function is a helper to re-select the last row based on the [Order] value
        /// It should be called after any changes in the data view
        /// </summary>
        private void handleSelectTheLastOrder()
        {
            try
            {
                if (listViewQuestions.InvokeRequired)
                    listViewQuestions.Invoke((MethodInvoker)(() =>
                    {
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
                    }));
                // to re-select the row after re-load

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
                Log.Info("FillListView Called");

                List<Question> list = new List<Question>();
                //  list = QuestionManager.questions;

                if (listViewQuestions.IsHandleCreated)
                    listViewQuestions.Invoke((MethodInvoker)(() =>
                {
                    Log.Info("FillListView Rebuild");

                    questionManager.GetQuestions(ref list);
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
                }));


            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        /// <summary>
        /// Sort the List View based on sorting type and selected column
        /// </summary>

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
            try
            {
                questionTypeNumber = question.getTypeNumber();
                questionId = question.getId();
                lastSelectedQuestionOrder = question.Order;
                ButtonsUpdateAndDeleteEnable(true);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        private void ClearSelectedQuestion()
        {
            try
            {
                questionId = -1;
                questionTypeNumber = -1;
                lastSelectedQuestionOrder = -1;
                ButtonsUpdateAndDeleteEnable(false);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Log.Error(ex);
            }



        }

        private void dataBaseConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var DbConnection = new FormDbConnection())
                {
                    DbConnection.ConnectionStringChanged += OnConnectionRefreshed;
                    DbConnection.ShowDialog();
                }


            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void TryConnectToServer()
        {
            try
            {
                int result = DbManager.IsDbConnected();
                bool tIsError = false;
                if (result == StatusCode.SUCCESS)
                {
                    labelStatus.ForeColor = Color.Green;
                    labelStatus.Text = null;
                    ButtonsEnable(true);
                    FillListView();
                    HandleListViewEnable(true);

                }
              
                else
                {
                    tIsError = true;
                    labelStatus.Text = Resource.LABEL_STATUS;
                }

                if (tIsError)
                {
                    labelStatus.ForeColor = Color.Red;
                    ButtonsEnable(false);
                    HandleListViewEnable(false);
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
        private void OnConnectionRefreshed(object sender, EventArgs e)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new EventHandler(OnConnectionRefreshed), sender, e);
                    return;
                }
                TryConnectToServer();
                ClearSelectedQuestion();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }
        private void ButtonsEnable(bool isEnable)
        {
            try
            {
                btnAdd.Enabled = isEnable;
                ButtonsUpdateAndDeleteEnable(isEnable);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        private void HandleListViewEnable(bool isEnable)
        {
            try
            {
                listViewQuestions.Enabled = isEnable;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        private void ButtonsUpdateAndDeleteEnable(bool isEnable)
        {
            try
            {
                btnDelete.Enabled = isEnable;
                btnUpdate.Enabled = isEnable;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        private void languageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form tLanguageForm = new FormLanguage();
                tLanguageForm.ShowDialog();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
    }
}


