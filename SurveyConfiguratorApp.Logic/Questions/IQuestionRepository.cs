using SurveyConfiguratorApp.Domain.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Logic.Questions
{
    public interface IQuestionRepository
    {
        List<Question> GetQuestions();
        void add(Question question);

    }
}
