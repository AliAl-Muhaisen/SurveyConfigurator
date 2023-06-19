using SurveyConfiguratorApp.Database;
using SurveyConfiguratorApp.Forms;
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
        SqlConnection conn;
        private Db db;
        public FormMain()
        {
            InitializeComponent();
            try
            {
                //conn = new SqlConnection();
                conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\a.al-muhaisen\\source\\repos\\SurveyConfiguratorApp\\Database1.mdf;Integrated Security=True");

                //db = new Db();
                //db.OpenConnection();
                //MessageBox.Show(db.ToString());
                //db.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("MainForm Error "+ex.Message+"\n"+ex.InnerException);
                //TODO: use log here
            }
            //try {
            //    db = new Db();
            //    MessageBox.Show(db.ToString());
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);

            //    //TODO: use log here
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new FormQuestion();
            form.ShowDialog();
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
