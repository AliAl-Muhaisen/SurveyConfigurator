using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SurveyConfiguratorApp.Models;
using SurveyConfiguratorApp.Models.Questions;
using static System.Net.Mime.MediaTypeNames;

namespace SurveyConfiguratorApp.Database.Questions
{

    /// <summary>
    /// The DbQuestion class extends the DB class and implements the ICRUD<Question> interface. 
    /// It provides methods to perform CRUD operations (create, read, update, delete) on the Question entity.
    /// The class includes a ColumnsName enumeration representing the column names in the Question table. 
    /// It also includes additional methods,
    /// retrieve the last inserted ID, and read all questions from the database.
    /// </summary>
    public class DbQuestion : DB, ICRUD<Question>
    {

        public DbQuestion() : base() { }

        enum ColumsName
        {
            Order,
            Text,
            TypeNumber

        }


        /// <summary>
        /// The create method inserts a new record into the Question table by constructing a parameterized SQL query.
        /// It catches any SQL exceptions and returns false in case of an error.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
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
                handleExceptionLog(e);
            }
            finally
            {
                base.CloseConnection();
            }
            return false;

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
                handleExceptionLog(e);



            }
            finally { base.CloseConnection(); }
            return false;

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

                handleExceptionLog(ex);

                MessageBox.Show("Error readAll: " + ex.Message);
            }
            catch (Exception ex)
            {

                handleExceptionLog(ex);

                MessageBox.Show("Error readAll: " + ex.Message);
            }

            return null;
        }

        /// <summary>
        /// The update method updates a specific record in the Question table based on the provided Question object.
        /// It catches SQL exceptions and returns false in case of an error.
        /// </summary>
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
                    handleExceptionLog(ex);
                }
                finally
                {
                    base.CloseConnection();
                }
                return false;
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

                ErrorLoggerFile errorLoggerFile = new ErrorLoggerFile();
                errorLoggerFile.HandleException(ex);
            }
            finally
            {
                dbQuestion.CloseConnection();
            }
            return false;
        }


        /// <summary>
        /// The getLastId method retrieves the maximum ID from the Question table.
        /// It catches any SQL exceptions and returns a default value of 1 in case of an error.
        /// </summary>
        /// <returns></returns>
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
                handleExceptionLog(ex);
            }
            finally
            {
                base.CloseConnection();

            }
            return 1;//TODO:!I will review this later :)
        }


    }
}
