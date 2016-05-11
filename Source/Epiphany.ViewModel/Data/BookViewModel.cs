using Epiphany.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public sealed class BookViewModel : DataViewModel<BookModel>, IBookViewModel
    {
        public IList<IAuthorViewModel> Authors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double AverageRating
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Description
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Id
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string ImageUrl
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Name
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override Task LoadAsync(BookModel parameter)
        {
            return Task.FromResult<bool>(true);
        }
    }
}
