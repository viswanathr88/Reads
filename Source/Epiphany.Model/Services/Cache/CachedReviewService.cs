using Epiphany.Model.Collections;
using Epiphany.Model.Messaging;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Epiphany.Model.Services
{
    class CachedReviewService : IReviewService
    {
        private readonly IReviewService baseService;
        private readonly IMessenger messenger;

        public CachedReviewService(IReviewService service, IMessenger messenger)
        {
            this.baseService = service;
            this.messenger = messenger;
        }

        public async Task<ReviewModel> GetReviewAsync(long id)
        {
            return await this.baseService.GetReviewAsync(id);
        }

        public IPagedCollection<ReviewModel> GetReviews(BookModel book)
        {
            return this.baseService.GetReviews(book);
        }

        public async Task AddReviewAsync(BookModel book, ReviewModel review)
        {
            await this.baseService.AddReviewAsync(book, review);
            //
            // Send message for listeners
            //
            ReviewAddedOrEditedMessage msg = new ReviewAddedOrEditedMessage(this, review, book);
            this.messenger.SendMessage<ReviewAddedOrEditedMessage>(this, msg);
        }

        public async Task EditReviewAsync(BookModel book, ReviewModel review, bool markAsFinished)
        {
            await this.baseService.EditReviewAsync(book, review, markAsFinished);
            //
            // Send message for listeners
            //
            ReviewAddedOrEditedMessage msg = new ReviewAddedOrEditedMessage(this, review, book);
            this.messenger.SendMessage<ReviewAddedOrEditedMessage>(this, msg);
        }

        public async Task LikeReviewAsync(ReviewModel review)
        {
            await this.baseService.LikeReviewAsync(review);
        }

        public async Task UnlikeReviewAsync(ReviewModel review)
        {
            await this.baseService.UnlikeReviewAsync(review);
        }


        public async Task AddComment(ReviewModel review, CommentModel comment)
        {
            await this.baseService.AddComment(review, comment);
        }

        public async Task<IList<FeedItemModel>> GetRecentReviewsAsync()
        {
            return await this.baseService.GetRecentReviewsAsync();
        }
    }
}
