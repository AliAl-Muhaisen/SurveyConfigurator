using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Domain.Questions
{
    public interface IQuestion<T>
    {
        bool add();
        bool delete();
        bool update();
    }

    public class Question 
    {

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

       public Question() { }
        public Question(int id, string text, int type, int order) : this()
        {
            Text = text;
            TypeNumber = type;
            Id = id;
            Order = order;

        }
       
    }
}
