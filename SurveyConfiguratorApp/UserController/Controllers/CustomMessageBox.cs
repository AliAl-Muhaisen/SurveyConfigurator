using SurveyConfiguratorApp.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using MessageBoxOptions = System.Windows.Forms.MessageBoxOptions;

namespace SurveyConfiguratorApp.UserController.Controllers
{
    public class CustomMessageBox
    {
        public static DialogResult Show(string pMessage,string pTitle, MessageBoxIcon pMessageBoxIcon, MessageBoxButtons pMessageBoxButtons= MessageBoxButtons.OK)
        {
            try {
                string language = ConfigurationManager.AppSettings["Language"];
                DialogResult dialogResult;
                if (language == "ar-JO")
                {
                    dialogResult= MessageBox.Show(pMessage, pTitle, pMessageBoxButtons, pMessageBoxIcon, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                }
                else
                {
                    dialogResult= MessageBox.Show(pMessage, pTitle, pMessageBoxButtons, pMessageBoxIcon);

                }
                return dialogResult;
            }
            catch (Exception e) {
                Log.Error(e);
            }
            return DialogResult.Cancel;
        }

    }
}
