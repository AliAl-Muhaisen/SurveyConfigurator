using SurveyConfiguratorApp.Models.Questions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.Database.Questions
{
    public class DbQuestionSlider : DbQuestion, ICRUD<QuestionSlider>
    {
        private const string tableName = "QuestionSlider";
        static public string TableName { get { return tableName; } }

        public bool create(QuestionSlider data)
        {
            try
            {
                base.create(data);
                int questionId = base.getLastId();
                using (SqlCommand cmd = new SqlCommand())
                {
                    base.OpenConnection();

                    cmd.Connection = base.conn;



                    cmd.CommandText = "INSERT INTO [QuestionSlider] ([QuestionId],[StartValue],[EndValue],[EndCaption],[StartCaption]) VALUES (@QuestionId,@StartValue,@EndValue,@EndCaption,@StartCaption);";

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
            catch (SqlException e)
            {
                handleExceptionLog(e);
            }
            finally
            {
                base.CloseConnection();
            }
            return false;

        }

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public QuestionSlider read(int id)
        {
            try
            {
                QuestionSlider questionSlider = new QuestionSlider();
                base.OpenConnection();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = base.conn;
                    cmd.CommandText = $"SELECT [Text],[StartValue],[EndValue],[StartCaption],[EndCaption],[Order] FROM Question as q  INNER JOIN QuestionSlider as f ON q.id=f.QuestionId WHERE q.Id={id};";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            questionSlider.Order = (int)reader["Order"];
                            questionSlider.Id = id;
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
                handleExceptionLog(e);
                MessageBox.Show("Error While fetch data " + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                base.CloseConnection();

            }
            return null;
        }

        public bool update(QuestionSlider questionSlider)
        {
            using (SqlCommand command = new SqlCommand())
            {


                try
                {
                    base.OpenConnection();
                    command.Connection = base.conn;
                    command.CommandText = $"UPDATE [{TableName}] SET" +
                        $" [StartCaption] = @StartCaption,[EndCaption] = @EndCaption,[StartValue] = @StartValue,[EndValue] = @EndValue WHERE [questionId] = @Id";

                    command.Parameters.AddWithValue("@StartCaption", questionSlider.StartCaption);
                    command.Parameters.AddWithValue("@EndCaption", questionSlider.EndCaption);
                    command.Parameters.AddWithValue("@StartValue", questionSlider.StartValue);
                    command.Parameters.AddWithValue("@EndValue", questionSlider.EndValue);
                    command.Parameters.AddWithValue("@Id", questionSlider.Id);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected <= 0)
                    {
                        // Row not found or not updated
                        return false;
                    }
                    base.CloseConnection();

                    return true && base.update(questionSlider);
                }
                catch (SqlException ex)
                {
                    handleExceptionLog(ex);
                }
                catch (Exception e)
                {
                    handleExceptionLog(e);

                }
                finally
                {
                    base.CloseConnection();
                }
                return false;


            }

        }
    }
}
