using SurveyConfiguratorApp.Data;
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
        private DB db;

        public event EventHandler ConnectionRefreshed;

        public DbManager(string server, string database, string username, string password)
        {
            try
            {
                connectionString = BuildConnectionString(server, database, username, password);
                conn = new SqlConnection(connectionString);
                db = new DB();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }
        public DbManager() { }
       protected void OnConnectionRefreshed()
        {
            try
            {
                ConnectionRefreshed?.Invoke(this, EventArgs.Empty);

            }
            catch (Exception e) {
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
            catch (SqlException)
            {

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
                return $"Server={server};Database={database};User Id={username};Password={password};";
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
                if(!IsConnect())
                {
                    return false;
                }

                Configuration config;
                config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.ConnectionStrings.ConnectionStrings["ConnectionString"].ConnectionString = connectionString;
                config.ConnectionStrings.ConnectionStrings["ConnectionString"].ProviderName = "System.Data.SqlClient";
                config.AppSettings.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
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

        public static bool IsDbConnected()
        {
            try
            {
               return DB.IsConnected();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return false;
        }

    }

}
