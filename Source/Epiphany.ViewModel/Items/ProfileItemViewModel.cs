
namespace Epiphany.ViewModel.Items
{
    public sealed class ProfileItemViewModel : IProfileItemViewModel
    {
        private readonly ProfileItemType type;
        private readonly string value;
        private readonly bool isEnabled;

        public ProfileItemViewModel(ProfileItemType type, string value, bool isEnabled)
        {
            this.type = type;
            this.value = value;
            this.isEnabled = isEnabled;
        }

        public ProfileItemType Type
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
