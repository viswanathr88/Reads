using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public interface ICommunityViewModel : IDataViewModel
    {
        ILazyObservableCollection<IReviewItemViewModel> Items { get; }

        bool IsEmpty { get; }

        ICommand Refresh
        {
            get;
        }
    }
}
