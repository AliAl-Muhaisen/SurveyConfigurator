using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
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
            try
            {
                this.iQuestionStarsRepository = iQuestionStarsRepository;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

        }
        public bool add(QuestionStars data)
        {
            try
            {
                return iQuestionStarsRepository.add(data);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return false;
        }

        public QuestionStars Get(int id)
        {
            try
            {
                return iQuestionStarsRepository.Get(id);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return null;
        }

        public bool update(QuestionStars data)
        {
            try
            {
                return iQuestionStarsRepository.update(data);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return false;
        }
    }
}
