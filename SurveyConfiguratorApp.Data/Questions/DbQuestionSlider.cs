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
        public bool Add(QuestionSlider data)
        {
            try
            {
                base.Add(data);
                int questionId = base.GetQuestionId();

                if (questionId == -1)
                    return false;

                using (SqlCommand cmd = new SqlCommand())
                {
                    base.OpenConnection();

                    cmd.Connection = base.conn;



                    cmd.CommandText = $"INSERT INTO [{tableName}] ([{ColumnNames.QuestionId}],[{ColumnNames.StartValue}]," +
                        $"[{ColumnNames.EndValue}],[{ColumnNames.EndCaption}],[{ColumnNames.StartCaption}]) " +
                        $"VALUES (@QuestionId,@StartValue,@EndValue,@EndCaption,@StartCaption);";

                    cmd.Parameters.AddWithValue("@QuestionId", questionId);
                    cmd.Parameters.AddWithValue("@StartValue", data.StartValue);
                    cmd.Parameters.AddWithValue("@EndValue", data.EndValue);
                    cmd.Parameters.AddWithValue("@EndCaption", data.EndCaption);
                    cmd.Parameters.AddWithValue("@StartCaption", data.StartCaption);



                    int rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        return true;
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


        public bool Update(QuestionSlider questionSlider)
        {
            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    base.OpenConnection();
                    command.Connection = base.conn;
                    command.CommandText = $"UPDATE [{tableName}] SET" +
                        $" [{ColumnNames.StartCaption}] = @StartCaption,[{ColumnNames.EndCaption}] = @EndCaption,[{ColumnNames.StartValue}] = @StartValue," +
                        $"[{ColumnNames.EndValue}] = @EndValue WHERE [{ColumnNames.QuestionId}] = @Id";

                    command.Parameters.AddWithValue("@StartCaption", questionSlider.StartCaption);
                    command.Parameters.AddWithValue("@EndCaption", questionSlider.EndCaption);
                    command.Parameters.AddWithValue("@StartValue", questionSlider.StartValue);
                    command.Parameters.AddWithValue("@EndValue", questionSlider.EndValue);
                    command.Parameters.AddWithValue("@Id", questionSlider.getId());

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected <= 0)
                    {
                        // Row not found or not updated
                        return false;
                    }
                    base.CloseConnection();

                    return true && base.Update(questionSlider);
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

        public new QuestionSlider Get(int id)
        {
            try
            {
                QuestionSlider questionSlider = new QuestionSlider();
                base.OpenConnection();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = base.conn;
                    cmd.CommandText = $"SELECT [{DbQuestion.ColumnNames.Text}],[{ColumnNames.StartValue}],[{ColumnNames.EndValue}],[{ColumnNames.StartCaption}],[{ColumnNames.EndCaption}]," +
                        $"[{DbQuestion.ColumnNames.Order}] FROM {DbQuestion.tableName} as q  INNER JOIN {tableName} as f ON q.id=f.{ColumnNames.QuestionId} WHERE q.{DbQuestion.ColumnNames.Id}={id};";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            questionSlider.Order = (int)reader["Order"];
                            questionSlider.setId(id);
                            questionSlider.Text = reader["Text"].ToString();
                            questionSlider.EndCaption = reader["EndCaption"].ToString();
                            questionSlider.StartCaption = reader["StartCaption"].ToString();
                            questionSlider.StartValue = (int)reader["StartValue"];
                            questionSlider.EndValue = (int)reader["EndValue"];
                            return questionSlider;

                        }
                    }

                }
            }
            catch (SqlException e)
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
