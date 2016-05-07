using Epiphany.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Media.Capture;
using Windows.UI.Xaml.Controls;

namespace Epiphany.ViewModel
{
    public sealed class ScanViewModel : DataViewModel<VoidType>, IScanViewModel
    {
        private MediaCapture mediaCapture;
        private CaptureElement captureElement;

        public ScanViewModel()
        {
            CaptureElement = new CaptureElement()
            {
                Stretch = Windows.UI.Xaml.Media.Stretch.UniformToFill,
                FlowDirection = Windows.UI.Xaml.FlowDirection.LeftToRight
            };
        }

        public CaptureElement CaptureElement
        {
            get
            {
                return this.captureElement;
            }
            private set
            {
                SetProperty(ref this.captureElement, value);
            }
        }

        public MediaCapture MediaCapture
        {
            get
            {
                return this.mediaCapture;
            }
            private set
            {
                SetProperty(ref this.mediaCapture, value);
            }
        }

        public async override Task LoadAsync(VoidType parameter)
        {
            Logger.LogDebug("Initializing Camera");
            await InitializeCameraAsync();
        }

        public async Task InitializeCameraAsync()
        {
            Logger.LogDebug("Starting camera initialization");

            if (MediaCapture != null)
            {
                Logger.LogInfo("MediaCapture is not null. Already initialized");
                return;
            }

            // Get all cameras on the device
            DeviceInformationCollection cameraList = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);

            if (cameraList == null)
            {
                Logger.LogError("Failed to grab camera list");
                // TODO: Set error on VM
                return;
            }

            // Find the back camera
            DeviceInformation backCamera = (from camera in cameraList
                                            where camera.EnclosureLocation != null &&
                                            camera.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Back
                                            select camera).FirstOrDefault();

            if (backCamera == null)
            {
                Logger.LogError("Failed to get backCamera");
                // TODO: Set error on VM
                return;
            }

            // Create MediaCapture
            MediaCapture = new MediaCapture();
            MediaCapture.Failed += MediaCapture_Failed;

            // Create Media Capture init settings
            MediaCaptureInitializationSettings settings = new MediaCaptureInitializationSettings()
            {
                VideoDeviceId = backCamera.Id,
                AudioDeviceId = string.Empty,
                StreamingCaptureMode = StreamingCaptureMode.Video,
                PhotoCaptureSource = PhotoCaptureSource.VideoPreview
            };

            try
            {
                await mediaCapture.InitializeAsync(settings);
            }
            catch (UnauthorizedAccessException ex)
            {
                Logger.LogException(ex);
                Logger.LogDebug("The app was denied camera access");
                // TODO: Show appropriate error
                return;
            }

            CaptureElement.Source = MediaCapture;
            
            // Start the preview
            await MediaCapture.StartPreviewAsync();
        }

        private void MediaCapture_Failed(MediaCapture sender, MediaCaptureFailedEventArgs errorEventArgs)
        {
            Logger.LogError(string.Format("MediaCapture_Failed: (0x{0:X}) {1}", errorEventArgs.Code, errorEventArgs.Message));

            CleanupCamera();
        }

        public void CleanupCamera()
        {
            if (CaptureElement != null)
            {
                CaptureElement.Source = null;
            }

            if (MediaCapture != null)
            {
                Logger.LogDebug("Cleaning up MediaCapture");
                MediaCapture.Failed -= MediaCapture_Failed;
                MediaCapture.Dispose();
                MediaCapture = null;
            }

        }

        public override void Dispose()
        {
            base.Dispose();

            CleanupCamera();
        }
    }
}
