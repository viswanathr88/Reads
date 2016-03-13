using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiphany.Strings
{
    public class LocalizedStrings
    {
        private static AppResources appResources = new AppResources();

        public AppResources LocalizedResources
        {
            get
            {
                return appResources;
            }
        }
    }
}
