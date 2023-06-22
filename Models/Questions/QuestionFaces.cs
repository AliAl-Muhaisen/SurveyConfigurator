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
        public QuestionFaces():base() {
            dbQuestionFaces=new DbQuestionFaces();
            TypeNumber = (int)QuestionTypes.FACES;

        }
        public int FacesNumber { get; set; }


        public override bool add()
        {
           return dbQuestionFaces.create(this);
        }

        public override bool delete()
        {
            throw new NotImplementedException();
        }

        public override bool update()
        {
            return dbQuestionFaces.update(this);
        }
       
    }
}
