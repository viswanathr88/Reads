using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Services;
using System;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public sealed class AboutViewModel : DataViewModel, IAboutViewModel
    {
        private readonly ICommand likeOnFacebookCommand;
        private readonly ICommand rateAppCommand;

        public AboutViewModel(IAppRateService rateService, IUrlLauncher urlLauncher)
        {
            if (rateService == null || urlLauncher == null)
            {
                throw new ArgumentNullException();
            }

            this.likeOnFacebookCommand = new LikeOnFacebookCommand(urlLauncher);
            this.rateAppCommand = new RateAppCommand(rateService);
        }

        public ICommand LikeOnFacebook
        {
            get
            {
                return this.likeOnFacebookCommand;
            }
        }

        public ICommand RateApp
        {
            get
            {
                return this.rateAppCommand;
            }
        }

        public override void Load()
        {
            // Nothing to load
            IsLoaded = true;
        }
    }
}
