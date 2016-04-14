
namespace Epiphany.ViewModel
{
    public enum AuthorAttribute
    {
        Gender,
        Born,
        Dead,
        Hometown,
        NumberOfFans,
        NumberOfWorks,
        About,
        AverageRating,
        Influences
    };

    public class AuthorAttributeViewModel : ViewModelBase
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
