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
        SignOutFailure
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
