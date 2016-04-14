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
        /// <summary>
        /// Create an instance of AboutViewModel
        /// </summary>
        /// <param name="rateService"></param>
        /// <param name="urlLauncher"></param>
        public AboutViewModel(IAppRateService rateService, IUrlLauncher urlLauncher)
        {
            if (rateService == null || urlLauncher == null)
            {
                throw new ArgumentNullException(nameof(rateService));
            }

            this.likeOnFacebookCommand = new LikeOnFacebookCommand(urlLauncher);
            this.rateAppCommand = new RateAppCommand(rateService);
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
