using System.Threading.Tasks;
using System.Windows.Input;
using Epiphany.Model.Services;
using Epiphany.ViewModel.Commands;

namespace Epiphany.ViewModel
{
    public interface IFeedOptionsViewModel
    {
        ICommand Cancel { get; }
        FeedUpdateFilter CurrentUpdateFilter { get; set; }
        FeedUpdateType CurrentUpdateType { get; set; }
        FeedOptions FeedOptions { get; }
        ICommand<FeedOptions> SaveOptions { get; }

        Task LoadAsync(VoidType parameter);
    }
}