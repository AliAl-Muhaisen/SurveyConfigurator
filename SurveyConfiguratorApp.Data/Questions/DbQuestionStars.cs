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

        private string INSERT_QUERY = string.Format("INSERT INTO [{0}] ([{1}],[{2}]) VALUES (@{1},@{2})",
                                           tableName, ColumnNames.QuestionId, ColumnNames.StarsNumber);
     
        private string UPDATE_QUERY=string.Format("UPDATE [{0}] SET [{1}] = @{1} WHERE [{2}] = @{2}",
                                       TableName, ColumnNames.StarsNumber, ColumnNames.QuestionId);
      
        private new enum ColumnNames
        {
            QuestionId,
            StarsNumber,
        }
        public DbQuestionStars() : base() { }

        static public string TableName { get { return tableName; } }
        public int Add(QuestionStars data)
        {
            try
            {

                using (SqlCommand cmd = new SqlCommand())
                {
                    int tConnectionStatus = base.OpenConnection();
                    if (tConnectionStatus != StatusCode.SUCCESS)
                    {
                        return tConnectionStatus;
                    }

                    cmd.Connection = base.conn;

                    SqlTransaction transaction = conn.BeginTransaction();
                    cmd.Transaction = transaction;

                    int isAddedStatus = base.Add(data, cmd);


                    if (isAddedStatus != StatusCode.SUCCESS)
                        return isAddedStatus;

                    int questionId = base.GetQuestionId();

                    if (questionId == -1)
                        return StatusCode.ERROR;

                    cmd.CommandText = INSERT_QUERY;

                    cmd.Parameters.AddWithValue($"@{ColumnNames.QuestionId}", questionId);
                    cmd.Parameters.AddWithValue($"@{ColumnNames.StarsNumber}", data.StarsNumber);



                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        transaction.Commit();
                        return StatusCode.SUCCESS;
                    }
                    // If the stars question not added successfully, Delete the base question 
                    transaction.Rollback();
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return StatusCode.ERROR;
            }
            finally
            {
                base.CloseConnection();
            }
            return StatusCode.VALIDATION_ERROR;
        }



        public int Update(QuestionStars questionStars)
        {
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    int tConnectionStatus = base.OpenConnection();
                    if (tConnectionStatus != StatusCode.SUCCESS)
                    {
                        return tConnectionStatus;
                    }

                    command.Connection = base.conn;

                    SqlTransaction transaction = conn.BeginTransaction();

                    command.Transaction = transaction;

                    command.CommandText = UPDATE_QUERY;

                    command.Parameters.AddWithValue($"@{ColumnNames.StarsNumber}", questionStars.StarsNumber);
                    command.Parameters.AddWithValue($"@{ColumnNames.QuestionId}", questionStars.getId());



                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected <= 0)
                    {
                        // Row not found or not updated
                        return StatusCode.VALIDATION_ERROR;
                    }


                    int tUpdatedBaseStatus = base.Update(questionStars, command);
                    if (tUpdatedBaseStatus != StatusCode.SUCCESS)
                    {
                        transaction.Rollback();
                        return tUpdatedBaseStatus;
                    }
                    transaction.Commit();
                    base.CloseConnection();
                    return StatusCode.SUCCESS;
                }

            }
            catch (SqlException ex)
            {
                return DbException.HandleSqlException(ex);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return StatusCode.ERROR;
            }
        }

        public int Get(ref QuestionStars questionStars)
        {
            try
            {

                int tStatusCode = base.OpenConnection();
                if (tStatusCode != StatusCode.SUCCESS)
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
                            return StatusCode.SUCCESS;

                        }
                    }

                }
            }

            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }
            finally
            {
                base.CloseConnection();

            }
            return StatusCode.DB_RECORD_NOT_EXISTS;
        }
    }
}
