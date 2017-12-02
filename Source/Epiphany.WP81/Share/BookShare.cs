using Epiphany.Model;
using System;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;

namespace Epiphany.View.Share
{
    public sealed class BookShare : SupportShareBase<BookModel>
    {
        protected override void UpdateShareData(DataPackage data)
        {
            data.Properties.Title = Strings.AppStrings.ShareBookTitle;
            data.Properties.Description = Item.Authors.First()?.Name;
            data.SetText(Item.Title);
            data.SetWebLink(new Uri(Item.Url));
        }
    }
}
