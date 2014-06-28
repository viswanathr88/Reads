using Epiphany.ViewModel.Services;
using System.Windows.Input;

namespace Epiphany.ViewModel.Commands
{
    class RateAppCommand : ICommand
    {
        private readonly IAppRateService service;

        public RateAppCommand(IAppRateService service)
        {
            this.service = service;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event System.EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            service.RateApp();

        }
    }
}
