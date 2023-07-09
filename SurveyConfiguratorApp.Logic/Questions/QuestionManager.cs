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

        public static List<Question> questions = new List<Question>();

        public event EventHandler DataChangedUI;

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

                FollowDbChanges();


            }
            catch (Exception e)
            {
                Log.Error(e);
            }

        }

        protected virtual void OnDataChanged()
        {
            DataChangedUI?.Invoke(this, EventArgs.Empty);
        }

        private void DbQuestion_DataChanged(object sender, EventArgs e)
        {
            questions = dbQuestion.GetQuestions();
        }

        //private void DbQuestion_DataChanged(object sender, DataChangedEventArgs e)
        //{
        //    // Handle the data change event here
        //    // Update the questions list and perform any necessary actions
        //}
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
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    List<Question> list = new List<Question>();
                    list = GetQuestions();
                    if (!list.SequenceEqual(questions))
                    {
                        questions = list;
                        OnDataChanged();

                    }
                    Thread.Sleep(4000);

                }

            });


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
    public bool Delete(int id)
    {
        try
        {
            return dbQuestion.Delete(id);
        }
        catch (Exception e)
        {
            Log.Error(e);
        }
        return false;
    }

    public bool AddQuestionFaces(QuestionFaces questionFaces)
    {
        try
        {
            bool isAdded = dbQuestionFaces.Add(questionFaces);
            if (isAdded)
            {
                // After adding the question, retrieve the updated questions
                questions = dbQuestion.GetQuestions();
            }

            return isAdded;
        }
        catch (Exception e)
        {
            Log.Error(e);
        }
        return false;
    }
    public bool UpdateQuestionFaces(QuestionFaces questionFaces)
    {
        try
        {
            return dbQuestionFaces.Update(questionFaces);
        }
        catch (Exception e)
        {
            Log.Error(e);
        }
        return false;
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
    public bool AddQuestionStars(QuestionStars questionStars)
    {
        try
        {
            return dbQuestionStars.Add(questionStars);
        }
        catch (Exception e)
        {
            Log.Error(e);
        }
        return false;
    }
    public bool UpdateQuestionStars(QuestionStars questionStars)
    {
        try
        {
            return dbQuestionStars.Update(questionStars);
        }
        catch (Exception e)
        {
            Log.Error(e);
        }
        return false;
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
    public bool AddQuestionSlider(QuestionSlider questionSlider)
    {
        try
        {
            return dbQuestionSlider.Add(questionSlider);
        }
        catch (Exception e)
        {
            Log.Error(e);
        }
        return false;
    }
    public bool UpdateQuestionSlider(QuestionSlider questionSlider)
    {
        try
        {
            return dbQuestionSlider.Update(questionSlider);
        }
        catch (Exception e)
        {
            Log.Error(e);
        }
        return false;
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
