
namespace Epiphany.ViewModel
{
    public class AuthorAttributeViewModel : ViewModelBase, IAuthorAttributeViewModel
    {
        private readonly AuthorAttribute type;
        private readonly string value;
        private readonly bool isEnabled;

        public AuthorAttributeViewModel(AuthorAttribute type, string value, bool isEnabled)
        {
            this.type = type;
            this.value = value;
            this.isEnabled = isEnabled;
        }

        public AuthorAttribute Type
        {
            get { return this.type; }
        }

        public string Value
        {
            get { return this.value; }
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
        }
    }
}
