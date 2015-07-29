using Epiphany.ViewModel.Services;
using System;
using System.Windows.Input;

namespace Epiphany.ViewModel.Commands
{
    class LikeOnFacebookCommand : ICommand
    {
        private readonly IUrlLauncher urlLauncher;
        private readonly string url = "www.facebook.com/epiphanywp";

        public LikeOnFacebookCommand(IUrlLauncher launcher)
        {
            this.urlLauncher = launcher;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.urlLauncher.Launch(url);
        }

        private void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
