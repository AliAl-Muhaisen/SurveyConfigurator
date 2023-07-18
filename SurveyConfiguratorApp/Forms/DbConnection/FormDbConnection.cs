using SurveyConfiguratorApp.Forms.Helper;
using SurveyConfiguratorApp.Helper;
using SurveyConfiguratorApp.Logic;
using SurveyConfiguratorApp.Properties;
using SurveyConfiguratorApp.UserController.Controllers;
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
            dbManager=new DbManager();
            Server = dbManager.Server;
            Database = dbManager.Database;
            Username = dbManager.Username;
            Password = dbManager.Password;
           
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
                    CustomMessageBoxForm.Show(Resource.SUCCESS, Resource.TEST_CONNECTION, false,Resource.OK);
                }

                else
                {
                    CustomMessageBoxForm.Show(Resource.ERROR, Resource.TEST_CONNECTION_FAILED, false, Resource.OK);

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
                    DialogResult tDialogResult = CustomMessageBoxForm.Show(Resource.CONFIRM, Resource.SAVE_CONNECTION_FAILED);
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
                    CustomMessageBoxForm.Show(Resource.SUCCESS, Resource.SAVE_SUCCESSFULLY, false, Resource.OK);

                    ConnectionStringChanged?.Invoke(this, EventArgs.Empty);

                    this.Close();
                }
                else
                {
                    CustomMessageBoxForm.Show(Resource.ERROR, Resource.SAVE_FAILED, false, Resource.OK);
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}
