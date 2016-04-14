using Epiphany.ViewModel.Services;
using System;
using System.Windows.Input;

namespace Epiphany.ViewModel.Commands
{
    sealed class LikeOnFacebookCommand : Command
    {
        private readonly IDeviceServices deviceServices;
        private readonly string url = "www.facebook.com/epiphanywp";

        public LikeOnFacebookCommand(IDeviceServices deviceServices)
        {
            this.deviceServices = deviceServices;
        }

        protected override bool CanExecute()
        {
            return true;
        }

        protected override void Run()
        {
            this.deviceServices.LaunchUrl(url);
        }
    }
}
