using SurveyConfiguratorApp.Database;
using SurveyConfiguratorApp.Database.Questions;
using SurveyConfiguratorApp.Forms;
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

namespace SurveyConfiguratorApp
{
    public partial class FormMain : Form
    {
        private DbQuestion dbQuestion;
        int questionId=-1;
        public FormMain()
        {
            InitializeComponent();
            dbQuestion= new DbQuestion();
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

            if(questionId !=-1)
            {
                dbQuestion.delete(questionId);
                loadDataGridView();

            }
            else
            {
                questionId = -1;
                MessageBox.Show("No row selected.");
            }
            

        }

       

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                DataGridViewRow selectedRow = dataGridView.Rows[e.RowIndex];

                questionId = Convert.ToInt32(selectedRow.Cells["id"].Value);

            }
            // Check if a row is selected
           else if (dataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                // Get the ID value from the selected row
                questionId = Convert.ToInt32(selectedRow.Cells["id"].Value);

           
            }
            else
            {
                questionId = -1;
               
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
    }
}


