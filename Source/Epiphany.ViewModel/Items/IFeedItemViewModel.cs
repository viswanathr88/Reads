using Epiphany.Model;
using Epiphany.ViewModel.Commands;
using System;
using System.Windows.Input;

namespace Epiphany.ViewModel.Items
{
    public interface IFeedItemViewModel
    {
        int Id { get; }

        FeedItemType Type { get; }

        IUserItemViewModel User { get; }

        IUserItemViewModel Friend { get; }

        IBookItemViewModel Book { get; }

        string ActionText { get; }

        string Body { get; }

        string ImageUrl { get; }

        DateTime UpdateTime { get; }

        ICommand<IUserItemViewModel> ShowProfile { get; }

        ICommand<IBookItemViewModel> ShowBook { get; }

        ICommand<IAuthorItemViewModel> ShowAuthor { get; }

        ICommand ShowReview { get; }
    }
}
