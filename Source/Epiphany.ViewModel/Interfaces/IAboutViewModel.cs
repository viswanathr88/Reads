using System.ComponentModel;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public interface IAboutViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Like on facebook command
        /// </summary>
        ICommand LikeOnFacebook
        {
            get;
        }
        /// <summary>
        /// Rate app command
        /// </summary>
        ICommand RateApp
        {
            get;
        }
    }
}
