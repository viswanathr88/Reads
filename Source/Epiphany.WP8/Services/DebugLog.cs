using System;
using System.Diagnostics;

namespace Epiphany.View.Services
{
    sealed class DebugLog : LoggerBase
    {

        protected override void WriteToLog(string logLine)
        {
            System.Diagnostics.Debug.WriteLine(logLine);
        }
    }
}
