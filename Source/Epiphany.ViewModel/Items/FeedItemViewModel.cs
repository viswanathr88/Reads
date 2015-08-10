using Epiphany.Logging;
using Epiphany.Model;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Services;
using System;
using System.Windows.Input;

namespace Epiphany.ViewModel.Items
{
    public class FeedItemViewModel : ItemViewModel<FeedItemModel>, IFeedItemViewModel
    {
        private readonly INavigationService navService;
        private readonly IResourceLoader resourceLoader;
        private IUserItemViewModel friend;
        private IBookItemViewModel book;
        private string actionText;

        private readonly ICommand<IUserItemViewModel> showProfileCommand;
        private readonly ICommand<IBookItemViewModel> showBookCommand;
        private readonly ICommand<IAuthorItemViewModel> showAuthorCommand;

        private const string FriendFeedItemActionTextKey = "FriendFeedItemActionText";
        private const string UserStatusFeedItemActionTextKey = "UserStatusFeedItemActionText";
        private const string UserStatusFeedItemFinishedActionTextKey = "UserStatusFeedItemFinishedActionText";
        private const string ReviewFeedItemOneStarRatingActionTextKey = "ReviewFeedItemOneStarRatingActionText";
        private const string ReviewFeedItemNStarRatingActionTextKey = "ReviewFeedItemNStarRatingActionText";
        private const string ReadStatusFeedItemToReadActionTextKey = "ReadStatusFeedItemToReadActionText";
        private const string ReadStatusFeedItemHasReadActionTextKey = "ReadStatusFeedItemHasReadActionText";
        private const string ReadStatusFeedItemCurrentlyReadingActionTextKey = "ReadStatusFeedItemCurrentlyReadingActionText";
        private const string CommentFeedItemActionTextKey = "CommentFeedItemActionText";

        public FeedItemViewModel(FeedItemModel model, INavigationService navService, IResourceLoader resourceLoader) 
            : base (model)
        {
            if (navService == null || resourceLoader == null)
            {
                throw new ArgumentNullException("services");
            }

            this.navService = navService;
            this.resourceLoader = resourceLoader;

            this.showProfileCommand = new ShowProfileFromItemCommand(this.navService);
            this.showBookCommand = new ShowBookFromItemCommand(this.navService);
            this.showAuthorCommand = new ShowAuthorFromItemCommand(this.navService);
            
            InitializeProperties();
        }

        public int Id
        {
            get { return this.Item.Id; }
        }

        public FeedItemType Type
        {
            get { return this.Item.ItemType; }
        }

        public IUserItemViewModel User
        {
            get { return new UserItemViewModel(this.Item.User); }
        }

        public IUserItemViewModel Friend
        {
            get { return this.friend; }
            private set
            {
                if (this.friend == value) return;
                this.friend = value;
                RaisePropertyChanged();
            }
        }

        public IBookItemViewModel Book
        {
            get { return this.book; }
            private set
            {
                if (this.book == value) return;
                this.book = value;
                RaisePropertyChanged();
            }

        }

        public string ActionText
        {
            get { return this.actionText; }
            private set
            {
                if (this.actionText == value) return;
                this.actionText = value;
                RaisePropertyChanged();
            }
        }

        public string Body
        {
            get { return this.Item.Body; }
        }

        public string ImageUrl
        {
            get { return this.Item.ImageUrl; }
        }

        public DateTime UpdateTime
        {
            get { return this.Item.UpdateTime; }
        }

        public ICommand<IUserItemViewModel> ShowProfile
        {
            get { return this.showProfileCommand; }
        }

        public ICommand<IBookItemViewModel> ShowBook
        {
            get { return this.showBookCommand; }
        }

        public ICommand<IAuthorItemViewModel> ShowAuthor
        {
            get { return this.showAuthorCommand; }
        }

        public ICommand ShowReview
        {
            get { return null; }
        }

        private void InitializeProperties()
        {
            switch (Item.ItemType)
            {
                case FeedItemType.Friend:
                    {
                        var friendFeedItem = Item as FriendFeedItemModel;
                        Friend = new UserItemViewModel(friendFeedItem.Friend);
                        ActionText = string.Format(this.resourceLoader.GetString(FriendFeedItemActionTextKey), User.Name);
                        break;
                    }
                case FeedItemType.Review:
                    {
                        var reviewFeedItem = Item as ReviewFeedItemModel;
                        Book = new BookItemViewModel(reviewFeedItem.Book);
                        
                        string format = (reviewFeedItem.Book.UserReview.Rating > 1) ?
                            ReviewFeedItemNStarRatingActionTextKey :
                            ReviewFeedItemOneStarRatingActionTextKey;

                        ActionText = string.Format(format, User.Name);
                        break;
                    }
                case FeedItemType.Comment:
                    {
                        ActionText = string.Format(CommentFeedItemActionTextKey, User.Name);
                        break;
                    }
                case FeedItemType.ReadStatus:
                    {
                        var readStatusFeedItem = Item as ReadStatusFeedItemModel;
                        Book = new BookItemViewModel(readStatusFeedItem.Book);
                        ActionText = GetActionText(readStatusFeedItem);
                        break;
                    }
                case FeedItemType.UserStatus:
                    {
                        var userStatusFeedItem = Item as UserStatusFeedItemModel;
                        ActionText = GetActionText(userStatusFeedItem);
                        break;
                    }
                default:
                    {
                        Log.Instance.Warn("Unknown FeedItemType found");
                        break;
                    }
            }
        }

        private string GetActionText(UserStatusFeedItemModel userStatusFeedItem)
        {
            string actionText = string.Empty;

            if (userStatusFeedItem.Percentage == 100)
            {
                actionText = string.Format(UserStatusFeedItemFinishedActionTextKey, User.Name);
            }
            else
            {
                actionText = string.Format(UserStatusFeedItemActionTextKey, User.Name, 
                    userStatusFeedItem.Page, userStatusFeedItem.Book.NumberOfPages);
            }

            return actionText;
        }

        private string GetActionText(ReadStatusFeedItemModel readStatusFeedItem)
        {
            string format = string.Empty;
            
            if (readStatusFeedItem.Status == "currently-reading")
            {
                format = ReadStatusFeedItemCurrentlyReadingActionTextKey;
            }
            else if (readStatusFeedItem.Status == "to-read")
            {
                format = ReadStatusFeedItemToReadActionTextKey;
            }
            else
            {
                format = ReadStatusFeedItemHasReadActionTextKey;
            }

            return string.Format(format, User.Name);
        }
        
    }
}
