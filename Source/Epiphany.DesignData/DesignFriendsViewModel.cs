using Epiphany.ViewModel;
using Epiphany.ViewModel.Items;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System;

namespace Epiphany.View.DesignData
{
    public class DesignFriendsViewModel : DesignBaseViewModel, IFriendsViewModel
    {
        public DesignFriendsViewModel()
        {
            Title = $"{Path.GetRandomFileName()}'s friends";

            FriendList = new List<IUserItemViewModel>();
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

        public IList<IUserItemViewModel> FriendList
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
