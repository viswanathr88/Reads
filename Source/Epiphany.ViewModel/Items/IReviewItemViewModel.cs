using System.ComponentModel;

namespace Epiphany.ViewModel.Items
{
    public interface IReviewItemViewModel : INotifyPropertyChanged
    {
        IUserItemViewModel User
        {
            get;
        }

        int Rating
        {
            get;
        }

        string Body
        {
            get;
        }
    }
}
