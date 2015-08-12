
namespace Epiphany.View.Services
{
    sealed class ReleaseLog : LoggerBase
    {
        protected override void Log(LogLevel level, string message, string memberName, string filePath, int lineNumber)
        {
            if (level != LogLevel.Debug)
            {
                base.Log(level, message, memberName, filePath, lineNumber);
            }
        }
        protected override void WriteToLog(string logLine)
        {
            //TODO: Write to a file here
            System.Diagnostics.Debug.WriteLine(logLine);
        }
    }
}
