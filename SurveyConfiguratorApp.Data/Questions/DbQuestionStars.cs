using SurveyConfiguratorApp.Domain;
using SurveyConfiguratorApp.Domain.Questions;
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
        public StatusCode Add(QuestionStars data)
        {
            try
            {
                StatusCode isAdded = base.Add(data);


                if (isAdded != StatusCode.Success)
                    return isAdded;

                int questionId = base.GetQuestionId();

                if (questionId == -1)
                    return StatusCode.Error;

                SqlCommand cmd = new SqlCommand();


                base.OpenConnection();

                cmd.Connection = base.conn;

                string insertQuery = string.Format("INSERT INTO [{0}] ([{1}],[{2}]) VALUES (@{1},@{2})",
                                   tableName, ColumnNames.QuestionId, ColumnNames.StarsNumber);


                cmd.CommandText = insertQuery;

                cmd.Parameters.AddWithValue($"@{ColumnNames.QuestionId}", questionId);
                cmd.Parameters.AddWithValue($"@{ColumnNames.StarsNumber}", data.StarsNumber);



                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    return StatusCode.Success;
                }
                // If the stars question not added successfully, Delete the base question 
                base.Delete(questionId);


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
            return StatusCode.ValidationError;
        }



        public StatusCode Update(QuestionStars questionStars)
        {
            using (SqlCommand command = new SqlCommand())
            {
                base.OpenConnection();
                command.Connection = base.conn;

                string updateQuery = string.Format("UPDATE [{0}] SET [{1}] = @{1} WHERE [{2}] = @{2}",
                                   TableName, ColumnNames.StarsNumber, ColumnNames.QuestionId);

                command.CommandText = updateQuery;

                command.Parameters.AddWithValue($"@{ColumnNames.StarsNumber}", questionStars.StarsNumber);
                command.Parameters.AddWithValue($"@{ColumnNames.QuestionId}", questionStars.getId());

                try
                {

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected <= 0)
                    {
                        // Row not found or not updated
                        return StatusCode.ValidationError;
                    }

                    base.CloseConnection();

                    return base.Update(questionStars);

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
        }

        public StatusCode Get(ref QuestionStars questionStars)
        {
            try
            {
                 
               StatusCode tStatusCode= base.OpenConnection();
                if (tStatusCode != StatusCode.Success)
                {
                    return tStatusCode;
                }

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = base.conn;
                    cmd.CommandText = $"SELECT [{DbQuestion.ColumnNames.Text}],[{ColumnNames.StarsNumber}],[{DbQuestion.ColumnNames.Order}]" +
                        $" FROM {DbQuestion.tableName} as q " +
                        $" INNER JOIN {tableName} as s ON q.{DbQuestion.ColumnNames.Id}=s.{ColumnNames.QuestionId} WHERE q.{DbQuestion.ColumnNames.Id}={questionStars.getId()};";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            questionStars.Order = (int)reader["Order"];
                            questionStars.Text = reader["Text"].ToString();
                            questionStars.StarsNumber = (int)reader["StarsNumber"];
                            return StatusCode.Success;

                        }
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
            return StatusCode.DbRecordNotExists;
        }
    }
}
