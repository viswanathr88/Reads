using System;
using System.Windows.Input;
namespace Epiphany.ViewModel
{
    public interface IAboutViewModel : IDataViewModel
    {
        /// <summary>
        /// Like the app on Facebook
        /// </summary>
        ICommand LikeOnFacebook { get; }
        /// <summary>
        /// Rate the app on the store
        /// </summary>
        ICommand RateApp { get; }
    }
}
