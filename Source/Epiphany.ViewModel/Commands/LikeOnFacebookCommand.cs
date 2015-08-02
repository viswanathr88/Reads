using Epiphany.ViewModel.Services;
using System;
using System.Windows.Input;

namespace Epiphany.ViewModel.Commands
{
    sealed class LikeOnFacebookCommand : Command
    {
        private readonly IUrlLauncher urlLauncher;
        private readonly string url = "www.facebook.com/epiphanywp";

        public LikeOnFacebookCommand(IUrlLauncher launcher)
        {
            this.urlLauncher = launcher;
        }

        protected override bool CanExecute()
        {
            return true;
        }

        protected override void Run()
        {
            this.urlLauncher.Launch(url);
        }
    }
}
