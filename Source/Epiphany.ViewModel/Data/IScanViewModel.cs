using System.Threading.Tasks;
using Windows.Media.Capture;
using Windows.UI.Xaml.Controls;

namespace Epiphany.ViewModel
{
    public interface IScanViewModel : IDataViewModel
    {
        CaptureElement CaptureElement { get; }
        MediaCapture MediaCapture { get; }

        void CleanupCamera();
        Task InitializeCameraAsync();
    }
}