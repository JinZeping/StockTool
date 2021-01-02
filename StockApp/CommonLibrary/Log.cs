using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace CommonLibrary
{
    public class Log
    {
        public bool Enable { get; set; } = true;
        public LogLevel EnableLevel { get; set; } = LogLevel.DEBUG;
        public string FilePath { get; private set; }

        public event Action<LogLevel, string> RecordEvent;

        public Log(string filePath = null)
        {
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                FilePath = filePath;
                RecordEvent += RecordToFile;

                string dir = Path.GetDirectoryName(filePath);

                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
            }
        }

        public void Debug(string content)
        {
            Record(LogLevel.DEBUG, content);
        }

        public void Info(string content)
        {
            Record(LogLevel.INFO, content);
        }

        public void Warn(string content)
        {
            Record(LogLevel.WARN, content);
        }

        public void Error(string content)
        {
            Record(LogLevel.ERROR, content);
        }

        public void Fatal(string content)
        {
            Record(LogLevel.FATAL, content);
        }

        public void Exception(Exception ex)
        {
            Record(LogLevel.EXCEPTION, $"{ex.Message} {ex.StackTrace}");

            if (ex.InnerException != null)
            {
                Exception(ex.InnerException);
            }
        }

        public void Record(LogLevel level, string content)
        {
            if (Enable && (level >= EnableLevel))
            {
                RecordEvent?.Invoke(level, content);
            }
        }

        private void RecordToFile(LogLevel level, string content)
        {
            content = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}, [{Thread.CurrentThread.ManagedThreadId:D4}], [{level}], "
                + $"{content.Replace(',', '，')}";

            using (StreamWriter writer = new StreamWriter(FilePath, true))
            {
                writer.WriteLine(content);
            }
        }
    }

    public enum LogLevel : int
    {
        DEBUG = 0,
        INFO,
        WARN,
        ERROR,
        FATAL,
        EXCEPTION
    }
}
