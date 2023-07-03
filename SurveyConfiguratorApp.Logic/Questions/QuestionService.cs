﻿using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
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
        public static List<Question> questionsList = new List<Question>();
        public QuestionService(IQuestionRepository questionRepository)
        {

            try
            {
                this.questionRepository = questionRepository;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public bool add(Question question)
        {

            try
            {
                return questionRepository.add(question);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return false;
        }

        public bool delete(int id)
        {

            try
            {
                return questionRepository.delete(id);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return false;
        }

        public Question Get(int id)
        {

            try
            {
                return questionRepository.Get(id);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return null;
        }

        public List<Question> GetQuestions()
        {

            try
            {
                return questionRepository.GetQuestions();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return new List<Question>();
        }

        public bool update(Question question)
        {

            try
            {
                return questionRepository.update(question);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return false;
        }

        public bool deleteByOrder(int order)
        {

            try
            {
                return questionRepository.deleteByOrder(order);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return false;
        }
        public bool isOrderAlreadyExists(int order)
        {

            try
            {
                return questionRepository.isOrderAlreadyExists(order);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return false;
        }
    }
}
