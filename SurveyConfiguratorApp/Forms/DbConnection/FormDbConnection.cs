using SurveyConfiguratorApp.Helper;
using SurveyConfiguratorApp.Logic;
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
    public partial class FormDbConnection : Form
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
            HandleSaveButtonEnable();

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
                bool isConnected = dbManager.IsConnect();
                if (isConnected)
                {
                    HandleSaveButtonEnable(true);
                    MessageBox.Show("Connected Successfullty");
                }

                else
                {
                    HandleSaveButtonEnable();
                    MessageBox.Show("Connection Failed");
                }


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
        private void HandleSaveButtonEnable(bool isEnable = false)
        {
            try
            {
                btnSave.Enabled = isEnable;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }


        }

        private void textBoxServer_TextChanged(object sender, EventArgs e)
        {
            try
            {
                HandleSaveButtonEnable();

            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void textBoxDataBase_TextChanged(object sender, EventArgs e)
        {
            try
            {
                HandleSaveButtonEnable();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                HandleSaveButtonEnable();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            try
            {
                HandleSaveButtonEnable();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
               bool isSaved = dbManager.SaveConnection();
              
                if (isSaved)
                {
                    MessageBox.Show("Saved Successfully");

                    ConnectionStringChanged?.Invoke(this, EventArgs.Empty);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Saved Failed");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
    }
}
