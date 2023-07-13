using SurveyConfiguratorApp.Helper;
using System;
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

        public Question() {
            setId(-1);

        }
        public Question(int id, string text, int type, int order)
        {
            try
            {
                Text = text;
                setTypeNumber(type);
                setId(id);
                Order = order;
                TypeName = ((QuestionTypes)typeNumber).ToString();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }


        }

        public void setId(int id)
        {
            try
            {
                this.id = id;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

        }
        public int getId()
        {
            try
            {
                return this.id;

            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return 0;

        }

        protected void setTypeNumber(int type)
        {
            try
            {
                typeNumber = type;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

        }
        public int getTypeNumber()
        {
            try
            {
                return typeNumber;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return 0;

        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Question otherQuestion = (Question)obj;

            // Compare all relevant properties for equality
            return Text == otherQuestion.Text &&
                   Order == otherQuestion.Order &&
                   TypeName == otherQuestion.TypeName;
        }

        ///  <summary>
        /// The GetHashCode method should be overridden consistently with the Equals method.
        /// The GetHashCode method should be overridden consistently with the Equals method. 
        /// That means if two objects are considered equal based on their property values in the Equals method, 
        /// they should have the same hash code in the GetHashCode method
        /// </summary>

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
