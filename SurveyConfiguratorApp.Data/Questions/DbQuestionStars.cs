﻿using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Logic.Questions.Stars;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Data.Questions
{
    public class DbQuestionStars : DbQuestion, IQuestionStarsRepository
    {
        private const string tableName = "QuestionStars";
        public DbQuestionStars() : base() { }

        static public string TableName { get { return tableName; } }
        public bool add(QuestionStars data)
        {
            try
            {
                base.add(data);
                int questionId = base.getLastId();
                SqlCommand cmd = new SqlCommand();


                    base.OpenConnection();

                cmd.Connection = base.conn;



                cmd.CommandText = "INSERT INTO [QuestionStars] ([QuestionId],[StarsNumber]) VALUES (@QuestionId,@StarsNumber);";

                cmd.Parameters.AddWithValue("@QuestionId", questionId);
                cmd.Parameters.AddWithValue("@StarsNumber", data.StarsNumber);



                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    return true;
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

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public QuestionStars read(int id)
        {

            try
            {
                QuestionStars questionStars = new QuestionStars();
                base.OpenConnection();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = base.conn;
                    cmd.CommandText = $"SELECT [Text],[StarsNumber],[Order] FROM Question as q  INNER JOIN QuestionStars as s ON q.id=s.QuestionId WHERE q.Id={id};";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            questionStars.Order = (int)reader["Order"];
                            questionStars.setId(id);
                            questionStars.Text = reader["Text"].ToString();
                            questionStars.StarsNumber = (int)reader["StarsNumber"];
                            return questionStars;

                        }
                    }

                }
            }
            catch (SqlException e)
            {
            }
            catch (Exception e)
            {

            }
            finally
            {
                base.CloseConnection();

            }
            return null;
        }

        public bool update(QuestionStars questionStars)
        {
            using (SqlCommand command = new SqlCommand())
            {
                base.OpenConnection();
                command.Connection = base.conn;
                command.CommandText = $"UPDATE [{TableName}] SET [StarsNumber] = @StarsNumber WHERE [questionId] = @Id";

                command.Parameters.AddWithValue("@StarsNumber", questionStars.StarsNumber);
                command.Parameters.AddWithValue("@Id", questionStars.getId());

                try
                {

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected <= 0)
                    {
                        // Row not found or not updated
                        return false;
                    }

                    base.CloseConnection();

                    return true && base.update(questionStars);

                }
                catch (Exception ex)
                {
                    // Handle any SQL errors

                }
                finally
                {
                    base.CloseConnection();
                }
                return false;


            }
        }

       public QuestionStars Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}