using Epiphany.Model;
using System.Collections.Generic;
using System.Linq;

namespace Epiphany.ViewModel.Items
{
    public sealed class BookItemViewModel : ItemViewModel<BookModel>, IBookItemViewModel
    {
        private readonly IList<IAuthorItemViewModel> authors;

        public BookItemViewModel(BookModel model) : base(model)
        {
            this.authors = new List<IAuthorItemViewModel>();
            
            foreach (AuthorModel author in Item.Authors)
            {
                authors.Add(new AuthorItemViewModel(author));
            }
        }

        public int Id
        {
            get { return Item.Id; }
        }

        public string Title
        {
            get { return Item.Title; }
        }

        public string ImageUrl
        {
            get { return Item.ImageUrl; }
        }

        public double AverageRating
        {
            get { return Item.AverageRating; }
        }


        public IEnumerable<IAuthorItemViewModel> Authors
        {
            get { return this.authors; }
        }

        public IAuthorItemViewModel MainAuthor
        {
            get { return this.authors.FirstOrDefault(); }
        }
    }
}
