﻿using System;
using Epiphany.Model;

namespace Epiphany.ViewModel.Items
{
    public sealed class AuthorItemViewModel : ItemViewModel<AuthorModel>, IAuthorItemViewModel
    {
        public AuthorItemViewModel(AuthorModel model) : base(model)
        {

        }

        public long Id
        {
            get { return Item.Id; }
        }

        public string ImageUrl
        {
            get
            {
                return Item.ImageUrl;
            }
        }

        public string Name
        {
            get { return this.Item.Name; }
        }
    }
}
