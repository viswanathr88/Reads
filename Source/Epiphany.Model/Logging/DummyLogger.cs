
namespace Epiphany.Logging
{
    class DummyLogger : ILogger
    {
        public void Debug(string message, string className, string memberName = "")
        {
        }

        public void Info(string message, string className, string memberName = "")
        {
        }

        public void Warn(string message, string className, string memberName = "")
        {
        }

        public void Error(string message, string className, string memberName = "")
        {
        }
    }
}
