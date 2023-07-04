using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
using SurveyConfiguratorApp.Logic.Questions.Faces;
using System;
using System.Data.SqlClient;

namespace SurveyConfiguratorApp.Data.Questions
{
    /// <summary>
    /// The class handles CRUD operations for the QuestionFaces table in the database
    /// </summary>
    public class DbQuestionFaces : DbQuestion, IQuestionFacesRepository
    {
        private const string tableName = "QuestionFaces";
        public enum ColumnNames
        {
            QuestionId,
            FacesNumber,
        }
        public DbQuestionFaces() : base() { }
        static public string TableName { get { return tableName; } }

        // Create a new QuestionFaces entry in the database
        public bool add(QuestionFaces data)
        {
            try
            {
                bool isBaseInfoAdded = base.add(data);
                if (isBaseInfoAdded)
                {
                    int questionId = base.getQuestionId();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        base.OpenConnection();

                        cmd.Connection = base.conn;



                        cmd.CommandText = "INSERT INTO [QuestionFaces] ([QuestionId],[FacesNumber]) VALUES (@QuestionId,@FacesNumber);";

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
        public bool update(QuestionFaces questionFaces)
        {


            try
            {
                using (SqlCommand command = new SqlCommand())
                {
                    base.OpenConnection();
                    command.Connection = base.conn;
                    command.CommandText = $"UPDATE [{TableName}] SET [FacesNumber] = @FacesNumber WHERE [questionId] = @Id";

                    command.Parameters.AddWithValue("@FacesNumber", questionFaces.FacesNumber);
                    command.Parameters.AddWithValue("@Id", questionFaces.getId());

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected <= 0)
                    {
                        // Row not found or not updated
                        return false;
                    }
                    base.CloseConnection();
                    base.update(questionFaces);
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
                    cmd.CommandText = $"SELECT [Text],[FacesNumber],[Order] FROM Question as q  INNER JOIN QuestionFaces as f ON q.id=f.QuestionId WHERE q.Id={id};";
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
