using Epiphany.ViewModel.Services;
using Microsoft.Phone.Tasks;

namespace Epiphany.View.Services
{
    public sealed class AppRateService : IAppRateService
    {
        public void RateApp()
        {
            MarketplaceReviewTask reviewTask = new MarketplaceReviewTask();
            reviewTask.Show();
        }
    }
}
