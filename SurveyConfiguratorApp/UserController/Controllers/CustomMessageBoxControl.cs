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
                    case StatusCode.VALIDATION_ERROR:
                        tMessage = "Validation errors, Please check the inputs";
                        break;

                    case StatusCode.DB_RECORD_NOT_EXISTS:
                        tMessage = "This Question does not exists";
                        break;

                    case StatusCode.ERROR:

                    case StatusCode.DB_FAILED_CONNECTION:

                    case StatusCode.DB_FAILED_NERORK_CONNECTION:
                        tMessage = "Something went wrong, Ask the Admin for help";
                        break;

                    case StatusCode.VALIDATION_ERROR_QUESTION_TEXT:
                        tMessage = "Question text Required";
                        break;
                    case StatusCode.VALIDATION_ERROR_ORDER_EXIST:
                        tMessage = "Order Should be unique";
                        break;
                    case StatusCode.VALIDATION_ERROR_SLIDER_VALUE:
                        tMessage ="Min Value Should be less than Max Value";
                        break;
                    case StatusCode.VALIDATION_ERROR_SLIDER_CAPTION:
                        tMessage ="Caption Text Required";
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
        public void StatusCodeMessage(int statusCode)
        {
            try
            {
                DisplayMessage(statusCode);


            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
        public void StatusCodeMessageList(ref List<int> statusCodes)
        {
            try
            {
                string tMessages = null;
                for (int i = 0; i < statusCodes.Count; i++)
                {
                    if (statusCodes[i] != StatusCode.SUCCESS)
                        tMessages += TextMessage(statusCodes[i]) + "\n";
                }
                if (tMessages != null)
                    DisplayMessage(StatusCode.ERROR, tMessages);
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



                if (pMessageType == StatusCode.SUCCESS)
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
