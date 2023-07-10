using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Helper
{
    public static class GenericHelper
    {
        public enum StatusCode
        {
            Error = -1,
            ValidationError = -2,
            Success = 0,
        }
    }
}
