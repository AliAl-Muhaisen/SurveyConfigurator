using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Domain
{
    public  class StatusCode
    {
        public int Code { get; set; }
        #region Common
        public static readonly StatusCode Success = new StatusCode { Code = 0 };
        public static readonly StatusCode ValidationError = new StatusCode { Code = -2 };
        public static readonly StatusCode Error = new StatusCode { Code = -1};
        #endregion

        #region Data Base
        public static readonly StatusCode DbFailedConnection = new StatusCode { Code = -3};
        public static readonly StatusCode DbFailedNetWorkConnection = new StatusCode { Code = -4};
        public static readonly StatusCode DbRecordNotExists = new StatusCode { Code = -5};
        public static readonly StatusCode DbSuccessConnection = new StatusCode { Code = 2};
        #endregion

        #region Validation
        public static readonly StatusCode ValidationErrorQuestionText= new StatusCode { Code = -20 };
        public static readonly StatusCode ValidationErrorRequiredValue= new StatusCode { Code = -24 };
        public static readonly StatusCode ValidationErrorQuestionOrder= new StatusCode { Code = -21 };
        public static readonly StatusCode ValidationErrorQuestionShort= new StatusCode { Code = -22 };
        public static readonly StatusCode ValidationErrorQuestionLong= new StatusCode { Code = -23 };

        #region Validation Faces

        public static readonly StatusCode ValidationErrorFacesNumber= new StatusCode { Code = -30 };

        #endregion

        #region Validation Stars

        public static readonly StatusCode ValidationErrorStarsNumber = new StatusCode { Code = -43 };

        #endregion
        #region Validation Slider

        public static readonly StatusCode ValidationErrorSliderStartValue = new StatusCode { Code = -54 };
        public static readonly StatusCode ValidationErrorSliderEndValue = new StatusCode { Code = -55 };
        public static readonly StatusCode ValidationErrorSliderCaption = new StatusCode { Code = -56 };
        public static readonly StatusCode ValidationErrorSliderValue = new StatusCode { Code = -58 };//start & end value


        #endregion

        #endregion


    }
}
