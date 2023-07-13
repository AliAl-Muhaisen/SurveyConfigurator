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
        private string TextMessage(StatusCode pStatusCode)
        {
            try
            {
                int tCode = pStatusCode.Code;
              //  Log.Info(tCode.ToString());
                if (tCode == StatusCode.ValidationError.Code)
                {
                    return "Validation errors, Please check the inputs";
                }
                //else if (tCode == StatusCode.Success.Code)
                //{
                //    MessageBox.Show("Completed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                else if (tCode == StatusCode.Error.Code)
                {
                    return "Something went wrong";
                }
                else if (tCode == StatusCode.DbRecordNotExists.Code)
                {
                    return "This Question does not exists";
                }
                else if (tCode == StatusCode.DbFailedNetWorkConnection.Code)
                {
                    return "You are not connected to the server, Please check your network connection or ask the Admin for help";
                }
                else if (tCode == StatusCode.DbFailedConnection.Code)
                {
                    return "Failed Connecting to the data base, Please check your network connection or ask the Admin for help";
                }
                else if(tCode ==StatusCode.ValidationErrorQuestionText.Code )
                {
                    return "Question text Required";
                }
                else if(tCode ==StatusCode.ValidationErrorQuestionOrder.Code)
                {
                    return "Order Should be unique";
                }
                //Slider
                else if (tCode==StatusCode.ValidationErrorSliderCaption.Code)
                {
                    return "Caption Text Required";
                }
                else if (tCode == StatusCode.ValidationErrorSliderEndValue.Code)
                {
                    return "";
                }
                else if (tCode == StatusCode.ValidationErrorSliderValue.Code)
                {
                    return "Min Value Should be less than Max Value";
                }

            }
            catch (Exception e)
            {
                Log.Error(e);
            }
            return null;
        }
        public void StatusCodeMessage(StatusCode statusCode)
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
        public void StatusCodeMessageList(ref List<StatusCode> statusCodes)
        {
            try
            {
                string tMessages = null;
                for (int i = 0; i < statusCodes.Count; i++)
                {
                    if (statusCodes[i].Code!=StatusCode.Success.Code)
                        tMessages+= TextMessage(statusCodes[i])+"\n";
                }
                if (tMessages != null)
                    DisplayMessage(StatusCode.Error, tMessages);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
        
        private void DisplayMessage(StatusCode pMessageType, string pMessageText = null)
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



                if (pMessageType.Code == StatusCode.Success.Code)
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
