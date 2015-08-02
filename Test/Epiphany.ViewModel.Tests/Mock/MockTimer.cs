using Epiphany.ViewModel.Services;
using System;

namespace Epiphany.ViewModel.Tests.Mock
{
    public class MockTimer : ITimer
    {
        private readonly Action action;

        public MockTimer(Action action)
        {
            this.action = action;
        }

        public TimeSpan Interval
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get
            {
                return false;
            }
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }

        void OnTimerTick(object sender, EventArgs e)
        {
             if (this.action != null)
             {
                 this.action.Invoke();
             }
        }

        public void Dispose()
        {
        }
    }
}
