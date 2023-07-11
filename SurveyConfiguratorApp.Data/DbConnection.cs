using SurveyConfiguratorApp.Helper;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SurveyConfiguratorApp.Data
{



    /// <summary>
    /// The DB class provides functionality for managing database connections 
    /// using ADO.NET. It includes methods to open and close the database connection.
    /// </summary>
    public class DbConnection
    {
        public SqlConnection conn;
        private static string connectionString;
        public const string AppConfigConnectionName = "ConnectionString";      
        public const string AppConfigConnectionValueName = "connectionStrings";      
        public const string AppConfigSettingsName = "appSettings";
        public const string AppConfigConnectionProviderName = "System.Data.SqlClient";
        public DbConnection()
        {


            try
            {
                connectionString = GetConfigConnectionString();
                conn = new SqlConnection(connectionString);
                OpenConnection();

            }
            catch (Exception ex)
            {
                Log.Error(ex);

            }
            finally
            {
                CloseConnection();
            }
        }

        public static bool IsConnected()
        {
            try
            {
                string connectionString = GetConfigConnectionString();
                using (SqlConnection conn =new SqlConnection(connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return false;
        }

        // Open the database connection
        public void OpenConnection()
        {
            try
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
                //string connectionString= GetConfigConnectionString();
                conn = new SqlConnection(connectionString);
                conn.Open();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
        private static string GetConfigConnectionString()
        {
            try
            {
                ConfigurationManager.RefreshSection(AppConfigSettingsName);
                ConfigurationManager.RefreshSection(AppConfigConnectionValueName);
                return ConfigurationManager.ConnectionStrings[AppConfigConnectionName].ConnectionString;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return "";
        }
        // Close the database connection
        public void CloseConnection()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                    conn = null;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);

            }

        }

        public void RefreshConnectionString()
        {
            try
            {
                connectionString = GetConfigConnectionString();
                Log.Info("Updated Connection String");
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }


    }

}
