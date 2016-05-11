using Epiphany.Model;
using System;

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
        FeedItemType Type { get; }
        DateTime UpdateTime { get; }
        IUserItemViewModel User { get; }
        int PercentageCompleted { get; }
        int Rating { get; }
    }
}