using System;

namespace Epiphany.ViewModel.Commands
{
    class CheckUriCommand : Command<bool, Uri>
    {
        private readonly Uri callbackUri;

        public CheckUriCommand(Uri callbackUri)
        {
            this.callbackUri = callbackUri;
        }

        public override bool CanExecute(Uri param)
        {
            return true;
        }

        protected override void Run(Uri uri)
        {
            bool result = false;

            if (uri.ToString().StartsWith(callbackUri.ToString()))
            {
                result = uri.ToString().Contains("authorize=1");
            }

            Result = result;
        }
    }
}
