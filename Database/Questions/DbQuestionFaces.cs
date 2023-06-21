using SurveyConfiguratorApp.Models.Questions;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.Database.Questions
{
    public class DbQuestionFaces : DbQuestion, ICRUD<QuestionFaces>
    {
        public DbQuestionFaces() : base() { }
        public void create(QuestionFaces data)
        {
            //try
            //{
            base.create(data);
            int questionId = base.getLastId();
            using (SqlCommand cmd = new SqlCommand())
            {
                base.OpenConnection();

                cmd.Connection = base.conn;



                cmd.CommandText = "INSERT INTO [QuestionFaces] ([QuestionId],[FacesNumber]) VALUES (@QuestionId,@FacesNumber);";

                cmd.Parameters.AddWithValue("@QuestionId", questionId);
                cmd.Parameters.AddWithValue("@FacesNumber", data.FacesNumber);



                cmd.ExecuteNonQuery();



            }

            //}
            //catch (Exception)
            //{

            //    throw;
            //    //TODO:user log here
            //}
            //finally
            //{
            base.CloseConnection();
            //}

        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public QuestionFaces read(int id)
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
                        if (reader.Read())
                        {
                            questionFaces.Order = (int)reader["Order"];
                            questionFaces.Id = id;
                            questionFaces.Text = reader["Text"].ToString();
                            questionFaces.FacesNumber = (int)reader["FacesNumber"];
                            return questionFaces;

                        }
                    }

                }
            }
            catch (SqlException e)
            {
                //TODO:add log here
                //!Error deleting row
                MessageBox.Show("Error While fetch data " + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                base.CloseConnection();

            }
            return null;
        }

        public void update(QuestionFaces questionFaces)
        {
            throw new NotImplementedException();
        }
    }
}
