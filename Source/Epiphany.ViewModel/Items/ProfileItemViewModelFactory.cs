using Epiphany.Model;
using Epiphany.ViewModel.Items;
using System;
using System.Collections.ObjectModel;

namespace Epiphany.ViewModel
{
    public enum ProfileItemType
    {
        Friends,
        Groups,
        ViewInGoodreads,
        Age,
        Gender,
        Location,
        Interests,
        FavoriteBooks,
        Username,
        JoinDate,
        FriendStatus
    };

    class ProfileItemViewModelFactory
    {
        public ObservableCollection<IProfileItemViewModel> GetProfileItems(ProfileModel profile)
        {
            if (profile == null)
                throw new ArgumentNullException("profile", "profile cannot be null");

            ObservableCollection<IProfileItemViewModel> profileItems = new ObservableCollection<IProfileItemViewModel>();
            if (profile.FriendsCount > 0)
                profileItems.Add(new ProfileItemViewModel(ProfileItemType.Friends, profile.FriendsCount.ToString(), true));
            if (profile.GroupsCount > 0)
                profileItems.Add(new ProfileItemViewModel(ProfileItemType.Groups, profile.GroupsCount.ToString(), true));

            if (!string.IsNullOrEmpty(profile.Link))
                profileItems.Add(new ProfileItemViewModel(ProfileItemType.ViewInGoodreads, profile.Link, true));
            if (profile.Age > 0)
                profileItems.Add(new ProfileItemViewModel(ProfileItemType.Age, profile.Age.ToString(), false));
            if (!string.IsNullOrEmpty(profile.Gender))
                profileItems.Add(new ProfileItemViewModel(ProfileItemType.Gender, profile.Gender, false));
            if (!string.IsNullOrEmpty(profile.Username))
                profileItems.Add(new ProfileItemViewModel(ProfileItemType.Username, profile.Username, false));
            if (!string.IsNullOrEmpty(profile.Interests))
                profileItems.Add(new ProfileItemViewModel(ProfileItemType.Interests, profile.Interests, false));
            if (!profile.JoinDate.Equals(default(DateTime)))
                profileItems.Add(new ProfileItemViewModel(ProfileItemType.JoinDate, profile.JoinDate.ToString(), false));
            if (!string.IsNullOrEmpty(profile.Location))
                profileItems.Add(new ProfileItemViewModel(ProfileItemType.Location, profile.Location, false));
            if (!string.IsNullOrEmpty(profile.FavoriteBooks))
                profileItems.Add(new ProfileItemViewModel(ProfileItemType.FavoriteBooks, profile.FavoriteBooks, false));

            if (!profile.IsFriend && profile.IsPendingFriendRequest)
            {
                profileItems.Add(new ProfileItemViewModel(ProfileItemType.FriendStatus, "RequestPending", false));
            }

            return profileItems;
        }
    }
}
