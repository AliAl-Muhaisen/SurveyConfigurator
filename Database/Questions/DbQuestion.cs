using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SurveyConfiguratorApp.Models.Questions;

namespace SurveyConfiguratorApp.Database.Questions
{
    public class DbQuestion : DB, ICRUD<Question>
    {

        public DbQuestion() : base() { }
        public void create<T>(Question data)
        {
            
            try
            {
                base.OpenConnection();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = base.conn;
                    cmd.CommandText = "INSERT INTO [Question] ([Order],[Text],[TypeNumber]) VALUES (@Order,@Text,@TypeNumber);";

                    cmd.Parameters.AddWithValue("@Order", data.Order);
                    cmd.Parameters.AddWithValue("@Text", data.Text);
                    cmd.Parameters.AddWithValue("@TypeNumber", data.TypeNumber);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
                //TODO:user log here
            }

        }

        public void create(Question data)
        {
            try
            {
                base.OpenConnection();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = base.conn;
                    cmd.CommandText = "INSERT INTO [Question] ([Order],[Text],[TypeNumber]) VALUES (@Order,@Text,@TypeNumber);";

                    cmd.Parameters.AddWithValue("@Order", data.Order);
                    cmd.Parameters.AddWithValue("@Order", data.Text);
                    cmd.Parameters.AddWithValue("@Order", data.TypeNumber);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                throw;
                //TODO:user log here
            }
            finally
            {
                base.CloseConnection();
            }
        }

       

        public void delete(Question data)
        {
            throw new NotImplementedException();
        }

      

        public void read(Question data)
        {
            throw new NotImplementedException();
        }

       

        public void update(Question data)
        {
            throw new NotImplementedException();
        }

        public bool isOrderReadyExists(int order)
        {
            try
            {
                using (SqlCommand cmd=new SqlCommand())
                {
                    cmd.Connection= base.conn;
                    cmd.CommandText="SELECT [Order] FROM [Question] WHERE [Order]=" + order + ";";
                }
            }
            finally
            {

            }
            return false;
        }
    }
}
