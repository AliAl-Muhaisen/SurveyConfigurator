﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Database
{
    public interface ICRUD<T>
    {
        void create(T data);
        void update(T data);
        void delete(int id);
        void read(T data);
    }
    public class DB
    {
       public SqlConnection conn;
        //protected SqlCommand cmd;
        const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\a.al-muhaisen\source\repos\SurveyConfiguratorApp\Database\Surveydb.mdf;Integrated Security=True";


        public DB() {
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

        public void OpenConnection()
        {
            try
            {
                conn = new SqlConnection(ConnectionString);
                //cmd = conn.CreateCommand();
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
