using Epiphany.Xml;

namespace Epiphany.Model.Adapter
{
    class UserStatusAdapter : IAdapter<UserStatusModel, GoodreadsUserStatus>
    {
        public UserStatusModel Convert(GoodreadsUserStatus item)
        {
            return new UserStatusModel(item);
        }
    }
}
