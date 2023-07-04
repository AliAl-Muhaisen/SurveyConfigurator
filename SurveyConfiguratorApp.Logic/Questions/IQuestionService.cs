using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Logic.Comman;
using System.Collections.Generic;

namespace SurveyConfiguratorApp.Logic.Questions
{
    public interface IQuestionService : ICRUD<Question>
    {
        List<Question> GetQuestions();
        bool delete(int id);
        bool deleteByOrder(int order);

        bool isOrderAlreadyExists(int order);
        void refresh();
    }
}
