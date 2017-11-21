using Epiphany.ViewModel.Items;
using System.Collections.Generic;

namespace Epiphany.ViewModel
{
    public interface ICommunityViewModel : IDataViewModel
    {
        IList<IReviewItemViewModel> Items { get; }

        bool IsEmpty { get; }
    }
}
