using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
using System;

namespace SurveyConfiguratorApp.Logic.Questions.Slider
{
    public class QuestionSliderService : IQuestionSliderService
    {
        private readonly IQuestionSliderRepository iQuestionSliderRepository;

        public QuestionSliderService(IQuestionSliderRepository iQuestionSliderRepository)
        {
            try
            {
                this.iQuestionSliderRepository = iQuestionSliderRepository;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

        }
        public bool add(QuestionSlider data)
        {
            try
            {
                return iQuestionSliderRepository.add(data);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return false;
        }

        public QuestionSlider Get(int id)
        {
            try
            {
                return iQuestionSliderRepository.Get(id);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return null;
        }

        public bool update(QuestionSlider data)
        {
            try
            {
                return iQuestionSliderRepository.update(data);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return false;
        }
    }
}
