using SurveyConfiguratorApp.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.Forms.Settings
{
    public partial class FormLanguage : CustomForm
    {
        string CurrentLanguage;
        string NewLanguage;
        public FormLanguage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (NewLanguage != CurrentLanguage)
                    SaveLanguageSettings(NewLanguage);

                Close();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void SaveLanguageSettings(string pNewLanguage)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["Language"].Value = pNewLanguage;
                configuration.Save();
                ConfigurationManager.RefreshSection("appSettings");
                Application.Restart();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void FormLanguage_Load(object sender, EventArgs e)
        {
            try
            {
                CurrentLanguage = ConfigurationManager.AppSettings["Language"];
                NewLanguage = CurrentLanguage;
                comboBox1.SelectedIndex=0;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string tSelectLanguage= comboBox1.SelectedItem.ToString();
               switch (tSelectLanguage)
                {
                    case "عربي":
                        NewLanguage = "ar-JO";
                        break;

                    default:
                        NewLanguage = "en-US";
                        break;


                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
    }
}
