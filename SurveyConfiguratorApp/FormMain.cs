﻿
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
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SurveyConfiguratorApp.Domain.Questions.Question;

namespace SurveyConfiguratorApp
{
    public partial class FormMain : Form
    {



        // Active form and current button variables

        int questionId = -1;
        int selectedRow = -1;
        public IQuestionService questionService { get; set; }
        private string questionTypeName = null;
        private int questionTypeNumber = -1;
        Question q;
        /// <summary>
        /// the FormMain constructor initializes the form's components, creates an instance of the DbQuestion class, 
        /// sets the initial value of the currentButton variable, and opens the FormHome as the initial child form within the main form.
        /// </summary>
        public FormMain()
        {
            try
            {
                InitializeComponent();
               string a= q.Text;
            }
            catch (Exception e)
            {
                Log.Error(e);
                MessageBox.Show("catch error");
            }



        }


        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }


        /// <summary>

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
            Form fromAdd = new FormQuestion();
            fromAdd.ShowDialog();
            loadDataGridView();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                if (questionId != -1)
                {
                    questionId = handleQuestionId(questionId);
                    Form fromAdd = new FormQuestion(false, questionId, questionTypeNumber,"Update Question");
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
                    }


                }
                else
                {
                    MessageBox.Show("No row selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
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
                    isChecked = true;

                }
                //? Check if a row is selected
                else if (dataGridViewQuestion.SelectedRows.Count > 0)
                {
                    //# Get the selected row
                    selectedRowData = dataGridViewQuestion.SelectedRows[0];
                    isChecked = true;

                    //# Get the ID value from the selected row

                }

                else
                {
                    questionId = -1;
                    questionTypeName = null;
                    questionTypeNumber = -1;
                    isChecked = false;



                }

                if (isChecked && selectedRowData != null)
                {
                    Question question = selectedRowData.DataBoundItem as Question;

                    questionTypeName = question.TypeName;
                    questionTypeNumber=question.getTypeNumber();
                    questionId = question.getId();
                }
            }
            catch (Exception ex)
            {

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

                MessageBox.Show(e.Message);
            }
            return -1;
        }
    }
}


