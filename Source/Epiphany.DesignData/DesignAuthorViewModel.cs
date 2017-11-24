using Epiphany.Model;
using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Epiphany.View.DesignData
{
    public sealed class DesignAuthorViewModel : DesignBaseViewModel<AuthorModel>, IAuthorViewModel
    {

        public DesignAuthorViewModel()
        {
            Name = "Test Author";
            ImageUrl = null;

            PopulateAttributes();
            PopulateBooks();
        }

        public string Name
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;
        }

        public IList<IBookItemViewModel> Books
        {
            get;
            set;
        }

        public IList<IAuthorAttributeViewModel> Attributes
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public int FollowersCount
        {
            get;
            set;
        }

        public double AverageRating
        {
            get;
            set;
        }

        public int RatingsCount
        {
            get;
            set;
        }

        public string Hometown
        {
            get;
            set;
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
        }
    }
}
