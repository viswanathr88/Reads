using System.Collections.Generic;

namespace Epiphany.ViewModel.Services
{
    public interface IResourceLoader
    {
        string GetString(string key);

        IEnumerable<string> GetLocaleGroupHeaders();

        int GetLocaleGroupIndex(string item);

        string GetString(object key);
    }
}
