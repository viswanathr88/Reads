using Epiphany.Model;

namespace Epiphany.ViewModel.Items
{
    public sealed class AuthorItemViewModel : ItemViewModel<AuthorModel>, IAuthorItemViewModel
    {
        public AuthorItemViewModel(AuthorModel model) : base(model)
        {

        }

        public int Id
        {
            get { return Item.Id; }
        }

        public string Name
        {
            get { return this.Item.Name; }
        }
    }
}
