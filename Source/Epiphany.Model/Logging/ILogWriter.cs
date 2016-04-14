using System;

namespace Epiphany.Logging
{

    public enum LogLevel
    {
        Error = 0,
        Warn = 1,
        Info = 2,
        Debug = 3
    };

    /// <summary>
    /// Interface for a log writer
    /// </summary>
    public interface ILogWriter : IDisposable
    {
        /// <summary>
        /// Write to log
        /// </summary>
        /// <param name="level">log level</param>
        /// <param name="log">string to log</param>
        void Write(LogLevel level, string log);
        /// <summary>
        /// Write line to log
        /// </summary>
        /// <param name="level">log level</param>
        /// <param name="log">string to log</param>
        void WriteLine(LogLevel level, string log);
    }
}
