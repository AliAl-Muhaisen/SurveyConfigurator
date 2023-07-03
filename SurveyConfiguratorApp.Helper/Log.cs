using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Helper
{
    public class Log
    {
        private static readonly string appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        private static object lockObject = new object();

        static public void Error(Exception ex)
        {
            try
            {
                string logDirectory = Path.Combine(appLocation, "logs");
                Directory.CreateDirectory(logDirectory);

                string logFilePath = Path.Combine(logDirectory, "errorLog.txt");

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


    }

}
