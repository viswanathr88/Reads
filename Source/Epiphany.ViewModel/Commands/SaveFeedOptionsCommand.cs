
using Epiphany.Model.Settings;
using Epiphany.ViewModel.Services;
namespace Epiphany.ViewModel.Commands
{
    sealed class SaveFeedOptionsCommand : Command<FeedOptions>
    {
        private readonly INavigationService navigationService;

        public SaveFeedOptionsCommand(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public override bool CanExecute(FeedOptions param)
        {
            return ApplicationSettings.Instance.UpdateType != param.UpdateType ||
                ApplicationSettings.Instance.UpdateFilter != param.UpdateFilter;
        }

        protected override void Run(FeedOptions param)
        {
            ApplicationSettings.Instance.UpdateType = param.UpdateType;
            ApplicationSettings.Instance.UpdateFilter = param.UpdateFilter;

            if (this.navigationService.CanGoBack)
            {
                this.navigationService.GoBack();
            }
        }
    }
}
