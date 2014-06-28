using Epiphany.Xml;

namespace Epiphany.Model.Adapter
{
    class AuthorAdapter : IAdapter<AuthorModel, GoodreadsAuthor>
    {
        public AuthorModel Convert(GoodreadsAuthor item)
        {
            AuthorModel model = new AuthorModel(item, null);
            return model;
        }
    }
}
