using SurveyConfiguratorApp.Domain.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Logic.Questions.Faces
{
    public class QuestionStarsService : IQuestionFacesService
    {
        private readonly IQuestionFacesRepository iQuestionFacesRepository;

        public QuestionStarsService(IQuestionFacesRepository iQuestionFacesRepository)
        {
            this.iQuestionFacesRepository = iQuestionFacesRepository;
        }
        public bool add(QuestionFaces data)
        {
            return iQuestionFacesRepository.add(data);
        }

        public QuestionFaces Get(int id)
        {
            return iQuestionFacesRepository.Get(id);
        }

        public bool update(QuestionFaces data)
        {
            return iQuestionFacesRepository.update(data);
        }
    }
}
