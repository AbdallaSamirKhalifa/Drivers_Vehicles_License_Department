using System;
using System.Diagnostics;

namespace DVLD_DataAccess
{
    public static class Logger
    {

        public static void Log(string Message, EventLogEntryType EntryType )
        
        {
            string SourceName = "DVLD";
            if (!EventLog.Exists( SourceName ))
            {
                EventLog.CreateEventSource( SourceName, "Application" );
            }

            EventLog.WriteEntry( SourceName, Message, EntryType );
        }

    }
}
