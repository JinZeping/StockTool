using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CommonLibrary
{
    public class TracedThread
    {
        public Action<object> Action { get; private set; }

        public Log Log { get; private set; }

        public TracedThread(Log log, Action<object> action)
        {
            Log = log;
            Action = action;
        }

        public void Start(object param = null, string desc = "")
        {
            new Thread(new ThreadStart(() =>
            {
                try
                {
                    Log.Debug("TracedThread Start " + desc);

                    Action.Invoke(param);

                    Log.Debug("TracedThread End");
                }
                catch(Exception ex)
                {
                    Log.Error("TracedThread Exception");
                    Log.Exception(ex);
                }
            })).Start();
        }
    }
}
