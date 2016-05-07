using Epiphany.Model;

namespace Epiphany.ViewModel.Items
{
    public sealed class UserItemViewModel : ItemViewModel<UserModel>, IUserItemViewModel
    {

        public UserItemViewModel(UserModel user) :
            base(user)
        {

        }

        public int Id
        {
            get
            {
                return Item.Id;
            }
        }

        public string Name
        {
            get
            {
                return Item.Name;
            }
        }

        public string ImageUrl
        {
            get
            {
                return Item.ImageUrl;
            }
        }
    }
}
