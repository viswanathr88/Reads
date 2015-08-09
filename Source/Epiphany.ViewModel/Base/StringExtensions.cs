using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Epiphany.ViewModel
{
    public static class StringExtensions
    {
        public static void AppendWithoutTags(this StringBuilder builder, string strWithTags)
        {
            if (string.IsNullOrEmpty(strWithTags))
                return;

            string result = Regex.Replace(strWithTags, @"<[^>]*>", String.Empty);
            builder.Append(result);
        }
    }
}
