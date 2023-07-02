using SurveyConfiguratorApp.Domain.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Logic.Questions.Slider
{
    public class QuestionSliderService : IQuestionSliderService
    {
        private readonly IQuestionSliderRepository iQuestionSliderRepository;

        public QuestionSliderService(IQuestionSliderRepository iQuestionSliderRepository)
        {
            this.iQuestionSliderRepository = iQuestionSliderRepository;
        }
        public bool add(QuestionSlider data)
        {
            return iQuestionSliderRepository.add(data);
        }

        public QuestionSlider Get(int id)
        {
            return iQuestionSliderRepository.Get(id);
        }

        public bool update(QuestionSlider data)
        {
            return iQuestionSliderRepository.update(data);
        }
    }
}
