using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Models.Questions
{
    public class Question
    {
        public int Id { get; private set; }
        public string Text { get; private set; }
        public string Type { get; private set; }
        = string.Empty;
        public Question() { }
        public Question(int id, string text, string type)
        {
            Text = text; 
            Type = type;
            Id = id;
        }



    }
}
