using Epiphany.ViewModel;
using Epiphany.ViewModel.Collections;
using Epiphany.ViewModel.Items;
using System.IO;

namespace Epiphany.View.DesignData
{
    public class DesignFriendsViewModel : DesignBaseViewModel, IFriendsViewModel
    {
        public DesignFriendsViewModel()
        {
            Title = $"{Path.GetRandomFileName()}'s friends";

            FriendList = new DesignLazyObservableCollection<IUserItemViewModel>();
            for (int i = 0; i < 5; i++)
            {
                var user = new DesignUserItemViewModel()
                {
                    Name = Path.GetRandomFileName(),
                    ImageUrl = @"http://style.anu.edu.au/_anu/4/images/placeholders/person.png"
                };

                FriendList.Add(user);
            }

            AreFriendsEmpty = false;
            IsLoaded = true;
        }

        public string Name
        {
            get;
            set;
        }

        public bool AreFriendsEmpty
        {
            get;
            set;
        }

        public ILazyObservableCollection<IUserItemViewModel> FriendList
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }
    }
}
