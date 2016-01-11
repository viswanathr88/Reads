using Epiphany.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
