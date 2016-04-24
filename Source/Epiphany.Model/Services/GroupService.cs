using Epiphany.Model.Adapter;
using Epiphany.Model.Collections;
using Epiphany.Model.DataSources;
using Epiphany.Web;
using Epiphany.Xml;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.Model.Services
{
    class GroupService : IGroupService
    {
        private readonly IWebClient webClient;
        private readonly int pageSize = 20;
        private readonly IAdapter<GroupModel, GoodreadsGroup> adapter;
        private readonly IAdapter<TopicModel, GoodreadsTopic> topicAdapter;
        private readonly IAdapter<CommentModel, GoodreadsComment> commentAdapter;

        private GoodreadsTopic currentTopic;

        public GroupService(IWebClient webClient)
        {
            if (webClient == null)
            {
                throw new ArgumentNullException();
            }

            this.webClient = webClient;
            this.adapter = new GroupAdapter();
            this.topicAdapter = new TopicAdapter();
            this.commentAdapter = new CommentAdapter();
        }

        public IPagedCollection<GroupModel> GetGroups(UserModel user)
        {
            // Create parameters
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["id"] = user.Id.ToString();
            
            // Create the data source
            IPagedDataSource<GoodreadsGroupList> ds = new PagedDataSource<GoodreadsGroupList>(webClient, parameters, ServiceUrls.GroupsUrl);
            return new PagedCollection<GroupModel, GoodreadsGroup, GoodreadsGroupList>(ds, adapter, pageSize);
        }

        public async Task<GroupModel> GetGroup(int groupId)
        {
            // Create parameters
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["id"] = groupId.ToString();

            // Create the data source
            IDataSource<GoodreadsGroup> ds = new DataSource<GoodreadsGroup>(webClient, parameters, ServiceUrls.GroupUrl);
            GoodreadsGroup group = await ds.GetAsync();

            // Convert to model and return
            return this.adapter.Convert(group);
        }

        public IPagedCollection<TopicModel> GetTopics(int groupId, int groupFolderId)
        {
            //
            // Create parameters
            //
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["id"] = groupFolderId.ToString();
            parameters["group_id"] = groupId.ToString();
            //
            // Create the data source
            //
            IPagedDataSource<GoodreadsTopics> ds = new PagedDataSource<GoodreadsTopics>(webClient, parameters, ServiceUrls.GroupFolderUrl);
            return new PagedCollection<TopicModel, GoodreadsTopic, GoodreadsTopics>(ds, topicAdapter, pageSize);
        }

        public async Task<TopicModel> GetTopic(int topicId)
        {
            //
            // Create parameters
            //
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["id"] = topicId.ToString();
            //
            // Create data source
            //
            IDataSource<GoodreadsTopic> ds = new DataSource<GoodreadsTopic>(webClient, parameters, ServiceUrls.TopicUrl);
            this.currentTopic = await ds.GetAsync();
            //
            // Create the model and return
            //
            return this.topicAdapter.Convert(this.currentTopic);
        }

        public IPagedCollection<CommentModel> GetComments(TopicModel topic)
        {
            //
            // Create parameters
            //
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["id"] = topic.Id.ToString();
            //
            // Create data source
            //
            IPagedDataSource<GoodreadsComments> ds = new PagedDataSource<GoodreadsComments>(webClient, parameters, ServiceUrls.TopicUrl);
            IPagedCollection<CommentModel> collection = null;
            if (currentTopic != null && currentTopic.Comments != null)
            {
                collection = new PagedCollection<CommentModel, GoodreadsComment, GoodreadsComments>(ds, commentAdapter, currentTopic.Comments.Items);
            }
            else
            {
                collection = new PagedCollection<CommentModel, GoodreadsComment, GoodreadsComments>(ds, commentAdapter, pageSize);
            }
            return collection;
        }

        public async Task CreateTopic(TopicModel topic, string body)
        {
            // Create web request and execute it
            WebRequest request = new WebRequest(ServiceUrls.CreateTopicUrl, WebMethod.Post);
            request.Authenticate = true;
            request.Parameters["topic[subject_type]"] = "Group";
            request.Parameters["topic[subject_id]"] = topic.Group.Id.ToString();
            request.Parameters["topic[folder_id]"] = topic.Folder.Id.ToString();
            request.Parameters["topic[title]"] = topic.Title;
            request.Parameters["comment[body_usertext]"] = body;

            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.Created);
        }

        public async Task AddComment(TopicModel topic, CommentModel comment)
        {
            // Create the web request and execute it
            WebRequest request = new WebRequest(ServiceUrls.CommentCreateUrl, WebMethod.Post);
            request.Authenticate = true;
            request.Parameters["type"] = "topic";
            request.Parameters["id"] = topic.Id.ToString();

            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.Created);
        }

        public async Task JoinGroup(GroupModel group)
        {
            // Create parameters
            IDictionary<string, object> headers = new Dictionary<string, object>();

            // Create the web request and execute it
            WebRequest request = new WebRequest(ServiceUrls.JoinGroupUrl, WebMethod.Post);
            request.Authenticate = true;
            request.Parameters["id"] = group.Id.ToString();

            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.OK);
        }

        public IPagedCollection<GroupModel> Find(string term)
        {
            // Create parameters
            IDictionary<string, string> headers = new Dictionary<string, string>();
            headers["q"] = term;

            // Create the data source
            IPagedDataSource<GoodreadsGroupList> ds = new PagedDataSource<GoodreadsGroupList>(webClient, headers, ServiceUrls.FindGroupUrl);
            return new PagedCollection<GroupModel, GoodreadsGroup, GoodreadsGroupList>(ds, adapter, pageSize);
        }
    }
}
