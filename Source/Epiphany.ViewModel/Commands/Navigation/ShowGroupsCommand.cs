using Epiphany.Model.Authentication;
using Epiphany.ViewModel.Services;

namespace Epiphany.ViewModel.Commands
{
    sealed class ShowGroupsCommand : Command<Session>
    {
        private readonly INavigationService navService;

        public ShowGroupsCommand(INavigationService navService)
        {
            this.navService = navService;
        }

        public override bool CanExecute(Session session)
        {
            return !string.IsNullOrEmpty(session.Name) &&
                !string.IsNullOrEmpty(session.UserId);
        }

        protected override void Run(Session session)
        {
            int userId = int.Parse(session.UserId);
            this.navService.CreateFor<IGroupsViewModel>()
                .AddParam<int>((x) => x.Id, userId)
                .AddParam<string>((x) => x.Name, session.Name)
                .Navigate();
        }
    }
}
