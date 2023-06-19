using SurveyConfiguratorApp.Database.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Models.Questions
{
    public interface IQuestion<T>
    {
         void add();
         void delete();
         void update();
    }

    public class Question:IQuestion<Question>
    {
        private DbQuestion dbQuestion;

        public static List<Question> AllQuestions = new List<Question>();
       public enum QuestionTypes
        {
            FACES=1,
            SLIDER=2,
            STARS=3,
            
        }

        public int Id { get;  set; }
        public string Text { get;  set; }
        public int TypeNumber { get;  set; }
        public int Order { get;  set; }
       
        public Question() {
            dbQuestion = new DbQuestion();
        }
        public Question(int id, string text, int type,int order):this()
        {
            Text = text;
            TypeNumber = type;
            Id = id;
            Order= order;
         
        }

        public virtual void add()
        {
            dbQuestion.create(this);
        }

        public virtual void delete()
        {
            throw new NotImplementedException();
        }

        public virtual void update()
        {
            throw new NotImplementedException();
        }
    }
}
