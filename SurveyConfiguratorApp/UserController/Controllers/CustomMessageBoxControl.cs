using SurveyConfiguratorApp.Domain;
using SurveyConfiguratorApp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Resources.ResXFileRef;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using SurveyConfiguratorApp.Properties;

namespace SurveyConfiguratorApp.UserController.Controllers
{
    public partial class CustomMessageBoxControl : UserControl
    {

        public CustomMessageBoxControl()
        {
            InitializeComponent();
        }
        private string TextMessage(int pStatusCode)
        {
            try
            {
                int tCode = pStatusCode;
                string tMessage = null;
                switch (tCode)
                {
                    case ResultCode.VALIDATION_ERROR:
                        tMessage = Resource.VALIDATION_ERROR;
                        break;

                    case ResultCode.DB_RECORD_NOT_EXISTS:
                        tMessage = Resource.DB_RECORD_NOT_EXISTS;
                        break;

                    case ResultCode.ERROR:

                    case ResultCode.DB_CONNECTION_FAILED:

                    case ResultCode.DB_FAILED_NETWORK_CONNECTION:
                        tMessage = Resource.DB_FAILED_NERORK_CONNECTION;
                        break;
                    case ResultCode.VALIDATION_ERROR_QUESTION_TEXT:
                        tMessage = Resource.VALIDATION_ERROR_QUESTION_TEXT;
                        break;
                    case ResultCode.VALIDATION_ERROR_ORDER_EXIST:
                        tMessage = Resource.VALIDATION_ERROR_ORDER_EXIST;
                        break;
                    case ResultCode.VALIDATION_ERROR_SLIDER_VALUE:
                        tMessage = Resource.VALIDATION_ERROR_SLIDER_VALUE;
                        break;
                    case ResultCode.VALIDATION_ERROR_SLIDER_CAPTION:
                        tMessage =Resource.VALIDATION_ERROR_SLIDER_CAPTION;
                        break;
                    case ResultCode.VALIDATION_ERROR_LONG_TEXT:
                        tMessage= Resource.VALIDATION_ERROR_LONG_TEXT;
                        break;
                    case ResultCode.VALIDATION_ERROR_SHORT_TEXT:
                        tMessage=Resource.VALIDATION_ERROR_SHORT_TEXT;
                        break;
                    default:
                        break;
                }

                return tMessage;
              
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return null;
        }
        public void StatusCodeMessage(int pResultCodes)
        {
            try
            {
                DisplayMessage(pResultCodes);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
        public void ResultCodeMessageList(ref List<int> pResultCodes)
        {
            try
            {
                string tMessages = null;
                for (int i = 0; i < pResultCodes.Count; i++)
                {
                    if (pResultCodes[i] != ResultCode.SUCCESS)
                        tMessages += TextMessage(pResultCodes[i]) + "\n";
                }
                if (tMessages != null)
                    DisplayMessage(ResultCode.ERROR, tMessages);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void DisplayMessage(int pMessageType, string pMessageText = null)
        {

            try
            {
                string tMessage;
                if (pMessageText == null)
                {
                    tMessage = TextMessage(pMessageType);
                }
                else
                {
                    tMessage = pMessageText;
                }



                if (pMessageType == ResultCode.SUCCESS)
                {
                    MessageBox.Show(tMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(tMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }


    }
}
