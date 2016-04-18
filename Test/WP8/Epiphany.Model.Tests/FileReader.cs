using System.IO;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace Epiphany.Model.Tests
{
    static class FileReader
    {
        public static async Task<string> ReadFile(string url)
        {
            var folder = Package.Current.InstalledLocation;

            using (Stream stream = await folder.OpenStreamForReadAsync(url))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    return content;
                }
            }
        } 
    }
}
