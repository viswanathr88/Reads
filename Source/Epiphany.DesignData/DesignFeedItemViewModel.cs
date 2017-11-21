using Epiphany.Model;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Items;
using System;
using System.Windows.Input;

namespace Epiphany.View.DesignData
{
    public sealed class DesignFeedItemViewModel : IFeedItemViewModel
    {
        public long Id
        {
            get;
            set;
        }

        public FeedItemType Type
        {
            get;
            set;
        }

        public IUserItemViewModel User
        {
            get;
            set;
        }

        public IUserItemViewModel Friend
        {
            get;
            set;
        }

        public IBookItemViewModel Book
        {
            get;
            set;
        }

        public string ActionText
        {
            get;
            set;
        }

        public string Body
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;
        }

        public DateTime UpdateTime
        {
            get;
            set;
        }

        public int PercentageCompleted
        {
            get;
            set;
        }

        public int Rating
        {
            get;
            set;
        }

        public ICommand<IUserItemViewModel> ShowProfile
        {
            get { return null; }
        }

        public ICommand<IBookItemViewModel> ShowBook
        {
            get { return null; }
        }

        public ICommand<IAuthorItemViewModel> ShowAuthor
        {
            get { return null; }
        }

        public ICommand ShowReview
        {
            get { return null; }
        }
    }
}
