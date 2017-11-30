using Epiphany.Model;
using Epiphany.Model.Authentication;
using Epiphany.Model.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public sealed class HomeViewModel : DataViewModel<string>, IHomeViewModel
    {
        private readonly ILogonService logonService;

        private IFeedViewModel feedViewModel;
        private ILauncherViewModel launcherVM;
        private IMyBooksViewModel booksVM;
        private ICommunityViewModel communityVM;
        private IEventsViewModel eventsVM;

        private bool isLoggedIn;
        private double opacity = 0;

        public HomeViewModel(IFeedViewModel feedVM, IMyBooksViewModel booksVm, 
            ICommunityViewModel communityVM, IEventsViewModel eventsVM, ILogonService logonService)
        {
            Feed = feedVM;
            Books = booksVm;
            Community = communityVM;
            Events = eventsVM;
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

        public IMyBooksViewModel Books
        {
            get
            {
                return this.booksVM;
            }
            private set
            {
                SetProperty(ref this.booksVM, value);
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

        public UserModel CurrentlyLoggedInUser
        {
            get
            {
                UserModel model = null;
                if (this.logonService.Session != null)
                {
                    int id = int.Parse(this.logonService.Session.UserId);
                    model = new UserModel(id)
                    {
                        Name = this.logonService.Session.Name
                    };
                }
                return model;
            }
        }

        public IEventsViewModel Events
        {
            get
            {
                return this.eventsVM;
            }
            private set
            {
                SetProperty(ref this.eventsVM, value);
            }
        }

        public override async Task LoadAsync(string parameter)
        {
            IsLoading = true;

            IList<Task> tasks = new List<Task>();
            if (IsLoggedIn)
            {
                // Start loading your feed but not await
                tasks.Add(Feed.LoadAsync(VoidType.Empty, true));

                // This should finish quickly as it is just creating the collection
                tasks.Add(Books.LoadAsync(int.Parse(this.logonService.Session.UserId), true));
            }

            // Load the community reviews
            tasks.Add(Community.LoadAsync(VoidType.Empty, true));

            // Wait for all tasks to finish
            await Task.WhenAll(tasks);

            IsLoading = false;
            IsLoaded = true;
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
