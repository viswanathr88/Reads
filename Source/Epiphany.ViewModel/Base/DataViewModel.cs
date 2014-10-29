using Epiphany.ViewModel.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Epiphany.ViewModel
{
    public abstract class DataViewModel<T> : ViewModelBase, IDataViewModel<T>, IDataViewModel
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

        public abstract void Load(T param);

        public void Load(object param)
        {
            T safeParam = GetSafeParam(param);

            Load(safeParam);
        }

        private T GetSafeParam(object param)
        {
            if (param == null)
            {
                throw new ArgumentNullException();
            }

            if (!(param is T))
            {
                throw new InvalidOperationException();
            }

            return (T)param;
        }
    }
}
