using Epiphany.Logging;
using Epiphany.Model;
using Epiphany.ViewModel.Services;
using System;

namespace Epiphany.ViewModel.Items
{
    public sealed class FeedItemViewModel : ItemViewModel<FeedItemModel>, IFeedItemViewModel
    {
        private readonly IResourceLoader resourceLoader;
        private IUserItemViewModel friend;
        private IBookItemViewModel book;
        private string actionText;
        private int percentageCompleted = -1;
        private int rating = -1;

        private const string FriendFeedItemActionTextKey = "FriendFeedItemActionText";
        private const string UserStatusFeedItemActionTextKey = "UserStatusFeedItemActionText";
        private const string UserStatusFeedItemFinishedActionTextKey = "UserStatusFeedItemFinishedActionText";
        private const string ReviewFeedItemActionTextKey = "ReviewFeedItemActionText";
        private const string ReadStatusFeedItemToReadActionTextKey = "ReadStatusFeedItemToReadActionText";
        private const string ReadStatusFeedItemHasReadActionTextKey = "ReadStatusFeedItemHasReadActionText";
        private const string ReadStatusFeedItemCurrentlyReadingActionTextKey = "ReadStatusFeedItemCurrentlyReadingActionText";
        private const string CommentFeedItemActionTextKey = "CommentFeedItemActionText";

        public FeedItemViewModel(FeedItemModel model, IResourceLoader resourceLoader) 
            : base (model)
        {
            if (resourceLoader == null)
            {
                throw new ArgumentNullException("services");
            }

            this.resourceLoader = resourceLoader;
            
            InitializeProperties();
        }

        public long Id
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
                SetProperty(ref this.friend, value);
            }
        }

        public IBookItemViewModel Book
        {
            get { return this.book; }
            private set
            {
                SetProperty(ref this.book, value);
            }

        }

        public string ActionText
        {
            get { return this.actionText; }
            private set
            {
                SetProperty(ref this.actionText, value);
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

        public int PercentageCompleted
        {
            get
            {
                return this.percentageCompleted;
            }
            private set
            {
                SetProperty(ref this.percentageCompleted, value);
            }
        }

        public int Rating
        {
            get
            {
                return this.rating;
            }
            private set
            {
                SetProperty(ref this.rating, value);
            }
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
                case FeedItemType.UserChallenge:
                    {
                        var userChallengeFeedItem = Item as UserChallengeFeedItemModel;
                        ActionText = $"{userChallengeFeedItem.User.Name} {userChallengeFeedItem.ActionText}";
                        break;
                    }
                default:
                    {
                        Logger.LogWarn($"Unknown FeedItemType {Item.ItemType} found");
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

            actionText = string.Format(resourceLoader.GetString(ReviewFeedItemActionTextKey), User.Name, reviewFeedItem.Rating);

            Rating = reviewFeedItem.Rating;

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

            PercentageCompleted = userStatusFeedItem.Percentage;

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
