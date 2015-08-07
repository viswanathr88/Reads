using Epiphany.ViewModel.Services;
using Microsoft.Phone.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Epiphany.View.Services
{
    sealed class ResourceLoader : IResourceLoader
    {
        private readonly SortedLocaleGrouping sortedLocaleGrouping = new SortedLocaleGrouping();

        public string GetString(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetLocaleGroupHeaders()
        {
            return this.sortedLocaleGrouping.GroupDisplayNames;
        }

        public int GetLocaleGroupIndex(string item)
        {
            return this.sortedLocaleGrouping.GetGroupIndex(item);
        }
    }
}
