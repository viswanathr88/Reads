using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public interface IAboutViewModel
    {
        ICommand LikeOnFacebook { get; }
        ICommand RateApp { get; }
    }
}