using Epiphany.Xml;

namespace Epiphany.Model.Adapter
{
    class EventAdapter : IAdapter<LiteraryEventModel, GoodreadsEvent>
    {
        public LiteraryEventModel Convert(GoodreadsEvent item)
        {
            LiteraryEventModel eventModel = new LiteraryEventModel(item);

            return eventModel;
        }
    }
}
