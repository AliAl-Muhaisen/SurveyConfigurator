using Microsoft.Extensions.DependencyInjection;
using SurveyConfiguratorApp.Data.Questions;
using SurveyConfiguratorApp.Forms;
using SurveyConfiguratorApp.Logic.Questions;
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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            services.AddScoped<IQuestionRepository, DbQuestion>();
            services.AddScoped<IQuestionService, QuestionService>();
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                // Resolve and run the main form
                var mainForm = new FormLayout();

                // Manually inject the dependencies
                mainForm.questionService = serviceProvider.GetRequiredService<IQuestionService>();
                Application.Run(mainForm);
            }

           // Application.Run(new FormLayout());
        }

       

    }
}
