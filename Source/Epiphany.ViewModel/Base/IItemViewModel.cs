using System.ComponentModel;

namespace Epiphany.ViewModel
{
    public interface IItemViewModel : INotifyPropertyChanged
    {
        bool IsSelected
        {
            get;
            set;
        }

        object Item
        {
            get;
        }
    }

    public interface IItemViewModel<TModel> : IItemViewModel
    {
        new TModel Item
        {
            get;
        }
    }
}
