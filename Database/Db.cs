using SurveyConfiguratorApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.Database
{

    public interface ICRUD<T>
    {
        bool create(T data);
        bool update(T data);
        bool delete(int id);
        T read(int id);
    }

    /// <summary>
    /// The DB class provides functionality for managing database connections 
    /// using ADO.NET. It includes methods to open and close the database connection.
    /// </summary>
    public class DB
    {
        public SqlConnection conn;
        //protected SqlCommand cmd;
        private string connectionString;
        public DB()
        {
           

            try
            {
                 connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                conn = new SqlConnection(connectionString);
                OpenConnection();

            }
            catch (Exception ex)
            {
                handleExceptionLog(ex);
                //throw new Exception(ex.Message);

            }
            finally
            {
                CloseConnection();
            }
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
                conn = new SqlConnection(connectionString);
                //cmd = conn.CreateCommand();
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                handleExceptionLog(ex);
                // throw new Exception(ex.Message);
            }
        }

        // Close the database connection
        public void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
                conn = null;
            }
        }
        protected void handleExceptionLog(Exception ex)
        {
            try
            {
                ErrorLoggerFile errorLoggerFile = new ErrorLoggerFile();
                errorLoggerFile.HandleException(ex);
            }
            catch { }
        }

    }
}
