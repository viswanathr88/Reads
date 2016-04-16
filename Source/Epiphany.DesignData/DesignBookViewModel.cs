﻿using Epiphany.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiphany.View.DesignData
{
    public class DesignBookViewModel : DesignBaseViewModel
    {
        public DesignBookViewModel()
        {
            Id = 50;
            Name = "Test Title";
            AverageRating = 3.6;
            Description = @"lorem ipsum lorem ipsum lorem ipsum
                lorem ipsum lorem ipsum lorem ipsum lorem ipsum";
            ImageUrl = @"https://upload.wikimedia.org/wikipedia/en/3/33/A_Prisoner_of_Birth_Jeffrey_Archer.jpg";

            Authors = new List<DesignAuthorViewModel>();
            DesignAuthorViewModel author = new DesignAuthorViewModel()
            {
                Id = 51,
                Name = "Test Author",
                ImageUrl = @"https://d.gr-assets.com/authors/1199698411p7/18541.jpg"
            };

            Authors.Add(author);
        }

        public IList<DesignAuthorViewModel> Authors
        {
            get;
            set;
        }

        public double AverageRating
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public int Id
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}