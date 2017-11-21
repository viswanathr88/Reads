using Epiphany.Xml;

namespace Epiphany.Model
{
    public class GroupFolderModel : Entity<long>
    {
        private GoodreadsGroupFolder folder;
        private readonly long id;

        public static GroupFolderModel Create(int id, string name)
        {
            GroupFolderModel model = new GroupFolderModel(id, name);
            return model;
        }

        internal GroupFolderModel(GoodreadsGroupFolder folder)
        {
            this.folder = folder;
            this.id = Converter.ToInt(folder.Id, -1);
        }

        private GroupFolderModel(int id, string name)
        {
            this.id = id;
            folder = new GoodreadsGroupFolder()
            {
                Name = name
            };
        }

        public override long Id
        {
            get
            {
                return this.id;
            }
        }

        public string Name
        {
            get
            {
                return this.folder.Name;
            }
        }

        public int ItemsCount
        {
            get
            {
                return Converter.ToInt(folder.ItemsCount, 0);
            }
        }

        public int SubItemsCount
        {
            get
            {
                return Converter.ToInt(folder.SubItemsCount, 0);
            }
        }

        
    }
}
