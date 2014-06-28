using System;

namespace Epiphany.ViewModel.Services
{
    public interface ITimerService
    {
        /// <summary>
        /// Creates a timer
        /// </summary>
        /// <param name="action">The Action to trigger when the timer ticks</param>
        /// <returns>timer</returns>
        ITimer CreateTimer(Action action);
    }
}
