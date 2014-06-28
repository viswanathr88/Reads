using Epiphany.Xml;

namespace Epiphany.Model.Adapter
{
    class WorkAdapter : IAdapter<WorkModel, GoodreadsWork>
    {
        private IAdapter<BookModel, GoodreadsBook> bookAdapter;

        public WorkAdapter(IAdapter<BookModel, GoodreadsBook> bookAdapter)
        {
            this.bookAdapter = bookAdapter;
        }

        public WorkModel Convert(GoodreadsWork item)
        {
            WorkModel workModel = new WorkModel(item.Id)
            {
                OriginalTitle = item.OriginalTitle,
                Book = this.bookAdapter.Convert(item.BestBook)
            };

            return workModel;
        }
    }
}
