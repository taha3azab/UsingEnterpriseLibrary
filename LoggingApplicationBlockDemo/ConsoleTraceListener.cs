﻿using System;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;

namespace LoggingApplicationBlockDemo
{
    [ConfigurationElementType(typeof (CustomTraceListenerData))]
    public class ConsoleTraceListener :CustomTraceListener
    {
        public override void TraceData(System.Diagnostics.TraceEventCache eventCache, string source, System.Diagnostics.TraceEventType eventType, int id, object data)
        {
            if (!(data is LogEntry) || Formatter == null) return;

            var logEntry = data as LogEntry;
            WriteLine(Formatter.Format(logEntry));
        }

        public override void Write(string message)
        {
            Console.Write(message);
        }

        public override void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
