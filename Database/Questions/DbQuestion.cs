using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SurveyConfiguratorApp.Models.Questions;
using static System.Net.Mime.MediaTypeNames;

namespace SurveyConfiguratorApp.Database.Questions
{
    public class DbQuestion : DB, ICRUD<Question>
    {

        public DbQuestion() : base() { }
       

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
                cmd.Parameters.AddWithValue("@Text", data.Text);
                cmd.Parameters.AddWithValue("@TypeNumber", data.TypeNumber);
                cmd.ExecuteNonQuery();
                }

            }
            catch (SqlException e)
            {

                MessageBox.Show("Error " + e.Message,"ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //TODO:user log here
            }
            finally
            {
                base.CloseConnection();
            }
        }

       

        public void delete(int id)
        {

            try
            {
                base.OpenConnection();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = base.conn;
                    cmd.CommandText = $"DELETE FROM [Question] WHERE [Id]={id};";
                   int rowsAffected =  cmd.ExecuteNonQuery();
                    

                    if (rowsAffected > 0)
                    {
                        // Row deleted successfully
                        MessageBox.Show("Row deleted successfully.");
                    }
                    else
                    {
                        // Row not found or not deleted
                        MessageBox.Show("No rows deleted.");
                    }
                }
            }
            catch(SqlException  e)
            {
                //TODO:add log here
                //!Error deleting row
            }
            finally { base.CloseConnection(); }
        }

      

        public Question read(int id)
        {
            throw new NotImplementedException();
        }

        public SqlDataReader readAll()
        {
            //try
            //{
            base.OpenConnection();
            SqlDataReader reader;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = base.conn;
                cmd.CommandText = "SELECT * FROM [Question]";




                 reader= cmd.ExecuteReader();
               
            }

            //}
            //catch (Exception)
            //{

            //    throw;
            //    //TODO:user log here
            //}
            //finally
            //{
            //base.CloseConnection();
            //}
            return reader;
        }


        public void update(Question question)
        {
            base.OpenConnection();
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection= base.conn;
                command.CommandText = $"UPDATE [Question] SET [Text] = @Text,[Order]=@Order WHERE [Id] = @Id";

                command.Parameters.AddWithValue("@Text", question.Text);
                command.Parameters.AddWithValue("@Order", question.Order);
                command.Parameters.AddWithValue("@Id", question.Id);

                try
                {
                   
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Row updated successfully
                        MessageBox.Show("Row updated successfully.");
                    }
                    else
                    {
                        // Row not found or not updated
                        MessageBox.Show("No rows updated for Question");
                    }
                }
                catch (SqlException ex)
                {
                    // Handle any SQL errors
                    MessageBox.Show("Error updating row: " + ex.Message);
                }
                finally
                {
                    base.CloseConnection();
                }
            }

        }

        public bool isOrderAlreadyExists(int order)
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

        public int getLastId()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    base.OpenConnection() ;
                    cmd.Connection = base.conn;
                    cmd.CommandText = "SELECT MAX(id) as MaxId FROM [Question]; ";
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    return Convert.ToInt32(dr["MaxId"]);
                }
            }
           
            finally
            {
                base.CloseConnection() ;
            }
        }
    }
}
