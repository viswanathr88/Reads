using Epiphany.Model.Adapter;
using Epiphany.Model.Collections;
using Epiphany.Model.DataSources;
using Epiphany.Model.Messaging;
using Epiphany.Web;
using Epiphany.Xml;
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
            // Create the parameters
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["id"] = id.ToString();

            // Create the data source and get the profile
            IDataSource<GoodreadsProfile> ds = new DataSource<GoodreadsProfile>(webClient, parameters, ServiceUrls.ProfileUrl);
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
            // Create the parameters
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["id"] = id.ToString();
            
            // Create the data source for the collection
            IPagedDataSource<GoodreadsFriends> ds = new PagedDataSource<GoodreadsFriends>(webClient, parameters, ServiceUrls.FriendsUrl);
            
            // create the paged collection and return
            return new PagedCollection<UserModel, GoodreadsUser, GoodreadsFriends>(ds, this.userAdapter, friendCollectionSize);
        }

        public async Task AddFriend(ProfileModel profile)
        {
            // Create the web request and execute it
            WebRequest request = new WebRequest(ServiceUrls.AddFriendUrl, WebMethod.Post);
            request.Authenticate = true;
            request.Parameters["id"] = profile.Id.ToString();

            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.Created);
        }

        public async Task<IEnumerable<FeedItemModel>> GetFriendUpdatesAsync(FeedUpdateType type, FeedUpdateFilter filter)
        {
            // Create the parameters
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["update"] = type.ToString();
            parameters["update_filter"] = filter.ToString();
            parameters["v"] = "2";
            
            // Create the data source and get the feed
            IDataSource<GoodreadsUpdates> ds = new DataSource<GoodreadsUpdates>(webClient, parameters, ServiceUrls.FeedUrl, true);
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
    }
}
