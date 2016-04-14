using Epiphany.Logging;
using Epiphany.Model;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Services;
using System;
using System.Windows.Input;

namespace Epiphany.ViewModel.Items
{
    public class FeedItemViewModel : ItemViewModel<FeedItemModel>
    {
        private readonly INavigationService navService;
        private readonly IResourceLoader resourceLoader;
        private UserItemViewModel friend;
        private BookItemViewModel book;
        private string actionText;

        private readonly ICommand<UserItemViewModel> showProfileCommand;
        private readonly ICommand<BookItemViewModel> showBookCommand;
        private readonly ICommand<AuthorItemViewModel> showAuthorCommand;

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

        public UserItemViewModel User
        {
            get { return new UserItemViewModel(this.Item.User); }
        }

        public UserItemViewModel Friend
        {
            get { return this.friend; }
            private set
            {
                if (this.friend == value) return;
                this.friend = value;
                RaisePropertyChanged();
            }
        }

        public BookItemViewModel Book
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

        public ICommand<UserItemViewModel> ShowProfile
        {
            get { return this.showProfileCommand; }
        }

        public ICommand<BookItemViewModel> ShowBook
        {
            get { return this.showBookCommand; }
        }

        public ICommand<AuthorItemViewModel> ShowAuthor
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
                        ActionText = GetActionText(reviewFeedItem);
                        break;
                    }
                case FeedItemType.Comment:
                    {
                        ActionText = string.Format(resourceLoader.GetString(CommentFeedItemActionTextKey), User.Name);
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
                        Book = new BookItemViewModel(userStatusFeedItem.Book);
                        ActionText = GetActionText(userStatusFeedItem);
                        break;
                    }
                default:
                    {
                        Logger.LogWarn("Unknown FeedItemType found");
                        break;
                    }
            }
        }

        private string GetActionText(ReviewFeedItemModel reviewFeedItem)
        {
            string actionText = string.Empty;

            if (reviewFeedItem.Rating < 0 || reviewFeedItem.Rating > 5)
            {
                throw new ArgumentOutOfRangeException("reviewFeedItem.Rating");
            }

            if (reviewFeedItem.Rating == 1)
            {
                actionText = string.Format(resourceLoader.GetString(ReviewFeedItemOneStarRatingActionTextKey), User.Name);
            }
            else
            {
                actionText = string.Format(resourceLoader.GetString(ReviewFeedItemNStarRatingActionTextKey), User.Name, reviewFeedItem.Rating);
            }

            return actionText;
        }

        private string GetActionText(UserStatusFeedItemModel userStatusFeedItem)
        {
            string actionText = string.Empty;

            if (userStatusFeedItem.Percentage == 100)
            {
                actionText = string.Format(resourceLoader.GetString(UserStatusFeedItemFinishedActionTextKey), User.Name);
            }
            else
            {
                actionText = string.Format(resourceLoader.GetString(UserStatusFeedItemActionTextKey), User.Name, 
                    userStatusFeedItem.Page, userStatusFeedItem.Book.NumberOfPages);
            }

            return actionText;
        }

        private string GetActionText(ReadStatusFeedItemModel readStatusFeedItem)
        {
            string formatKey = string.Empty;
            
            if (readStatusFeedItem.Status == "currently-reading")
            {
                formatKey = ReadStatusFeedItemCurrentlyReadingActionTextKey;
            }
            else if (readStatusFeedItem.Status == "to-read")
            {
                formatKey = ReadStatusFeedItemToReadActionTextKey;
            }
            else
            {
                formatKey = ReadStatusFeedItemHasReadActionTextKey;
            }

            return string.Format(resourceLoader.GetString(formatKey), User.Name);
        }
        
    }
}
