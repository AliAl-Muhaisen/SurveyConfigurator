using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
using System;
using System.Data.SqlClient;

namespace SurveyConfiguratorApp.Data.Questions
{
    /// <summary>
    /// The class handles CRUD operations for the QuestionFaces table in the database
    /// </summary>
    public class DbQuestionFaces : DbQuestion
    {
        private new const string tableName = "QuestionFaces";
        public new enum ColumnNames
        {
            QuestionId,
            FacesNumber,
        }
        public DbQuestionFaces() : base() { }

        // Create a new QuestionFaces entry in the database
        public StatusCode Add(QuestionFaces data)
        {
            try
            {
                StatusCode isBaseInfoAdded = base.Add(data);
                if (isBaseInfoAdded== StatusCode.Success)
                {
                    int questionId = base.GetQuestionId();
                    if (questionId == -1)
                        return StatusCode.Error;

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        base.OpenConnection();

                        cmd.Connection = base.conn;



                        cmd.CommandText = $"INSERT INTO [{tableName}] ([{ColumnNames.QuestionId}],[{ColumnNames.FacesNumber}]) VALUES (@QuestionId,@FacesNumber);";

                        cmd.Parameters.AddWithValue("@QuestionId", questionId);
                        cmd.Parameters.AddWithValue("@FacesNumber", data.FacesNumber);

                        int rowAffectrowsAffected = cmd.ExecuteNonQuery();
                        if (rowAffectrowsAffected > 0)
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

        // Update a QuestionFaces entry in the database
        public StatusCode Update(QuestionFaces questionFaces)
        {


            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    base.OpenConnection();
                    command.Connection = base.conn;
                    command.CommandText = $"UPDATE [{tableName}] SET [{ColumnNames.FacesNumber}] = @FacesNumber WHERE [{ColumnNames.QuestionId}] = @Id";

                    command.Parameters.AddWithValue("@FacesNumber", questionFaces.FacesNumber);
                    command.Parameters.AddWithValue("@Id", questionFaces.getId());

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected <= 0)
                    {
                        // Row not found or not updated
                        return StatusCode.ValidationError;
                    }
                    base.CloseConnection();
                    ;
                    return base.Update(questionFaces);
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

        // Read a QuestionFaces entry from the database based on the ID
        public new QuestionFaces Get(int id)
        {
            try
            {
                QuestionFaces questionFaces = new QuestionFaces();
                base.OpenConnection();

                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = base.conn;

                    cmd.CommandText = $"SELECT [{DbQuestion.ColumnNames.Text}],[{ColumnNames.FacesNumber}],[{DbQuestion.ColumnNames.Order}] FROM " +
                        $"{DbQuestion.tableName} as q  INNER JOIN {tableName} as f ON q.{DbQuestion.ColumnNames.Id}=f.{ColumnNames.QuestionId}" +
                        $" WHERE q.{DbQuestion.ColumnNames.Id}={id};";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows) return null;
                        if (reader.Read())
                        {
                            questionFaces.Order = (int)reader["Order"];
                            questionFaces.setId(id);
                            questionFaces.Text = reader["Text"].ToString();
                            questionFaces.FacesNumber = (int)reader["FacesNumber"];
                            return questionFaces;

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
