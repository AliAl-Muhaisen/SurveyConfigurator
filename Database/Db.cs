using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Database
{
    public class Db
    {
        SqlConnection conn;
        SqlCommand cmd;
        const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\a.al-muhaisen\source\repos\SurveyConfiguratorApp\Database1.mdf;Integrated Security=True";


        public Db() {
            conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\a.al-muhaisen\\source\\repos\\SurveyConfiguratorApp\\Database1.mdf;Integrated Security=True");

            //try
            //{
            //    OpenConnection();



            //}
            //catch(Exception ex) {

            //    throw new Exception(ex.Message);

            //}
            //finally
            //{
            //    CloseConnection();
            //}
        }

        public void OpenConnection()
        {
            try
            {
                conn = new SqlConnection(ConnectionString);
                cmd = conn.CreateCommand();
                conn.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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
