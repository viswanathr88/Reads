using Epiphany.ViewModel.Services;
using System;
using Windows.UI.Xaml;

namespace Epiphany.View.Services
{
    class Timer : ITimer
    {
        private readonly Action tickAction;
        private readonly DispatcherTimer internalTimer;

        public Timer(Action tickAction)
        {
            this.tickAction = tickAction;
            this.internalTimer = new DispatcherTimer();
            this.internalTimer.Tick += OnTimeout;
        }

        public TimeSpan Interval
        {
            get
            {
                return this.internalTimer.Interval;
            }
            set
            {
                this.internalTimer.Interval = value;
            }
        }

        public bool IsEnabled
        {
            get
            {
                return this.internalTimer.IsEnabled;
            }
        }

        public void Start()
        {
            this.internalTimer.Start();
        }

        public void Stop()
        {
            this.internalTimer.Stop();
        }

        private void OnTimeout(object sender, object e)
        {
            if (tickAction != null)
            {
                tickAction.Invoke();
            }
        }

        public void Dispose()
        {
            this.internalTimer.Tick -= OnTimeout;
        }
    }
}
