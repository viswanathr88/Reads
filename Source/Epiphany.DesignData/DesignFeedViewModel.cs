using Epiphany.Model;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Epiphany.View.DesignData
{
    public sealed class DesignFeedViewModel : DataViewModel, IFeedViewModel
    {
        public DesignFeedViewModel()
        {
            IsFeedEmpty = false;
            Feed = new ObservableCollection<IFeedItemViewModel>();

            /*Feed.Add(new DesignFeedItemViewModel()
            {
                Type = FeedItemType.Friend,
                ActionText = "MyNameIsX is now friends with:",
                UpdateTime = new DateTime(2015, 6, 15),
                Friend = new DesignUserItemViewModel() 
                {
                    Name = "MyNameIsY",
                    ImageUrl = @"http://www.photonicconference.com/Phosphors/media/Examples/male-placeholder.png"
                },
                User = new DesignUserItemViewModel()
                {
                    Name = "MyNameIsX",
                    ImageUrl = @"http://www.photonicconference.com/Phosphors/media/Examples/male-placeholder.png"
                }
            });

            Feed.Add(new DesignFeedItemViewModel()
            {
                Type = FeedItemType.UserStatus,
                ActionText = "X is on page 15 of 50 of:",
                UpdateTime = new DateTime(2014, 7, 15),
                User = new DesignUserItemViewModel()
                {
                    Name = "MyNameIsX",
                    ImageUrl = @"http://www.photonicconference.com/Phosphors/media/Examples/male-placeholder.png"
                },
                Book = new DesignBookItemViewModel() 
                {
                    Title = "Test Book",
                    MainAuthor = new DesignAuthorItemViewModel() 
                    {
                        Name = "Test Author"
                    }
                }
            });*/

            Feed.Add(new DesignFeedItemViewModel()
            {
                Type = FeedItemType.ReadStatus,
                ActionText = "X is currently reading:",
                UpdateTime = new DateTime(2015, 7, 15),
                User = new DesignUserItemViewModel()
                {
                    Name = "MyNameIsX",
                    ImageUrl = @"http://www.photonicconference.com/Phosphors/media/Examples/male-placeholder.png"
                },
                Book = new DesignBookItemViewModel()
                {
                    Title = "Test Book",
                    ImageUrl = @"http://history.fas.nyu.edu/docs/IO/1555/PlaceholderBook.png",
                    MainAuthor = new DesignAuthorItemViewModel()
                    {
                        Name = "Test Author"
                    }
                }
            });

            Feed.Add(new DesignFeedItemViewModel()
            {
                Type = FeedItemType.Review,
                ActionText = "X gave 4 stars to:",
                UpdateTime = new DateTime(2015, 7, 15),
                User = new DesignUserItemViewModel()
                {
                    Name = "MyNameIsX",
                    ImageUrl = @"http://www.photonicconference.com/Phosphors/media/Examples/male-placeholder.png"
                },
                Book = new DesignBookItemViewModel()
                {
                    Title = "Test Book",
                    ImageUrl = @"http://history.fas.nyu.edu/docs/IO/1555/PlaceholderBook.png",
                    MainAuthor = new DesignAuthorItemViewModel()
                    {
                        Name = "Test Author"
                    }
                },
                Body = "lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum"
            });

        }
        public IList<IFeedItemViewModel> Feed
        {
            get;
            set;
        }

        public IFeedOptionsViewModel FeedOptionsViewModel
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsFeedEmpty
        {
            get;
            set;
        }

        public bool IsFilterEnabled
        {
            get;
            set;
        }

        public ICommand ShowOptions
        {
            get { return null; }
        }

        public IAsyncCommand<IEnumerable<FeedItemModel>, VoidType> FetchFeed
        {
            get { return null; }
        }

        public override Task LoadAsync()
        {
            return Task.FromResult(true);
        }
    }
}
