using Epiphany.Strings;
using Epiphany.ViewModel.Services;
using Microsoft.Phone.Globalization;
using System.Collections.Generic;

namespace Epiphany.View.Services
{
    sealed class ResourceLoader : IResourceLoader
    {
        private readonly SortedLocaleGrouping sortedLocaleGrouping = new SortedLocaleGrouping();

        public string GetString(string key)
        {
            return AppResources.ResourceManager.GetString(key, AppResources.Culture);
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
