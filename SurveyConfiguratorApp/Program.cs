using Microsoft.Extensions.DependencyInjection;
using SurveyConfiguratorApp.Data.Questions;
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

            var services = new ServiceCollection();
            //This line registers the DbQuestion class as the implementation for the IQuestionRepository interface.
            //It means that whenever an instance of IQuestionRepository is requested, the DbQuestion implementation will be provided.
            services.AddScoped<IQuestionRepository, DbQuestion>();
            services.AddScoped<IQuestionService, QuestionService>();


            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var mainForm = new FormMain();

                // Manually inject the dependencies
                //This line performs dependency injection by retrieving an instance of IQuestionService from the ServiceProvider and assigning it to the questionService property of the FormMain instance.

                mainForm.questionService = serviceProvider.GetRequiredService<IQuestionService>();
                Application.Run(mainForm);
            }
        }



    }
}
