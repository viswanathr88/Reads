using Epiphany.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiphany.Model.Adapter
{
    class ReviewAdapter : IAdapter<ReviewModel, GoodreadsReview>
    {
        public ReviewModel Convert(GoodreadsReview item)
        {
            return new ReviewModel(item);
        }
    }
}
