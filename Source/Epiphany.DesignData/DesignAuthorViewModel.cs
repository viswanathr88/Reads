using Epiphany.Model;
using Epiphany.Model.Collections;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Commands;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Epiphany.View.DesignData
{
    public sealed class DesignAuthorViewModel : DesignBaseViewModel
    {

        public DesignAuthorViewModel()
        {
            Id = 50;
            Name = "Test Author";
            BookLoadingStarted = false;
            ImageUrl = null;

            PopulateAttributes();
            PopulateBooks();
        }

        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public bool BookLoadingStarted
        {
            get;
            set;
        }

        public AuthorModel Author
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;
        }

        public IBookItemViewModel SelectedBook
        {
            get;
            set;
        }

        public IList<IBookItemViewModel> Books
        {
            get;
            set;
        }

        public IList<AuthorAttributeViewModel> Attributes
        {
            get;
            set;
        }

        public IAsyncCommand<IAsyncEnumerator<BookModel>> FetchBooks
        {
            get { return null; }
        }

        public IAsyncEnumerator<BookModel> BookEnumerator
        {
            get { return null; }
        }

        public ICommand<AuthorModel> PinAuthor
        {
            get { return null; }
        }

        public ICommand GoHome
        {
            get { return null; }
        }

        private void PopulateAttributes()
        {
            Attributes = new ObservableCollection<IAuthorAttributeViewModel>();

            Attributes.Add(new DesignAuthorAttributeViewModel()
            {
                Type = AuthorAttribute.About,
                Value = "lorem ipsum",
                IsEnabled = false
            });

            Attributes.Add(new DesignAuthorAttributeViewModel()
            {
                Type = AuthorAttribute.AverageRating,
                Value = "4.0",
                IsEnabled = false
            }); 
            
            Attributes.Add(new DesignAuthorAttributeViewModel()
            {
                Type = AuthorAttribute.Born,
                Value = DateTime.Now.ToString(),
                IsEnabled = false
            }); 
            
            Attributes.Add(new DesignAuthorAttributeViewModel()
            {
                Type = AuthorAttribute.Gender,
                Value = "male",
                IsEnabled = true
            });

            Attributes.Add(new DesignAuthorAttributeViewModel()
            {
                Type = AuthorAttribute.Hometown,
                Value = "chennai",
                IsEnabled = false
            });

        }

        private void PopulateBooks()
        {
            Books = new ObservableCollection<IBookItemViewModel>();

            for (int i = 0; i < 15; i++ )
            {
                Books.Add(new DesignBookItemViewModel()
                {
                    Id = i,
                    Title = "Test Book " + i,
                    ImageUrl = @"https://upload.wikimedia.org/wikipedia/en/3/33/A_Prisoner_of_Birth_Jeffrey_Archer.jpg",
                    AverageRating = 4.0
                });
            }
            SelectedBook = Books[0];
        }
    }
}
