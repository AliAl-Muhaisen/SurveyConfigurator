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
        public QuestionStars() : base() {
            dbQuestionStars=new DbQuestionStars();
            TypeNumber = (int)QuestionTypes.STARS;
        }
        public override bool add()
        {
            return dbQuestionStars.create(this);
        }

        public override bool delete()
        {
            throw new NotImplementedException();
        }

        public override bool update()
        {
           return dbQuestionStars.update(this);
        }
    }
}
