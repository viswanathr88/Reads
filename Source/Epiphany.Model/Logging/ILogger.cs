
using System.Runtime.CompilerServices;
namespace Epiphany.Logging
{
    public interface ILogger
    {
        void Debug(string message, string className, [CallerMemberName] string memberName = "");

        void Info(string message, string className, [CallerMemberName] string memberName = "");

        void Warn(string message, string className, [CallerMemberName] string memberName = "");

        void Error(string message, string className, [CallerMemberName] string memberName = "");
    }
}
