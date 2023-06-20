using SurveyConfiguratorApp.Models.Questions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Database.Questions
{
    public class DbQuestionSlider : DbQuestion, ICRUD<QuestionSlider>
    {
        public void create(QuestionSlider data)
        {
            //try
            //{
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

        public void delete(QuestionSlider data)
        {
            throw new NotImplementedException();
        }

        public void read(QuestionSlider data)
        {
            throw new NotImplementedException();
        }

        public void update(QuestionSlider data)
        {
            throw new NotImplementedException();
        }
    }
}
