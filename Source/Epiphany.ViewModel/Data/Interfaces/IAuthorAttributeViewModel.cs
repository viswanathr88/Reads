using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public interface IAuthorAttributeViewModel
    {
        AuthorAttribute Type { get; }

        string Value { get; }

        bool IsEnabled { get; }
    }
}
