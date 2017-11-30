using Epiphany.ViewModel;
using Epiphany.ViewModel.Commands;
using System;
using System.Threading.Tasks;

namespace Epiphany.View.DesignData
{
    sealed class DesignLogonViewModel : DesignBaseViewModel, ILogonViewModel
    {
        public DesignLogonViewModel()
        {
            IsLoading = true;
            IsWaitingForUserInteraction = false;
            IsSignInTakingLonger = true;
            Error = new Exception();
        }

        public Uri CallbackUri
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICommand<bool, Uri> CheckUriForLoginCompletion
        {
            get { return null; }
        }

        public Uri CurrentUri
        {
            get;
            set;
        }

        public bool IsLoginCompleted
        {
            get;
            private set;
        }

        public bool IsSignInTakingLonger
        {
            get;
            private set;
        }

        public bool IsWaitingForUserInteraction
        {
            get;
            private set;
        }

        public ICommand<Uri, VoidType> Login
        {
            get { return null; }
        }

        public Task CheckUriAsync(Uri uri)
        {
            throw new NotImplementedException();
        }
    }
}
