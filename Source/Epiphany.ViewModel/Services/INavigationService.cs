
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

        INavigationOperation<TViewModel> CreateFor<TViewModel>();

        void Navigate(string uri);
    }
}
