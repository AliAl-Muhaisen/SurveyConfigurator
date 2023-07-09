using SurveyConfiguratorApp.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Logic
{
    public class DbManager
    {
        private readonly string connectionString;
        public DbManager(string server,string database, string username,string password)
        {
            try
            {
                connectionString = BuildConnectionString(server,database,username,password);
            }
            catch(Exception ex)
            {
                Log.Error(ex);
            }

        }
        public bool Connect()
        {
            try
            {
                using(SqlConnection  conn = new SqlConnection(connectionString))
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
        private string BuildConnectionString(string server, string database, string username, string password)
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

       // public static bool TestConnection()
    }
}
