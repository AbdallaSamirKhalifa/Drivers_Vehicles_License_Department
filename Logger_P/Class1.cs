using System;
using System.Diagnostics;

namespace Logger_P
{
    public static class Logger
    {
        public static void Logging(string Message, string SourceName, EventLogEntryType EntryType)
        {            
            if (!EventLog.Exists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }

            EventLog.WriteEntry(SourceName, Message, EntryType);

        }


    }
}
