using SurveyConfiguratorApp.Domain;
using SurveyConfiguratorApp.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Data
{
    public class DbException
    {
        public static StatusCode HandleSqlException(SqlException sqlException)
        {
            try
            {
                Log.Info("DbException called");
                Log.Error(sqlException);
                if (sqlException.Number == 2)
                {
                    return StatusCode.DbFailedNetWorkConnection;
                }
                else if (sqlException.Number == 2627)
                {
                    return StatusCode.ValidationErrorQuestionOrder;
                }
                else if (sqlException.Number == 515)
                {
                    // Handle the NOT NULL constraint violation
                     return StatusCode.ValidationErrorRequiredValue;
                }
                else
                {
                    return StatusCode.DbFailedConnection;
                }
            }
            catch(Exception ex)
            {
                Log.Error(ex);
                return StatusCode.Error;
            }
        }
       

    }
}
