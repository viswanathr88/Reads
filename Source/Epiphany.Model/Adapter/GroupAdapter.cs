using Epiphany.Xml;

namespace Epiphany.Model.Adapter
{
    class GroupAdapter : IAdapter<GroupModel, GoodreadsGroup>
    {
        public GroupModel Convert(GoodreadsGroup item)
        {
            return new GroupModel(item);
        }
    }
}
