using Epiphany.Model;
using Epiphany.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.Text;

namespace Epiphany.ViewModel
{
    class AuthorAttributeViewModelFactory
    {
        public ObservableCollection<IAuthorAttributeViewModel> GetAuthorAttributeItems(AuthorModel author)
        {
            ObservableCollection<IAuthorAttributeViewModel> items = new ObservableCollection<IAuthorAttributeViewModel>();

            if (!string.IsNullOrEmpty(author.About))
            {
                items.Add(new AuthorAttributeViewModel(AuthorAttribute.About, author.About, false));
            }

            if (!string.IsNullOrEmpty(author.Gender))
            {
                items.Add(new AuthorAttributeViewModel(AuthorAttribute.Gender, author.Gender, false));
            }

            if (author.BornAt != default(DateTime))
            {
                items.Add(new AuthorAttributeViewModel(AuthorAttribute.Born, author.BornAt.ToString(), false));
            }

            if (author.FansCount > 0)
            {
                items.Add(new AuthorAttributeViewModel(AuthorAttribute.NumberOfFans, author.FansCount.ToString(), false));
            }

            if (author.WorksCount > 0)
            {
                items.Add(new AuthorAttributeViewModel(AuthorAttribute.NumberOfWorks, author.WorksCount.ToString(), false));
            }

            if (!string.IsNullOrEmpty(author.Hometown))
            {
                items.Add(new AuthorAttributeViewModel(AuthorAttribute.Hometown, author.Hometown, false));
            }

            if (!string.IsNullOrWhiteSpace(author.Influences))
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendWithoutTags(author.Influences);
                string influences = builder.ToString();
                if (!string.IsNullOrWhiteSpace(influences))
                {
                    items.Add(new AuthorAttributeViewModel(AuthorAttribute.Influences, influences, false));
                }
            }

            if (author.AverageRating > 0.0)
            {
                items.Add(new AuthorAttributeViewModel(AuthorAttribute.AverageRating, author.AverageRating.ToString(), false));
            }

            return items;
        }
    }
}
