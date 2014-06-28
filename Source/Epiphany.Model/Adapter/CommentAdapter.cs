using Epiphany.Xml;

namespace Epiphany.Model.Adapter
{
    class CommentAdapter : IAdapter<CommentModel, GoodreadsComment>
    {
        public CommentModel Convert(GoodreadsComment item)
        {
            return new CommentModel(item);
        }
    }
}
