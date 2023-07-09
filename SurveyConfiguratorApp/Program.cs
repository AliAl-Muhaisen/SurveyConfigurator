using Microsoft.Extensions.DependencyInjection;
using SurveyConfiguratorApp.Logic.Questions;
using System;
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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new FormMain());
        }



    }
}
