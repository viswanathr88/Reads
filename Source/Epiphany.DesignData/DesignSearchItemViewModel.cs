using Epiphany.ViewModel.Items;

namespace Epiphany.View.DesignData
{
    public sealed class DesignSearchItemViewModel : ISearchResultItemViewModel
    {
        public IBookItemViewModel Book { get; set; }

        public IAuthorItemViewModel Author { get; set; }
    }
}
