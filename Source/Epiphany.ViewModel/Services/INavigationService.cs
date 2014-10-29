
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
    }
}
