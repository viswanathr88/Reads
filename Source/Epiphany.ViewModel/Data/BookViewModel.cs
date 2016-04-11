using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiphany.ViewModel
{
    public sealed class BookViewModel : DataViewModel, IBookViewModel
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

        public override Task LoadAsync()
        {
            throw new NotImplementedException();
        }
    }
}
