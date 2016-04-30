using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiphany.Strings
{
    public class LocalizedStrings
    {
        private static AppStrings appResources = new AppStrings();

        public AppStrings LocalizedResources
        {
            get
            {
                return appResources;
            }
        }
    }
}
