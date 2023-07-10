using Microsoft.Extensions.DependencyInjection;
using SurveyConfiguratorApp.Data.Questions;
using SurveyConfiguratorApp.Helper;
using SurveyConfiguratorApp.Logic;
using SurveyConfiguratorApp.Logic.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Domain.Questions
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

        const int questionTextLength = 1500;
        const int sliderCaptionTextLengthMax = 500;
        const int sliderCaptionTextLengthMin = 3;


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
                Log.Error(e);

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
        public bool IsNotEmpty(string text)
        {
            return (text != null && text.Trim().Length > 0);
        }
        public bool IsEmpty(string text)
        {
            return !IsNotEmpty(text);
        }

        private bool IsMinNum(int sourceNum, int comparedNum)
        {
            return comparedNum >= sourceNum;
        }
        private string GeneralMsgMinNum(int num)
        {
            return ("You can't enter number less than " + num);
        }

        private bool isMaxNum(int sourceNum, int comparedNum)
        {
            try
            {
                return comparedNum <= sourceNum;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }

        }

        private string GeneralMsgMaxNum(int num)
        {
            try
            {
                return ("You can't enter number greater than " + num);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return null;
            }

        }

        private bool IsValidQuestionText(string text)
        {
            try
            {
                return text.Trim().Length > 0 && text.Trim().Length <= questionTextLength;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }
        }
        public string HandelQuestionText(string text)
        {
            try
            {
                if (IsEmpty(text))
                {
                    return "Required Field";
                }
                else if (text.Trim().Length > questionTextLength)
                {
                    return $"Maximum input length exceeded. Please enter a value that is within {questionTextLength} character";
                }
                else if (text.Trim().Length < 10)
                {
                    return "Too Short";
                }
                return null;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return null;
            }



        }


        //End General Functions


        //?Stars Question Validation
        public string starsMinNumMsg(int minNumStars)
        {
            return !IsMinNum(StarsMinValue, minNumStars) ? GeneralMsgMinNum(StarsMinValue) : null;
        }
        public string starsMaxNumMsg(int minNumStars)
        {
            return !isMaxNum(StarsMaxValue, minNumStars) ? GeneralMsgMaxNum(StarsMaxValue) : null;
        }

        public string starsHandleMsg(int num)
        {
            return starsMaxNumMsg(num) ?? starsMinNumMsg(num);
        }

        //!End Stars Question Validation

        //?Faces Question Validation

        public string facesMinNumMsg(int minNumStars)
        {
            return !IsMinNum(FacesMinValue, minNumStars) ? GeneralMsgMinNum(FacesMinValue) : null;
        }
        public string facesMaxNumMsg(int minNumStars)
        {
            return !isMaxNum(FacesMaxValue, minNumStars) ? GeneralMsgMaxNum(FacesMaxValue) : null;
        }

        public string facesHandleMsg(int num)
        {
            return facesMaxNumMsg(num) ?? facesMinNumMsg(num);
        }

        //!End Faces Question Validation

        //# Slider Question Validation
        public string handelCaptionText(string text)
        {
            if (IsEmpty(text))
            {
                return "Required Field";
            }
            else if (text.Trim().Length > sliderCaptionTextLengthMax)
            {
                return "Too Long";
            }
            else if (text.Trim().Length < sliderCaptionTextLengthMin)
            {
                return "Too Short";
            }
            return null;


        }

        //! End Slider Question Validation


        public bool IsOrderAlreadyExists(int order, int oldOrder = -1)
        {
            try
            {
                QuestionManager questionManager = new QuestionManager();
                return questionManager.IsOrderAlreadyExists(order, oldOrder);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return false;

        }

        private bool IsValidFacesNumber(int facesNumber)
        {
            try
            {
                return facesNumber >= FacesMinValue && facesNumber <= FacesMaxValue;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }
        }
        public bool IsValidFacesQuestion(QuestionFaces questionFaces, bool isUpdate = false)
        {
            try
            {
                bool isOrderExists;
                if (questionFaces == null) return false;

                if (isUpdate)
                    isOrderExists = !IsOrderAlreadyExists(questionFaces.Order, questionFaces.Order);
                else
                    isOrderExists = !IsOrderAlreadyExists(questionFaces.Order);

                return IsValidQuestionText(questionFaces.Text) &&
                   isOrderExists &&
                    IsValidFacesNumber(questionFaces.FacesNumber);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }
        }

        private bool IsValidStarsNumber(int starsNumber)
        {
            try
            {
                return starsNumber >= StarsMinValue && starsNumber <= StarsMaxValue;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }
        }

        public bool IsValidStarsQuestion(QuestionStars questionStars, bool isUpdate = false)
        {
            try
            {

                if (questionStars == null) return false;
                bool isOrderExists;
                if (isUpdate)
                    isOrderExists = !IsOrderAlreadyExists(questionStars.Order, questionStars.Order);
                else
                    isOrderExists = !IsOrderAlreadyExists(questionStars.Order);

                return IsValidQuestionText(questionStars.Text) &&
                         isOrderExists &&
                    IsValidStarsNumber(questionStars.StarsNumber);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }
        }

        private bool IsValidSliderStartValue(int value)
        {
            try
            {
                return value >= SliderMinValue && value < SliderMaxValue;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }
        }
        private bool IsValidSliderEndtValue(int value)
        {
            try
            {
                return (value > SliderMinValue && (value <= SliderMaxValue));
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }
        }
        private bool IsValidSilderValue(int min, int max)
        {
            try
            {
                return IsValidSliderStartValue(min) && IsValidSliderEndtValue(max) && min < max;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }
        }
        private bool IsValidCaption(string caption)
        {
            try
            {
                return caption.Trim().Length >= sliderCaptionTextLengthMin && caption.Trim().Length <= sliderCaptionTextLengthMax;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }
        }
        public bool IsValidSliderQuestion(QuestionSlider questionSlider, bool isUpdate = false)
        {
            try
            {
                if (questionSlider == null) return false;

                bool isOrderExists;
                if (isUpdate)
                    isOrderExists = !IsOrderAlreadyExists(questionSlider.Order, questionSlider.Order);
                else
                    isOrderExists = !IsOrderAlreadyExists(questionSlider.Order);

                return IsValidQuestionText(questionSlider.Text) &&
                    isOrderExists &&
                    IsValidSilderValue(questionSlider.StartValue, questionSlider.EndValue) &&
                    IsValidCaption(questionSlider.StartCaption) &&
                    IsValidCaption(questionSlider.EndCaption);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return false;
            }
        }
    }
}
