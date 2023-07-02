using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Logic.Questions.Stars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Logic.Questions.Stars
{
    public class QuestionStarsService : IQuestionStarsService
    {
        private readonly IQuestionStarsRepository iQuestionStarsRepository;

        public QuestionStarsService(IQuestionStarsRepository iQuestionStarsRepository)
        {
            this.iQuestionStarsRepository = iQuestionStarsRepository;
        }
        public bool add(QuestionStars data)
        {
            return iQuestionStarsRepository.add(data);
        }

        public QuestionStars Get(int id)
        {
            return iQuestionStarsRepository.Get(id);
        }

        public bool update(QuestionStars data)
        {
            return iQuestionStarsRepository.update(data);
        }
    }
}
