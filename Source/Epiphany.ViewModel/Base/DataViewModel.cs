using System.Collections.Generic;

namespace Epiphany.ViewModel
{
    public abstract class DataViewModel : ViewModelBase
    {
        private bool isLoading;
        private bool isLoaded;

        public bool IsLoading
        {
            get { return this.isLoading; }
            protected set
            {
                if (this.isLoading == value) return;
                this.isLoading = value;
                RaisePropertyChanged("IsLoading");
            }
        }

        public bool IsLoaded
        {
            get { return this.isLoaded; }
            protected set
            {
                if (this.isLoaded == value) return;
                this.isLoaded = value;
                RaisePropertyChanged("IsLoaded");
            }
        }

        public abstract void Load();
    }
}
