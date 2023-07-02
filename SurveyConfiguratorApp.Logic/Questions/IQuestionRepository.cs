﻿using SurveyConfiguratorApp.Domain.Questions;
using SurveyConfiguratorApp.Logic.Comman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Logic.Questions
{
    public interface IQuestionRepository: ICRUD<Question>
    {
        List<Question> GetQuestions();
        bool delete(int id);

    }
    
}