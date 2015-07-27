
namespace Epiphany.Logging
{
    class DummyLogger : ILogger
    {
        public void Debug(string message, string memberName = "", string filePath = "", int lineNumber = 0)
        {
        }

        public void Info(string message, string memberName = "", string filePath = "", int lineNumber = 0)
        {
        }

        public void Warn(string message, string memberName = "", string filePath = "", int lineNumber = 0)
        {
        }

        public void Error(string message, string memberName = "", string filePath = "", int lineNumber = 0)
        {
        }
    }
}
