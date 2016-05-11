using Epiphany.Model.Collections;
using Epiphany.Model.Messaging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    class CachedUserService : IUserService
    {
        private readonly IUserService baseService;
        private readonly IMessenger messenger;
        private readonly IDictionary<int, ProfileModel> cache;
        private readonly IDictionary<int, IPagedCollection<UserModel>> friendsCache;

        public CachedUserService(IUserService service, IMessenger messenger)
        {
            this.baseService = service;
            this.messenger = messenger;
            this.cache = new Dictionary<int, ProfileModel>();
            this.friendsCache = new Dictionary<int, IPagedCollection<UserModel>>();
        }

        public async Task<ProfileModel> GetProfile(int id)
        {
            if (cache.ContainsKey(id))
            {
                return cache[id];
            }
            else
            {
                ProfileModel model = await this.baseService.GetProfile(id);
                cache[id] = model;
                return model;
            }
        }

        public IPagedCollection<UserModel> GetFriends(int id)
        {
            if (friendsCache.ContainsKey(id))
            {
                return friendsCache[id];
            }
            else
            {
                IPagedCollection<UserModel> friends = this.baseService.GetFriends(id);
                friendsCache[id] = friends;
                return friends;
            }
        }

        public async Task<IEnumerable<FeedItemModel>> GetFriendUpdatesAsync(FeedUpdateType type, FeedUpdateFilter filter)
        {
            return await this.baseService.GetFriendUpdatesAsync(type, filter);
        }

        public async Task AddFriend(ProfileModel profile)
        {
            await this.baseService.AddFriend(profile);
            //
            // Clear the caches
            //
            if (cache.ContainsKey(profile.Id))
            {
                cache.Remove(profile.Id);
            }

            if (friendsCache.ContainsKey(profile.Id))
            {
                friendsCache.Remove(profile.Id);
            }
        }

        public async Task<IList<FeedItemModel>> GetRecentUserStatusesAsync()
        {
            return await this.baseService.GetRecentUserStatusesAsync();
        }
    }
}
