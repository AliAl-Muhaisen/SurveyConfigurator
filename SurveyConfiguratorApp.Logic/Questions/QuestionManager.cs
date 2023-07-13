﻿using SurveyConfiguratorApp.Data.Questions;
using SurveyConfiguratorApp.Domain;
using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Logic
{
    public class QuestionManager
    {
        private DbQuestion dbQuestion;
        private DbQuestionFaces dbQuestionFaces;
        private DbQuestionSlider dbQuestionSlider;
        private DbQuestionStars dbQuestionStars;

        QuestionValidation questionValidation;

        private static List<Question> questions = new List<Question>();
        private static bool firstCall = true;
        public event EventHandler DataChangedUI;

        private Thread thread;

       public List<StatusCode> ValidationErrorList;

        public QuestionManager()
        {
            try
            {
                questions = new List<Question>();
                dbQuestion = new DbQuestion();
                dbQuestionFaces = new DbQuestionFaces();
                dbQuestionSlider = new DbQuestionSlider();
                dbQuestionStars = new DbQuestionStars();
                dbQuestion.GetQuestions(ref questions);
                // DbQuestion.DataChanged += DbQuestion_DataChanged;
                questionValidation =new QuestionValidation();
                ValidationErrorList = new List<StatusCode>();


            }
            catch (Exception e)
            {
                Log.Error(e);
            }

        }

        protected void OnDataChanged()
        {
            try
            {
                DataChangedUI?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }


        }

        private void DbQuestion_DataChanged(object sender, EventArgs e)
        {
            try
            {
                dbQuestion.GetQuestions(ref questions);

            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }


        public static StatusCode IsOrderAlreadyExists(int order, int questionId = -1)
        {
            try
            {
                for (int i = 0; i < questions.Count; i++)
                {
                    if (questions[i].Order == order && questions[i].getId() != questionId) { return StatusCode.ValidationErrorQuestionOrder; }
                }

            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.Error;
            }
            return StatusCode.Success;
        }
        public StatusCode IsQuestionExists(int questionId)
        {
            try
            {
                return dbQuestion.IsQuestionExists(questionId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return StatusCode.Error;

            }
        }
        public void FollowDbChanges()
        {
            try
            {
                //I used ThreadStart because the method does not take any parameters
                List<Question> list = new List<Question>();
                thread = new Thread(new ThreadStart(delegate
               {
                   while (true)
                   {

                       StatusCode tStatusCode = GetQuestions(ref list);
                       if (!list.SequenceEqual(questions) || firstCall)
                       {
                           questions = list;
                           OnDataChanged();
                           firstCall = false;

                       }
                       Thread.Sleep(4000);
                   }

               }));


                thread.IsBackground = true;
                thread.Start();
                // Wait for the background thread to complete
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
        public StatusCode GetQuestions(ref List<Question> list)
        {
            try
            {
                return dbQuestion.GetQuestions(ref list);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.Error;
            }
        }

        public Question GetQuestion(int id)
        {
            try
            {
                return dbQuestion.Get(id);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return null;
        }
        public static List<int> Orders
        {
            get
            {
                try
                {
                    List<int> list = new List<int>();
                    for (int i = 0; i < questions.Count; i++)
                    {
                        list.Add(questions[i].Order);
                    }
                    return list;
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
                return null;
            }
        }
        public StatusCode Delete(int id)
        {
            try
            {
                return dbQuestion.Delete(id);

            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.Error;
            }
        }
        #region QuestionFaces
        public StatusCode AddQuestionFaces(QuestionFaces questionFaces)
        {
            ValidationErrorList.Clear();
            try
            {

                StatusCode tStatusCode = questionValidation.IsValidFacesQuestion(questionFaces);
                if (tStatusCode.Code != StatusCode.Success.Code)
                {
                    ValidationErrorList = questionValidation.ErorrValidationList;
                    return StatusCode.ValidationError;
                }

            return dbQuestionFaces.Add(questionFaces);
                 
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.Error;
            }
        }
        public StatusCode UpdateQuestionFaces(QuestionFaces questionFaces)
        {
            ValidationErrorList.Clear();

            try
            {
                StatusCode tStatusCode = questionValidation.IsValidFacesQuestion(questionFaces);
                if (tStatusCode.Code != StatusCode.Success.Code)
                {
                    ValidationErrorList = questionValidation.ErorrValidationList;
                    return StatusCode.ValidationError;
                }
             return dbQuestionFaces.Update(questionFaces);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.Error;
            }
        }

        public StatusCode GetQuestionFaces(ref QuestionFaces questionFaces)
        {
            try
            {
                return dbQuestionFaces.Get(ref questionFaces); ;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.Error;
            }

        }
        #endregion

        #region QuestionStars

        //Stars
        public StatusCode AddQuestionStars(QuestionStars questionStars)
        {
            try
            {
                ValidationErrorList.Clear();
                StatusCode tStatusCode = questionValidation.IsValidStarsQuestion(questionStars);

                if (tStatusCode.Code != StatusCode.Success.Code)
                {
                    ValidationErrorList = questionValidation.ErorrValidationList;
                    return StatusCode.ValidationError;
                }

                return dbQuestionStars.Add(questionStars);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.Error;
            }
        }
        public StatusCode UpdateQuestionStars(QuestionStars questionStars)
        {
            try
            {
                ValidationErrorList.Clear();

                StatusCode tStatusCode = questionValidation.IsValidStarsQuestion(questionStars);
                if (tStatusCode.Code != StatusCode.Success.Code)
                {
                    ValidationErrorList = questionValidation.ErorrValidationList;
                    return StatusCode.ValidationError;
                }


                return dbQuestionStars.Update(questionStars);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.Error;
            }
        }

        public StatusCode GetQuestionStars(ref QuestionStars questionStars)
        {
            try
            {
                return dbQuestionStars.Get(ref questionStars);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.Error;
            }
        }
        #endregion

        #region QuestionSlider
        //Slider
        public StatusCode AddQuestionSlider(QuestionSlider questionSlider)
        {
            try
            {
                ValidationErrorList.Clear();

                StatusCode tStatusCode = questionValidation.IsValidSliderQuestion(questionSlider);
                if (tStatusCode.Code != StatusCode.Success.Code)
                {
                    ValidationErrorList = questionValidation.ErorrValidationList;
                    return StatusCode.ValidationError;
                }

                return dbQuestionSlider.Add(questionSlider);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.Error;
            }

        }
        public StatusCode UpdateQuestionSlider(QuestionSlider questionSlider)
        {
            try
            {
                ValidationErrorList.Clear();

                StatusCode tStatusCode = questionValidation.IsValidSliderQuestion(questionSlider);
                if (tStatusCode.Code != StatusCode.Success.Code)
                {
                    ValidationErrorList = questionValidation.ErorrValidationList;
                    return StatusCode.ValidationError;
                }

                return dbQuestionSlider.Update(questionSlider);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.Error;
            }

        }

        public StatusCode GetQuestionSlider(ref QuestionSlider questionSlider)
        {
            try
            {
                return dbQuestionSlider.Get(ref questionSlider);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.Error;
            }
        }
        #endregion

    }

}
