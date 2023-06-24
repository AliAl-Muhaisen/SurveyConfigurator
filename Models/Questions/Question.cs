using SurveyConfiguratorApp.Database.Questions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.Models.Questions
{
    public interface IQuestion<T>
    {
        bool add();
        bool delete();
        bool update();
    }

    public class Question : IQuestion<Question>
    {
        private DbQuestion dbQuestion;

        public static List<Question> AllQuestions = new List<Question>();
        public enum QuestionTypes
        {
            FACES = 1,
            SLIDER = 2,
            STARS = 3,

        }

        public int Id { get; set; }
        public string Text { get; set; }
        public int TypeNumber { get; protected set; }
        public int Order { get; set; }

        public Question()
        {
            try
            {
                dbQuestion = new DbQuestion();
            }
            catch (Exception e)
            {
                handleExceptionLog(e);
            }

        }
        public Question(int id, string text, int type, int order) : this()
        {
            Text = text;
            TypeNumber = type;
            Id = id;
            Order = order;

        }

        public virtual bool add()
        {
            try
            {
                return dbQuestion.create(this);
            }
            catch (Exception e)
            {
                handleExceptionLog(e);

            }
            return false;

        }

        public virtual bool delete()
        {
            throw new NotImplementedException();
        }

        public virtual bool update()
        {
            try
            {
                return dbQuestion.update(this);
            }
            catch (Exception e)
            {
                handleExceptionLog(e);

            }
            return false;

        }

        protected void handleExceptionLog(Exception ex)
        {
            try
            {
                ErrorLoggerFile errorLoggerFile = new ErrorLoggerFile();
                errorLoggerFile.HandleException(ex);
            }
            catch
            {
            }
        }
    }
}
