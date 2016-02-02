namespace BangaloreUniversityLearningSystem.Utilities.Exceptions
{
    using System;

    public class AuthorizationFailedException : Exception
    {
        public AuthorizationFailedException()
        {
        }

        public AuthorizationFailedException(string message)
            : base(message)
        {
        }

        public AuthorizationFailedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}