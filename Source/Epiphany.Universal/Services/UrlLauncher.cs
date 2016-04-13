using Epiphany.Logging;
using Epiphany.ViewModel.Services;
using Microsoft.Phone.Tasks;
using System;

namespace Epiphany.View.Services
{
    public sealed class UrlLauncher : IUrlLauncher
    {
        public void Launch(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }

            Log.Instance.Info(string.Format("Launching url {0}", url));

            WebBrowserTask webTask = new WebBrowserTask();
            webTask.Uri = new Uri(url);
            webTask.Show();
        }
    }
}
