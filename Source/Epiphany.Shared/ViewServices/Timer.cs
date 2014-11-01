using Epiphany.ViewModel.Services;
using System;
using Windows.UI.Xaml;

namespace Epiphany.View.Services
{
    class Timer : ITimer
    {
        private readonly DispatcherTimer timer;
        private readonly Action tickAction;

        public Timer(Action action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            this.timer = new DispatcherTimer();
            this.timer.Tick += OnTick;

            this.tickAction = action;
        }

        public TimeSpan Interval
        {
            get
            {
                return this.timer.Interval;
            }
            set
            {
                this.timer.Interval = value;
            }
        }

        public bool IsEnabled
        {
            get
            {
                return this.timer.IsEnabled;
            }
        }

        public void Start()
        {
            this.timer.Start();
        }

        public void Stop()
        {
            this.timer.Stop();
        }
        public void Dispose()
        {
            this.timer.Tick -= this.OnTick;
        }

        private void OnTick(object sender, object e)
        {
            this.tickAction();
        }
    }
}
