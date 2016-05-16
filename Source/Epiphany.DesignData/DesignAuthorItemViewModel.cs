using Epiphany.ViewModel.Items;

namespace Epiphany.View.DesignData
{
    public sealed class DesignAuthorItemViewModel : IAuthorItemViewModel
    {
        public DesignAuthorItemViewModel()
        {
            Name = "Test Author";
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
