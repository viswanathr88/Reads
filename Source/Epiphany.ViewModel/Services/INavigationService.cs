
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

        void Navigate<TViewModel, TParam>(TParam param) where TViewModel : DataViewModel<TParam>;

        INavigationOperation<TViewModel> CreateFor<TViewModel>() where TViewModel : IDataViewModel;

        void Navigate(string uri);
    }
}
