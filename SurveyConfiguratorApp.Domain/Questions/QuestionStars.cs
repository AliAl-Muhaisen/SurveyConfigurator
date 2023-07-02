using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Domain.Questions
{
    public class QuestionStars : Question
    {
        public int StarsNumber { get; set; }
        public QuestionStars() : base()
        {

            try
            {
                TypeNumber = (int)QuestionTypes.STARS;
            }
            catch (Exception e)
            {
            }
        }
      
    }
}
