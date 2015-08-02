using System;

namespace Epiphany.ViewModel.Services
{
    public interface ITimerService
    {
        /// <summary>
        /// Creates a timer
        /// </summary>
        /// <uri name="action">The Action to trigger when the timer ticks</uri>
        /// <returns>timer</returns>
        ITimer CreateTimer(Action action);
    }
}
