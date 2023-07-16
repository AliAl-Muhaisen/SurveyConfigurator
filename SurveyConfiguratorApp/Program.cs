using Microsoft.Extensions.DependencyInjection;
using SurveyConfiguratorApp.Logic.Questions;
using System;
using System.Configuration;
using System.Threading;
using System.Windows.Forms;

namespace SurveyConfiguratorApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string language = ConfigurationManager.AppSettings["Language"];
           Thread.CurrentThread.CurrentUICulture=new System.Globalization.CultureInfo(language);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Application.Run(new FormMain());
        }



    }
}
