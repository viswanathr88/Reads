using Epiphany.Model.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    /// <summary>
    /// Interface for review service
    /// </summary>
    public interface IReviewService
    {
        /// <summary>
        /// Get a review
        /// </summary>
        /// <param name="id">id of the review</param>
        /// <returns>review model</returns>
        Task<ReviewModel> GetReviewAsync(int id);
        /// <summary>
        /// Get reviews for a book
        /// </summary>
        /// <param name="book">book whose reviews need to be fetched</param>
        /// <returns>collection of reviews</returns>
        IPagedCollection<ReviewModel> GetReviewsAsync(BookModel book);
        /// <summary>
        /// Add a review to a book
        /// </summary>
        /// <param name="book">book</param>
        Task AddReviewAsync(BookModel book, ReviewModel review);
        /// <summary>
        /// Edit an existing review
        /// </summary>
        /// <param name="book">book</param>
        /// <param name="review">review to be edit</param>
        /// <param name="markAsFinished">True if review should be marked as finished, false otherwise</param>
        Task EditReviewAsync(BookModel book, ReviewModel review, bool markAsFinished);
        /// <summary>
        /// Like a review
        /// </summary>
        /// <param name="review">review to be liked</param>
        Task LikeReviewAsync(ReviewModel review);
        /// <summary>
        /// Unlike a review 
        /// </summary>
        /// <param name="review">review to be unliked</param>
        Task UnlikeReviewAsync(ReviewModel review);
        /// <summary>
        /// Add a comment to a review
        /// </summary>
        /// <param name="review">review to comment on</param>
        /// <param name="comment">comment to add</param>
        Task AddComment(ReviewModel review, CommentModel comment);
        /// <summary>
        /// Gets the recent reviews from Goodreads
        /// </summary>
        /// <returns></returns>
        Task<IList<FeedItemModel>> GetRecentReviewsAsync();
    }
}
