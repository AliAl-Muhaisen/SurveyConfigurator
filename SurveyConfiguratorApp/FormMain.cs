﻿using SurveyConfiguratorApp.Domain.Questions;
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
using System.Drawing;
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
                listViewQuestions.Items.Clear();
                FillListView();
                questionManager.DataChangedUI += OnRefreshData;
                questionManager.FollowDbChanges();
                listViewQuestions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.None);

                dbManager = new DbManager();
                dbManager.ConnectionRefreshed += OnConnectionRefreshed;

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

                labelStatus.ForeColor = Color.Red;
                labelStatus.Text = "Try connecting...";
                TryConnectToServer();
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
                //    Log.Info("OnRefreshData called");
                // MessageBox.Show("Refresh");
                if (listViewQuestions.InvokeRequired)
                    listViewQuestions.Invoke((MethodInvoker)(() =>
                    {
                        RefreshData();
                    }));
                //if (listViewQuestions.InvokeRequired)
                //{
                //    Invoke(new EventHandler(OnRefreshData), sender, e);
                //    return;
                //}
                else
                    RefreshData();
                //DataChanged?.Invoke(this, EventArgs.Empty);
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
                if (listViewQuestions.InvokeRequired)
                    listViewQuestions.Invoke((MethodInvoker)(() =>
                    {
                        FillListView();
                    }));
                else
                    FillListView();

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
                    RefreshData();

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
                        RefreshData();
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
                    RefreshData();
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
                List<Question> list = new List<Question>();
                //  list = QuestionManager.questions;
                
                if (listViewQuestions.IsHandleCreated)
                    listViewQuestions.Invoke((MethodInvoker)(() =>
                {
                    list = questionManager.GetQuestions();
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
        /// Sort Data Grid View based on sorting type and selected column
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
                bool result = DbManager.IsDbConnected();
                if (result)
                {
                    labelStatus.ForeColor = Color.Green;
                    labelStatus.Text = null;
                    ButtonsEnable(true);

                    // this.Refresh();
                     FillListView();
                  

                }
                else
                {
                    labelStatus.ForeColor = Color.Red;
                    labelStatus.Text = "Connected Failed";
                    ButtonsEnable(false);
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
                btnDelete.Enabled = isEnable;
                btnUpdate.Enabled = isEnable;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}


