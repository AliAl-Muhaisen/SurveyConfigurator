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
    public class DbQuestionStars : DbQuestion, ICRUD<QuestionStars>
    {
        private const string tableName = "QuestionStars";
        public DbQuestionStars():base() { }

        static public string TableName { get { return tableName; } }
        public void create(QuestionStars data)
        {
            try
            {
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

            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error creating row: " + ex.Message);
                //TODO:user log here
            }
            finally
            {
                base.CloseConnection();
            }
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public QuestionStars read(int id)
        { 
            
            try
            {
                QuestionStars questionStars = new QuestionStars();
                base.OpenConnection();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = base.conn;
                    cmd.CommandText = $"SELECT [Text],[StarsNumber],[Order] FROM Question as q  INNER JOIN QuestionStars as s ON q.id=s.QuestionId WHERE q.Id={id};";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            questionStars.Order = (int)reader["Order"];
                            questionStars.Id = id;                         
                            questionStars.Text = reader["Text"].ToString();
                            questionStars.StarsNumber = (int)reader["StarsNumber"];
                            return questionStars;

                        }
                    }
                           
                }
            }
            catch (SqlException e)
            {
                //TODO:add log here
                //!Error deleting row
                MessageBox.Show("Error While fetch data "+e.Message,"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally { base.CloseConnection();
               
            }
            return null;
        }

        public void update(QuestionStars questionStars)
        {
            using (SqlCommand command = new SqlCommand())
            {  
                base.OpenConnection();
                command.Connection = base.conn;
                command.CommandText = $"UPDATE [{TableName}] SET [StarsNumber] = @StarsNumber WHERE [questionId] = @Id";

                command.Parameters.AddWithValue("@StarsNumber", questionStars.StarsNumber);
                command.Parameters.AddWithValue("@Id", questionStars.Id);

                try
                {
                  
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Row updated successfully
                        MessageBox.Show("Row updated successfully.");
                    }
                    else
                    {
                        // Row not found or not updated
                        MessageBox.Show("No rows updated for Question");
                    }
                    base.CloseConnection();
                    base.update(questionStars);
                }
                catch (SqlException ex)
                {
                    // Handle any SQL errors
                    MessageBox.Show("Error updating row: " + ex.Message);
                }
                finally
                {
                    base.CloseConnection();
                }

            }
        }
    }
}
