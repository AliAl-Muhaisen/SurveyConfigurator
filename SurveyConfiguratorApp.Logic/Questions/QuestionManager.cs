using SurveyConfiguratorApp.Data.Questions;
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

        public List<int> ValidationErrorList;

        const int RefreshDuration = 4000;
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
                questionValidation = new QuestionValidation();
                ValidationErrorList = new List<int>();


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


        public static int IsOrderAlreadyExists(int order, int questionId = -1)
        {
            try
            {


                for (int i = 0; i < questions.Count; i++)
                {

                    if (questions[i].Order == order && questions[i].getId() != questionId)
                    {

                        return StatusCode.VALIDATION_ERROR_ORDER_EXIST;
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }
            return StatusCode.SUCCESS;
        }
        public int IsQuestionExists(int questionId)
        {
            try
            {
                return dbQuestion.IsQuestionExists(questionId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                return StatusCode.ERROR;

            }
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
                       int tStatusCode = GetQuestions(ref list);

                       bool isChanged = !list.SequenceEqual<Question>(questions);
                       if (isChanged || firstCall||list.Count!=questions.Count)
                       {
                           questions.Clear();
                           questions = list;
                           firstCall = false;
                           OnDataChanged();

                       }
                       list.Clear();
                       Thread.Sleep(RefreshDuration);
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

        public int GetQuestions(ref List<Question> list)
        {
            try
            {
                return dbQuestion.GetQuestions(ref list);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
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
        public int Delete(int id)
        {
            try
            {
                return dbQuestion.Delete(id);

            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }
        }
        #region QuestionFaces
        public int AddQuestionFaces(QuestionFaces questionFaces)
        {
            ValidationErrorList.Clear();
            try
            {

                int tStatusCode = questionValidation.IsValidFacesQuestion(questionFaces);
                if (tStatusCode != StatusCode.SUCCESS)
                {
                    ValidationErrorList = questionValidation.ErorrValidationList;
                    return StatusCode.VALIDATION_ERROR;
                }

                return dbQuestionFaces.Add(questionFaces);

            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }
        }
        public int UpdateQuestionFaces(QuestionFaces questionFaces)
        {
            ValidationErrorList.Clear();

            try
            {
                int tStatusCode = questionValidation.IsValidFacesQuestion(questionFaces);
                if (tStatusCode != StatusCode.SUCCESS)
                {
                    ValidationErrorList = questionValidation.ErorrValidationList;
                    return StatusCode.VALIDATION_ERROR;
                }
                return dbQuestionFaces.Update(questionFaces);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }
        }

        public int GetQuestionFaces(ref QuestionFaces questionFaces)
        {
            try
            {
                return dbQuestionFaces.Get(ref questionFaces); ;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }

        }
        #endregion

        #region QuestionStars

        //Stars
        public int AddQuestionStars(QuestionStars questionStars)
        {
            try
            {
                ValidationErrorList.Clear();
                int tStatusCode = questionValidation.IsValidStarsQuestion(questionStars);

                if (tStatusCode != StatusCode.SUCCESS)
                {
                    ValidationErrorList = questionValidation.ErorrValidationList;
                    return StatusCode.VALIDATION_ERROR;
                }

                return dbQuestionStars.Add(questionStars);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }
        }
        public int UpdateQuestionStars(QuestionStars questionStars)
        {
            try
            {
                ValidationErrorList.Clear();

                int tStatusCode = questionValidation.IsValidStarsQuestion(questionStars);
                if (tStatusCode != StatusCode.SUCCESS)
                {
                    ValidationErrorList = questionValidation.ErorrValidationList;
                    return StatusCode.VALIDATION_ERROR;
                }


                return dbQuestionStars.Update(questionStars);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }
        }

        public int GetQuestionStars(ref QuestionStars questionStars)
        {
            try
            {
                return dbQuestionStars.Get(ref questionStars);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }
        }
        #endregion

        #region QuestionSlider
        //Slider
        public int AddQuestionSlider(QuestionSlider questionSlider)
        {
            try
            {
                ValidationErrorList.Clear();

                int tStatusCode = questionValidation.IsValidSliderQuestion(questionSlider);
                if (tStatusCode != StatusCode.SUCCESS)
                {
                    ValidationErrorList = questionValidation.ErorrValidationList;
                    return StatusCode.VALIDATION_ERROR;
                }

                return dbQuestionSlider.Add(questionSlider);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }

        }
        public int UpdateQuestionSlider(QuestionSlider questionSlider)
        {
            try
            {
                ValidationErrorList.Clear();

                int tStatusCode = questionValidation.IsValidSliderQuestion(questionSlider);
                if (tStatusCode != StatusCode.SUCCESS)
                {
                    ValidationErrorList = questionValidation.ErorrValidationList;
                    return StatusCode.VALIDATION_ERROR;
                }

                return dbQuestionSlider.Update(questionSlider);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }

        }

        public int GetQuestionSlider(ref QuestionSlider questionSlider)
        {
            try
            {
                return dbQuestionSlider.Get(ref questionSlider);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }
        }
        #endregion

    }

}
