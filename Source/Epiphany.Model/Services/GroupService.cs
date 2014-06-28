using Epiphany.Model.Adapter;
using Epiphany.Model.Collections;
using Epiphany.Model.DataSources;
using Epiphany.Model.Web;
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
            //
            // Create headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["id"] = user.Id;
            //
            // Create the data source
            //
            IPagedDataSource<GoodreadsGroupList> ds = new PagedDataSource<GoodreadsGroupList>(webClient, headers, ServiceUrls.GroupsUrl);
            return new PagedCollection<GroupModel, GoodreadsGroup, GoodreadsGroupList>(ds, adapter, pageSize);
        }

        public async Task<GroupModel> GetGroup(int groupId)
        {
            //
            // Create headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["id"] = groupId;
            //
            // Create the data source
            //
            IDataSource<GoodreadsGroup> ds = new DataSource<GoodreadsGroup>(webClient, headers, ServiceUrls.GroupUrl);
            GoodreadsGroup group = await ds.GetAsync();
            //
            // Convert to model and return
            //
            return this.adapter.Convert(group);
        }

        public IPagedCollection<TopicModel> GetTopics(int groupId, int groupFolderId)
        {
            //
            // Create headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["id"] = groupFolderId;
            headers["group_id"] = groupId;
            //
            // Create the data source
            //
            IPagedDataSource<GoodreadsTopics> ds = new PagedDataSource<GoodreadsTopics>(webClient, headers, ServiceUrls.GroupFolderUrl);
            return new PagedCollection<TopicModel, GoodreadsTopic, GoodreadsTopics>(ds, topicAdapter, pageSize);
        }

        public async Task<TopicModel> GetTopic(int topicId)
        {
            //
            // Create headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["id"] = topicId;
            //
            // Create data source
            //
            IDataSource<GoodreadsTopic> ds = new DataSource<GoodreadsTopic>(webClient, headers, ServiceUrls.TopicUrl);
            this.currentTopic = await ds.GetAsync();
            //
            // Create the model and return
            //
            return this.topicAdapter.Convert(this.currentTopic);
        }

        public IPagedCollection<CommentModel> GetComments(TopicModel topic)
        {
            //
            // Create headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["id"] = topic.Id;
            //
            // Create data source
            //
            IPagedDataSource<GoodreadsComments> ds = new PagedDataSource<GoodreadsComments>(webClient, headers, ServiceUrls.TopicUrl);
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
            //
            // Create headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["topic[subject_type]"] = "Group";
            headers["topic[subject_id]"] = topic.Group.Id;
            headers["topic[folder_id]"] = topic.Folder.Id;
            headers["topic[title]"] = topic.Title;
            headers["comment[body_usertext]"] = body;
            //
            // Create web request and execute it
            //
            WebRequest request = new WebRequest(ServiceUrls.CreateTopicUrl, WebMethod.AuthenticatedPost);
            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.Created);
        }

        public async Task AddComment(TopicModel topic, CommentModel comment)
        {
            //
            // Create headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["type"] = "topic";
            headers["id"] = topic.Id;
            //
            // Create the web request and execute it
            //
            WebRequest request = new WebRequest(ServiceUrls.CommentCreateUrl, WebMethod.AuthenticatedPost);
            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.Created);
        }

        public async Task JoinGroup(GroupModel group)
        {
            //
            // Create headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["id"] = group.Id;
            //
            // Create the web request and execute it
            //
            WebRequest request = new WebRequest(ServiceUrls.JoinGroupUrl, WebMethod.AuthenticatedPost);
            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.OK);
        }

        public IPagedCollection<GroupModel> Find(string term)
        {
            //
            // Create headers
            //
            IDictionary<string, object> headers = new Dictionary<string, object>();
            headers["q"] = term;
            //
            // Create the data source
            //
            IPagedDataSource<GoodreadsGroupList> ds = new PagedDataSource<GoodreadsGroupList>(webClient, headers, ServiceUrls.FindGroupUrl);
            return new PagedCollection<GroupModel, GoodreadsGroup, GoodreadsGroupList>(ds, adapter, pageSize);
        }
    }
}
