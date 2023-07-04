using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
using System;

namespace SurveyConfiguratorApp.Logic.Questions.Faces
{
    public class QuestionFacesService : IQuestionFacesService
    {
        private readonly IQuestionFacesRepository iQuestionFacesRepository;

        public QuestionFacesService(IQuestionFacesRepository iQuestionFacesRepository)
        {
            try
            {
                this.iQuestionFacesRepository = iQuestionFacesRepository;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }

        }
        public bool add(QuestionFaces data)
        {
            try
            {
                return iQuestionFacesRepository.add(data);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return false;

        }

        public QuestionFaces Get(int id)
        {
            try
            {
                return iQuestionFacesRepository.Get(id);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return null;

        }

        public bool update(QuestionFaces data)
        {
            try
            {
                return iQuestionFacesRepository.update(data);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return false;

        }
    }
}
