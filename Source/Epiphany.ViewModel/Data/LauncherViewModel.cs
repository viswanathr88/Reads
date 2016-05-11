using Epiphany.Model.Authentication;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public sealed class LauncherViewModel : DataViewModel<VoidType>, ILauncherViewModel
    {
        private readonly INavigationService navService;
        private readonly ILogonService logonService;

        public LauncherViewModel(INavigationService navService, ILogonService logonService)
        {
            /*if (navService == null)
            {
                throw new ArgumentNullException("navService");
            }*/

            if (logonService == null)
            {
                throw new ArgumentNullException("logonService");
            }

            this.navService = navService;
            this.logonService = logonService;
        }

        public ICommand<Session> ShowProfile
        {
            get
            {
                return new ShowProfileCommand(this.navService);
            }
        }

        public ICommand<Session> ShowBookshelves
        {
            get
            {
                return new ShowBookshelvesCommand(this.navService);
            }
        }

        public ICommand<Session> ShowFriends
        {
            get
            {
                return new ShowFriendsCommand(this.navService);
            }
        }

        public ICommand<Session> ShowGroups
        {
            get
            {
                return new ShowGroupsCommand(this.navService);
            }
        }

        public ICommand ShowSearch
        {
            get
            {
                return new ShowSearchCommand(this.navService);
            }
        }

        public ICommand ShowEvents
        {
            get
            {
                return new ShowEventsCommand(this.navService);
            }
        }

        public Session CurrentSession
        {
            get
            {
                return this.logonService.Session;
            }
        }

        public override Task LoadAsync(VoidType parameter)
        {
            throw new NotImplementedException();
        }
    }
}
