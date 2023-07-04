using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Domain.Questions
{

    public class Question
    {


        public enum QuestionTypes
        {
            FACES = 1,
            SLIDER = 2,
            STARS = 3,

        }

        private int id;
        public string Text { get; set; }

        private int typeNumber;
        public string TypeName { get; set; }
        public int Order { get; set; }

        public Question() { }
        public Question(int id, string text, int type, int order)
        {
            Text = text;
            setTypeNumber(type);
            setId(id);
            Order = order;
            TypeName = ((QuestionTypes)typeNumber).ToString();

        }

        public void setId(int id)
        {
            this.id = id;
        }
        public int getId()
        {
            return this.id;
        }

        protected void setTypeNumber(int type)
        {
            typeNumber = type;
        }
        public int getTypeNumber()
        {
            return typeNumber;
        }

    }
}
