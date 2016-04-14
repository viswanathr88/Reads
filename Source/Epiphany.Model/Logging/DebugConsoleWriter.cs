using System.Diagnostics;

namespace Epiphany.Logging
{
    /// <summary>
    /// Represents a log writer that will show up in debug console
    /// </summary>
    public sealed class DebugConsoleWriter : ILogWriter
    {
        public void Write(LogLevel level, string log)
        {
            Debug.WriteLine(log);
        }

        public void WriteLine(LogLevel level, string log)
        {
            Debug.WriteLine(log);
        }

        public void Dispose()
        {
            // Nothing to do here
        }
    }
}
