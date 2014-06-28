
namespace Epiphany.Model
{
    public class Credential
    {
        private string title;
        private int id;

        public Credential(string title, int id)
        {
            this.title = title;
            this.id = id;
        }

        public string Name
        {
            get { return this.title; }
        }

        public int UserId
        {
            get { return this.id; }
        }
    }
}
