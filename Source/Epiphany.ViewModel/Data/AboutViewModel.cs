using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    /// <summary>
    /// ViewModel for About
    /// </summary>
    public sealed class AboutViewModel : DataViewModel<VoidType>
    {
        private readonly ICommand likeOnFacebookCommand;
        private readonly ICommand rateAppCommand;

        public AboutViewModel() { }

        /// <summary>
        /// Create an instance of AboutViewModel
        /// </summary>
        /// <param name="rateService"></param>
        /// <param name="urlLauncher"></param>
        public AboutViewModel(IDeviceServices deviceServices)
        {
            if (deviceServices == null)
            {
                throw new ArgumentNullException(nameof(deviceServices));
            }

            this.likeOnFacebookCommand = new LikeOnFacebookCommand(deviceServices);
            this.rateAppCommand = new RateAppCommand(deviceServices);
        }
        /// <summary>
        /// Like the app on facebook command
        /// </summary>
        public ICommand LikeOnFacebook
        {
            get
            {
                return this.likeOnFacebookCommand;
            }
        }
        /// <summary>
        /// Rate the app command
        /// </summary>
        public ICommand RateApp
        {
            get
            {
                return this.rateAppCommand;
            }
        }
        /// <summary>
        /// Load the VM
        /// </summary>
        /// <param name="parameter">input param</param>
        /// <returns></returns>
        public override Task LoadAsync(VoidType parameter)
        {
            // Nothing to load
            IsLoaded = true;
            return Task.FromResult(true);
        }
    }
}
