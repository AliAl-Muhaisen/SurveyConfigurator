using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Domain.Questions
{
    public class QuestionSlider : Question
    {
        public int StartValue { get; set; }
        public int EndValue { get; set; }
        public string StartCaption { get; set; }
        public string EndCaption { get; set; }
        public QuestionSlider() : base()
        {

            try
            {

                TypeNumber = (int)QuestionTypes.SLIDER;
            }
            catch (Exception e)
            {
            }
        }
     
    }
}
