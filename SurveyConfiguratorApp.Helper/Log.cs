using System;
using System.IO;
using System.Reflection;

namespace SurveyConfiguratorApp.Helper
{
    public class Log
    {
        private static readonly string appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        private static object lockObject = new object();

        private static string CreateFile(string fileName)
        {
            try
            {
                string logDirectory = Path.Combine(appLocation, "logs");
                Directory.CreateDirectory(logDirectory);

                string logFilePath = Path.Combine(logDirectory, $"{fileName}.txt");
                return logFilePath;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        static public void Error(Exception ex)
        {
            try
            {


                string logFilePath = CreateFile("Error.Log");

                // to ensure that only one thread at a time can write to the log file
                lock (lockObject)
                {
                    using (StreamWriter streamWriter = new StreamWriter(logFilePath, true))
                    {
                        streamWriter.WriteLine($"DateTime: {DateTime.Now}");
                        streamWriter.WriteLine($"Type: {ex.GetType()}");
                        streamWriter.WriteLine($"Message: {ex.Message}");
                        streamWriter.WriteLine($"Stack Trace: {ex.StackTrace}");
                        streamWriter.WriteLine("\n\n");
                    }
                }
            }
            catch (Exception handleEx)
            {
                Console.WriteLine($"Error handling exception: {handleEx.Message}");
            }

        }

        static public void Info(string info)
        {
            try
            {


                string logFilePath = CreateFile("Info.Log");

                // to ensure that only one thread at a time can write to the log file
                lock (lockObject)
                {
                    using (StreamWriter streamWriter = new StreamWriter(logFilePath, true))
                    {
                        streamWriter.WriteLine($"DateTime: {DateTime.Now}");
                        streamWriter.WriteLine($"Message: {info}");
 
                        streamWriter.WriteLine("\n\n");
                    }
                }
            }
            catch (Exception handleEx)
            {
                Console.WriteLine($"Error handling exception: {handleEx.Message}");
            }

        }
    }

}
