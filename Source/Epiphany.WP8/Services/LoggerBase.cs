using Epiphany.Logging;
using System;

namespace Epiphany.View.Services
{
    public enum LogLevel
    {
        Debug,
        Info,
        Warn,
        Error
    };

    abstract class LoggerBase : ILogger
    {
        public void Debug(string message, string memberName = "", string filePath = "", int lineNumber = 0)
        {
            Log(LogLevel.Debug, message, memberName, filePath, lineNumber);
        }

        public void Info(string message, string memberName = "", string filePath = "", int lineNumber = 0)
        {
            Log(LogLevel.Info, message, memberName, filePath, lineNumber);
        }

        public void Warn(string message, string memberName = "", string filePath = "", int lineNumber = 0)
        {
            Log(LogLevel.Warn, message, memberName, filePath, lineNumber);
        }

        public void Error(string message, string memberName = "", string filePath = "", int lineNumber = 0)
        {
            Log(LogLevel.Error, message, memberName, filePath, lineNumber);
        }

        protected abstract void WriteToLog(string logLine);

        protected virtual void Log(LogLevel level, string message, string memberName, string filePath, int lineNumber)
        {
            string logLine = string.Format("{0} {1} {2}:{3} {4} - {5}",
                DateTime.Now,
                level,
                filePath, // FilePath
                lineNumber, // LineNumber
                memberName, // MemberFunction
                message  // Message 
                );

            WriteToLog(logLine);
        }
    }
}
