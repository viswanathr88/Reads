using Epiphany.Model.Authentication;
using Epiphany.Model.Services;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public sealed class HomeViewModel : DataViewModel<VoidType>, IHomeViewModel
    {
        private readonly ILogonService logonService;

        private IFeedViewModel feedViewModel;
        private ILauncherViewModel launcherVM;
        private IBookshelvesViewModel bookshelvesVM;
        private ICommunityViewModel communityVM;

        private bool isLoggedIn;
        private double opacity = 0;

        public HomeViewModel(IFeedViewModel feedVM, IBookshelvesViewModel shelvesVM, 
            ICommunityViewModel communityVM, ILogonService logonService)
        {
            Feed = feedVM;
            Books = shelvesVM;
            Community = communityVM;
            Launcher = new LauncherViewModel(null, logonService);
            this.logonService = logonService;

            IsLoggedIn = (this.logonService.Session != null);
            Opacity = IsLoggedIn ? 0 : 0.15;

            Feed.PropertyChanged += OnChildVMPropertyChanged;
            this.logonService.SessionChanged += LogonService_SessionChanged;
        }

        public int NewNotificationCount
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsLoggedIn
        {
            get
            {
                return this.isLoggedIn;
            }
            private set
            {
                SetProperty(ref this.isLoggedIn, value);
            }
        }

        public double Opacity
        {
            get
            {
                return this.opacity;
            }
            private set
            {
                SetProperty(ref this.opacity, value);
            }
        }

        public IFeedViewModel Feed
        {
            get
            {
                return this.feedViewModel;
            }
            private set
            {
                SetProperty(ref this.feedViewModel, value);
            }
        }

        public ILauncherViewModel Launcher
        {
            get
            {
                return this.launcherVM;
            }
            private set
            {
                SetProperty(ref this.launcherVM, value);
            }
        }

        public IBookshelvesViewModel Books
        {
            get
            {
                return this.bookshelvesVM;
            }
            private set
            {
                SetProperty(ref this.bookshelvesVM, value);
            }
        }

        public ICommunityViewModel Community
        {
            get
            {
                return this.communityVM;
            }
            private set
            {
                SetProperty(ref this.communityVM, value);
            }
        }

        public override async Task LoadAsync(VoidType parameter)
        {
            if (IsLoggedIn && !IsLoaded)
            {
                IsLoading = true;

                // Start loading your feed but not await
                Task feedLoadTask = Feed.LoadAsync(parameter);

                // This should finish quickly as it is just creating the collection
                await Books.LoadAsync(int.Parse(this.logonService.Session.UserId));

                // Wait for the feed task to finish
                await feedLoadTask;

                IsLoading = false;
                IsLoaded = true;
            }
        }

        private void OnChildVMPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IsLoading))
            {
                IsLoading = Feed.IsLoading;
            }
            else if (e.PropertyName == nameof(IsLoaded))
            {
                IsLoaded = Feed.IsLoaded;
            }
        }

        private void LogonService_SessionChanged(object sender, SessionChangedEventArgs e)
        {
            if (e.Session != null)
            {
                IsLoggedIn = true;
                IsLoaded = false;
                Opacity = 0;
            }
            else
            {
                IsLoggedIn = false;
                Opacity = 0.15;
            }
        }
    }
}
