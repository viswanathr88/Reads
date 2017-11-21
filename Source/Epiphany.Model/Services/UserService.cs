using Epiphany.Model.Adapter;
using Epiphany.Model.Collections;
using Epiphany.Model.DataSources;
using Epiphany.Model.Messaging;
using Epiphany.Web;
using Epiphany.Xml;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Epiphany.Model.Services
{
    internal class UserService : IUserService
    {
        private readonly IWebClient webClient;
        private readonly IMessenger messenger;
        private readonly IAdapter<UserModel, GoodreadsUser> userAdapter;
        private readonly IAdapter<ProfileModel, GoodreadsProfile> profileAdapter;
        private readonly IAdapter<FeedItemModel, GoodreadsUpdate> feedItemAdapter;
        private readonly int friendCollectionSize = 40;

        public UserService(IWebClient webClient, IMessenger messenger)
        {
            this.webClient = webClient;
            this.messenger = messenger;
            this.userAdapter = new UserAdapter();
            this.profileAdapter = new ProfileAdapter();
            this.feedItemAdapter = new FeedItemAdapter();

        }
        public async Task<ProfileModel> GetProfileAsync(long id)
        {
            // Create the data source and get the profile
            var ds = new DataSource<GoodreadsProfile>(webClient);
            ds.SourceUrl = ServiceUrls.ProfileUrl;
            ds.Parameters["id"] = id.ToString();
            ds.RequiresAuthentication = false;
            ds.Returns = (response) => response.Profile;
            
            GoodreadsProfile profile = await ds.GetAsync();

            // Send a message to all listeners
            GenericMessage<GoodreadsProfile> msg = new GenericMessage<GoodreadsProfile>(this, profile);
            this.messenger.SendMessage<GenericMessage<GoodreadsProfile>>(this, msg);

            // Convert and return the profile model
            return this.profileAdapter.Convert(profile);
        }

        public IPagedCollection<UserModel> GetFriends(long id)
        {
            // Create the data source for the collection
            var ds = new PagedDataSource<GoodreadsFriends>(webClient);
            ds.SourceUrl = ServiceUrls.FriendsUrl;
            ds.Parameters["id"] = id.ToString();
            ds.Parameters["sort"] = "first_name";
            ds.RequiresAuthentication = true;
            ds.Returns = (response) => response.Friends;
            
            // create the paged collection and return
            return new PagedCollection<UserModel, GoodreadsUser, GoodreadsFriends>(ds, this.userAdapter, friendCollectionSize);
        }

        public async Task AddFriend(ProfileModel profile)
        {
            // Create the web request and execute it
            WebRequest request = new WebRequest(ServiceUrls.AddFriendUrl, WebMethod.Post);
            request.Authenticate = true;
            request.Parameters["id"] = profile.Id.ToString();
            request.Parameters["format"] = "xml";

            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.Created);
        }

        public async Task<IEnumerable<FeedItemModel>> GetFriendUpdatesAsync(FeedUpdateType type, FeedUpdateFilter filter)
        {
            // Create the data source and get the feed
            var ds = new DataSource<GoodreadsUpdates>(webClient);
            ds.SourceUrl = ServiceUrls.FeedUrl;
            ds.Parameters["update"] = type.ToString();
            ds.Parameters["update_filter"] = filter.ToString();

            ds.RequiresAuthentication = true;
            ds.Returns = (response) => response.Updates;
            
            GoodreadsUpdates updates = await ds.GetAsync();
            
            // Iterate the updates and create feed items
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

        public async Task FollowUser(ProfileModel user)
        {
            // Create the web request and execute it
            WebRequest request = new WebRequest(string.Format(ServiceUrls.FollowUserUrlFormat, user.Id), WebMethod.Post);
            request.Authenticate = true;
            request.Parameters["id"] = user.Id.ToString();

            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.Created);
        }

        public async Task UnfollowUser(ProfileModel user)
        {
            // Create the web request and execute it
            WebRequest request = new WebRequest(string.Format(ServiceUrls.UnfollowUserUrlFormat, user.Id), WebMethod.Delete);
            request.Authenticate = true;
            request.Parameters["id"] = user.Id.ToString();
            request.Parameters["format"] = "xml";

            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.OK);
        }
    }
}
