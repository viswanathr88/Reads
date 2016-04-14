using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Epiphany.Logging
{
    public static class Logger
    {
        public static ICollection<ILogWriter> Writers = new List<ILogWriter>();

        [ConditionalAttribute("DEBUG")]
        public static void LogDebug(string message, [CallerMemberName] string member = null)
        {
            LogMessage(LogLevel.Debug, message, member);
        }

        public static void LogInfo(string message, [CallerMemberName] string member = null)
        {
            LogMessage(LogLevel.Info, message, member);
        }

        public static void LogWarn(string message, [CallerMemberName] string member = null)
        {
            LogMessage(LogLevel.Warn, message, member);
        }

        public static void LogError(string message, [CallerMemberName] string member = null)
        {
            LogMessage(LogLevel.Error, message, member);
        }

        public static void LogException(Exception ex, [CallerMemberName] string member = null)
        {
            LogMessage(LogLevel.Error, ex.ToString(), member);
        }

        private static void LogMessage(LogLevel level, string message, string member)
        {
            if (Writers.Count > 0)
            {
                string logEntry = string.Format("{0} {1} {2} {3} {4}",
                    DateTime.Now.ToString("yyyy-MM-dd-hh:mm:ss.fff tt"),
                    System.Environment.CurrentManagedThreadId,
                    level, member, message);

                foreach (ILogWriter writer in Writers)
                {
                    writer.WriteLine(level, logEntry);
                }
            }
        }
    }
}
