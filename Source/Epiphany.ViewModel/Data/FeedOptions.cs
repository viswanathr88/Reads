using Epiphany.Model.Services;

namespace Epiphany.ViewModel
{
    public sealed class FeedOptions
    {
        private readonly FeedUpdateType updateType;
        private readonly FeedUpdateFilter updateFilter;

        public FeedOptions(FeedUpdateType type, FeedUpdateFilter filter)
        {
            this.updateFilter = filter;
            this.updateType = type;
        }

        public FeedUpdateType UpdateType
        {
            get
            {
                return this.updateType;
            }
        }

        public FeedUpdateFilter UpdateFilter
        {
            get
            {
                return this.updateFilter;
            }
        }
    }
}

