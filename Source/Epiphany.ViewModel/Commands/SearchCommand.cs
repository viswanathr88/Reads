using Epiphany.Model;
using Epiphany.Model.Collections;
using Epiphany.Model.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    sealed class SearchCommand : AsyncCommand<IEnumerable<WorkModel>, SearchQuery>
    {
        private readonly IBookService bookService;
        private readonly int itemsCount;

        private SearchQuery currentQuery;
        private IAsyncEnumerator<WorkModel> currentIterator;

        public SearchCommand(IBookService bookService, int itemsCount)
        {
            this.bookService = bookService;
            this.itemsCount = itemsCount;
        }

        public override bool CanExecute(SearchQuery query)
        {
            return !string.IsNullOrWhiteSpace(query.Term);
        }

        protected override async Task RunAsync(SearchQuery query)
        {
            if (this.currentQuery != query)
            {
                this.currentQuery = query;
                this.currentIterator = this.bookService.Find(query.Type, query.Term).GetEnumerator();
            }

            IList<WorkModel> results = new List<WorkModel>();
            for (int i = 0; i < itemsCount; i++)
            {
                if (await currentIterator.MoveNext())
                {
                    results.Add(currentIterator.Current);
                }
                else
                {
                    break;
                }
            }

            Result = results;
        }
    }
}
