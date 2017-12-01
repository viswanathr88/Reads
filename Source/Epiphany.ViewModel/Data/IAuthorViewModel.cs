using Epiphany.Model;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using System.Collections.Generic;

namespace Epiphany.ViewModel
{
    public interface IAuthorViewModel : IDataViewModel<AuthorModel>
    {
        /// <summary>
        /// Gets the name of the author
        /// </summary>
        string Name
        {
            get;
        }
        /// <summary>
        /// Gets the description about the author
        /// </summary>
        string Description
        {
            get;
        }
        /// <summary>
        /// Gets the number of followers for the author
        /// </summary>
        int FollowersCount
        {
            get;
        }
        /// <summary>
        /// Gets the image url
        /// </summary>
        string ImageUrl
        {
            get;
        }
        /// <summary>
        /// Gets the average rating for this author
        /// </summary>
        double AverageRating
        {
            get;
        }
        /// <summary>
        /// Gets the number of ratings for this author
        /// </summary>
        int RatingsCount
        {
            get;
        }
        /// <summary>
        /// Gets the hometown of the author
        /// </summary>
        string Hometown
        {
            get;
        }
        /// <summary>
        /// Gets all additional attributes of the author
        /// </summary>
        IList<IAuthorAttributeViewModel> Attributes
        {
            get;
        }
        /// <summary>
        /// Gets all the books by the author
        /// </summary>
        ILazyObservableCollection<IBookItemViewModel> Books
        {
            get;
        }
    }
}