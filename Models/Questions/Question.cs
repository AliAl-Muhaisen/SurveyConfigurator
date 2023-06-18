using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Models.Questions
{
    public interface IQuestion
    {
         void add();
         void delete();
         void update();
    }

    public class Question:IQuestion
    {
       public enum QuestionTypes
        {
            FACES=1,
            SLIDER=2,
            STARS=3,
            
        }

        public int Id { get; private set; }
        public string Text { get; private set; }
        public string Type { get; private set; }
        public int Order { get; private set; }
       
        public Question() { }
        public Question(int id, string text, string type,int order)
        {
            Text = text; 
            Type = type;
            Id = id;
            Order= order;
        }

        public virtual void add()
        {
            throw new NotImplementedException();
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
