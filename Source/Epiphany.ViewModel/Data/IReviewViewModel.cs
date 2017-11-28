using Epiphany.Model;
using Epiphany.ViewModel.Items;
using System;

namespace Epiphany.ViewModel
{
    public interface IReviewViewModel : IDataViewModel<ReviewParameter>
    {
        /// <summary>
        /// Gets the book for the review
        /// </summary>
        IBookItemViewModel Book
        {
            get;
        }

        int Rating
        {
            get;
        }

        DateTime ReviewTime
        {
            get;
        }

        string ReviewText
        {
            get;
        }
    }
}
