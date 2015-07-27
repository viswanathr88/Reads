using Epiphany.Model.Services;
using Epiphany.ViewModel.Services;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace Epiphany.ViewModel
{
    public sealed class ShellViewModel : ViewModelBase
    {
        private Frame frame;
        private ObservableCollection<ShellItemViewModel> shellItems;
        private ShellItemViewModel selectedItem;
        private readonly INavigationService navigationService;
        private readonly ILogonService logonService;

        public ShellViewModel(Frame frame, INavigationService navigationService, ILogonService logonService)
        {
            if (frame == null)
            {
                throw new ArgumentNullException("frame");
            }

            if (navigationService == null || logonService == null)
            {
                throw new ArgumentNullException("services");
            }

            this.navigationService = navigationService;
            this.logonService = logonService;

            Frame = frame;
            Items = new ObservableCollection<ShellItemViewModel>();
            PopulateItems();
            
            if (Items.Count > 0)
            {
                SelectedItem = Items[0];
            }
        }

        public Frame Frame
        {
            get
            {
                return this.frame;
            }
            private set
            {
                if (this.frame == value) return;
                this.frame = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<ShellItemViewModel> Items
        {
            get
            {
                return this.shellItems;
            }
            private set
            {
                if (this.shellItems == value) return;
                this.shellItems = value;
                RaisePropertyChanged();
            }
        }

        public ShellItemViewModel SelectedItem
        {
            get
            {
                return this.selectedItem;
            }
            set
            {
                if (this.selectedItem == value) return;
                this.selectedItem = value;
                RaisePropertyChanged();

                this.selectedItem.Navigate(navigationService, this.logonService.Session);
            }
        }

        private void PopulateItems()
        {
            Items.Add(new ShellItemViewModel(ShellItemType.Feed));
            Items.Add(new ShellItemViewModel(ShellItemType.MyProfile));
            Items.Add(new ShellItemViewModel(ShellItemType.MyBooks));
            Items.Add(new ShellItemViewModel(ShellItemType.Friends));
            Items.Add(new ShellItemViewModel(ShellItemType.Events));
            Items.Add(new ShellItemViewModel(ShellItemType.Groups));
        }
    }
}
