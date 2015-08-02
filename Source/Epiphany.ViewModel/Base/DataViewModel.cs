using Epiphany.Logging;
using System;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public abstract class DataViewModel : ViewModelBase, IDataViewModel
    {
        private bool isLoading;
        private bool isLoaded;
        private object error;

        public bool IsLoading
        {
            get { return this.isLoading; }
            protected set
            {
                if (this.isLoading == value) return;
                this.isLoading = value;
                RaisePropertyChanged();
            }
        }

        public bool IsLoaded
        {
            get { return this.isLoaded; }
            protected set
            {
                if (this.isLoaded == value) return;
                this.isLoaded = value;
                RaisePropertyChanged(() => IsLoaded);
            }
        }

        public abstract Task LoadAsync();


        public object Error
        {
            get
            {
                return this.error;
            }
            protected set
            {
                if (this.error == value) return;
                this.error = value;
                RaisePropertyChanged();
            }
        }
    }
}
