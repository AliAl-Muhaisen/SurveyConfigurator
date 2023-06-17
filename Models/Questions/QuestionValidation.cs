using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Models.Questions
{
    /// <summary>
    /// [Singleton Class] 
    /// 
    /// To Read more Singleton https://www.c-sharpcorner.com/UploadFile/8911c4/singleton-design-pattern-in-C-Sharp/
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

       public bool isNotEmpty(string text)
        {
            return true && (text != null || text.Trim().Length > 0);
        }
        public bool isEmpty(string text)
        {
            return !isNotEmpty(text);
        }

        private QuestionValidation()
        {
            SliderMaxValue = 100;
            SliderMinValue = 0;
            

            StarsMaxValue = 10;
            StarsMinValue = 1;

            FacesMaxValue = 5;
            FacesMinValue = 2;
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




    }
}
