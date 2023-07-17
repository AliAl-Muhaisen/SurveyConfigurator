using SurveyConfiguratorApp.Helper;
using SurveyConfiguratorApp.Logic;
using SurveyConfiguratorApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.Forms.DbConnection
{
    public partial class FormDbConnection : CustomForm
    {
        DbManager dbManager;
        private string Server { get; set; }
        private string Database { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        public event EventHandler ConnectionStringChanged;

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
                HandleValues();
                bool isConnected = dbManager.IsConnect();
                if (isConnected)
                {
                    MessageBox.Show(Resource.TEST_CONNECTION);
                }

                else
                {
                    MessageBox.Show(Resource.TEST_CONNECTION_FAILED);
                }


            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }
        private void HandleValues()
        {
            try {
                GetInputValues();
                dbManager = new DbManager(Server, Database, Username, Password);
            }
            catch(Exception ex) { 
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


        

      
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                HandleValues();
                bool isConnected = dbManager.IsConnect();
                if (isConnected)
                {
                    HandelSave();
                }
                else
                {
                    DialogResult tDialogResult = MessageBox.Show(Resource.SAVE_CONNECTION_FAILED,"Error",MessageBoxButtons.OKCancel);
                    if (tDialogResult == DialogResult.OK)
                         HandelSave();

                }

            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void HandelSave()
        {
            try
            {
                bool isSaved = dbManager.SaveConnection();

                if (isSaved)
                {
                    MessageBox.Show(Resource.SAVE_SUCCESSFULLY);

                    ConnectionStringChanged?.Invoke(this, EventArgs.Empty);

                    this.Close();
                }
                else
                {
                    MessageBox.Show(Resource.SAVE_FAILED);
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}
