﻿using Epiphany.ViewModel.Items;

namespace Epiphany.View.DesignData
{
    public sealed class DesignBookshelfItemViewModel : DesignBaseItemViewModel, IBookshelfItemViewModel
    {
        public int ShelfId
        {
            get;
            set;
        }

        public int UserId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int NumberOfBooks
        {
            get;
            set;
        }

        public IUserItemViewModel User
        {
            get;
            set;
        }
    }
}
