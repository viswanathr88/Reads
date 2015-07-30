
namespace Epiphany.ViewModel.Services
{
    public interface INavigationService
    {
        bool CanGoBack
        {
            get;
        }

        void GoBack();

        void GoBackAll();

        INavigationOperation<TViewModel> CreateFor<TViewModel>() where TViewModel : ViewModelBase;

        void Navigate(string uri);
    }
}
