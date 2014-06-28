using Epiphany.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiphany.Model
{
    public sealed class ReadStatusFeedItemModel : FeedItemModel
    {
        private readonly GoodreadsReadStatus update;

        public ReadStatusFeedItemModel(GoodreadsUpdate update)
            : base(update)
        {
            this.update = update.Object.ReadStatus;
            if (this.update == null)
            {
                this.update = new GoodreadsReadStatus();
            }
        }

        protected override int GetId(GoodreadsUpdate update)
        {
            return update.Object.ReadStatus.Id;
        }

        public int ReviewId
        {
            get
            {
                return Converter.ToInt(this.update.ReviewId, 0);
            }
        }

        public string Status
        {
            get
            {
                return this.update.Status;
            }
        }

        public DateTime StatusUpdateTime
        {
            get
            {
                return Converter.ToDateTime(this.update.UpdatedAt);
            }
        }

        public int UserId
        {
            get
            {
                return Converter.ToInt(this.update.UserId, 0);
            }
        }
    }
}
