using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StockApp
{
    public static class Log
    {
        public static CommonLibrary.Log LogInstance { get; private set; }

        static Log()
        {
            string path = $"{Directory.GetCurrentDirectory()}\\Log\\Log_{DateTime.Now:yyyyMMdd}.txt";
            LogInstance = new CommonLibrary.Log(path);

#if DEBUG
            LogInstance.RecordEvent += (level, content) =>
            {
                System.Diagnostics.Debug.WriteLine($"LOG:  {level}  {content}");
            };
#endif
        }

        public static void Debug(string content)
            => LogInstance.Debug(content);

        public static void Info(string content)
            => LogInstance.Info(content);

        public static void Warn(string content)
            => LogInstance.Warn(content);

        public static void Error(string content)
            => LogInstance.Error(content);

        public static void Fatal(string content)
            => LogInstance.Fatal(content);

        public static void Exception(Exception ex)
            => LogInstance.Exception(ex);
    }
}
