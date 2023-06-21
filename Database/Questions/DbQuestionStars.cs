using SurveyConfiguratorApp.Models.Questions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Database.Questions
{
    public class DbQuestionStars : DbQuestion, ICRUD<QuestionStars>
    {
        public DbQuestionStars():base() { }

        public void create(QuestionStars data)
        {
            //try
            //{
            base.create(data);
            int questionId = base.getLastId();
            using (SqlCommand cmd = new SqlCommand())
            {
                base.OpenConnection();

                cmd.Connection = base.conn;



                cmd.CommandText = "INSERT INTO [QuestionStars] ([QuestionId],[StarsNumber]) VALUES (@QuestionId,@StarsNumber);";

                cmd.Parameters.AddWithValue("@QuestionId", questionId);
                cmd.Parameters.AddWithValue("@StarsNumber", data.StarsNumber);



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

        public void read(QuestionStars data)
        {
            throw new NotImplementedException();
        }

        public void update(QuestionStars questionStars)
        {
            throw new NotImplementedException();
        }
    }
}
