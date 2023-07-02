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

        public bool add(Question question)
        {
           return questionRepository.add(question);
            
        }

        public bool delete(int id)
        {
           return questionRepository.delete(id);
        }

        public Question Get(int id)
        {
            return questionRepository.Get(id);
        }

        public List<Question> GetQuestions()
        {
            return questionRepository.GetQuestions();
        }

        public bool update(Question question)
        {
            return questionRepository.update(question);
        }
    }
}
