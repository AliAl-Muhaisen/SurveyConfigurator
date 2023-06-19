using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Models.Questions
{
    public class QuestionSlider:Question
    {
        public QuestionSlider() : base() { }
        public override void add()
        {
           //base.add(question);

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
