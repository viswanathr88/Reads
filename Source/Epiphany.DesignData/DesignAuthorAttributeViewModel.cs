﻿using Epiphany.ViewModel;

namespace Epiphany.View.DesignData
{
    public sealed class DesignAuthorAttributeViewModel : IAuthorAttributeViewModel
    {
        public AuthorAttribute Type
        {
            get;
            set;
        }

        public string Value
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get;
            set;
        }
    }
}
