using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SurveyConfiguratorApp.Helper
{
    public class LogError
    {
        private readonly string logFilePath;
        private FileStream fileStream;
        private BinaryFormatter binaryFormatter;

        public LogError()
        {
            string appDirectory = AppDomain.CurrentDomain.BaseDirectory;

            logFilePath = Path.Combine(appDirectory, "errorlog.bin");
            binaryFormatter = new BinaryFormatter();
           // OpenLogFile();
        }
        public string LogFilePath { get { return logFilePath; } }
        private void OpenLogFile()
        {
            try
            {
                fileStream = new FileStream(logFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error opening log file: {ex.Message}");
            }
        }

        public void CloseLogFile()
        {
            try
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error closing log file: {ex.Message}");
            }
        }

        //private void log(Exception ex)
        //{
        //    try
        //    {
        //        fileStream.Seek(0, SeekOrigin.End);
        //        binaryFormatter.Serialize(fileStream, ex);
        //    }
        //    catch (Exception innerEx)
        //    {
        //        Console.WriteLine($"Error logging exception: {innerEx.Message}");
        //    }
        //}

       
      static public void log(Exception ex)
        {
            try
            {
               // OpenLogFile();
                //log(ex);
            }
            catch (Exception handleEx)
            {
                Console.WriteLine($"Error handling exception: {handleEx.Message}");
            }
            finally
            {
               // CloseLogFile();
            }
        }


    }

}
