using SurveyConfiguratorApp.Data;
using SurveyConfiguratorApp.Domain;
using SurveyConfiguratorApp.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Logic
{
    public class DbManager
    {
        private readonly string connectionString;
        SqlConnection conn;
        private DbConnection db;

        public event EventHandler ConnectionRefreshed;

        public DbManager(string server, string database, string username, string password) : this()
        {
            try
            {
                connectionString = BuildConnectionString(server, database, username, password);
                conn = new SqlConnection(connectionString);

            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }
        public DbManager()
        {
            db = new DbConnection();
            DbConnection.ConnectionFailed += ConnectionFailed;
        }
        public void ConnectionFailed(object sender, EventArgs e)
        {
            try
            {
                OnConnectionRefreshed();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
        protected void OnConnectionRefreshed()
        {
            try
            {
                ConnectionRefreshed?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

        }
        public bool IsConnect()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                return true;

            }

            catch (Exception e)
            {
                Log.Error(e);


            }
            return false;
        }
        private static string BuildConnectionString(string server, string database, string username, string password)
        {
            try
            {
                string connString = String.Format("Server={0};Database={1};User Id={2};Password={3};", server, database, username, password);
                return connString;
            }

            catch (Exception ex)
            {
                Log.Error(ex);
            }
            return "";
        }

        public bool SaveConnection()
        {
            try
            {
                
                //if (!IsConnect())
                //{
                //    return false;
                //}

                Configuration config;
                config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.ConnectionStrings.ConnectionStrings[DbConnection.APP_CONFIG_CONNECTION_NAME].ConnectionString = connectionString;
                config.ConnectionStrings.ConnectionStrings[DbConnection.APP_CONFIG_CONNECTION_NAME].ProviderName = DbConnection.APP_CONFIG_CONNECTION_PROVIDER_NAME;
                config.AppSettings.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(DbConnection.APP_CONFIG_SETTINGS_NAME);
                db.RefreshConnectionString();
                OnConnectionRefreshed();

                return true;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return false;
        }

        public static int IsDbConnected()
        {
            try
            {
                return DbConnection.IsConnected();
            }
            catch (Exception e)
            {
                Log.Error(e);
                return ResultCode.ERROR;
            }
        }



    }

}
