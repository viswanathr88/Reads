using Epiphany.Model;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public interface IFeedViewModel : INotifyPropertyChanged, IDisposable
    {
        IList<IFeedItemViewModel> Feed
        {
            get;
        }

        bool IsFeedEmpty
        {
            get;
        }

        bool IsFilterEnabled
        {
            get;
        }

        ICommand<IEnumerable<FeedItemModel>, VoidType> FetchFeed
        {
            get;
        }

        ICommand ShowOptions
        {
            get;
        }

        IFeedOptionsViewModel FeedOptionsViewModel
        {
            get;
        }
    }
}
