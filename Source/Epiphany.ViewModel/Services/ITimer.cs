using System;

namespace Epiphany.ViewModel.Services
{
    /// <summary>
    /// Interface for a timer
    /// </summary>
    public interface ITimer : IDisposable
    {
        /// <summary>
        /// Tick interval
        /// </summary>
        TimeSpan Interval
        {
            get;
            set;
        }
        /// <summary>
        /// Gets whether the timer is enabled
        /// </summary>
        bool IsEnabled
        {
            get;
        }
        /// <summary>
        /// Starts the timer
        /// </summary>
        void Start();
        /// <summary>
        /// Stops the timer
        /// </summary>
        void Stop();
    }
}
