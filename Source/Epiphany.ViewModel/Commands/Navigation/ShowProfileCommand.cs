using Epiphany.Model;
using Epiphany.Model.Authentication;
using Epiphany.ViewModel.Services;

namespace Epiphany.ViewModel.Commands
{
    sealed class ShowProfileCommand : Command<Session>
    {
        private readonly INavigationService navService;

        public ShowProfileCommand(INavigationService navService)
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
            this.navService.CreateFor<IProfileViewModel>()
                .AddParam<int>((x) => x.Id, userId)
                .AddParam<string>((x) => x.Name, session.Name)
                .Navigate();
        }
    }

    sealed class ShowProfileForUserCommand : Command<UserModel>
    {
        private readonly INavigationService navService;

        public ShowProfileForUserCommand(INavigationService navService)
        {
            this.navService = navService;
        }
        public override bool CanExecute(UserModel user)
        {
            return user.Id >= 0;
        }

        protected override void Run(UserModel user)
        {
            this.navService.CreateFor<IProfileViewModel>()
                .AddParam<int>((x) => x.Id, user.Id)
                .AddParam<string>((x) => x.Name, user.Name)
                .Navigate();
        }
    }

}
