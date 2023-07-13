﻿using SurveyConfiguratorApp.Domain;
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
                if (isBaseInfoAdded != StatusCode.Success)
                    return isBaseInfoAdded;
                    int questionId = base.GetQuestionId();
                    if (questionId == -1)
                        return StatusCode.Error;

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        base.OpenConnection();
                        cmd.Connection = base.conn;
                        string insertQuery = string.Format("INSERT INTO [{0}] ([{1}],[{2}]) VALUES (@{1},@{2})",
                                   tableName, ColumnNames.QuestionId, ColumnNames.FacesNumber);

                        cmd.CommandText = insertQuery;

                        cmd.Parameters.AddWithValue($"@{ColumnNames.QuestionId}", questionId);
                        cmd.Parameters.AddWithValue($"@{ColumnNames.FacesNumber}", data.FacesNumber);

                        int rowAffectrowsAffected = cmd.ExecuteNonQuery();
                        if (rowAffectrowsAffected > 0)
                            return StatusCode.Success;

                    }
                


            }
            catch (SqlException ex)
            {
               DbException.HandleSqlException(ex);
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

                    string updateQuery = string.Format("UPDATE [{0}] SET [{1}] = @{1} WHERE [{2}] = @{2}",
                                   tableName, ColumnNames.FacesNumber, ColumnNames.QuestionId);

                    command.CommandText = updateQuery;

                    command.Parameters.AddWithValue($"@{ColumnNames.FacesNumber}", questionFaces.FacesNumber);
                    command.Parameters.AddWithValue($"@{ColumnNames.QuestionId}", questionFaces.getId());

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
            catch (SqlException ex)
            {
                Log.Error(ex);
                // Handle the network exception
                if (ex.Number == 2)
                {
                    return StatusCode.DbFailedNetWorkConnection;
                }
                else
                {
                    return StatusCode.DbFailedConnection;
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
        public new StatusCode Get(ref QuestionFaces questionFaces)
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
                        if (!reader.HasRows) return null;
                        if (reader.Read())
                        {
                            questionFaces.Order = (int)reader[$"{DbQuestion.ColumnNames.Order}"];
                           // questionFaces.setId(id);
                            questionFaces.Text = reader[$"{DbQuestion.ColumnNames.Text}"].ToString();
                            questionFaces.FacesNumber = (int)reader[$"{ColumnNames.FacesNumber}"];
                            return StatusCode.Success;
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
