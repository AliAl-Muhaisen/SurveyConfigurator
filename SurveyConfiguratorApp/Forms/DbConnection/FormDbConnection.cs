using SurveyConfiguratorApp.Helper;
using SurveyConfiguratorApp.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.Forms.DbConnection
{
    public partial class FormDbConnection : Form
    {
        DbManager dbManager;
        private string Server { get; set; }
        private string Database { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }

        public FormDbConnection()
        {
            InitializeComponent();

            Server = ".";
            Database = "survey";
            Username = "sa";
            Password = "sedco@123";
            FillInputs();
        }

        private void FormDbConnection_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                GetInputValues();
                dbManager = new DbManager(Server, Database, Username, Password);
                bool isConnected = dbManager.Connect();
                if (isConnected)
                    MessageBox.Show("Connected Successfullty");
                else
                    MessageBox.Show("Connection Failed");

            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        private void GetInputValues()
        {
            try
            {
                Server = textBoxServer.Text;
                Database = textBoxDataBase.Text;
                Username = textBoxUsername.Text;
                Password = textBoxPassword.Text;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

        }
        private void FillInputs()
        {
            try
            {
                textBoxServer.Text = Server;
                textBoxDataBase.Text = Database;
                textBoxUsername.Text = Username;
                textBoxPassword.Text = Password;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

        }
    }
}
