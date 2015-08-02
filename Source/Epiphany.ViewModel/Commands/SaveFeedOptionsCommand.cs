
using Epiphany.ViewModel.Services;
namespace Epiphany.ViewModel.Commands
{
    sealed class SaveFeedOptionsCommand : Command<FeedOptions>
    {
        private readonly IAppSettings appSettings;
        private readonly INavigationService navigationService;

        public SaveFeedOptionsCommand(IAppSettings appSettings, INavigationService navigationService)
        {
            this.appSettings = appSettings;
            this.navigationService = navigationService;
        }

        public override bool CanExecute(FeedOptions param)
        {
            return appSettings.UpdateType != param.UpdateType ||
                appSettings.UpdateFilter != param.UpdateFilter;
        }

        protected override void Run(FeedOptions param)
        {
            appSettings.UpdateType = param.UpdateType;
            appSettings.UpdateFilter = param.UpdateFilter;

            if (this.navigationService.CanGoBack)
            {
                this.navigationService.GoBack();
            }
        }
    }
}
