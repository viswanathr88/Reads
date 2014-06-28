
namespace Epiphany.Xml
{
    public interface IPartialCollection<T>
    {
        string Start
        {
            get;
        }

        string End
        {
            get;
        }

        string Total
        {
            get;
        }

        T[] Items
        {
            get;
        }
    }
}
