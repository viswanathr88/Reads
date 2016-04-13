using RestSharp;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Threading.Tasks;

namespace Epiphany.Web
{
    public static class RestSharpExtensions
    {
        public static Task<IRestResponse> ExecuteAsync(this RestClient @this, IRestRequest request)
        {
            return @this.Execute(request);
        }

        public static string GetContent(this IRestResponse @this)
        {
            if (@this == null)
            {
                throw new NullReferenceException(nameof(IRestResponse));
            }

            string result = string.Empty;
            if (@this.RawBytes != null)
            {
                result = System.Text.Encoding.UTF8.GetString(@this.RawBytes, 0, @this.RawBytes.Length);
            }

            return result;
        }
    }
}
