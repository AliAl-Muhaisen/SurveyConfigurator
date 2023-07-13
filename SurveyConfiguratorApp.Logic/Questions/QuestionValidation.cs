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
        public int SliderMaxValue { get; private set; }
        public int SliderMinValue { get; private set; }
        public int StarsMaxValue { get; private set; }
        public int StarsMinValue { get; private set; }

        public int FacesMaxValue { get; private set; }
        public int FacesMinValue { get; private set; }

        const int questionTextLength = 1500;
        const int sliderCaptionTextLengthMax = 500;
        const int sliderCaptionTextLengthMin = 3;
        public List<int> ErorrValidationList;

        public QuestionValidation()
        {
            try
            {
                SliderMaxValue = 100;
                SliderMinValue = 0;


                StarsMaxValue = 10;
                StarsMinValue = 1;

                FacesMaxValue = 5;
                FacesMinValue = 2;
                ErorrValidationList = new List<int>();
            }
            catch (Exception e)
            {
                Log.Error(e);

            }

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

        private int IsValidQuestionText(string text)
        {
            try
            {
                return (text.Trim().Length > 0 && text.Trim().Length <= questionTextLength) ? StatusCode.SUCCESS : StatusCode.VALIDATION_ERROR_QUESTION_TEXT;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
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

        public int IsOrderAlreadyExists(int order, int questionId)
        {
            try
            {
                return QuestionManager.IsOrderAlreadyExists(order, questionId);
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }
        }

        #region Faces
        private int IsValidFacesNumber(int facesNumber)
        {
            try
            {
                return (facesNumber >= FacesMinValue && facesNumber <= FacesMaxValue) ? StatusCode.SUCCESS : StatusCode.VALIDATION_ERROR_FACES_NUMBER;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }
        }
        public int IsValidFacesQuestion(QuestionFaces questionFaces)
        {

            try
            {
                ErorrValidationList.Clear();

                int isOrderExists;
                if (questionFaces == null)
                {
                    return StatusCode.DB_RECORD_NOT_EXISTS; ;
                }


                isOrderExists = IsOrderAlreadyExists(questionFaces.Order, questionFaces.getId());

                ErorrValidationList.Add(isOrderExists);
                ErorrValidationList.Add(IsValidQuestionText(questionFaces.Text));
                ErorrValidationList.Add(IsValidFacesNumber(questionFaces.FacesNumber));
                ClearSuccessState(ref ErorrValidationList);
                if (ErorrValidationList.Count != 0) return StatusCode.VALIDATION_ERROR;

                return StatusCode.SUCCESS;

            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }
        }
        #endregion
        #region Stars
        private int IsValidStarsNumber(int starsNumber)
        {
            try
            {
                return (starsNumber >= StarsMinValue && starsNumber <= StarsMaxValue) ? StatusCode.SUCCESS : StatusCode.VALIDATION_ERROR_STARS_NUMBER;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }
        }

        public int IsValidStarsQuestion(QuestionStars questionStars)
        {
            try
            {
                ErorrValidationList.Clear();
                int isOrderExists;
                if (questionStars == null)
                {
                    return StatusCode.DB_RECORD_NOT_EXISTS; ;
                }

                isOrderExists = IsOrderAlreadyExists(questionStars.Order, questionStars.getId());
                ErorrValidationList.Add(isOrderExists);
                ErorrValidationList.Add(IsValidQuestionText(questionStars.Text));
                ErorrValidationList.Add(IsValidStarsNumber(questionStars.StarsNumber));
                ClearSuccessState(ref ErorrValidationList);
                if (ErorrValidationList.Count != 0)
                    return StatusCode.VALIDATION_ERROR;

                return StatusCode.SUCCESS;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }
        }

        #endregion

        #region Slider
        private int IsValidSliderStartValue(int value)
        {
            try
            {
                return (value >= SliderMinValue && value < SliderMaxValue) ? StatusCode.SUCCESS : StatusCode.VALIDATION_ERROR_SLIDER_START_VALUE;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }
        }
        private int IsValidSliderEndtValue(int value)
        {
            try
            {
                return (value > SliderMinValue && (value <= SliderMaxValue)) ? StatusCode.SUCCESS : StatusCode.VALIDATION_ERROR_SLIDER_END_VALUE;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }
        }
        private int IsValidSilderValue(int min, int max)
        {
            try
            {
                int tStartValueCode = IsValidSliderStartValue(min);
                int tEndValueCode = IsValidSliderEndtValue(max);
                if (tStartValueCode == StatusCode.SUCCESS && tEndValueCode == StatusCode.SUCCESS)
                {
                    return (min < max) ? StatusCode.SUCCESS : StatusCode.VALIDATION_ERROR_SLIDER_VALUE;
                }
                return StatusCode.VALIDATION_ERROR_SLIDER_VALUE;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }
        }
        private int IsValidCaption(string caption)
        {
            try
            {
                return (caption.Trim().Length >= sliderCaptionTextLengthMin && caption.Trim().Length <= sliderCaptionTextLengthMax) ? StatusCode.SUCCESS : StatusCode.VALIDATION_ERROR_SLIDER_CAPTION;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }
        }
        public int IsValidSliderQuestion(QuestionSlider questionSlider)
        {
            try
            {
                ErorrValidationList.Clear();
                int isOrderExists;
                if (questionSlider == null)
                {
                    return StatusCode.DB_RECORD_NOT_EXISTS;
                }

                isOrderExists = IsOrderAlreadyExists(questionSlider.Order, questionSlider.getId());
                ErorrValidationList.Add(isOrderExists);
                ErorrValidationList.Add(IsValidQuestionText(questionSlider.Text));
                ErorrValidationList.Add(IsValidSilderValue(questionSlider.StartValue, questionSlider.EndValue));
                ErorrValidationList.Add(IsValidCaption(questionSlider.EndCaption));
                ClearSuccessState(ref ErorrValidationList);
                if (ErorrValidationList.Count != 0)
                    return StatusCode.VALIDATION_ERROR;

                return StatusCode.SUCCESS;
            }
            catch (Exception e)
            {
                Log.Error(e);
                return StatusCode.ERROR;
            }
        }

        #endregion

        void ClearSuccessState(ref List<int> list)
        {
            try
            {
                list = list.Distinct<int>().ToList();

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] == StatusCode.SUCCESS)
                    {
                        list.RemoveAt(i);
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

    }
}
