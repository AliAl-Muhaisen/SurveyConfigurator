﻿using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
using System;
using System.Data.SqlClient;

namespace SurveyConfiguratorApp.Data.Questions
{
    public class DbQuestionStars : DbQuestion
    {
        private new const string tableName = "QuestionStars";
        private new enum ColumnNames
        {
            QuestionId,
            StarsNumber,
        }
        public DbQuestionStars() : base() { }

        static public string TableName { get { return tableName; } }
        public bool Add(QuestionStars data)
        {
            try
            {
                bool isAdded = base.Add(data);


                if (!isAdded)
                    return false;

                int questionId = base.GetQuestionId();

                if (questionId == -1)
                    return false;

                SqlCommand cmd = new SqlCommand();


                base.OpenConnection();

                cmd.Connection = base.conn;

                cmd.CommandText = $"INSERT INTO [{tableName}] ([{ColumnNames.QuestionId}],[{ColumnNames.StarsNumber}]) VALUES (@QuestionId,@StarsNumber);";
                cmd.Parameters.AddWithValue("@QuestionId", questionId);
                cmd.Parameters.AddWithValue("@StarsNumber", data.StarsNumber);



                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    return true;
                }
                // If the stars question not added successfully, Delete the base question 
                base.Delete(questionId);


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



        public bool Update(QuestionStars questionStars)
        {
            using (SqlCommand command = new SqlCommand())
            {
                base.OpenConnection();
                command.Connection = base.conn;
                command.CommandText = $"UPDATE [{TableName}] SET [{ColumnNames.StarsNumber}] = @StarsNumber WHERE [{ColumnNames.QuestionId}] = @Id";

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

                    return base.Update(questionStars);

                }
                catch (Exception ex)
                {
                    // Handle any SQL errors
                    Log.Error(ex);
                }
                finally
                {
                    base.CloseConnection();
                }
                return false;


            }
        }

        public new QuestionStars Get(int id)
        {
            try
            {
                QuestionStars questionStars = new QuestionStars();
                base.OpenConnection();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = base.conn;
                    cmd.CommandText = $"SELECT [{DbQuestion.ColumnNames.Text}],[{ColumnNames.StarsNumber}],[{DbQuestion.ColumnNames.Order}]" +
                        $" FROM {DbQuestion.tableName} as q " +
                        $" INNER JOIN {tableName} as s ON q.{DbQuestion.ColumnNames.Id}=s.{ColumnNames.QuestionId} WHERE q.{DbQuestion.ColumnNames.Id}={id};";
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

            catch (Exception e)
            {
                Log.Error(e);
            }
            finally
            {
                base.CloseConnection();

            }
            return null;
        }
    }
}
