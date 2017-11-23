using Epiphany.Model;
using Epiphany.ViewModel.Commands;
using System;
using System.Windows.Input;

namespace Epiphany.ViewModel.Items
{
    public interface IFeedItemViewModel
    {
        string ActionText { get; }
        string Body { get; }
        IBookItemViewModel Book { get; }
        IUserItemViewModel Friend { get; }
        long Id {get; }
        string ImageUrl { get; }
        FeedItemType Type { get; }
        DateTime UpdateTime { get; }
        IUserItemViewModel User { get; }
        int PercentageCompleted { get; }
        int Rating { get; }
        IAsyncCommand<VoidType> Like { get; }
        ICommand Comment { get; }
        ICommand ViewInBrowser { get; }
    }
}