using SurveyConfiguratorApp.Database.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Models.Questions
{
    public class QuestionFaces : Question
    {

        private DbQuestionFaces dbQuestionFaces;
        public QuestionFaces() : base()
        {
            try
            {
                dbQuestionFaces = new DbQuestionFaces();
                TypeNumber = (int)QuestionTypes.FACES;
            }
            catch (Exception e)
            {
                handleExceptionLog(e);

            }


        }
        public int FacesNumber { get; set; }


        public override bool add()
        {
            try
            {
                return dbQuestionFaces.create(this);
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
                return dbQuestionFaces.update(this);
            }
            catch (Exception e)
            {
                handleExceptionLog(e);
            }
            return false;

        }

    }
}
