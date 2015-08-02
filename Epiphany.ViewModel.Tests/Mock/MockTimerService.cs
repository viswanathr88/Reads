using Epiphany.ViewModel.Services;
using System;

namespace Epiphany.ViewModel.Tests.Mock
{
    public class MockTimerService : ITimerService
    {
        public ITimer CreateTimer(Action action)
        {
            return new MockTimer(action);
        }
    }
}
