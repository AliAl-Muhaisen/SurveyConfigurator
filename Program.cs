using SurveyConfiguratorApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
            // global exception handler
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new FormMain());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // Handle the exception
            HandleException(e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // Handle the exception
            HandleException(e.ExceptionObject as Exception);
        }
        private static void HandleException(Exception exception)
        {
            ErrorLoggerFile errorLoggerFile = new ErrorLoggerFile();
            errorLoggerFile.HandleException(exception);
           
        }

    }
}
