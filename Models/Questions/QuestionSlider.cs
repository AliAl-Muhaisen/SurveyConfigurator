using SurveyConfiguratorApp.Database.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Models.Questions
{
    public class QuestionSlider : Question
    {
        private DbQuestionSlider dbQuestionSlider;
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public string MinCaption { get; set; }
        public string MaxCaption { get; set; }
        public QuestionSlider() : base()
        {
            dbQuestionSlider=new DbQuestionSlider();

            TypeNumber = (int)QuestionTypes.SLIDER;
        }
        public override void add()
        {
            dbQuestionSlider.create(this);

        }

        public override void delete()
        {
            throw new NotImplementedException();
        }

        public override void update()
        {
            throw new NotImplementedException();
        }
    }
}
