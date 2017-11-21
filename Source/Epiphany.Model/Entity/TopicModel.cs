using Epiphany.Xml;
using System;

namespace Epiphany.Model
{
    public sealed class TopicModel : Entity<long>
    {
        private readonly GoodreadsTopic topic;
        private readonly long id;

        public static TopicModel Create(string title)
        {
            return new TopicModel(title);
        }

        internal TopicModel(GoodreadsTopic topic)
        {
            this.topic = topic;
            this.id = topic.Id;
        }

        private TopicModel(string title)
        {
            topic = new GoodreadsTopic()
            {
                Title = title
            };
        }

        public override long Id
        {
            get
            {
                return this.id;
            }
        }

        public int CommentsCount
        {
            get
            {
                return Converter.ToInt(this.topic.CommentsCount, 0);
            }
        }

        public int NewCommentsCount
        {
            get
            {
                return Converter.ToInt(this.topic.NewCommentsCount, 0);
            }
        }

        public string Title
        {
            get
            {
                return this.topic.Title;
            }
        }

        public DateTime UpdateTime
        {
            get
            {
                return Converter.ToDateTime(this.topic.UpdatedAt);
            }
        }

        public DateTime LastCommentTime
        {
            get
            {
                return Converter.ToDateTime(this.topic.LastCommentAt);
            }
        }

        public string SubjectType
        {
            get
            {
                return this.topic.SubjectType;
            }
        }

        public bool IsMember
        {
            get
            {
                return Converter.ToBool(this.topic.IsMember, false);
            }
        }

        public GroupFolderModel Folder
        {
            get
            {
                return new GroupFolderModel(this.topic.Folder);
            }
        }

        public GroupModel Group
        {
            get
            {
                return new GroupModel(this.topic.Group);
            }
        }
    }
}
