﻿using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Logic.Questions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
                    cmd.CommandText = "INSERT INTO [Question] ([Order],[Text],[TypeNumber]) VALUES (@Order,@Text,@TypeNumber);";

                    cmd.Parameters.AddWithValue("@Order", data.Order);
                    cmd.Parameters.AddWithValue("@Text", data.Text);
                    cmd.Parameters.AddWithValue("@TypeNumber", data.getTypeNumber());
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
            catch (SqlException e)
            {



            }
            finally { base.CloseConnection(); }
            return false;

        }



        public Question read(int id)
        {
            throw new NotImplementedException();
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
                command.Parameters.AddWithValue("@Id", question.getId());

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
            }
            finally
            {
                base.CloseConnection();

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
                        Question question = new Question()
                        {
                            Order = Convert.ToInt32(reader[$"{ColumNames.Order}"]),
                            TypeName = ((Question.QuestionTypes)Convert.ToInt32(reader[$"{ColumNames.TypeNumber}"])).ToString(),
                            Text = (reader[$"{ColumNames.Text}"]).ToString()

                        };
                        list.Add(question);
                    }

                }
                return list;
            }

            catch (Exception ex)
            {


            }

            return list;
        }



        public Question Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}