using Epiphany.Logging;
using Epiphany.Model;
using System;
using System.Net;

namespace Epiphany.Web
{
    static class WebResponseValidator
    {
        public static void Validate(this WebResponse response, HttpStatusCode expectedCode, bool emptyResponseCheck = false)
        {
            if (response == null)
            {
                Logger.LogError("WebResponse is null");
                throw new ArgumentNullException(nameof(response));
            }

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                Logger.LogError("StatusCode =  " + response.StatusCode);
                throw new ModelException(ModelExceptionType.ServerUnreachable);
            }

            else if (response.StatusCode != expectedCode)
            {
                Logger.LogError(string.Format("Expected Code = {0}, Status Code = {1}", expectedCode, response.StatusCode));
                throw new ModelException(ModelExceptionType.UnexpectedError);
            }

            if (emptyResponseCheck)
            {
                if (string.IsNullOrEmpty(response.Content))
                {
                    Logger.LogError("Server returned an empty response");
                    throw new ModelException(ModelExceptionType.EmptyServerResponse);
                }
            }
        }
    }
}
