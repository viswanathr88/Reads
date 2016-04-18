﻿using Epiphany.Logging;
using Epiphany.Model.Adapter;
using Epiphany.Model.Collections;
using Epiphany.Model.DataSources;
using Epiphany.Model.Messaging;
using Epiphany.Web;
using Epiphany.Xml;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    internal class UserService : IUserService
    {
        private readonly IWebClient webClient;
        private readonly IMessenger messenger;
        private readonly IAdapter<UserModel, GoodreadsUser> userAdapter;
        private readonly IAdapter<ProfileModel, GoodreadsProfile> profileAdapter;
        private readonly IAdapter<FeedItemModel, GoodreadsUpdate> feedItemAdapter;
        private readonly int friendCollectionSize = 200;

        public UserService(IWebClient webClient, IMessenger messenger)
        {
            this.webClient = webClient;
            this.messenger = messenger;
            this.userAdapter = new UserAdapter();
            this.profileAdapter = new ProfileAdapter();
            this.feedItemAdapter = new FeedItemAdapter();

        }
        public async Task<ProfileModel> GetProfile(int id)
        {
            Logger.LogDebug(Environment.CurrentManagedThreadId.ToString());
            //
            // Create the headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["id"] = id;
            //
            // Create the data source and get the profile
            //
            IDataSource<GoodreadsProfile> ds = new DataSource<GoodreadsProfile>(webClient, headers, ServiceUrls.ProfileUrl);
            GoodreadsProfile profile = await ds.GetAsync();

            // Send a message to all listeners
            GenericMessage<GoodreadsProfile> msg = new GenericMessage<GoodreadsProfile>(this, profile);
            this.messenger.SendMessage<GenericMessage<GoodreadsProfile>>(this, msg);

            //
            // Convert and return the profile model
            //
            return this.profileAdapter.Convert(profile);
        }

        public IPagedCollection<UserModel> GetFriends(int id)
        {
            //
            // Create the headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["id"] = id;
            //
            // Create the data source for the collection
            //
            IPagedDataSource<GoodreadsFriends> ds = new PagedDataSource<GoodreadsFriends>(webClient, headers, ServiceUrls.FriendsUrl);
            //
            // create the paged collection and return
            //
            return new PagedCollection<UserModel, GoodreadsUser, GoodreadsFriends>(ds, this.userAdapter, friendCollectionSize);
        }

        public async Task AddFriend(ProfileModel profile)
        {
            //
            // Create the headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["id"] = profile.Id;
            //
            // Create the web request and execute it
            //
            WebRequest request = new WebRequest(ServiceUrls.AddFriendUrl, WebMethod.Post);
            request.Authenticate = true;
            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.Created);
        }

        public async Task<IEnumerable<FeedItemModel>> GetFriendUpdatesAsync(FeedUpdateType type, FeedUpdateFilter filter)
        {
            //
            // Create the headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["update"] = type.ToString();
            headers["update_filter"] = filter.ToString();
            headers["v"] = 2;
            //
            // Create the data source and get the feed
            //
            IDataSource<GoodreadsUpdates> ds = new DataSource<GoodreadsUpdates>(webClient, headers, ServiceUrls.FeedUrl);
            GoodreadsUpdates updates = await ds.GetAsync();
            //
            // Iterate the updates and create feed items
            //
            IList<FeedItemModel> items = new List<FeedItemModel>();
            foreach (GoodreadsUpdate update in updates.Updates)
            {
                FeedItemModel model = this.feedItemAdapter.Convert(update);
                if (model != null)
                {
                    items.Add(model);
                }
            }
            return items;
        }
    }
}
