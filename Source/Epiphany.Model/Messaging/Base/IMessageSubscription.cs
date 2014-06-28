using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiphany.Model.Messaging
{
    interface IMessageSubscription
    {
        object Source
        {
            get;
        }

        void Deliver(IMessage message);
    }
}
