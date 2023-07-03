using SurveyConfiguratorApp.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Data
{

  

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
                Log.Error(ex);

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
                Log.Error(ex);
            }
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


    }

}
