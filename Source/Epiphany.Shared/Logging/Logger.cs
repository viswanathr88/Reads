using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;

namespace Epiphany.Logging
{
    public sealed class Logger : EventSource, ILogger
    {
        [NonEvent]
        public void Debug(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0
            )
        {
            if (IsEnabled())
            {
                DebugInternal(message, memberName, filePath, lineNumber);
            }
        }

        [NonEvent]
        public void Info(string message, 
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0
            )
        {
            if (IsEnabled())
            {
                InfoInternal(message, memberName, filePath, lineNumber);
            }
        }

        [NonEvent]
        public void Warn(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0
            )
        {
            if (IsEnabled())
            {
                WarnInternal(message, memberName, filePath, lineNumber); 
            }
        }

        [NonEvent]
        public void Error(string message, 
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0
            )
        {
            if (IsEnabled())
            {
                ErrorInternal(message, memberName, filePath, lineNumber);
            }
        }


        [Event(1, Level=EventLevel.Verbose)]
        public void DebugInternal(string message, string memberName, string filePath, int lineNumber)
        {
            this.WriteEvent(1, message, memberName, filePath, lineNumber);
        }

        [Event(2, Level=EventLevel.Informational)]
        public void InfoInternal(string message, string memberName, string filePath, int lineNumber)
        {
            this.WriteEvent(2, message, memberName, filePath, lineNumber);
        }

        [Event(3, Level=EventLevel.Warning)]
        public void WarnInternal(string message, string memberName, string filePath, int lineNumber)
        {
            this.WriteEvent(3, message, memberName, filePath, lineNumber);
        }

        [Event(4, Level=EventLevel.Error)]
        public void ErrorInternal(string message, string memberName, string filePath, int lineNumber)
        {
            this.WriteEvent(4, message, memberName, filePath, lineNumber);
        }
    }
}
