using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public interface IFeedOptionsViewModel : INotifyPropertyChanged, IDisposable
    {
        FeedUpdateType CurrentUpdateType
        {
            get;
            set;
        }

        FeedUpdateFilter CurrentUpdateFilter
        {
            get;
            set;
        }

        FeedOptions FeedOptions
        {
            get;
        }

        ICommand<VoidType, FeedOptions> SaveOptions
        {
            get;
        }

        ICommand Cancel
        {
            get;
        }
    }
}
