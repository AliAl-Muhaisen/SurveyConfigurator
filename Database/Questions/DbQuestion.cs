using System;
using System.Collections.Generic;
using System.Data;
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


        public bool create(Question data)
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
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

            }
            catch (SqlException e)
            {

              
                return false;
                //TODO:user log here
            }
            finally
            {
                base.CloseConnection();
            }

        }



        public bool delete(int id)
        {

            try
            {
                base.OpenConnection();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = base.conn;
                    cmd.CommandText = $"DELETE FROM [Question] WHERE [Id]={id};";
                    int rowsAffected = cmd.ExecuteNonQuery();


                    if (rowsAffected > 0)
                    {
                        // Row deleted successfully
                        MessageBox.Show("Row deleted successfully.");
                        return true;

                    }
                    else
                    {
                        // Row not found or not deleted
                        MessageBox.Show("No rows deleted.");
                        return false;

                    }
                }
            }
            catch (SqlException e)
            {
                //TODO:add log here
                //!Error deleting row
                return false;

            }
            finally { base.CloseConnection(); }
        }



        public Question read(int id)
        {
            throw new NotImplementedException();
        }

        public SqlDataReader readAll()
        {
            try
            {
                base.OpenConnection();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.conn;
                cmd.CommandText = "SELECT * FROM [Question]";

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (SqlException ex)
            {
                // Handle any SQL errors
                // TODO: Use log here
                MessageBox.Show("Error readAll: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle any other errors
                // TODO: Use log here
                MessageBox.Show("Error readAll: " + ex.Message);
            }

            return null;
        }


        public bool update(Question question)
        {
            base.OpenConnection();
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = base.conn;
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
                        return true;
                    }
                    else
                    {
                        // Row not found or not updated
                        return false;
                    }
                }
                catch (SqlException ex)
                {
                    // Handle any SQL errors
                    //TODO:use log here
                   
                    return false;

                }
                finally
                {
                    base.CloseConnection();
                }

            }

        }

        public static bool isOrderAlreadyExists(int order, int oldOrder = -1)
        {
            DbQuestion dbQuestion = new DbQuestion();
            try
            {
                dbQuestion.OpenConnection();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = dbQuestion.conn;
                    cmd.CommandText = "SELECT [Order] FROM [Question] WHERE ([Order] = @order AND [Order]!= @oldOrder);";
                    cmd.Parameters.AddWithValue("@order", order);
                    cmd.Parameters.AddWithValue("@oldOrder", oldOrder);
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                        return true;
                }
            }
            catch (SqlException ex)
            {
                // Handle any SQL errors
                //TODO:use log here
            }
            finally
            {
                dbQuestion.CloseConnection();
            }
            return false;
        }

        public int getLastId()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    base.OpenConnection();
                    cmd.Connection = base.conn;
                    cmd.CommandText = "SELECT MAX(id) as MaxId FROM [Question]; ";
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    return Convert.ToInt32(dr["MaxId"]);
                }
            }
            catch (SqlException ex)
            {
                // Handle any SQL errors
                //TODO:use log here
               
            }
            finally
            {
                base.CloseConnection();

            }
            return 1;//TODO:!I will review this later :)
        }
    }
}
