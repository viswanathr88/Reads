using System.Collections.Generic;
using System.Windows.Input;
using Epiphany.Model;
using Epiphany.ViewModel.Items;

namespace Epiphany.ViewModel
{
    public interface IEventsViewModel : IDataViewModel
    {
        IList<IEventItemViewModel> Events { get; }
        IAsyncCommand<IEnumerable<LiteraryEventModel>, VoidType> FetchEvents { get; }
        ICommand Refresh { get; }
        LiteraryEventModel SelectedEvent { get; set; }
    }
}