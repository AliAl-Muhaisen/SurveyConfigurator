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
        public StatusCode Add(QuestionSlider data)
        {
            try
            {
                StatusCode isAdded= base.Add(data);
                if (isAdded != StatusCode.Success)
                    return isAdded;
                int questionId = base.GetQuestionId();

                if (questionId == -1)
                    return StatusCode.Error;

                using (SqlCommand cmd = new SqlCommand())
                {
                    base.OpenConnection();

                    cmd.Connection = base.conn;

                    string insertQuery = string.Format("INSERT INTO [{0}] ([{1}],[{2}],[{3}],[{4}],[{5}]) " +
                                   "VALUES (@{1},@{2},@{3},@{4},@{5})",
                                   tableName, ColumnNames.QuestionId, ColumnNames.StartValue,
                                   ColumnNames.EndValue, ColumnNames.EndCaption, ColumnNames.StartCaption);


                    cmd.CommandText = insertQuery;

                    cmd.Parameters.AddWithValue($"@{ColumnNames.QuestionId}", questionId);
                    cmd.Parameters.AddWithValue($"@{ColumnNames.StartValue}", data.StartValue);
                    cmd.Parameters.AddWithValue($"@{ColumnNames.EndValue}", data.EndValue);
                    cmd.Parameters.AddWithValue($"@{ColumnNames.EndCaption}", data.EndCaption);
                    cmd.Parameters.AddWithValue($"@{ColumnNames.StartCaption}", data.StartCaption);



                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        return StatusCode.Success;
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
            return StatusCode.ValidationError;

        }


        public StatusCode Update(QuestionSlider questionSlider)
        {
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    base.OpenConnection();
                    command.Connection = base.conn;

                    string updateQuery = string.Format("UPDATE [{0}] SET [{1}] = @{1}, [{2}] = @{2}, [{3}] = @{3}, [{4}] = @{4} " +
                                   "WHERE [{5}] = @{5}",
                                   tableName, ColumnNames.StartCaption, ColumnNames.EndCaption,
                                   ColumnNames.StartValue, ColumnNames.EndValue, ColumnNames.QuestionId);


                    command.CommandText = updateQuery;

                    command.Parameters.AddWithValue($"@{ColumnNames.StartCaption}", questionSlider.StartCaption);
                    command.Parameters.AddWithValue($"@{ColumnNames.EndCaption}", questionSlider.EndCaption);
                    command.Parameters.AddWithValue($"@{ColumnNames.StartValue}", questionSlider.StartValue);
                    command.Parameters.AddWithValue($"@{ColumnNames.EndValue}", questionSlider.EndValue);
                    command.Parameters.AddWithValue($"@{ColumnNames.QuestionId}", questionSlider.getId());

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected <= 0)
                    {
                        // Row not found or not updated
                        return StatusCode.ValidationError;
                    }
                    base.CloseConnection();

                    return  base.Update(questionSlider);
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

        public  StatusCode Get(ref QuestionSlider questionSlider)
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
                          return  StatusCode.Success;
                        }
                    }

                }
            }
            catch (SqlException e)
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
