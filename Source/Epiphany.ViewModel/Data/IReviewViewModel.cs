using Epiphany.ViewModel.Items;
using System.Collections.Generic;
using System.Windows.Input;

namespace Epiphany.ViewModel
{
    public interface IReviewViewModel : IDataViewModel<ReviewParameter>
    {
        /// <summary>
        /// Gets whether any user is logged in
        /// </summary>
        bool IsLoggedIn
        {
            get;
        }
        /// <summary>
        /// Gets the book for the review
        /// </summary>
        IBookItemViewModel Book
        {
            get;
        }
        /// <summary>
        /// Gets the user who posted the review
        /// </summary>
        IUserItemViewModel User
        {
            get;
        }
        /// <summary>
        /// Gets the rating
        /// </summary>
        int Rating
        {
            get;
        }
        /// <summary>
        /// Gets the review time
        /// </summary>
        string ReviewTime
        {
            get;
        }
        /// <summary>
        /// Gets the review text
        /// </summary>
        string ReviewText
        {
            get;
        }
        /// <summary>
        /// Gets the shelves for the user
        /// </summary>
        IList<IBookshelfItemViewModel> Shelves
        {
            get;
        }
        /// <summary>
        /// Gets or sets the comment text
        /// </summary>
        string CommentText
        {
            get;
            set;
        }
        /// <summary>
        /// Command to post a comment on a review
        /// </summary>
        ICommand PostComment
        {
            get;
        } 
    }
}
