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
            // Create the data source
            var ds = new PagedDataSource<GoodreadsGroupList>(webClient);
            ds.SourceUrl = ServiceUrls.GroupsUrl;
            ds.Parameters["id"] = user.Id.ToString();
            ds.RequiresAuthentication = false;
            ds.Returns = (response) => response.Groups.GroupList;
            
            // Create the collection
            return new PagedCollection<GroupModel, GoodreadsGroup, GoodreadsGroupList>(ds, adapter, pageSize);
        }

        public async Task<GroupModel> GetGroup(long groupId)
        {
            // Create the data source
            var ds = new DataSource<GoodreadsGroup>(webClient);
            ds.SourceUrl = ServiceUrls.GroupUrl;
            ds.Parameters["id"] = groupId.ToString();
            ds.RequiresAuthentication = false;
            ds.Returns = (response) => response.Group;
            
            GoodreadsGroup group = await ds.GetAsync();

            // Convert to model and return
            return this.adapter.Convert(group);
        }

        public IPagedCollection<TopicModel> GetTopics(long groupId, long groupFolderId)
        {
            // Create the data source
            var ds = new PagedDataSource<GoodreadsTopics>(webClient);
            ds.SourceUrl = ServiceUrls.GroupFolderUrl;
            ds.Parameters["id"] = groupFolderId.ToString();
            ds.Parameters["group_id"] = groupId.ToString();

            // Create the collection
            return new PagedCollection<TopicModel, GoodreadsTopic, GoodreadsTopics>(ds, topicAdapter, pageSize);
        }

        public async Task<TopicModel> GetTopic(long topicId)
        {
            // Create data source
            var ds = new DataSource<GoodreadsTopic>(webClient);
            ds.SourceUrl = ServiceUrls.TopicUrl;
            ds.Parameters["id"] = topicId.ToString();

            this.currentTopic = await ds.GetAsync();
            
            // Create the model and return
            return this.topicAdapter.Convert(this.currentTopic);
        }

        public IPagedCollection<CommentModel> GetComments(TopicModel topic)
        {
            // Create parameters
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["id"] = topic.Id.ToString();

            // Create data source
            var ds = new PagedDataSource<GoodreadsComments>(webClient);
            ds.SourceUrl = ServiceUrls.TopicUrl;
            ds.Parameters["id"] = topic.Id.ToString();
            ds.Returns = (response) => response.Topic.Comments;
            
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
            request.Parameters["format"] = "xml";
            request.Parameters["type"] = "topic";
            request.Parameters["id"] = topic.Id.ToString();

            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.Created);
        }

        public async Task JoinGroup(GroupModel group)
        {
            // Create the web request and execute it
            WebRequest request = new WebRequest(ServiceUrls.JoinGroupUrl, WebMethod.Post);
            request.Authenticate = true;
            request.Parameters["id"] = group.Id.ToString();

            WebResponse response = await this.webClient.ExecuteAsync(request);
            response.Validate(System.Net.HttpStatusCode.OK);
        }

        public IPagedCollection<GroupModel> Find(string term)
        {
            // Create the data source
            var ds = new PagedDataSource<GoodreadsGroupList>(webClient);
            ds.SourceUrl = ServiceUrls.FindGroupUrl;
            ds.Parameters["q"] = term;
            ds.Returns = (response) => response.Groups.GroupList;

            // Create the collection
            return new PagedCollection<GroupModel, GoodreadsGroup, GoodreadsGroupList>(ds, adapter, pageSize);
        }
    }
}
