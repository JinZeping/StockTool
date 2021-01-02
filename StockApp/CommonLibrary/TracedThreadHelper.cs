using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CommonLibrary
{
    public static class TracedThreadHelper
    {
        public static Log Log { get; set; }

        public static void StartThread(Action<object> action, object param = null, string desc = "")
        {
            if(Log == null)
            {
                CreateLog();
            }

            TracedThread tt = new TracedThread(Log, action);
            tt.Start(param, desc);
        }

        private static void CreateLog()
        {
            string dir = "Log/TracedThreadLog";

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            string path = Path.Combine(dir, $"{DateTime.Now:yyyy-MM-dd}.txt");

            Log = new Log(path);
        }
    }
}
