﻿using SurveyConfiguratorApp.Database.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Models.Questions
{
    public class QuestionSlider : Question
    {
        private DbQuestionSlider dbQuestionSlider;
        public int StartValue { get; set; }
        public int EndValue { get; set; }
        public string StartCaption { get; set; }
        public string EndCaption { get; set; }
        public QuestionSlider() : base()
        {
            dbQuestionSlider=new DbQuestionSlider();

            TypeNumber = (int)QuestionTypes.SLIDER;
        }
        public override bool add()
        {
            return dbQuestionSlider.create(this);

        }

        public override bool delete()
        {
            throw new NotImplementedException();
        }

        public override bool update()
        {
           return dbQuestionSlider.update(this);
        }
    }
}
