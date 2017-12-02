using Epiphany.ViewModel;
using System.ComponentModel;
using System;

namespace Epiphany.View.DesignData
{
    public abstract class DesignBaseItemViewModel<T> : ViewModelBase, IItemViewModel<T>
    {
        public bool IsSelected
        {
            get;
            set;
        }

        public T Item
        {
            get;
            set;
        }

        object IItemViewModel.Item
        {
            get
            {
                return Item;
            }
        }
    }

    public abstract class DesignBaseItemViewModel : ViewModelBase, IItemViewModel
    {
        public bool IsSelected
        {
            get;
            set;
        }

        public object Item
        {
            get;
            set;
        }
    }
}
