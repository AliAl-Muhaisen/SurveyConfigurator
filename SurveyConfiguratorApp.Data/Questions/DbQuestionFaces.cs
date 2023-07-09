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
        public bool Add(QuestionFaces data)
        {
            try
            {
                bool isBaseInfoAdded = base.Add(data);
                if (isBaseInfoAdded)
                {
                    int questionId = base.GetQuestionId();
                    if (questionId == -1)
                        return false;

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        base.OpenConnection();

                        cmd.Connection = base.conn;



                        cmd.CommandText = $"INSERT INTO [{tableName}] ([{ColumnNames.QuestionId}],[{ColumnNames.FacesNumber}]) VALUES (@QuestionId,@FacesNumber);";

                        cmd.Parameters.AddWithValue("@QuestionId", questionId);
                        cmd.Parameters.AddWithValue("@FacesNumber", data.FacesNumber);



                        int rowAffectrowsAffected = cmd.ExecuteNonQuery();
                        if (rowAffectrowsAffected > 0)
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

        // Update a QuestionFaces entry in the database
        public bool Update(QuestionFaces questionFaces)
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
                        return false;
                    }
                    base.CloseConnection();
                    base.Update(questionFaces);
                    return true;
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
