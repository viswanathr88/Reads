using Epiphany.Model;
using Epiphany.Model.Collections;
using Epiphany.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Epiphany.View.DesignData
{
    public sealed class DesignProfileViewModel : DataViewModel, IProfileViewModel
    {
        public DesignProfileViewModel()
        {
            Id = 50;
            Name = "Test User";
            AreShelvesEmpty = true;
            AreUpdatesEmpty = true;
            IsLoading = true;
            IsLoaded = true;
        }
        public int Id
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public Model.ProfileModel Model
        {
            get;
            private set;
        }

        public bool AreShelvesEmpty
        {
            get;
            private set;
        }

        public bool AreUpdatesEmpty
        {
            get;
            private set;
        }

        public System.Windows.Input.ICommand GoHome
        {
            get { return null; }
        }

        public IAsyncCommand<Model.ProfileModel, int> FetchProfile
        {
            get { return null; }
        }

        public IAsyncCommand<IEnumerable<BookshelfModel>, IAsyncEnumerator<BookshelfModel>> FetchBookshelves
        {
            get { return null; }
        }

        public IAsyncEnumerator<BookshelfModel> FetchBookshelvesArg
        {
            get { return null; }
        }

        public ObservableCollection<Model.BookshelfModel> Shelves
        {
            get { return null; }
        }

        public override Task LoadAsync()
        {
            throw new NotImplementedException();
        }
    }
}
