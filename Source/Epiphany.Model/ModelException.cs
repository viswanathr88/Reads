using System;

namespace Epiphany.Model
{
    public enum ModelExceptionType
    {
        ServerUnreachable,
        EmptyServerResponse,
        ParseError,
        UnexpectedError,
        NoTokens,
        NoUserId,
        SignOutFailure,
        TokenRequestError,
        NoUrlForDataSource,
        NoReturnsForDataSource
    };

    public class ModelException : Exception
    {
        private readonly ModelExceptionType type;

        public ModelException(ModelExceptionType type)
        {
            this.type = type;
        }

        public ModelExceptionType Type
        {
            get
            {
                return this.type;
            }
        }
    }
}
