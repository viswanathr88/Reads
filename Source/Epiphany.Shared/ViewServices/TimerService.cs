using Epiphany.ViewModel.Services;
using System;

namespace Epiphany.View.Services
{
    class TimerService : ITimerService
    {
        public ITimer CreateTimer(Action action)
        {
            return new Timer(action);
        }
    }
}
