using System;

namespace Epiphany.ViewModel
{
    public class ItemViewModel<T> : ViewModelBase, IItemViewModel<T>
    {
        private T item;
        private bool isSelected;
        private bool isLoading;

        public ItemViewModel(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            this.item = item;
        }
        public T Item
        {
            get
            {
                return this.item;
            }
        }

        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }
            set
            {
                SetProperty(ref this.isSelected, value);
            }
        }

        public bool IsLoading
        {
            get
            {
                return this.isLoading;
            }
            protected set
            {
                SetProperty(ref this.isLoading, value);
            }
        }

        object IItemViewModel.Item
        {
            get
            {
                return Item;
            }
        }
    }
}
