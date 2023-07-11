using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SurveyConfiguratorApp.Data.Questions
{

    /// <summary>
    /// The DbQuestion class extends the DB class and implements the ICRUD<Question> interface. 
    /// It provides methods to perform CRUD operations (Add, read, update, Delete) on the Question entity.
    /// The class includes a ColumnsName enumeration representing the column names in the Question table. 
    /// It also includes additional methods,
    /// retrieve the last inserted ID, and read all questions from the database.
    /// </summary>
    public class DbQuestion : DbConnection
    {
        public static event EventHandler DataChanged;
        public DbQuestion() : base() { }
        public const string tableName = "Question";
       public enum ColumnNames
        {
            Id,
            Order,
            Text,
            TypeNumber

        }
        private int questionId =-1;

        /// <summary>
        /// The Add method inserts a new record into the Question table by constructing a parameterized SQL query.
        /// It catches any SQL exceptions and returns false in case of an error.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public StatusCode Add(Question data)
        {
            try
            {
                base.OpenConnection();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = base.conn;
                    //SCOPE_IDENTITY() is a function in SQL Server that returns the last identity value inserted into an identity column within the current scope.
                    //It is commonly used to retrieve the generated ID value after performing an insert operation.
                    string query= string.Format("INSERT INTO [{0}] ([{1}],[{2}],[{3}]) VALUES " +
                        "(@{1},@{2},@{3});SELECT SCOPE_IDENTITY();",
                        tableName, ColumnNames.Order, ColumnNames.Text, ColumnNames.TypeNumber);

                    cmd.CommandText = query;

                
                   
                    cmd.Parameters.AddWithValue($"@{ColumnNames.Order}", data.Order);
                    cmd.Parameters.AddWithValue($"@{ColumnNames.Text}", data.Text);
                    cmd.Parameters.AddWithValue($"@{ColumnNames.TypeNumber}", data.getTypeNumber());
                    // Execute the query and retrieve the generated ID
                     questionId = Convert.ToInt32(cmd.ExecuteScalar());
                 
                    if (questionId > 0)
                    {
                        OnDataChanged();
                        return StatusCode.Success;
                    }
                    else
                    {
                        return StatusCode.ValidationError;
                    }

                }

            }
            catch (Exception e)
            {
                Log.Error(e);
               return StatusCode.Error;
            }
            finally
            {
                base.CloseConnection();
            }

        }



        public StatusCode Delete(int id)
        {

            try
            {
                base.OpenConnection();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = base.conn;
                    cmd.CommandText = $"DELETE FROM [{tableName}] WHERE [{ColumnNames.Id}]={id};";
                    int rowsAffected = cmd.ExecuteNonQuery();


                    if (rowsAffected > 0)
                    {
                        // Row deleted successfully
                        return StatusCode.Success;

                    }
                   
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            finally { base.CloseConnection(); }
            return StatusCode.Error;

        }








        /// <summary>
        /// The update method updates a specific record in the Question table based on the provided Question object.
        /// It catches SQL exceptions and returns false in case of an error.
        /// </summary>
        public StatusCode Update(Question question)
        {


            try
            {
                base.OpenConnection();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = base.conn;

                    string updateQuery = string.Format("UPDATE [{0}] SET [{1}] = @{1}, [{2}] = @{2} WHERE [{3}] = @{3}",
                                   tableName, ColumnNames.Text, ColumnNames.Order, ColumnNames.Id);


                    command.CommandText = updateQuery;

                    command.Parameters.AddWithValue($"@{ColumnNames.Text}", question.Text);
                    command.Parameters.AddWithValue($"@{ColumnNames.Order}", question.Order);
                    command.Parameters.AddWithValue($"@{ColumnNames.Id}", question.getId());

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Row updated successfully
                        return StatusCode.Success;
                    }
                    else
                    {
                        // Row not found or not updated
                        return StatusCode.ValidationError;
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return StatusCode.Error;
            }
            finally
            {
                base.CloseConnection();
            }

        }



        /// <summary>
        /// The GetQuestionId method retrieves the maximum ID from the Question table.
        /// It catches any SQL exceptions and returns a default value of 1 in case of an error.
        /// </summary>
        /// <returns></returns>
        public int GetQuestionId()
        {
            try
            {
                return questionId;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
           
            return -1;//TODO:!I will review this later :)
        }

        public List<Question> GetQuestions()
        {
            // return new List<Question> { new Question() {Order = 1, Text = "asdfsdf", TypeName="Stars" } };
            List<Question> list = new List<Question>();
            try
            {
                base.OpenConnection();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = base.conn;
                cmd.CommandText = $"SELECT * FROM [{tableName}]";

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        Question question = new Question(
                               (int)reader[$"{ColumnNames.Id}"],
                               reader[$"{ColumnNames.Text}"].ToString(),
                               (int)reader[$"{ColumnNames.TypeNumber}"],
                               (int)reader[$"{ColumnNames.Order}"]
                               );


                        question.setId(Convert.ToInt32(reader[$"{ColumnNames.Id}"]));

                        list.Add(question);
                    }

                }
                return list;
            }

            catch (Exception ex)
            {
                Log.Error(ex);
            }

            return list;
        }



        public Question Get(int id)
        {
            try
            {

                base.OpenConnection();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = base.conn;
                    cmd.CommandText = $"SELECT * FROM {tableName} WHERE {ColumnNames.Id}={id};";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Question question = new Question(
                                id,
                                reader[$"{ColumnNames.Text}"].ToString(),
                                (int)reader[$"{ColumnNames.TypeNumber}"],
                                (int)reader[$"{ColumnNames.Order}"]
                                );

                            return question;

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
            finally
            {
                base.CloseConnection();

            }
            return null;
        }

        public bool IsOrderAlreadyExists(int order,int oldOrder=-1)
        {
            DbQuestion dbQuestion = new DbQuestion();
            try
            {
                dbQuestion.OpenConnection();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = dbQuestion.conn;
                    cmd.CommandText = $"SELECT [{ColumnNames.Order}] FROM [{tableName}] WHERE ([{ColumnNames.Order}] = @{ColumnNames.Order}" +
                        $" AND [{ColumnNames.Order}] != @oldOrder);";
                    cmd.Parameters.AddWithValue($"@{ColumnNames.Order}", order);
                    cmd.Parameters.AddWithValue($"@oldOrder", oldOrder);

                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.HasRows)
                        return true;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
            finally
            {
                dbQuestion.CloseConnection();
            }
            return false;
        }

        protected virtual void OnDataChanged()
        {
            DataChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
