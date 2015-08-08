using Epiphany.Model;
using System.Collections.Generic;

namespace Epiphany.ViewModel.Items
{
    public sealed class BookItemViewModel : ItemViewModel<BookModel>, IBookItemViewModel
    {
        public BookItemViewModel(BookModel model) : base(model)
        {
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
            get 
            {
                IList<IAuthorItemViewModel> authors = new List<IAuthorItemViewModel>();
                foreach (AuthorModel author in Item.Authors)
                {
                    authors.Add(new AuthorItemViewModel(author));
                }

                return authors;
            }
        }
    }
}
