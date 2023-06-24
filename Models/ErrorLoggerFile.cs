using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyConfiguratorApp.Models
{
    public class ErrorLoggerFile
    {
        private readonly string logFilePath;
        private FileStream fileStream;
        private BinaryFormatter binaryFormatter;

        public ErrorLoggerFile()
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

        private void LogError(Exception ex)
        {
            try
            {
                fileStream.Seek(0, SeekOrigin.End);
                binaryFormatter.Serialize(fileStream, ex);
            }
            catch (Exception innerEx)
            {
                Console.WriteLine($"Error logging exception: {innerEx.Message}");
            }
        }

        public List<Exception> DeserializeLogFile()
        {
            try
            {

                List<Exception> strings = new List<Exception>();
                //# repositioning the file stream's current position to the start of the file
                if (fileStream == null)
                {
                    OpenLogFile();
                }
              
                fileStream.Seek(0, SeekOrigin.Begin);
                while (fileStream.Position < fileStream.Length)
                {
                    var exception = (Exception)binaryFormatter.Deserialize(fileStream);
                    strings.Add(exception);
                    Console.WriteLine(exception.ToString());
                }
                return strings;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deserializing log file: {ex.Message}");

            }
            finally
            {
                CloseLogFile();
            }
            return new List<Exception>();
        }

        public void HandleException(Exception ex)
        {
            try
            {
                OpenLogFile();
                LogError(ex);
            }
            catch (Exception handleEx)
            {
                Console.WriteLine($"Error handling exception: {handleEx.Message}");
            }
            finally
            {
                CloseLogFile();
            }
        }


    }

}
