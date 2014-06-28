using Epiphany.Xml;

namespace Epiphany.Model.Adapter
{
    class UserAdapter : IAdapter<UserModel, GoodreadsUser>
    {
        public UserModel Convert(GoodreadsUser item)
        {
            UserModel model = new UserModel(item);
            return model;
        }
    }
}
