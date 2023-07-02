using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Domain.Questions
{
    public class QuestionFaces : Question
    {

        public QuestionFaces() : base()
        {
            try
            {
                TypeNumber = (int)QuestionTypes.FACES;
            }
            catch (Exception e)
            {

            }


        }
        public int FacesNumber { get; set; }


    }
}
