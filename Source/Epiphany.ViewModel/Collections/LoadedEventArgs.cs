using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Collections
{
    public sealed class LoadedEventArgs
    {
        private Exception error;

        public LoadedEventArgs(Exception error)
        {
            this.error = error;
        }

        public Exception Error
        {
            get
            {
                return this.error;
            }
        }
    }
}
