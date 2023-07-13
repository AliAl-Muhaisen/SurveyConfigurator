﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Domain
{
    public class ErrorCode
    {
        #region Common
        public const int SUCCESS = 0;
        public const int VALIDATION_ERROR = -2;
        public const int ERROR = -1;
        #endregion

        #region Data Base
        public const int DB_FAILED_CONNECTION = -3;
        public const int DB_FAILED_NERORK_CONNECTION = -4;
        public const int DB_RECORD_NOT_EXISTS = -5;
        public const int DB_CONNECTION_SUCCESSFULLY = 2;
        public const int DB_FAILED_DELETE_ERROR = -6;
        #endregion

        #region Validation
        public const int VALIDATION_ERROR_QUESTION_TEXT = -20;
        public const int VALIDATION_ERROR_REQUIRED_VALUE = -24;
        public const int VALIDATION_ERROR_ORDER_EXIST = -21;
        public const int VALIDATION_ERROR_SHORT_TEXT = -22;
        public const int VALIDATION_ERROR_LONG_TEXT = -23;

        #region Validation Faces

        public const int VALIDATION_ERROR_FACES_NUMBER = -30;

        #endregion

        #region Validation Stars

        public const int VALIDATION_ERROR_STARS_NUMBER = -43;

        #endregion
        #region Validation Slider
        public const int VALIDATION_ERROR_SLIDER_START_VALUE = -54;
        public const int VALIDATION_ERROR_SLIDER_END_VALUE = -55;
        public const int VALIDATION_ERROR_SLIDER_CAPTION = -56;
        public const int VALIDATION_ERROR_SLIDER_VALUE = -58;//start & end value


        #endregion

        #endregion

    }
}

