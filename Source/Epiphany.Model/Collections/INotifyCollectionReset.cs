using System;

namespace Epiphany.Model.Collections
{
    public interface INotifyCollectionReset
    {
        event EventHandler<EventArgs> Reset;
    }
}
