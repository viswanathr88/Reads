using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;

namespace Epiphany.Logging
{
    public sealed class Logger : EventSource, ILogger
    {
        [NonEvent]
        public void Debug(string message, string className, [CallerMemberName] string memberName = "")
        {
            if (IsEnabled())
            {
                DebugInternal(message, className, memberName);
            }
        }

        [NonEvent]
        public void Info(string message, string className, [CallerMemberName] string memberName = "")
        {
            if (IsEnabled())
            {
                InfoInternal(message, className, memberName);
            }
        }

        [NonEvent]
        public void Warn(string message, string className, [CallerMemberName] string memberName = "")
        {
            if (IsEnabled())
            { 
                WarnInternal(message, className, memberName); 
            }
        }

        [NonEvent]
        public void Error(string message, string className, [CallerMemberName] string memberName = "")
        {
            if (IsEnabled())
            {
                ErrorInternal(message, className, memberName);
            }
        }


        [Event(1, Level=EventLevel.Verbose)]
        public void DebugInternal(string message, string className, string memberName = "")
        {
            this.WriteEvent(1, message, className, memberName);
        }

        [Event(2, Level=EventLevel.Informational)]
        public void InfoInternal(string message, string className, string memberName = "")
        {
            this.WriteEvent(2, message, className, memberName);
        }

        [Event(3, Level=EventLevel.Warning)]
        public void WarnInternal(string message, string className, string memberName = "")
        {
            this.WriteEvent(3, message, className, memberName);
        }

        [Event(4, Level=EventLevel.Error)]
        public void ErrorInternal(string message, string className, string memberName = "")
        {
            this.WriteEvent(4, message, className, memberName);
        }
    }
}
