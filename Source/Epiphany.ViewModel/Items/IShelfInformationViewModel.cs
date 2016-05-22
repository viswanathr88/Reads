using Windows.UI;

namespace Epiphany.ViewModel.Items
{
    public interface IShelfInformationViewModel
    {
        string Name
        {
            get;
        }

        int Count
        {
            get;
        }

        Color Color
        {
            get;
        }

        Color Foreground
        {
            get;
        }
    }
}
