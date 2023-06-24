using SurveyConfiguratorApp.Database.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Models.Questions
{
    /// <summary>
    /// [Singleton Class] 
    /// 
    /// To Read more about Singleton https://www.c-sharpcorner.com/UploadFile/8911c4/singleton-design-pattern-in-C-Sharp/
    /// </summary>
    public class QuestionValidation
    {
        private static QuestionValidation _instance;
        private static readonly object _lock = new object();
        public int SliderMaxValue { get; private set; }
        public int SliderMinValue { get; private set; }
        public int StarsMaxValue { get; private set; }
        public int StarsMinValue { get; private set; }

        public int FacesMaxValue { get; private set; }
        public int FacesMinValue { get; private set; }

        const int questionTextLength = 100;
        const int sliderCaptionTextLength = 100;
      

        private QuestionValidation()
        {
            try
            {
  SliderMaxValue = 100;
            SliderMinValue = 0;
            

            StarsMaxValue = 10;
            StarsMinValue = 1;

            FacesMaxValue = 5;
            FacesMinValue = 2;
            }
            catch (Exception e)
            {
                handleExceptionLog(e);

            }
          
        }

        public static QuestionValidation Instance()
        {

            if (_instance == null)
            {
                lock (_lock)
                {
                    _instance = _instance ?? new QuestionValidation();
                }
            }

            return _instance;


        }

        //General Functions
        public bool isNotEmpty(string text)
        {
            return (text != null && text.Trim().Length > 0);
        }
        public bool isEmpty(string text)
        {
            return !isNotEmpty(text);
        }

        private bool isMinNum(int sourceNum, int comparedNum)
        {
            return comparedNum >= sourceNum;
        }
        private string generalMsgMinNum(int num)
        {
            return ("You can't enter number less than " + num);
        }

        private bool isMaxNum(int sourceNum, int comparedNum)
        {
            return comparedNum <= sourceNum;
        }

        private string generalMsgMaxNum(int num)
        {
            return ("You can't enter number greater than " + num);
        }

        public string handelQuestionText(string text)
        {
            if(isEmpty(text))
            {
                return "Required Field";
            }
            else if( text.Length > questionTextLength)
            {
                return "Maximum input length exceeded. Please enter a value that is within 100 character";
            }
            return null;

            
        }


        //End General Functions


        //?Stars Question Validation
        public string starsMinNumMsg(int minNumStars)
        {
            return !isMinNum(StarsMinValue, minNumStars) ? generalMsgMinNum(StarsMinValue) : null;
        }
        public string starsMaxNumMsg(int minNumStars)
        {
            return !isMaxNum(StarsMaxValue, minNumStars) ? generalMsgMaxNum(StarsMaxValue) : null;
        }

        public string starsHandleMsg(int num)
        {
            return starsMaxNumMsg(num) ?? starsMinNumMsg(num);
        }

        //!End Stars Question Validation

        //?Faces Question Validation

        public string facesMinNumMsg(int minNumStars)
        {
            return !isMinNum(FacesMinValue, minNumStars) ? generalMsgMinNum(FacesMinValue) : null;
        }
        public string facesMaxNumMsg(int minNumStars)
        {
            return !isMaxNum(FacesMaxValue, minNumStars) ? generalMsgMaxNum(FacesMaxValue) : null;
        }

        public string facesHandleMsg(int num)
        {
            return facesMaxNumMsg(num) ?? facesMinNumMsg(num);
        }

        //!End Faces Question Validation

        //# Slider Question Validation
        public string handelCaptionText(string text)
        {
            if (isEmpty(text))
            {
                return "Required Field";
            }
            else if (text.Length > sliderCaptionTextLength)
            {
                return "Maximum input length exceeded";
            }
            return null;


        }
        private bool isMinEqualMax(int min,int max)
        {
            return min == max;
        }
        //public string handleSliderMin(int numMin)
        //{
        //    if (!isMinEqualMax(numMin,numMa))
        //    return null;
        //}

        //! End Slider Question Validation


        public bool isOrderAlreadyExists(int order,int oldOrder=-1)
        {
            return DbQuestion.isOrderAlreadyExists(order, oldOrder);
        }
        private void handleExceptionLog(Exception ex)
        {
            try
            {
                ErrorLoggerFile errorLoggerFile = new ErrorLoggerFile();
                errorLoggerFile.HandleException(ex);
            }
            catch
            {
            }
        }
    }
}
