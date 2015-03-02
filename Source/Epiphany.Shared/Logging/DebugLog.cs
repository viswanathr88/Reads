using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;

namespace Epiphany.Logging
{
    public sealed class DebugLog : EventListener
    {
        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            string logLine = string.Format("{0} {1} {2}::{3} - {4}", 
                DateTime.Now, 
                eventData.Level, 
                eventData.Payload[1].ToString(), 
                eventData.Payload[2].ToString(), 
                eventData.Payload[0].ToString());
            Debug.WriteLine(logLine);
        }
    }
}
