using Epiphany.ViewModel;
using System;

namespace Epiphany.View
{
    sealed class DataContextWrapper<TDataContextType> where TDataContextType : IDataViewModel
    {
        private readonly object dataContext;

        public DataContextWrapper(object dataContext)
        {
            if (dataContext == null)
            {
                throw new ArgumentNullException(nameof(dataContext));
            }

            this.dataContext = dataContext;
        }

        public TDataContextType ViewModel
        {
            get
            {
                return GetViewModel<TDataContextType>();
            }
        }

        public IDataViewModel DataViewModel
        {
            get
            {
                return GetViewModel<IDataViewModel>();
            }
        }

        public ViewModelBase BaseViewModel
        {
            get
            {
                return GetViewModel<ViewModelBase>();
            }
        }

        private T GetViewModel<T>()
        {
            T vm = default(T);
            if (dataContext != null && dataContext is T)
            {
                vm = (T)dataContext;
            }

            return vm;
        }
    }
}
