using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiphany.ViewModel
{
    public class VoidType
    {
        public static VoidType Empty
        {
            get
            {
                return new VoidType();
            }
        }
    }
}
