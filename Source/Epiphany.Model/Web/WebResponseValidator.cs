using System;
using System.Net;

namespace Epiphany.Model.Web
{
    static class WebResponseValidator
    {
        public static void Validate(this WebResponse response, HttpStatusCode expectedCode, bool emptyResponseCheck = false)
        {
            if (response == null)
            {
                throw new ArgumentNullException("response");
            }

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new ModelException(ModelExceptionType.ServerUnreachable);
            }

            else if (response.StatusCode != expectedCode)
            {
                throw new ModelException(ModelExceptionType.UnexpectedError);
            }

            if (emptyResponseCheck)
            {
                if (string.IsNullOrEmpty(response.Content))
                {
                    throw new ModelException(ModelExceptionType.EmptyServerResponse);
                }
            }
        }
    }
}
