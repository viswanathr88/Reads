using Epiphany.Xml;

namespace Epiphany.Model.Adapter
{
    class TopicAdapter : IAdapter<TopicModel, GoodreadsTopic>
    {
        public TopicModel Convert(GoodreadsTopic item)
        {
            return new TopicModel(item);
        }
    }
}
