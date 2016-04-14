
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

        INavigationOperation<TViewModel> CreateFor<TViewModel>() where TViewModel : IDataViewModel;

        void Navigate(string uri);

        void Navigate<TViewModel>(object parameter) where TViewModel : IDataViewModel;
    }
}
