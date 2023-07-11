using SurveyConfiguratorApp.Data.Questions;
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
        public QuestionManager()
        {
            try
            {
                questions = new List<Question>();
                dbQuestion = new DbQuestion();
                dbQuestionFaces = new DbQuestionFaces();
                dbQuestionSlider = new DbQuestionSlider();
                dbQuestionStars = new DbQuestionStars();
                questions = dbQuestion.GetQuestions();
                // DbQuestion.DataChanged += DbQuestion_DataChanged;
                questionValidation = QuestionValidation.Instance();



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
                questions = dbQuestion.GetQuestions();

            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }


        public bool IsOrderAlreadyExists(int order, int oldOrder = -1)
        {
            try
            {
                return dbQuestion.IsOrderAlreadyExists(order, oldOrder);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return false;
        }

        public void FollowDbChanges()
        {
            try
            {
                //I used ThreadStart because the method does not take any parameters
                thread = new Thread(new ThreadStart(delegate
               {
                   while (true)
                   {
                       List<Question> list = new List<Question>();
                       list = GetQuestions();
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
        public List<Question> GetQuestions()
        {
            try
            {
                return dbQuestion.GetQuestions();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return null;
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

        public StatusCode AddQuestionFaces(QuestionFaces questionFaces)
        {
            try
            {
                if (!questionValidation.IsValidFacesQuestion(questionFaces))
                    return StatusCode.ValidationError;
                StatusCode isAdded = dbQuestionFaces.Add(questionFaces);


                return isAdded;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.Error;
            }
        }
        public StatusCode UpdateQuestionFaces(QuestionFaces questionFaces)
        {
            try
            {

                if (!questionValidation.IsValidFacesQuestion(questionFaces, true))
                    return StatusCode.ValidationError;
               
                return dbQuestionFaces.Update(questionFaces);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.Error;
            }
        }

        public QuestionFaces GetQuestionFaces(int id)
        {
            try
            {
                return dbQuestionFaces.Get(id);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return null;
        }

        //Stars
        public StatusCode AddQuestionStars(QuestionStars questionStars)
        {
            try
            {
                if (!questionValidation.IsValidStarsQuestion(questionStars))
                    return StatusCode.ValidationError;
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
                if (!questionValidation.IsValidStarsQuestion(questionStars, true))
                    return StatusCode.ValidationError;
                return dbQuestionStars.Update(questionStars);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.Error;
            }
        }

        public QuestionStars GetQuestionStars(int id)
        {
            try
            {
                return dbQuestionStars.Get(id);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return null;
        }

        //Slider
        public StatusCode AddQuestionSlider(QuestionSlider questionSlider)
        {
            try
            {
                if (!questionValidation.IsValidSliderQuestion(questionSlider))
                    return StatusCode.ValidationError;
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
                if (!questionValidation.IsValidSliderQuestion(questionSlider, true))
                    return StatusCode.ValidationError;
                return dbQuestionSlider.Update(questionSlider);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.Error;
            }

        }

        public QuestionSlider GetQuestionSlider(int id)
        {
            try
            {
                return dbQuestionSlider.Get(id);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return null;
        }

    }

}
