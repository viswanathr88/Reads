using RestSharp.Portable;
using System;

namespace Epiphany.Web
{
    public static class RestSharpExtensions
    {
        public static string GetContent(this IRestResponse @this)
        {
            if (@this == null)
            {
                throw new NullReferenceException();
            }
            string content = string.Empty;

            if (@this.RawBytes != null)
            {
                content = System.Text.Encoding.UTF8.GetString(@this.RawBytes);
            }

            return content;
        }
    }
}
