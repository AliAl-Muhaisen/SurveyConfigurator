using SurveyConfiguratorApp.Database.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Models.Questions
{
    public class QuestionStars : Question
    {
        private DbQuestionStars dbQuestionStars;
        public int StarsNumber { get; set; }
        public QuestionStars() : base()
        {

            try
            {
                dbQuestionStars = new DbQuestionStars();
                TypeNumber = (int)QuestionTypes.STARS;
            }
            catch (Exception e)
            {
                handleExceptionLog(e);
            }
        }
        public override bool add()
        {

            try
            {
                return dbQuestionStars.create(this);
            }
            catch (Exception e)
            {
                handleExceptionLog(e);

            }
            return false;
        }

        public override bool delete()
        {
            throw new NotImplementedException();
        }

        public override bool update()
        {

            try
            {
                return dbQuestionStars.update(this);
            }
            catch (Exception e)
            {
                handleExceptionLog(e);

            }
            return false;
        }
    }
}
