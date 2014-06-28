using System;

namespace Epiphany.ViewModel.Commands
{
    public class CancelEventArgs : EventArgs
    {
        private bool cancel;

        public CancelEventArgs(bool cancel)
        {
            this.cancel = cancel;
        }

        public bool Cancel
        {
            get { return this.cancel; }
            set { this.cancel = value; }
        }
    }
}
