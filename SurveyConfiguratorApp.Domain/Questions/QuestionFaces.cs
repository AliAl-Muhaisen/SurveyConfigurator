﻿using SurveyConfiguratorApp.Helper;
using System;

namespace SurveyConfiguratorApp.Domain.Questions
{
    public class QuestionFaces : Question
    {

        public QuestionFaces() : base()
        {
            try
            {
                setTypeNumber((int)QuestionTypes.FACES);

            }
            catch (Exception e)
            {
                Log.Error(e);
            }


        }
        public int FacesNumber { get; set; }


    }
}
