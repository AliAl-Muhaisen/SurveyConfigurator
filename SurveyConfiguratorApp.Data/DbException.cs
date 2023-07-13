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
        public static int HandleSqlException(SqlException sqlException)
        {
            try
            {
                Log.Error(sqlException);
                if (sqlException.Number == 2)
                {
                    return StatusCode.DB_FAILED_NERORK_CONNECTION;
                }
                else if (sqlException.Number == 2627)
                {
                    return StatusCode.VALIDATION_ERROR_ORDER_EXIST;
                }
                else if (sqlException.Number == 515)
                {
                    // Handle the NOT NULL constraint violation
                     return StatusCode.VALIDATION_ERROR_REQUIRED_VALUE;
                }
                else
                {
                    return StatusCode.DB_FAILED_CONNECTION;
                }
            }
            catch(Exception ex)
            {
                Log.Error(ex);
                return StatusCode.ERROR;
            }
        }
       

    }
}
