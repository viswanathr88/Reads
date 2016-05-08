using System;
using System.Windows.Input;
using Epiphany.Model;
using Epiphany.ViewModel.Commands;

namespace Epiphany.ViewModel.Items
{
    public interface IFeedItemViewModel
    {
        string ActionText { get; }
        string Body { get; }
        IBookItemViewModel Book { get; }
        IUserItemViewModel Friend { get; }
        int Id { get; }
        string ImageUrl { get; }
        ICommand<IAuthorItemViewModel> ShowAuthor { get; }
        ICommand<IBookItemViewModel> ShowBook { get; }
        ICommand<IUserItemViewModel> ShowProfile { get; }
        ICommand ShowReview { get; }
        FeedItemType Type { get; }
        DateTime UpdateTime { get; }
        IUserItemViewModel User { get; }
        int PercentageCompleted { get; }
        int Rating { get; }
    }
}