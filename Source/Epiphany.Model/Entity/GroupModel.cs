using Epiphany.Xml;
using System;
using System.Collections.Generic;

namespace Epiphany.Model
{
    public sealed class GroupModel : Entity<int>
    {
        private readonly GoodreadsGroup group;
        private readonly int id;

        public GroupModel(int id)
        {
            this.id = id;
            this.group = new GoodreadsGroup();
        }

        internal GroupModel(GoodreadsGroup group)
        {
            this.group = group;
        }

        public override int Id
        {
            get
            {
                return this.id;
            }
        }

        public string Title
        {
            get
            {
                return this.group.Title;
            }
        }

        public string Description
        {
            get
            {
                return this.group.Description;
            }
        }

        public string Access
        {
            get
            {
                return this.group.Access;
            }
        }

        public string Location
        {
            get
            {
                return this.Location;
            }
        }

        public DateTime LastActivityTime
        {
            get
            {
                return Converter.ToDateTime(this.group.LastActivityAt);
            }
        }

        public bool IsMember
        {
            get
            {
                return Converter.ToBool(this.group.IsMember, false);
            }
        }

        public string ImageUrl
        {
            get
            {
                return this.group.ImageUrl;
            }
        }

        public int MembersCount
        {
            get
            {
                return Converter.ToInt(this.group.UsersCount, 0);
            }
        }

        public string Organizations
        {
            get
            {
                return this.group.Organizations;
            }
        }

        public string SubCategory
        {
            get
            {
                return this.group.SubCategory;
            }
        }

        public IList<GroupFolderModel> Folders
        {
            get
            {
                IList<GroupFolderModel> items = new List<GroupFolderModel>();
                foreach (GoodreadsGroupFolder folder in group.Folders)
                {
                    items.Add(new GroupFolderModel(folder));
                }
                return items;
            }
        }

        public IList<ModeratorModel> Moderators
        {
            get
            {
                IList<ModeratorModel> users = new List<ModeratorModel>();
                foreach (GoodreadsGroupUser user in group.Moderators)
                {
                    users.Add(new ModeratorModel(user));
                }
                return users;
            }
        }
    }
}
