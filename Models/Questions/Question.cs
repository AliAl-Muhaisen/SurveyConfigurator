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
       
        public int? Id { get; private set; }
        public string Text { get; private set; }
        public string Type { get; private set; }
       
        public Question() { }
        public Question(int id, string text, string type)
        {
            Text = text; 
            Type = type;
            Id = id;
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
