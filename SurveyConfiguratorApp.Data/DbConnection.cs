using SurveyConfiguratorApp.Domain;
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

        public static event EventHandler ConnectionFailed;

        
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
        public void OnConnectionFailed()
        {
            try
            {
                ConnectionFailed?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        public static StatusCode IsConnected()
        {
            try
            {
                string connectionString = GetConfigConnectionString();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return StatusCode.Success;
                }
            }
            catch (SqlException ex)
            {
                return DbException.HandleSqlException(ex);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.Error;
            }
        }

        // Open the database connection
        public StatusCode OpenConnection()
        {
            try
            {
                if (conn != null && conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
                conn = new SqlConnection(connectionString);
                conn.Open();

                return StatusCode.Success;
            }
            catch (SqlException ex)
            {
                OnConnectionFailed();
                return DbException.HandleSqlException(ex);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return StatusCode.Error;
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
