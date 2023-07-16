using SurveyConfiguratorApp.Domain;
using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
using System;
using System.Data.SqlClient;

namespace SurveyConfiguratorApp.Data.Questions
{
    public class DbQuestionSlider : DbQuestion
    {
        private new const string tableName = "QuestionSlider";
        public new enum ColumnNames
        {
            QuestionId,
            StartValue,
            EndValue,
            StartCaption,
            EndCaption,
        }
        private string INSERT_QUERY = string.Format("INSERT INTO [{0}] ([{1}],[{2}],[{3}],[{4}],[{5}]) " +
                                   "VALUES (@{1},@{2},@{3},@{4},@{5})",
                                   tableName, ColumnNames.QuestionId, ColumnNames.StartValue,
                                   ColumnNames.EndValue, ColumnNames.EndCaption, ColumnNames.StartCaption);

        private string UPDATE_QUERY = string.Format("UPDATE [{0}] SET [{1}] = @{1}, [{2}] = @{2}, [{3}] = @{3}, [{4}] = @{4} " +
                                   "WHERE [{5}] = @{5}",
                                   tableName, ColumnNames.StartCaption, ColumnNames.EndCaption,
                                   ColumnNames.StartValue, ColumnNames.EndValue, ColumnNames.QuestionId);

        public int Add(QuestionSlider data)
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
                    cmd.Parameters.AddWithValue($"@{ColumnNames.StartValue}", data.StartValue);
                    cmd.Parameters.AddWithValue($"@{ColumnNames.EndValue}", data.EndValue);
                    cmd.Parameters.AddWithValue($"@{ColumnNames.EndCaption}", data.EndCaption);
                    cmd.Parameters.AddWithValue($"@{ColumnNames.StartCaption}", data.StartCaption);



                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        transaction.Commit();
                        return StatusCode.SUCCESS;
                    }
                    transaction.Rollback();
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
            return StatusCode.VALIDATION_ERROR;

        }


        public int Update(QuestionSlider questionSlider)
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

                    command.Parameters.AddWithValue($"@{ColumnNames.StartCaption}", questionSlider.StartCaption);
                    command.Parameters.AddWithValue($"@{ColumnNames.EndCaption}", questionSlider.EndCaption);
                    command.Parameters.AddWithValue($"@{ColumnNames.StartValue}", questionSlider.StartValue);
                    command.Parameters.AddWithValue($"@{ColumnNames.EndValue}", questionSlider.EndValue);
                    command.Parameters.AddWithValue($"@{ColumnNames.QuestionId}", questionSlider.getId());

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected <= 0)
                    {
                        // Row not found or not updated
                        transaction.Rollback();
                        return StatusCode.VALIDATION_ERROR;
                    }


                    int tUpdatedBaseStatus = base.Update(questionSlider, command);
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
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }



        }

        public int Get(ref QuestionSlider questionSlider)
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
                    cmd.CommandText = $"SELECT [{DbQuestion.ColumnNames.Text}],[{ColumnNames.StartValue}],[{ColumnNames.EndValue}],[{ColumnNames.StartCaption}],[{ColumnNames.EndCaption}]," +
                        $"[{DbQuestion.ColumnNames.Order}] FROM {DbQuestion.tableName} as q  INNER JOIN {tableName} as f ON q.id=f.{ColumnNames.QuestionId} WHERE q.{DbQuestion.ColumnNames.Id}={questionSlider.getId()};";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            questionSlider.Order = (int)reader["Order"];
                            questionSlider.Text = reader["Text"].ToString();
                            questionSlider.EndCaption = reader["EndCaption"].ToString();
                            questionSlider.StartCaption = reader["StartCaption"].ToString();
                            questionSlider.StartValue = (int)reader["StartValue"];
                            questionSlider.EndValue = (int)reader["EndValue"];
                            return StatusCode.SUCCESS;
                        }
                    }

                }
            }
            catch (SqlException e)
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
