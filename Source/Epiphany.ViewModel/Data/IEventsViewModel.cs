using System.Collections.Generic;
using System.Windows.Input;
using Epiphany.Model;

namespace Epiphany.ViewModel
{
    public interface IEventsViewModel : IDataViewModel
    {
        IList<LiteraryEventModel> Events { get; }
        IAsyncCommand<IEnumerable<LiteraryEventModel>, VoidType> FetchEvents { get; }
        ICommand Refresh { get; }
        LiteraryEventModel SelectedEvent { get; set; }
    }
}