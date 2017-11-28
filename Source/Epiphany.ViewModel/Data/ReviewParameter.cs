using Epiphany.Model;

namespace Epiphany.ViewModel
{
    /// <summary>
    /// Represents a parameter class for the ReviewViewModel
    /// </summary>
    public sealed class ReviewParameter
    {
        /// <summary>
        /// Review Model
        /// </summary>
        public ReviewModel ReviewModel
        {
            get;
            set;
        }
        /// <summary>
        /// FeedItem Model
        /// </summary>
        public FeedItemModel FeedItemModel
        {
            get;
            set;
        }
    }
}
