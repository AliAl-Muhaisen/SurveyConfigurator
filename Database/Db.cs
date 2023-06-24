using System;
using System.Collections.Generic;
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
        const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\a.al-muhaisen\source\repos\SurveyConfiguratorApp\Database\Surveydb.mdf;Integrated Security=True";



        public DB()
        {
            conn = new SqlConnection(ConnectionString);

            try
            {
                OpenConnection();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);

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
                conn = new SqlConnection(ConnectionString);
                //cmd = conn.CreateCommand();
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

    }
}
