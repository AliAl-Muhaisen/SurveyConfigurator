using SurveyConfiguratorApp.Domain.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Logic.Questions
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository questionRepository;

        public QuestionService(IQuestionRepository questionRepository) {
            this.questionRepository = questionRepository;
        }

        public void add(Question question)
        {
            questionRepository.add(question);
        }

        public List<Question> GetQuestions()
        {
            return questionRepository.GetQuestions();
        }
    }
}
