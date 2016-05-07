using System;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public interface ILogonViewModel
    {
        Uri CallbackUri { get; }
        Uri CurrentUri { get; set; }
        bool IsLoginCompleted { get; }
        bool IsSignInTakingLonger { get; }
        bool IsWaitingForUserInteraction { get; }

        Task CheckUriAsync(Uri uri);
        void Dispose();
    }
}