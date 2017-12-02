using Epiphany.Logging;
using System;
using Windows.ApplicationModel.DataTransfer;

namespace Epiphany.View.Share
{
    public abstract class SupportShareBase<T> : ISupportShare<T>
    {
        public SupportShareBase()
        {
            DataTransferManager manager = DataTransferManager.GetForCurrentView();
            manager.DataRequested += Manager_DataRequested;
        }

        public void Share(T item)
        {
            Item = item;
            // This will lead to the Share UI displayed and Manager_DataRequested
            // will be called to get the share data
            DataTransferManager.ShowShareUI();
        }

        protected T Item
        {
            get;
            private set;
        }

        protected abstract void UpdateShareData(DataPackage data);

        private void Manager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            var deferral = args.Request.GetDeferral();

            try
            {
                UpdateShareData(args.Request.Data);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                args.Request.FailWithDisplayText(Strings.AppStrings.SharingFailedMessage);
            }
            finally
            {
                deferral.Complete();
            }

        }
    }
}
