
namespace Epiphany.ViewModel
{
    public interface IAuthorViewModel : IDataViewModel
    {
        int Id
        {
            get;
            set;
        }

        string Name
        {
            get;
            set;
        }
    }
}
