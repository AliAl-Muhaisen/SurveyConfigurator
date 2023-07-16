using SurveyConfiguratorApp.Domain;
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

        private string INSERT_QUERY = string.Format("INSERT INTO [{0}] ([{1}],[{2}]) VALUES (@{1},@{2})",
                               tableName, ColumnNames.QuestionId, ColumnNames.FacesNumber);



        private string UPDATE_QUERY = string.Format("UPDATE [{0}] SET [{1}] = @{1} WHERE [{2}] = @{2}",
                                   tableName, ColumnNames.FacesNumber, ColumnNames.QuestionId);

        public new enum ColumnNames
        {
            QuestionId,
            FacesNumber,
        }
        public DbQuestionFaces() : base() { }



        // Create a new QuestionFaces entry in the database
        public int Add(QuestionFaces data)
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
                    int isBaseInfoAdded = base.Add(data, cmd);
                    if (isBaseInfoAdded != StatusCode.SUCCESS)
                        return isBaseInfoAdded;

                    int questionId = base.GetQuestionId();
                    if (questionId < 0)
                        return StatusCode.ERROR;

                    cmd.CommandText = INSERT_QUERY;

                    cmd.Parameters.AddWithValue($"@{ColumnNames.QuestionId}", questionId);
                    cmd.Parameters.AddWithValue($"@{ColumnNames.FacesNumber}", data.FacesNumber);

                    int rowAffectrowsAffected = cmd.ExecuteNonQuery();
                    if (rowAffectrowsAffected > 0)
                    {
                        transaction.Commit();
                        return StatusCode.SUCCESS;
                    }
                    transaction.Rollback();

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
            finally
            {
                base.CloseConnection();
            }
            return StatusCode.VALIDATION_ERROR;

        }

        // Update a QuestionFaces entry in the database
        public int Update(QuestionFaces questionFaces)
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

                    command.Parameters.AddWithValue($"@{ColumnNames.FacesNumber}", questionFaces.FacesNumber);
                    command.Parameters.AddWithValue($"@{ColumnNames.QuestionId}", questionFaces.getId());

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected <= 0)
                    {
                        // Row not found or not updated
                        return StatusCode.VALIDATION_ERROR;
                    }

                    int tUpdateBaseStatus = base.Update(questionFaces, command);
                    if (tUpdateBaseStatus != StatusCode.SUCCESS)
                    {
                        transaction.Rollback();
                        return tUpdateBaseStatus;
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

        // Read a QuestionFaces entry from the database based on the ID
        public int Get(ref QuestionFaces questionFaces)
        {
            try
            {

                base.OpenConnection();

                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = base.conn;

                    cmd.CommandText = $"SELECT [{DbQuestion.ColumnNames.Text}],[{ColumnNames.FacesNumber}],[{DbQuestion.ColumnNames.Order}] FROM " +
                        $"{DbQuestion.tableName} as q  INNER JOIN {tableName} as f ON q.{DbQuestion.ColumnNames.Id}=f.{ColumnNames.QuestionId}" +
                        $" WHERE q.{DbQuestion.ColumnNames.Id}={questionFaces.getId()};";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows) return StatusCode.DB_RECORD_NOT_EXISTS;
                        if (reader.Read())
                        {
                            questionFaces.Order = (int)reader[$"{DbQuestion.ColumnNames.Order}"];
                            // questionFaces.setId(id);
                            questionFaces.Text = reader[$"{DbQuestion.ColumnNames.Text}"].ToString();
                            questionFaces.FacesNumber = (int)reader[$"{ColumnNames.FacesNumber}"];

                        }
                        return StatusCode.SUCCESS;
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
        }
    }

}
