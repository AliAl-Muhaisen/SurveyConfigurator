using SurveyConfiguratorApp.Models.Questions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Database.Questions
{
    public class DbQuestionFaces : DbQuestion
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

        public void delete(QuestionFaces data)
        {
            throw new NotImplementedException();
        }

        public void read(QuestionFaces data)
        {
            throw new NotImplementedException();
        }

        public void update(QuestionFaces data)
        {
            throw new NotImplementedException();
        }
    }
}
