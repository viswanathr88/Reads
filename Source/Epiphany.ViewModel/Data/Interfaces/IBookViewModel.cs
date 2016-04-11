
using System.Collections;
using System.Collections.Generic;

namespace Epiphany.ViewModel
{
    public interface IBookViewModel : IDataViewModel
    {
        int Id
        {
            get;
            set;
        }

        string Name
        {
            get;
            set;
        }

        IList<IAuthorViewModel> Authors
        {
            get;
        }

        string ImageUrl
        {
            get;
        }

        string Description
        {
            get;
        }

        double AverageRating
        {
            get;
        }
    }
}
