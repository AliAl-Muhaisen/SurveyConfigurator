using SurveyConfiguratorApp.Helper;
using System;

namespace SurveyConfiguratorApp.Domain.Questions
{
    public class QuestionStars : Question
    {
        public int StarsNumber { get; set; }
        public QuestionStars() : base()
        {

            try
            {
                SetTypeNumber((int)QuestionTypes.STARS);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

    }
}
