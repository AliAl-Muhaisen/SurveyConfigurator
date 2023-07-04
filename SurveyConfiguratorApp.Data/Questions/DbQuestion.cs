﻿using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
using SurveyConfiguratorApp.Logic.Questions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SurveyConfiguratorApp.Data.Questions
{

    /// <summary>
    /// The DbQuestion class extends the DB class and implements the ICRUD<Question> interface. 
    /// It provides methods to perform CRUD operations (add, read, update, delete) on the Question entity.
    /// The class includes a ColumnsName enumeration representing the column names in the Question table. 
    /// It also includes additional methods,
    /// retrieve the last inserted ID, and read all questions from the database.
    /// </summary>
    public class DbQuestion : DB, IQuestionRepository
    {

        public DbQuestion() : base() { }

        enum ColumNames
        {
            Id,
            Order,
            Text,
            TypeNumber

        }
        private int questionId =-1;

        /// <summary>
        /// The add method inserts a new record into the Question table by constructing a parameterized SQL query.
        /// It catches any SQL exceptions and returns false in case of an error.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool add(Question data)
        {
            try
            {
                base.OpenConnection();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = base.conn;
                    //SCOPE_IDENTITY() is a function in SQL Server that returns the last identity value inserted into an identity column within the current scope.
                    //It is commonly used to retrieve the generated ID value after performing an insert operation.
                    cmd.CommandText = "INSERT INTO [Question] ([Order],[Text],[TypeNumber]) VALUES (@Order,@Text,@TypeNumber);SELECT SCOPE_IDENTITY();";

                    cmd.Parameters.AddWithValue("@Order", data.Order);
                    cmd.Parameters.AddWithValue("@Text", data.Text);
                    cmd.Parameters.AddWithValue("@TypeNumber", data.getTypeNumber());
                    // Execute the query and retrieve the generated ID
                     questionId = Convert.ToInt32(cmd.ExecuteScalar());
                 
                    if (questionId > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }

            }
            catch (Exception e)
            {
                Log.Error(e);
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
                        return true;

                    }
                    else
                    {
                        // Row not found or not deleted
                        return false;

                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            finally { base.CloseConnection(); }
            return false;

        }








        /// <summary>
        /// The update method updates a specific record in the Question table based on the provided Question object.
        /// It catches SQL exceptions and returns false in case of an error.
        /// </summary>
        public bool update(Question question)
        {


            try
            {
                base.OpenConnection();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = base.conn;
                    command.CommandText = $"UPDATE [Question] SET [Text] = @Text,[Order]=@Order WHERE [Id] = @Id";

                    command.Parameters.AddWithValue("@Text", question.Text);
                    command.Parameters.AddWithValue("@Order", question.Order);
                    command.Parameters.AddWithValue("@Id", question.getId());

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
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
            finally
            {
                base.CloseConnection();
            }
            return false;


        }



        /// <summary>
        /// The getQuestionId method retrieves the maximum ID from the Question table.
        /// It catches any SQL exceptions and returns a default value of 1 in case of an error.
        /// </summary>
        /// <returns></returns>
        public int getQuestionId()
        {
            try
            {
                return questionId;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
           
            return 1;//TODO:!I will review this later :)
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
                cmd.CommandText = "SELECT * FROM [Question]";

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        Question question = new Question(
                               (int)reader[$"{ColumNames.Id}"],
                               reader["Text"].ToString(),
                               (int)reader["TypeNumber"],
                               (int)reader["Order"]
                               );


                        question.setId(Convert.ToInt32(reader[$"{ColumNames.Id}"]));

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
                    cmd.CommandText = $"SELECT * FROM Question as q WHERE q.Id={id};";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Question question = new Question(
                                id,
                                reader["Text"].ToString(),
                                (int)reader["TypeNumber"],
                                (int)reader["Order"]
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

        public bool deleteByOrder(int order)
        {

            try
            {
                base.OpenConnection();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = base.conn;
                    cmd.CommandText = $"DELETE FROM [Question] WHERE [{ColumNames.Order}]={order};";
                    int rowsAffected = cmd.ExecuteNonQuery();


                    if (rowsAffected > 0)
                    {
                        // Row deleted successfully
                        return true;

                    }
                    else
                    {
                        // Row not found or not deleted
                        return false;

                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
            finally { base.CloseConnection(); }
            return false;
        }

        public bool isOrderAlreadyExists(int order)
        {
            DbQuestion dbQuestion = new DbQuestion();
            try
            {
                dbQuestion.OpenConnection();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = dbQuestion.conn;
                    cmd.CommandText = "SELECT [Order] FROM [Question] WHERE ([Order] = @order);";
                    cmd.Parameters.AddWithValue("@order", order);
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
    }
}
