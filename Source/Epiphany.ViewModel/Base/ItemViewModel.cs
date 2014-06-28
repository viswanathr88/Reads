using System;

namespace Epiphany.ViewModel
{
    public abstract class ItemViewModel<T> : ViewModelBase
    {
        private T item;
        private bool isSelected;

        public ItemViewModel(T item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

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
                if (this.isSelected == value) return;
                this.isSelected = value;
                RaisePropertyChanged("IsSelected");
            }
        }
    }
}
